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
                                                                             Assert.IsNotEmpty(stations.Result);
                                                                             mutex.Set();
                                                                         });

            mutex.WaitOne();
        }

        [Test]
        public void TestLines()
        {
            MetroManager.Instance.GetLineInformation().ContinueWith((lines) =>
                                                         {
                                                             Assert.IsNotEmpty(lines.Result);
                                                             mutex.Set();
                                                         });

            mutex.WaitOne();
        }

        [Test]
        public void TestArrivalTimes()
        {
            MetroManager.Instance.GetStationsByLine(LineCodeType.Green).ContinueWith((stations) =>
            MetroManager.Instance.GetArrivalTimesForStations (stations.Result).ContinueWith((arrivals) =>
                                {
                                    Assert.IsNotEmpty(arrivals.Result);
                                    mutex.Set();
                                }));
            

            mutex.WaitOne();
        }

        [Test]
        public void TestRailIncidents()
        {
            MetroManager.Instance.GetRailIncidents().ContinueWith((incidents) =>
            {
                Assert.IsNotNull(incidents.Result);
                mutex.Set();
            });

            mutex.WaitOne();
        }
    }
}
