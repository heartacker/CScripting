using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Python.System;

namespace Python.Tests
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

        [TestMethod()]
        [DataRow(ulong.MaxValue, "0xFFFFFFFFFFFFFFFF")]
        [DataRow(ulong.MaxValue, "0xFFFFFFFFFFFFFFFF", 8)]
        public void hexTestUlong(ulong a, string res, int? width = null)
        {
            Assert.AreEqual(hex(a, width), res);
        }

        [TestMethod()]
        [DataRow(10, "0b1010")]
        [DataRow(10, "0b00001010", 8)]
        public void binTest(int a, string res, int? width = null)
        {
            Assert.AreEqual(bin(a, width), res);
        }

        [TestMethod()]
        [DataRow("hello world")]
        public void printTest(string abcs)
        {
            print(abcs);
        }
    }
}