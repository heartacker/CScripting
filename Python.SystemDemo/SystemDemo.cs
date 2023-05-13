using static Python.System;

namespace Python.SystemDemo
{
    public class Demo
    {
        public static void Main(string[] args)
        {
            print("hello world");
            uint[] a = { 1, 2, 3, 4, 5, 6, 7 };
            print("hello world");
            print(a);
            print(a, sep: "\t");


            var eargs = Environment.GetCommandLineArgs();

            print(eargs);

            help();

            help(a);
            help(typeof(Math));
            help(typeof(Python.System));
        }

    }
}