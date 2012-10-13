using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using DcMetroLib.Common;
using DcMetroLib.Data;
using DcMetroLib.Interfaces;

namespace DcMetroLib.MetroService
{
    public class MetroManager
    {
        private const string API_KEY = "u6ctd5b38t8nun52dbe7m9pc";
        private const string BaseUrl = "http://api.wmata.com/";

        private List<StationInfo> _arrivalStations;
        public static MetroManager Instance = new MetroManager();

        private  MetroManager()
        {
            
        }

        public void GetLineInformation(Action<List<LineInfo>> onComplete)
        {
            string url = GetApiKeySingle(BaseUrl + "Rail.svc/Lines");
            GetXmlFromUrl(url, data =>
                                                    {
                                                        var lines = MetroBuilder<LineInfo>.Build(data, "Lines");
                                                        onComplete(lines);
                                                    });
        }

        public void GetStationsByLine(LineCodeType lineCode, Action<List<StationInfo>> onComplete)
        {
            string url;
            
            // get stations for a specific line
            if(lineCode != LineCodeType.All)
            {
                string lineCodeString = "?LineCode=" + lineCode.ToCode();
                url = GetApiKeyMultiple(BaseUrl + "Rail.svc/Stations" + lineCodeString);
            }

            // list all stations
            else
            {
                url = GetApiKeySingle(BaseUrl + "Rail.svc/Stations");
            }

            GetXmlFromUrl(url, data =>
                                   {
                                       var stations = MetroBuilder<StationInfo>.Build(data, "Stations");
                                       onComplete(stations);
                                   });
        }

        public void GetArrivalTimesForStations(List<StationInfo> stations, Action<List<TrainArrivalTime>> onComplete)
        {
            if (stations != null)
            {
                // cache the stations whos arrival times we want to know, if we get a null use the cached value to refresh
                _arrivalStations = stations;
            }

            string url = GetApiKeySingle(BaseUrl + "StationPrediction.svc/GetPrediction/" + _arrivalStations.FoldToCommaDelimitedList(s => s.Code));
            GetXmlFromUrl(url, data =>
                                   {
                                       var arrivalTimes = MetroBuilder<TrainArrivalTime>.Build(data, "Trains");
                                       onComplete(arrivalTimes);
                                   });
        }

        public void UpdateEntrances(double lat, double lon, int radiusInMeters, Action<List<StationEntrance>> onComplete)
        {
            string url = GetApiKeyMultiple(BaseUrl + String.Format("Rail.svc/StationEntrances?lat={0}&lon={1}&radius={2}", lat, lon, radiusInMeters));
            GetXmlFromUrl(url, data =>
                                   {
                                       var entrances = MetroBuilder<StationEntrance>.Build(data, "Entrances");
                                       onComplete(entrances);
                                   });
        }

        private static void GetXmlFromUrl(string url, Action<XDocument> callback)
        {
            var client = new WebClient();

            client.OpenReadCompleted += (sender, e) =>
                                            {
                                                XDocument xdoc;
                                                using (var str = e.Result)
                                                {
                                                    xdoc = XDocument.Load(str);
                                                }
                                                callback(xdoc);
                                            };

            client.OpenReadAsync(new Uri(url, UriKind.Absolute));
        }

        /// <summary>
        /// Use when you have no url paramters in the url string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string GetApiKeySingle(string s)
        {
            
            return s + "?" + ApiKey;
        }

        /// <summary>
        /// Use when you have multiple url paramters in the url string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string GetApiKeyMultiple(string s)
        {
            return s + "&" + ApiKey;
        }

        private string ApiKey
        {
            get { return "api_key=" + API_KEY; }
        }
    }

    internal static class MetroBuilder<T> where T : class, IMetroData
    {
        public static List<T> Build(XDocument root, string childName)
        {
            if (root != null && root.Root != null)
            {
                XNamespace df = root.Root.Name.Namespace;

                var val = (from items in root.Descendants(df + childName)
                                    from item in items.Elements()
                                    select (Activator.CreateInstance(typeof (T)) as T).Decode(item, df) as T).ToList();

                return val;
            }
            return null;
        }
    }
}


