using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static S.System;

namespace S.Tests
{
    [TestClass()]
    public class SystemTests
    {
        [TestMethod()]
        [DataRow(10, "0xA")]
        [DataRow(10, "0x0000000A", 8)]
        public void hexTest(int a, string res, int? width = null)
        {
            Assert.AreEqual(hex(a, width), res);
        }
    }
}