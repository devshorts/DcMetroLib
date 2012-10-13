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

        [Test]
        public void TestStations()
        {
            MetroManager.Instance.GetStationsByLine(LineCodeType.Green, (stations) =>
                                                                         {
                                                                             Assert.IsNotEmpty(stations);
                                                                             mutex.Set();
                                                                         });

            mutex.WaitOne();
        }

        [Test]
        public void TestLines()
        {
            MetroManager.Instance.GetLineInformation((lines) =>
                                                         {
                                                             Assert.IsNotEmpty(lines);
                                                             mutex.Set();
                                                         });

            mutex.WaitOne();
        }

        [Test]
        public void TestArrivalTimes()
        {
            MetroManager.Instance.GetStationsByLine(LineCodeType.Green, (stations) =>
            MetroManager.Instance.GetArrivalTimesForStations (stations, (arrivals) =>
                                {
                                    Assert.IsNotEmpty(arrivals);
                                    mutex.Set();
                                }));
            

            mutex.WaitOne();
        }

        [Test]
        public void TestRailIncidents()
        {
            MetroManager.Instance.GetRailIncidents((incidents) =>
            {
                Assert.IsNotNull(incidents);
                mutex.Set();
            });

            mutex.WaitOne();
        }
    }
}
