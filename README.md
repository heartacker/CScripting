# Python.System

![Nuget](https://img.shields.io/nuget/v/Python.System?style=for-the-badge)
![Nuget](https://img.shields.io/nuget/dt/Python.System?style=for-the-badge)

write c# script like python
## demo
- code

<div align=center>
<table class="row">
<tr>
<td class="col-6">

🔗 [ **C#** ](./Python.System.Demo.csx)

```csharp
#r "nuget: Python.System, 1.0.2"
using static Python.System;

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

🔗 [ **Python** ](./Python.System.Compare.py)

```python
#r


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
~$ dotnet script
> #r "nuget: Python.System, 1.0.2"
> using static Python.System;
> hex(1024)
"0x400"
> print("Hello Scripy")
Hello Scripy

```