using System.Threading;
using DcMetroLib.Data;
using DcMetroLib.MetroService;
using NUnit.Framework;

namespace DcMetroLib.tests
{
    [TestFixture]
    public class Tests
    {
        private AutoResetEvent mutex = new AutoResetEvent(false);

        [TestFixtureSetUp]
        public void Setup()
        {
            MetroManager.Instance.RegisterApiKey("u6ctd5b38t8nun52dbe7m9pc");
        }

        [Test]
        public void TestStations()
        {
            MetroManager.Instance.GetStationsByLine(LineCodeType.Green).ContinueWith((stations) =>
                                                                         {
                                                                             Assert.IsNotEmpty(stations.Result.Stations);
                                                                             mutex.Set();
                                                                         });

            mutex.WaitOne();
        }

        [Test]
        public void TestLines()
        {
            MetroManager.Instance.GetLineInformation().ContinueWith((lines) =>
                                                         {
                                                             Assert.IsNotEmpty(lines.Result.Lines);
                                                             mutex.Set();
                                                         });

            mutex.WaitOne();
        }

        [Test]
        public void TestArrivalTimes()
        {
            MetroManager.Instance.GetStationsByLine(LineCodeType.Green).ContinueWith((stations) =>
            MetroManager.Instance.GetArrivalTimesForStations (stations.Result.Stations).ContinueWith((arrivals) =>
                                {
                                    Assert.IsNotEmpty(arrivals.Result.TrainArrivalTimes);
                                    mutex.Set();
                                }));
            
            mutex.WaitOne();
        }

        [Test]
        public void TestRailIncidents()
        {
            MetroManager.Instance.GetRailIncidents().ContinueWith((incidents) =>
            {
                Assert.IsNotNull(incidents.Result.RailIncidents);
                mutex.Set();
            });

            mutex.WaitOne();
        }

        [Test]
        public void TestElevatorIncidents()
        {
            MetroManager.Instance.GetElevatorIncidents("A10").ContinueWith((incidents) =>
            {
                Assert.IsNotNull(incidents.Result.ElevatorIncidents);
                mutex.Set();
            });

            mutex.WaitOne();
        }


        [Test]
        public void GetNearestStations()
        {
            MetroManager.Instance.GetNearestEntrances(38.878586, -76.989626, 500).ContinueWith((stationEntrances) =>
            {
                Assert.IsNotEmpty(stationEntrances.Result.StationEntrances);
                mutex.Set();
            });

            mutex.WaitOne();
        }

        [Test]
        public void GetStationInfo()
        {
            MetroManager.Instance.GetStationInfo("A10").ContinueWith((stationInfo) =>
            {
                Assert.IsNotNull(stationInfo.Result);
                mutex.Set();
            });

            mutex.WaitOne();
        }

        [Test]
        public void GetStationsBetween()
        {
            MetroManager.Instance.GetStationsBetween("A10", "A12").ContinueWith((stationList) =>
            {
                Assert.IsNotEmpty(stationList.Result.MetroPathItems);
                Assert.IsTrue(stationList.Result.MetroPathItems.Count == 3);
                mutex.Set();
            });

            mutex.WaitOne();
        }

        [Test]
        public void GetBusRoutes()
        {
            MetroManager.Instance.GetBusRoutes().ContinueWith((routes) =>
            {
                Assert.IsNotEmpty(routes.Result.BusRoutes);
                mutex.Set();
            });

            mutex.WaitOne();
        }

        [Test]
        public void GetBusStops()
        {
            MetroManager.Instance.GetBusStops(38.878586, -76.989626, 500).ContinueWith((stops) =>
            {
                Assert.IsNotEmpty(stops.Result.BusStops);
                mutex.Set();
            });

            mutex.WaitOne();
        }
    }
}
