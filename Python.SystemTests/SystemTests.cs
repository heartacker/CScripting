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


        [TestMethod()]
        public void printTestSep()
        {
            int[] c = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            print(c, "+");
        }

        [TestMethod()]
        [DataRow(8, "0o10")]
        [DataRow(0x12345678, "0o2215053170")]

        public void octTest(long x, string res)
        {
            Assert.AreEqual(res, oct(x));
        }
    }
}