# Python.System

![Nuget](https://img.shields.io/nuget/v/Python.System?style=for-the-badge)
![Nuget](https://img.shields.io/nuget/dt/Python.System?style=for-the-badge)

write c# script like python
## demo
- code
```csharp
using static Python.System;

var addr = 0x12345678;
var addrr = Hex(addr);

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
- output
```log
305419896
0x12345678
305419896
0b10010001101000101011001111000
0 1 2 3 4 5 6 7
0	1	2	3	4	5	6	7

```
