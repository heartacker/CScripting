# 1. Python.System

[![GitHub stars](https://img.shields.io/github/stars/heartacker/Python.System?style=for-the-badge)](https://github.com/heartacker/Python.System)
[![Nuget](https://img.shields.io/nuget/v/Python.System?style=for-the-badge)](https://www.nuget.org/packages/Python.System)
![Nuget](https://img.shields.io/nuget/dt/Python.System?style=for-the-badge)
[![GitHub release](https://img.shields.io/github/v/release/heartacker/Python.System?style=for-the-badge)](https://github.com/heartacker/Python.System/releases)

<!-- @import "[TOC]" {cmd="toc" depthFrom=1 depthTo=6 orderedList=false} -->

<!-- code_chunk_output -->

- [1. Python.System](#1-pythonsystem)
  - [1.1. Instruction](#11-instruction)
  - [1.2. Recent Changelog](#12-recent-changelog)
  - [1.3. Demo](#13-demo)
  - [1.4. Dotnet script and repl](#14-dotnet-script-and-repl)
  - [1.5. Extended function list](#15-extended-function-list)
  - [1.6. Extended function list like `Matlab`](#16-extended-function-list-like-matlab)
  - [1.7. `Python` Built-in function list](#17-python-built-in-function-list)

<!-- /code_chunk_output -->

## 1.1. Instruction

**write c# script like python**

!!! done 思路
    我们主要是想在 `C#` 实现 **`Python` 的内置函数**，并**在`C#` 中可以直接使用**, 以便提高简单脚本的编写效率。

    !!! tip 欢迎 ❤️
        欢迎 任何 PR

!!! done idea
    We aim to implement the **built-in function of python in `C#`** and **direct use in `C#`** to improve the effect.

    !!! done **Welcome** ❤️
        welcome any pull request

## 1.2. Recent Changelog

- time: 2023年5月15日
- version: 1.0.6
- log:
  1. change readme
  2. add `help` function
  3. add `dir` function
  4. fix trim `print()` last sep

more information, see [CHANGELOG.md](https://github.com/heartacker/Python.System/blob/master/CHANGELOG.md)

## 1.3. Demo

- `Code`

<div align=center>
<table class="row">
<tr>
<td class="col-6">

🔗 [**C#**](./Python.System.Demo.csx)

```csharp
#r "nuget: Python.System, *"
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

🔗 [**Python**](./Python.System.Compare.py)

```python
#r "nuget: Python.System, *"


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

- `Output`

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
0 1 2 3 4 5 6 7

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

## 1.4. [Dotnet script and repl](https://github.com/dotnet-script/dotnet-script#repl)

```shell
~$ dotnet-script
> #r "nuget: Python.System, *"
> using static Python.System;
> hex(1024)
"0x400"
> print("Hello Scripy")
Hello Scripy

```

## 1.5. Extended function list

- MyOwn
  - [ ] `load()`
  - [ ] `unload()`

## 1.6. Extended function list like `Matlab`

- coming
  - [ ] `???`
  - [ ] `????`

## 1.7. `Python` Built-in function list

- A
  - [x] [`abs()`](./Python.System/Python/abs.cs)
  - [ ] `aiter()`
  - [x] [`all()`](./Python.System/Python/all.cs)
  - [x] [`any()`](./Python.System/Python/any.cs)
  - [ ] `anext()`
  - [ ] `ascii()`

- B
  - [x] [`bin()`](./Python.System/Python/bin.cs)
  - [ ] `bool()`
  - [ ] `breakpoint()`
  - [x] [`bytearray()`](./Python.System/Python/bytearry.cs)
  - [x] [`bytes()`](./Python.System/Python/bytearry.cs)

- C
  - [ ] `callable()`
  - [x] [`chr()`](./Python.System/Python/chr.cs)
  - [ ] `classmethod()`
  - [ ] `compile()` **
  - [ ] `complex()` **

- D
  - [ ] `delattr()`
  - [ ] `dict()`
  - [ ] `dir()` *
  - [ ] `divmod()`

- E
  - [ ] `enumerate()`
  - [ ] `eval()`
  - [ ] `exec()`

- F
  - [ ] `filter()`
  - [ ] `float()`
  - [ ] `format()`
  - [ ] `frozenset()`

- G
  - [ ] `getattr()`
  - [ ] `globals()`

- H
  - [ ] `hasattr()`
  - [ ] `hash()`
  - [x] [`help()`](./Python.System/Python/help.cs)
  - [x] [`hex()`](./Python.System/Python/hex.cs)

- I
  - [ ] `id()`
  - [ ] `input()`
  - [ ] `int()`
  - [ ] `isinstance()`
  - [ ] `issubclass()`
  - [ ] `iter()`

- L
  - [ ] `len()`
  - [ ] `list()`
  - [ ] `locals()`

- M
  - [ ] `map()`
  - [ ] `max()`
  - [ ] `memoryview()`
  - [ ] `min()`

- N
  - [ ] `next()`

- O
  - [ ] `object()`
  - [x] [`oct()`](./Python.System/Python/oct.cs)
  - [ ] `open()`
  - [x] [`ord()`](./Python.System/Python/ord.cs)

- P
  - [ ] `pow()`
  - [x] [`print()`](./Python.System/Python/print.cs)
  - [ ] `property()`

- R
  - [ ] `range()`
  - [ ] `repr()`
  - [ ] `reversed()`
  - [ ] `round()`

- S
  - [ ] `set()`
  - [ ] `setattr()`
  - [ ] `slice()`
  - [ ] `sorted()`
  - [ ] `staticmethod()`
  - [ ] `str()`
  - [ ] `sum()`
  - [ ] `super()`

- T
  - [ ] `tuple()`
  - [ ] `type()`
  -

- V
  - [ ]`vars()`

- Z
  - [ ] `zip()`

- misc
  - [ ] `_`
  - [ ] `__import__()`
  - [ ] `???`
