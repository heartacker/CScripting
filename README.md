# System.Python

[![GitHub stars](https://img.shields.io/github/stars/heartacker/System.Py?style=for-the-badge)](https://github.com/heartacker/System.Py)
[![Nuget](https://img.shields.io/nuget/v/System.Py?style=for-the-badge)](https://www.nuget.org/packages/System.Py)
![Nuget](https://img.shields.io/nuget/dt/System.Py?style=for-the-badge)
[![GitHub release](https://img.shields.io/github/v/release/heartacker/System.Py?style=for-the-badge)](https://github.com/heartacker/System.Py/releases)

**write c# script like python**

我们主要是想在 `C#` 实现 **`Python` 的内置函数**，并**在`C#` 中可以直接使用**, 以便提高简单脚本的编写效率。

We aim to implement the **built-in function of python in `C#`** and **direct use in `C#`** to improve the effect.

## demo

- code

<div align=center>
<table class="row">
<tr>
<td class="col-6">

🔗 [ **C#** ](./System.Py.Demo.csx)

```csharp
#r "nuget: System.Py, *"
using static System.Py;

var addr = 0x12345678;
var addrr = hex(addr);

print(addr); // 305419896
print(addrr);

var val = 0x12345678;
var valr = bin(addr);

print(val); // 305419896
print(valr);

var c = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };

print(c);
print(c, sep:"\t");

```

</td>

<td class="col-6">

🔗 [ **Python** ](./System.Py.Compare.py)

```python
#r "nuget: System.Py, *"


addr = 0x12345678
addrr = hex(addr)

print(addr) # 305419896
print(addrr)

val = 0x12345678
valr = bin(addr)

print(val); # 305419896
print(valr)

c = [0, 1, 2, 3, 4, 5, 6, 7]

print(c)
print(c, sep="\t")

```

</td>
</tr>
</table>
</div>

- output

<div align=center>
<table class="row">
<tr>
<td class="col-6">

**C#**

```csharp
305419896
0x12345678
305419896
0b10010001101000101011001111000
0 1 2 3 4 5 6 7
0	1	2	3	4	5	6	7

```

</td>

<td class="col-6">

**Python**

```python
305419896
0x12345678
305419896
0b10010001101000101011001111000
[0, 1, 2, 3, 4, 5, 6, 7]
[0, 1, 2, 3, 4, 5, 6, 7]

```

</td>
</tr>
</table>
</div>

## [dotnet script and repl](https://github.com/dotnet-script/dotnet-script#repl)

```shell
~$ dotnet-script
> #r "nuget: System.Py, *"
> using static System.Py;
> hex(1024)
"0x400"
> print("Hello System.Py")
Hello System.Py

```