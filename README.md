DcMetroLib
==========

A C# class for querying the DC metro.  Raw XML queries are mapped to typed objects. All queries are returned as asynch tasks.

An example for querying:

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
                                                                         
```                                                                         