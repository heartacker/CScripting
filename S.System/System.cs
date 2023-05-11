using System;
using System.Collections;
using System.IO;
using System.Numerics;

namespace S
{

    public static class System
    {
        /// <summary>
        /// 将整形的数转为hex
        /// </summary>
        /// <param name="num">整数</param>
        /// <param name="width">位宽，<see langword="null"/> 则不关注，如果转换结果大于位宽，则取位宽</param>
        /// <returns>hex字符串</returns>
        public static string hex(long num, int? width = null)
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

        /// <summary>
        /// 将ulong整形的数转为hex
        /// </summary>
        /// <param name="num">整数</param>
        /// <param name="width">位宽，<see langword="null"/> 则不关注，如果转换结果大于位宽，则取位宽</param>
        /// <returns>hex字符串</returns>
        public static string hex(ulong num, int? width = null)
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



        /// <summary>
        /// 将整形的数转为二进制
        /// </summary>
        /// <param name="num">整数</param>
        /// <param name="width">位宽，<see langword="null"/> 则不关注，如果转换结果大于位宽，则取位宽</param>
        /// <returns>二进制字符串</returns>
        public static string bin(long num, int? width = null)
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

        public static void print(object objects,
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

        public static void print(IList objects,
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