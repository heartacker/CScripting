using System;

namespace Python
{
    public static partial class System
    {
        #region ord

        public static int Ord(char c) => ord(c);



        /// <summary>
        /// 对表示单个 Unicode 字符的字符串，返回代表它 Unicode 码点的整数。例如 ord('a') 返回整数 97， ord('€') （欧元符号）返回 8364 。这是 chr() 的逆函数。
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int Ord(string c) => ord(c);




#if OBSOLETE
        [Obsolete("This method is deprecated, use `{nameof(Ord)}` instead.")]
#endif
        public static int ord(char c) => Convert.ToInt32(c);



        /// <summary>
        /// 对表示单个 Unicode 字符的字符串，返回代表它 Unicode 码点的整数。例如 ord('a') 返回整数 97， ord('€') （欧元符号）返回 8364 。这是 chr() 的逆函数。
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>

#if OBSOLETE
        [Obsolete("This method is deprecated, use `{nameof(Ord)}` instead.")]
#endif
        public static int ord(string c)
        {
            if (string.IsNullOrEmpty(c) || c.Length != 1)
            {
                throw new ArgumentException("实参必须是表示单个 Unicode 字符的字符串");
            }
            return Convert.ToInt32(c[0]);
        }
        #endregion

    }
}
