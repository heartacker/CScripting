#r "nuget: Python.System, *"
#r "nuget: Microsoft.CodeAnalysis.CSharp.Scripting, *"

using Python;
using static Python.System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.IO;

var so = ScriptOptions.Default.WithImports("System.IO");
so.WithImports("System");
Console.WriteLine(@"测试输入输出函数:Directory.GetCurrentDirectory()");
var res = await CSharpScript.EvaluateAsync(@"
using System;
Console.WriteLine(10086);
Directory.GetCurrentDirectory()", so);// *if end with ; no return value
Console.WriteLine(res);


var codeText = File.ReadAllText(@"./CSharp.Scripting.codetext.csx");
codeText = codeText.Insert(0, "using static Python.System;\r\n");
codeText = codeText.Insert(0, "using static Python.System;\r\n");
var scriptOptions = ScriptOptions.Default
    .AddReferences(typeof(Python.System).Assembly);
scriptOptions.AddReferences(typeof(System.Math).Assembly);

SyntaxTree tree = CSharpSyntaxTree.ParseText(codeText);

var script = CSharpScript.Create(codeText, scriptOptions);
/*
        public ScriptRunner<T> CreateDelegate(CancellationToken cancellationToken = default);
        public Task<ScriptState<T>> RunAsync(object globals, CancellationToken cancellationToken);
        public Task<ScriptState<T>> RunAsync(object globals = null, Func<Exception, bool> catchException = null, CancellationToken cancellationToken = default);
        public Task<ScriptState<T>> RunFromAsync(ScriptState previousState, CancellationToken cancellationToken);
        public Task<ScriptState<T>> RunFromAsync(ScriptState previousState, Func<Exception, bool> catchException = null, CancellationToken cancellationToken = default);
        public Script<T> WithOptions(ScriptOptions options);
*/
try
{
    script.Compile();
    res = await script.RunAsync();
    print(res);
}
catch (System.Exception codeError)
{
    print(codeError.Message);
    // print(codeError.StackTrace);
}
