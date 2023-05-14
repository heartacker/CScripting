using System;

namespace Python
{
    public partial class System
    {
        #region bin

        /// <summary>
        /// 将整形的数转为二进制
        /// </summary>
        /// <param name="x">整数</param>
        /// <param name="width">位宽，<see langword="null"/> 则不关注，如果转换结果大于位宽，则取位宽</param>
        /// <returns>二进制字符串</returns>
        public static string Bin(long x, int? width = null)
            => Bin(x, width);





#if OBSOLETE
        [Obsolete("This method is deprecated, use `{nameof(bin)}` instead.")]
#endif
        public static string bin(long x, int? width = null)
        {
            if (width == null || width <= 0)
            {
                return "0b" + Convert.ToString(x, 2);
            }
            else
            {
                string format = Convert.ToString(x, 2);
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

        #endregion
    }
}
