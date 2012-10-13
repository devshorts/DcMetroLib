using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using DcMetroLib.Common;
using DcMetroLib.Data;
using DcMetroLib.Interfaces;

namespace DcMetroLib.MetroService
{
    public class MetroManager
    {
        private const string BaseUrl = "http://api.wmata.com/";

        private static Lazy<MetroManager> _instance = new Lazy<MetroManager>();

        public static MetroManager Instance
        {
            get { return _instance.Value; }
        }

        public  MetroManager()
        {
            
        }

        private String ApiKey { get; set; }

        public void RegisterApiKey(string key)
        {
            ApiKey = key;
        }

        public Task<List<LineInfo>> GetLineInformation()
        {
            string url = GetApiKeySingle(BaseUrl + "Rail.svc/Lines");

            var taskSource = new TaskCompletionSource<List<LineInfo>>();

            GetXmlFromUrl(url).ContinueWith(data =>
                                                    {
                                                        var lines = MetroBuilder<LineInfo>.Build(data.Result, "Lines");
                                                        
                                                        taskSource.SetResult(lines);
                                                    });

            return taskSource.Task;
        }

        public Task<List<IncidentData>> GetRailIncidents()
        {
            string url = GetApiKeySingle(BaseUrl + "Incidents.svc/Incidents");

            var taskSource = new TaskCompletionSource<List<IncidentData>>();

            GetXmlFromUrl(url).ContinueWith(data =>
                                                    {
                                                        var incidents = MetroBuilder<IncidentData>.Build(data.Result, "Incidents");
                                                        
                                                        taskSource.SetResult(incidents);
                                                    });

            return taskSource.Task;
        }

        public Task<List<StationInfo>> GetStationsByLine(LineCodeType lineCode)
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

            var taskSource = new TaskCompletionSource<List<StationInfo>>();

            GetXmlFromUrl(url).ContinueWith(data =>
                                   {
                                       var stations = MetroBuilder<StationInfo>.Build(data.Result, "Stations");
                                       
                                       taskSource.SetResult(stations);
                                   });

            return taskSource.Task;
        }


        public Task<List<TrainArrivalTime>> GetArrivalTimesForStations(List<StationInfo> stations)
        {
            string url = GetApiKeySingle(BaseUrl + "StationPrediction.svc/GetPrediction/" + stations.FoldToCommaDelimitedList(s => s.Code));

            var taskSource = new TaskCompletionSource<List<TrainArrivalTime>>();
            GetXmlFromUrl(url).ContinueWith(data =>
                                   {
                                       var arrivalTimes = MetroBuilder<TrainArrivalTime>.Build(data.Result, "Trains");
                                       
                                       taskSource.SetResult(arrivalTimes);
                                   });

            return taskSource.Task;
        }

        public Task<List<StationEntrance>> UpdateEntrances(double lat, double lon, int radiusInMeters)
        {
            string url = GetApiKeyMultiple(BaseUrl + String.Format("Rail.svc/StationEntrances?lat={0}&lon={1}&radius={2}", lat, lon, radiusInMeters));

            var taskSource = new TaskCompletionSource<List<StationEntrance>>();
            GetXmlFromUrl(url).ContinueWith(data =>
                                   {
                                       var entrances = MetroBuilder<StationEntrance>.Build(data.Result, "Entrances");

                                       taskSource.SetResult(entrances);
                                   });

            return taskSource.Task;
        }

        private static Task<XDocument> GetXmlFromUrl(string url)
        {
            var taskCompletionSource = new TaskCompletionSource<XDocument>();

            var client = new WebClient();

            client.OpenReadCompleted += (sender, e) =>
                                            {
                                                XDocument xdoc;
                                                using (var str = e.Result)
                                                {
                                                    xdoc = XDocument.Load(str);
                                                }
                                                
                                                taskCompletionSource.SetResult(xdoc);
                                            };

            client.OpenReadAsync(new Uri(url, UriKind.Absolute));

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Use when you have no url paramters in the url string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string GetApiKeySingle(string s)
        {

            return s + "?" + ApiKeyUrlItem;
        }

        /// <summary>
        /// Use when you have multiple url paramters in the url string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string GetApiKeyMultiple(string s)
        {
            return s + "&" + ApiKeyUrlItem;
        }

        private string ApiKeyUrlItem
        {
            get { return "api_key=" + ApiKey; }
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


