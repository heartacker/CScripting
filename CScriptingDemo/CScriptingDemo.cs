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
            uint[] a = { 1, 2, 3, 4, 5, 6, 7 };
            print(a);
            print(a, sep: "\t");




            help();

            help(a);
            help(typeof(Math));
            help(typeof(CScripting));
            help(typeof(matlab));
            help(typeof(CScripting.matlab));
        }

    }
}