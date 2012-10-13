DcMetroLib
==========

A C# class for querying the DC metro.  Raw XML queries are mapped to typed objects. All queries are returned as asynch tasks.

An example for querying:

```c#

MetroManager.Instance.RegisterApiKey(...);
MetroManager.Instance.GetStationsByLine(LineCodeType.Green).ContinueWith((stations) =>
                                                                         {
                                                                             // stations.Result is a List<StationInfo>
                                                                         });                                          
                                                                         
```                                                                         