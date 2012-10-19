DcMetroLib
==========
          
DcMetroLib is a complete C# library for querying the DC metro.  All the available Metro API are implemented. Raw XML queries are mapped to typed objects. All queries are returned as asynch tasks.  Each data object exposes a way to convert stringly typed data to strongly typed data, so you can query lines using Line enumerations, etc.  For raw docs check the metro api documentation here: http://developer.wmata.com/docs/read/Home

- **GetStationsByLine** -  Returns Metro lines.
- **GetLineInformation** - Returns the list of Metro stations.
- **GetStationInfo** - Returns information about individual Metro stations.
- **GetStationsBetween** - Returns a path of stations between two stations.
- **GetArrivalTimesForStations** - Returns station arrival information as it appears on Public Information Displays.
- **GetRailIncidents** - Returns incident information as it appears on the Public Information Displays.
- **GetElevatorIncidents** - Returns information about elevators and escalators as it appears on the Public Information Displays.
- **GetNearestEntrances** - Returns entrances to Metro stations.
- **GetBusRoutes** - Returns the list of all bus routes.
- **GetBusStops** - Returns the list of all bus stops.
- **GetBusRouteDetails** - Returns schedule for the route.
- **GetBusPositions** - Returns shape of the route (locations the bus is going through) and its bus stops.
- **GetBusPositions** - Returns real time bus positions.
- **GetBusStopSchedule** - Returns schedule for the stop.
- **GetArrivalsForBusStop** - Returns the bus arrival predictions for a specific bus stop according to the real-time positions of the buses. 

Examples for querying (full examples in tests project):

```c#

MetroManager.Instance.RegisterApiKey(...);                               

MetroManager.Instance.GetStationsByLine(LineCodeType.Green).ContinueWith(stations => { });       
                                                                         
MetroManager.Instance.GetLineInformation().ContinueWith(lines => { }); 

MetroManager.Instance.GetStationsByLine(LineCodeType.Green).ContinueWith(stations =>
MetroManager.Instance.GetArrivalTimesForStations (stations.Result.Stations).ContinueWith(arrivals => { }));

MetroManager.Instance.GetRailIncidents().ContinueWith(incidents => { });

MetroManager.Instance.GetElevatorIncidents("A10").ContinueWith(incidents => { });

MetroManager.Instance.GetNearestEntrances(38.878586, -76.989626, 500).ContinueWith(stationEntrances => { });

MetroManager.Instance.GetStationInfo("A10").ContinueWith(stationInfo => { });

MetroManager.Instance.GetStationsBetween("A10", "A12").ContinueWith(stationList => { });

MetroManager.Instance.GetBusRoutes().ContinueWith(routes => { });

MetroManager.Instance.GetBusStops(38.878586, -76.989626, 500).ContinueWith(stops => { });

MetroManager.Instance.GetBusScheduleByRoute("16L", true).ContinueWith(schedule => { });

MetroManager.Instance.GetBusRouteDetails("16L").ContinueWith(route => { });

MetroManager.Instance.GetBusPositions("10A", 38.878586, -76.989626, 50000, true).ContinueWith(route => { });                                   

MetroManager.Instance.GetBusStopSchedule("2000019").ContinueWith(busStop => { });

MetroManager.Instance.GetArrivalsForBusStop("1001888").ContinueWith(busStop => { });
                                                                         
```                                                                         