using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public void TestStation()
        {
            MetroManager.Instance.GetStationsByLine(LineCodeType.Green, (stations) =>
                                                                         {
                                                                             Assert.IsNotEmpty(stations);
                                                                             mutex.Set();
                                                                         });

            mutex.WaitOne();
        }
    }
}
