using System;

#if WITH_NAME_SPACE
namespace CScripting
{
#endif

public partial class CScripting
    {
        #region oct
        public static string Oct(long x, int? width = null)
            => oct(x, width);






        /// <summary>
        /// 将整形的数转为8进制
        /// </summary>
        /// <param name="x">整数</param>
        /// <param name="width">位宽，<see langword="null"/> 则不关注，如果转换结果大于位宽，则取位宽</param>
        /// <returns>二进制字符串</returns>
#if OBSOLETE
        [Obsolete("This method is deprecated, use `{nameof(bin)}` instead.")]
#endif
        public static string oct(long x, int? width = null)
        {
            if (width == null || width <= 0)
            {
                return "0o" + Convert.ToString(x, 8);
            }
            else
            {
                string format = Convert.ToString(x, 8);
                if (format.Length < width)
                {
                    string par = "";
                    for (int c = 0; c < width - format.Length; c++)
                    {
                        par += "0";
                    }
                    return "0o" + par + format;
                }
                return "0o" + format;
            }
        }

        #endregion
    }
#if WITH_NAME_SPACE
}
#endif
