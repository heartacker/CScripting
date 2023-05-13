using System;

namespace Python
{
    public partial class System
    {
        #region chr
        public static string Chr(uint i) => chr(i);

        /// <summary>
        /// 返回 Unicode 码位为整数 i 的字符的字符串格式。例如，chr(97) 返回字符串 'a'，chr(8364) 返回字符串 '€'。这是 ord() 的逆函数。

        /// 实参的合法范围是 0 到 1,114,111（16 进制表示是 0x10FFFF）。如果 i 超过这个范围，会触发 ValueError 异常。
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string Chr(int i) => chr(i);











#if OBSOLETE
        [Obsolete("This method is deprecated, use `{nameof(Hex)}` instead.")]
#endif
        public static string chr(uint i) => chr(i);



        /// <summary>
        /// 返回 Unicode 码位为整数 i 的字符的字符串格式。例如，chr(97) 返回字符串 'a'，chr(8364) 返回字符串 '€'。这是 ord() 的逆函数。

        /// 实参的合法范围是 0 到 1,114,111（16 进制表示是 0x10FFFF）。如果 i 超过这个范围，会触发 ValueError 异常。
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>

#if OBSOLETE
        [Obsolete("This method is deprecated, use `{nameof(Hex)}` instead.")]
#endif
        public static string chr(int i)
        {
            if (i < 0 || i > 0x10FFFF)
            {
                throw new ArgumentOutOfRangeException("i", "实参的合法范围是 0 到 1,114,111（16 进制表示是 0x10FFFF）");
            }
            return Convert.ToChar(i).ToString();
        }
        #endregion

    }
}
