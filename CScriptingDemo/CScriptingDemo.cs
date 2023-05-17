namespace CScriptingDemo
{
    using static CScripting;

    public class Demo
    {
        public static void Main(string[] args)
        {
            var eargs = Environment.GetCommandLineArgs();
            print(eargs);

            print("hello world");
            print("hello world", "\t");// \t no use
            int[] a = { 1, 2, 3, 4, 5, 6, 7 };
            print(a);
            print(a, sep: "\t"); // \t ok

            List<int> b = new()
            {
                1,
                2
            };
            print(b);
            print(b, sep: "\t");
            Dictionary<string, int> d = new()
            {
                { "a", 1 },
                { "b", 2 }
            };
            print(d);
            print(d, sep: "\t");
            Dictionary<int, object> d2 = new()
            {
                { 1, "a" },
                { 2, "b" }
            };
            print(d2);
            print(d2, sep: "\t");


            help();
            help(d2);

            help(a);
            help(typeof(Math));
            help(typeof(CScripting));
            help(typeof(matlab));
            help(typeof(CScripting.matlab));
        }

    }
}