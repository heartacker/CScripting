using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;


using static System.Math;
using static System.Linq.Enumerable;
using static System.Numerics.Complex;
using static System.Numerics.BigInteger;


namespace S
{
    /// <summary>
    /// A:
    /// abs()    <see cref="abs"/> <see cref="Math.Abs"/>
    /// aiter()
    /// all()
    /// any()
    /// anext()
    /// ascii()
    ///
    /// B:
    /// bin()    <see cref="bin"/>
    /// bool()
    /// breakpoint()
    /// bytearray()
    /// bytes()
    ///
    /// C:
    /// callable()
    /// chr()
    /// classmethod()
    /// compile()
    /// complex()
    ///
    /// D:
    /// delattr()
    /// dict()
    /// dir()
    /// divmod()
    ///
    /// E:
    /// enumerate()
    /// eval()
    /// exec()
    ///
    /// F:
    /// filter()
    /// float()
    /// format()
    /// frozenset()
    ///
    /// G:
    /// getattr()
    /// globals()
    ///
    /// H:
    /// hasattr()
    /// hash()
    /// help()
    /// hex()    <see cref="hex"/>
    ///
    /// I:
    /// id()
    /// input()
    /// int()
    /// isinstance()
    /// issubclass()
    /// iter()
    ///
    /// L:
    /// len()
    /// list()
    /// locals()
    ///
    /// M:
    /// map()
    /// max()
    /// memoryview()
    /// min()
    ///
    /// N:
    /// next()
    ///
    /// O:
    /// object()
    /// oct()
    /// open()
    /// ord()
    ///
    /// P:
    /// pow()
    /// print()    <see cref="print"/>
    /// property()
    ///
    /// R:
    /// range()
    /// repr()
    /// reversed()
    /// round()
    ///
    /// S:
    /// set()
    /// setattr()
    /// slice()
    /// sorted()
    /// staticmethod()
    /// str()
    /// sum()
    /// super()
    ///
    /// T:
    /// tuple()
    /// type()
    ///
    /// V:
    /// vars()
    ///
    /// Z:
    /// zip()
    ///
    /// _
    /// __import__()
    /// </summary>
    public static class System
    {
        public static double Abs(Complex num)
        {
            return Abs(num.Magnitude);
        }

        [Obsolete("This method is deprecated, use `Abs` instead.")]
        public static double abs(Complex num) => Abs(num);


        [Obsolete("This method is deprecated, `using static System.Math;` and use `Abs` instead.")]
        public static int abs(int num) => Math.Abs(num);



        /// <summary>
        ///  <see cref="Enumerable"/>
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="iterable"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool All<TSource>(IEnumerable<TSource> iterable, Func<TSource, bool> predicate = null)
        {
            if (predicate == null)
                return iterable.All(a => Convert.ToBoolean(a));
            else
                return iterable.All(predicate);
        }


        [Obsolete("This method is deprecated, use `{nameof(All)}` instead.")]
        public static bool all<TSource>(IEnumerable<TSource> iterable, Func<TSource, bool> predicate = null)
            => All(iterable, predicate);



        /// <summary>
        ///  <see cref="Enumerable"/>
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="iterable"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool Any<TSource>(IEnumerable<TSource> iterable, Func<TSource, bool> predicate = null)
        {
            if (predicate == null)
                return iterable.Any();
            else
                return iterable.Any(predicate);
        }


        [Obsolete("This method is deprecated, use `{nameof(Any)}` instead.")]
        public static bool any<TSource>(IEnumerable<TSource> iterable, Func<TSource, bool> predicate = null)
            => Any(iterable, predicate);



        /// <summary>
        /// 将整形的数转为hex
        /// </summary>
        /// <param name="num">整数</param>
        /// <param name="width">位宽，<see langword="null"/> 则不关注，如果转换结果大于位宽，则取位宽</param>
        /// <returns>hex字符串</returns>
        public static string Hex(long num, int? width = null)
        {
            if (width == null || width <= 0)
            {
                return string.Format("0x{0:X}", num);
            }
            else
            {
                string format = "0x{0:" + "X" + width + "}";
                return string.Format(format, num);
            }
        }

        [Obsolete("This method is deprecated, use `{nameof(Hex)}` instead.")]
        public static string hex(long num, int? width = null) => Hex(num, width);

        /// <summary>
        /// 将ulong整形的数转为hex
        /// </summary>
        /// <param name="num">整数</param>
        /// <param name="width">位宽，<see langword="null"/> 则不关注，如果转换结果大于位宽，则取位宽</param>
        /// <returns>hex字符串</returns>

        public static string Hex(ulong num, int? width = null)
        {
            if (width == null || width <= 0)
            {
                return string.Format("0x{0:X}", num);
            }
            else
            {
                string format = "0x{0:" + "X" + width + "}";
                return string.Format(format, num);
            }
        }

        [Obsolete("This method is deprecated, use `{nameof(Hex)}` instead.")]
        public static string hex(ulong num, int? width = null) => Hex(num, width);

        /// <summary>
        /// 将整形的数转为二进制
        /// </summary>
        /// <param name="num">整数</param>
        /// <param name="width">位宽，<see langword="null"/> 则不关注，如果转换结果大于位宽，则取位宽</param>
        /// <returns>二进制字符串</returns>
        public static string Bin(long num, int? width = null)
        {
            if (width == null || width <= 0)
            {
                return "0b" + Convert.ToString(num, 2);
            }
            else
            {
                string format = Convert.ToString(num, 2);
                if (format.Length < width)
                {
                    string par = "";
                    for (int c = 0; c < width - format.Length; c++)
                    {
                        par += "0";
                    }
                    return "0b" + par + format;
                }
                return "0b" + format;
            }
        }

        [Obsolete("This method is deprecated, use `{nameof(bin)}` instead.")]
        public static string bin(long num, int? width = null) => Bin(num, width);


        [Obsolete("This method is deprecated, use `{nameof(Print)}` instead.")]
        public static void print(object objects,
                                 string sep = " ",
                                 string end = "\r\n",
                                 StreamWriter file = null,
                                 bool flush = false) => Print(objects, sep, end, file, flush);

        public static void Print(object objects,
                                 string sep = " ",
                                 string end = "\r\n",
                                 StreamWriter file = null,
                                 bool flush = false)
        {
            var _file = file ?? Console.Out;

            _file.Write(objects.ToString());
            _file.Write(end);
            if (flush) _file.Flush();
        }


        [Obsolete("This method is deprecated, use `{nameof(Print)}` instead.")]
        public static void print(IList objects,
                                 string sep = " ",
                                 string end = "\r\n",
                                 StreamWriter file = null,
                                 bool flush = false) => Print(objects, sep, end, file, flush);

        public static void Print(IList objects,
                                 string sep = " ",
                                 string end = "\r\n",
                                 StreamWriter file = null,
                                 bool flush = false)
        {
            var _file = file ?? Console.Out;
            foreach (var item in objects)
            {
                _file.Write(item.ToString());
                _file.Write(sep);
            }
            _file.Write(end);
            if (flush) _file.Flush();
        }
    }

}