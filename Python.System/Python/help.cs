using System;
using System.Collections.Generic;
using System.Text;


namespace Python
{
    public partial class System
    {
        public static void Help()
        {

        }



        /// <summary>
        ///  启动内置的帮助系统（此函数主要在交互式中使用）。
        ///  如果实参是一个字符串，则在模块、函数、类、方法、关键字或文档主题中搜索该字符串，并在控制台上打印帮助信息。
        ///  如果实参是其他任意对象，则会生成该对象的帮助页。
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static void Help(object request) => help(request.GetType());

        /// <summary>
        ///  启动内置的帮助系统（此函数主要在交互式中使用）。
        ///  如果实参是一个字符串，则在模块、函数、类、方法、关键字或文档主题中搜索该字符串，并在控制台上打印帮助信息。
        ///  如果实参是其他任意对象，则会生成该对象的帮助页。
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        public static void Help(Type request) => help(request);







#if OBSOLETE
        [Obsolete("This method is deprecated, use `{nameof(Print)}` instead.")]
#endif
        public static void help()
        {
            print("Welcome to the Python.System, Welcome PRs => https://github.com/heartacker/Python.System");
        }



#if OBSOLETE
        [Obsolete("This method is deprecated, use `{nameof(Print)}` instead.")]
#endif
        public static void help(object request) => help(request.GetType());


        // //如果没有实参，解释器控制台里会启动交互式帮助系统。

        /// <summary>
        ///  启动内置的帮助系统（此函数主要在交互式中使用）。
        ///  如果实参是一个字符串，则在模块、函数、类、方法、关键字或文档主题中搜索该字符串，并在控制台上打印帮助信息。
        ///  如果实参是其他任意对象，则会生成该对象的帮助页。
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

#if OBSOLETE
        [Obsolete("This method is deprecated, use `{nameof(Print)}` instead.")]
#endif
        public static void help(Type request)
        {
            ClassHelper.ClassInfo c = ClassHelper.GetClassInfo(request);
            var sb = new StringBuilder();

            sb.AppendLine("=================================================================");

            sb.AppendLine("Name\t\t" + request.FullName);
            sb.AppendLine("Assembly\t\t\t" + request.Assembly.FullName);
            sb.AppendLine();
            sb.AppendLine("field:");
            sb.AppendLine("----------------------------------------------------------------");

            foreach (var item in c.members)
            {
                if (item.Value is FieldObject)
                {
                    sb.AppendLine($"{item.Key}:\t\t\t{((FieldObject)item.Value).fi}");
                }
            }
            sb.AppendLine();
            sb.AppendLine("Method:");
            sb.AppendLine("----------------------------------------------------------------");

            foreach (var item in c.members)
            {
                if (item.Value is MethodObject)
                {
                    sb.AppendLine($"{item.Key}:\t\t\t{((MethodObject)item.Value).mlist[0].ToString()}");
                }
            }
            sb.AppendLine();
            sb.AppendLine("=================================================================");
            sb.AppendLine();
            Console.Write(sb.ToString());
        }
    }
}