using static S.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.Tests
{
    public class SystemDemo
    {
        public static void Main(string[] args)
        {
            print("hello world");
            uint[] a = { 1, 2, 3, 4, 5, 6, 7 };
            print("hello world");
            print(a);
            print(a, sep: "\t");
        }
    }
}