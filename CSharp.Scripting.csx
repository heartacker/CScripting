#r "nuget: Python.System, *"
#r "nuget: Microsoft.CodeAnalysis.CSharp.Scripting, *"
using Python;
using static Python.System;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.IO;

var so = ScriptOptions.Default.WithImports("System.IO");
so.WithImports("System");
Console.WriteLine(@"测试输入输出函数:Directory.GetCurrentDirectory()");
var res = await CSharpScript.EvaluateAsync(@"
using System;
Console.WriteLine(10086);
Directory.GetCurrentDirectory()",so);// *if end with ; no return value
Console.WriteLine(res);


var codeText = File.ReadAllText(@"./CSharp.Scripting.codetext.csx");
codeText = codeText.Insert(0, "using static Python.System;\r\n");
var scriptOptions = ScriptOptions.Default
    .AddReferences(typeof(Python.System).Assembly);
scriptOptions.AddReferences(typeof(System.Math).Assembly);

res = await CSharpScript.EvaluateAsync(codeText, scriptOptions);
Console.WriteLine(res);
