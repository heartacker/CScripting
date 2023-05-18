using System;
using System.Text;
using System.Collections.Generic;

#if WITH_NAME_SPACE
namespace CScripting
{
#endif

using CScriptingEngine;
using static CScripting;

public partial class CScripting
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
        print("Welcome to the CScripting, Welcome PRs => https://github.com/heartacker/CScripting");
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

        sb.AppendLine("Name".FixLens() + "\t" + request.FullName);
        sb.AppendLine("NameSpace".FixLens() + "\t" + request.Namespace);
        sb.AppendLine("Assembly".FixLens() + "\t" + request.Assembly.FullName);
        sb.AppendLine();
        sb.AppendLine("field");
        sb.AppendLine("----------------------------------------------------------------");

        foreach (var item in c.members)
        {
            if (item.Value is FieldObject)
            {
                sb.AppendLine($"{item.Key.ToString().FixLens()}\t{((FieldObject)item.Value).fi}");
            }
        }
        sb.AppendLine();
        sb.AppendLine("Method:");
        sb.AppendLine("----------------------------------------------------------------");

        foreach (var item in c.members)
        {
            if (item.Value is MethodObject)
            {
                sb.AppendLine($"{item.Key.ToString().FixLens()}\t{((MethodObject)item.Value).mlist[0]}");
            }
        }
        sb.AppendLine();
        sb.AppendLine("=================================================================");
        sb.AppendLine();
        Console.Write(sb.ToString());
    }
}

#if WITH_NAME_SPACE
}
#endif