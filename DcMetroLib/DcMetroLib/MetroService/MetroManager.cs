using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using DcMetroLib.Common;
using DcMetroLib.Data;
using DcMetroLib.Data.Containers;
using DcMetroLib.Interfaces;

namespace DcMetroLib.MetroService
{
    public class MetroManager
    {
        #region Data

        private const string BaseUrl = "http://api.wmata.com/";

        private static Lazy<MetroManager> _instance = new Lazy<MetroManager>();

        public static MetroManager Instance
        {
            get { return _instance.Value; }
        }

        public  MetroManager()
        {
            
        }

        #endregion

        #region Api Key

        private String ApiKey { get; set; }

        public void RegisterApiKey(string key)
        {
            ApiKey = key;
        }

        #endregion

        #region Outbound Calls

        public Task<LinesContainer> GetLineInformation()
        {
            return Get<LinesContainer>("Rail.svc/Lines");
        }

        public Task<RailIncidentsContainer> GetRailIncidents()
        {
            return Get<RailIncidentsContainer>("Incidents.svc/Incidents");
        }

        public Task<ElevatorIncidentsContainer> GetElevatorIncidents(String stationCode)
        {
            return GetElevatorIncidents(new StationInfo {Code = stationCode});
        }

        public Task<ElevatorIncidentsContainer> GetElevatorIncidents(StationInfo station)
        {
            return Get<ElevatorIncidentsContainer>("Incidents.svc/ElevatorIncidents?StationCode=" + station.Code);
        }

        public Task<StationInfo> GetStationInfo(string stationCode)
        {
            return GetStationInfo(new StationInfo { Code = stationCode });
        }

        public Task<StationInfo> GetStationInfo(StationInfo stationCode)
        {
            return Get<StationInfo>("Rail.svc/StationInfo?StationCode=" + stationCode.Code);
        }
        
        public Task<BusRoutesContainer> GetBusRoutes()
        {
            return Get<BusRoutesContainer>("Bus.svc/Routes");
        }

        public Task<BusScheduleByRouteContainer> GetBusScheduleByRoute(String routeID, bool includeVariations = false)
        {
            return GetBusScheduleByRoute(routeID, DateTime.Now, includeVariations);
        }

        public Task<BusScheduleByRouteContainer> GetBusScheduleByRoute(String routeID, DateTime date, bool includeVariations = false)
        {
            return Get<BusScheduleByRouteContainer>(String.Format("Bus.svc/RouteSchedule?routeId={0}&date={1}&includingVariations={2}",
                routeID, FormatDate(date), includeVariations));
        }

        public Task<BusRoutePositionsContainer> GetBusRouteDetails(String routeId)
        {
            return GetBusRouteDetails(routeId, DateTime.Now);
        }

        public Task<BusRoutePositionsContainer> GetBusRouteDetails(String routeID, DateTime date)
        {
            return Get<BusRoutePositionsContainer>(String.Format("Bus.svc/RouteDetails?routeId={0}&date={1}", 
                routeID, FormatDate(date)));
        }

        public Task<BusStopsContainer> GetBusStops(double lat, double lon, int radiusInMeters)
        {
            return Get<BusStopsContainer>(String.Format("Bus.svc/Stops?lat={0}&lon={1}&radius={2}", lat, lon, radiusInMeters));
        }

        public Task<StationPathContainer> GetStationsBetween(String fromCode, String toCode)
        {
            return GetStationsBetween(new StationInfo {Code = fromCode}, new StationInfo {Code = toCode});
        }

        public Task<BusStopScheduleContainer> GetBusStopSchedule(String stopID)
        {
            return GetBusStopSchedule(stopID, DateTime.Now);
        }

        public Task<BusStopScheduleContainer> GetBusStopSchedule(String stopID, DateTime date)
        {
            return Get<BusStopScheduleContainer>(String.Format("Bus.svc/StopSchedule?stopId={0}&date={1}", stopID,
                                                            FormatDate(date)));
        }

        private string FormatDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public Task<StationPathContainer> GetStationsBetween(StationInfo from, StationInfo to)
        {
            return Get<StationPathContainer>(String.Format("Rail.svc/Path?FromStationCode={0}&ToStationCode={1}", from.Code, to.Code));
        }

        public Task<BusStopPredictionContainer> GetArrivalsForBusStop(string stopID)
        {
            return Get<BusStopPredictionContainer>("NextBusService.svc/Predictions?StopID=" + stopID);
        }

        public Task<BusPositionsContainer> GetAllBusPositions(double lat, double lon, int radiusInMeters, bool includeVariations = false)
        {
            return GetBusPositions(null, lat, lon, radiusInMeters, includeVariations);
        }

        public Task<BusPositionsContainer> GetBusPositions(string routeID, double lat, double lon, int radiusInMeters, bool includeVariations = false)
        {
            var url = String.Format("Bus.svc/BusPositions?{0}includingVariations={1}&lat={2}&lon={3}&radius={4}",
                          String.IsNullOrEmpty(routeID) ? String.Empty : String.Format("routeId={0}&", routeID),
                          includeVariations,
                          lat,
                          lon,
                          radiusInMeters);

            return Get<BusPositionsContainer>(url);
        }

        public Task<StationsContainer> GetStationsByLine(LineCodeType lineCode)
        {
            string url;

            // get stations for a specific line
            if(lineCode != LineCodeType.All)
            {
                string lineCodeString = "?LineCode=" + lineCode.ToCode();
                url = "Rail.svc/Stations" + lineCodeString;
            }

            // list all stations
            else
            {
                url = "Rail.svc/Stations";
            }

            return Get<StationsContainer>(url);
        }

        public Task<TrainArrivalContainer> GetArrivalTimesForStations(List<StationInfo> stations)
        {
            return Get<TrainArrivalContainer>("StationPrediction.svc/GetPrediction/" + stations.FoldToCommaDelimitedList(s => s.Code));
        }

        public Task<StationEntranceContainer> GetNearestEntrances(double lat, double lon, int radiusInMeters)
        {
            return Get<StationEntranceContainer>(String.Format("Rail.svc/StationEntrances?lat={0}&lon={1}&radius={2}", lat, lon, radiusInMeters));
        }

        #endregion

        #region Helpers

        private String GetKeyedUrl(string svc)
        {
            return AppendApiKey(BaseUrl + svc);
        }

        private Task<T> Get<T>(string svc) where T : MetroDataItemBase
        {
            var taskSource = new TaskCompletionSource<T>();

            GetXmlFromUrl(GetKeyedUrl(svc)).ContinueWith(data =>
            {
                var items = MetroBuilder<T>.Build(data.Result);

                taskSource.SetResult(items);
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

        private string AppendApiKey(string s)
        {
            if(s.Contains("?"))
            {
                return GetApiKeyMultiple(s);
            }
            return GetApiKeySingle(s);
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

        #endregion
    }

    internal static class MetroBuilder<T> where T : MetroDataItemBase
    {
        public static T Build(XDocument root)
        {
            var item = SerializationUtil.Deserialize<T>(root);
            item.Process();
            return item;
        }
    }
}


