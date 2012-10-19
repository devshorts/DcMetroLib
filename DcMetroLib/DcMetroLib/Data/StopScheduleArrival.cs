using System;

namespace DcMetroLib.Data
{
    public class StopScheduleArrival
    {
        public int DirectionNum { get; set; }

        public DateTime EndTime { get; set; }

        public string RouteID { get; set; }

        public DateTime StartTime { get; set; }

        public String TripDirectionText { get; set; }

        public String TripHeadsign { get; set; }

        public String TripID { get; set; }
    }
}
