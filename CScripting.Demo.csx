#r "nuget: CScripting, *"
using static CScripting;

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
print(c, sep: "\t");
