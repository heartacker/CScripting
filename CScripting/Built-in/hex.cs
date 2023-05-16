using System;
using System.Numerics;

#if WITH_NAME_SPACE
namespace CScripting
{
#endif

public partial class CScripting
{
    #region hex
    /// <summary>
    /// 将整形的数转为hex
    /// </summary>
    /// <param name="x">整数</param>
    /// <param name="width">位宽，<see langword="null"/> 则不关注，如果转换结果大于位宽，则取位宽</param>
    /// <returns>hex字符串</returns>
    public static string Hex(long x, int? width = null)
        => Hex(x, width);

    /// <summary>
    /// 将ulong整形的数转为hex
    /// </summary>
    /// <param name="x">整数</param>
    /// <param name="width">位宽，<see langword="null"/> 则不关注，如果转换结果大于位宽，则取位宽</param>
    /// <returns>hex字符串</returns>

    public static string Hex(ulong x, int? width = null)
        => Hex(x, width);





#if OBSOLETE
        [Obsolete("This method is deprecated, use `{nameof(Hex)}` instead.")]
#endif
    public static string hex(long x, int? width = null)
    {
        if (width == null || width <= 0)
        {
            return string.Format("0x{0:X}", x);
        }
        else
        {
            string format = "0x{0:" + "X" + width + "}";
            return string.Format(format, x);
        }
    }


#if OBSOLETE
        [Obsolete("This method is deprecated, use `{nameof(Hex)}` instead.")]
#endif
    public static string hex(ulong x, int? width = null)
    {
        if (width == null || width <= 0)
        {
            return string.Format("0x{0:X}", x);
        }
        else
        {
            string format = "0x{0:" + "X" + width + "}";
            return string.Format(format, x);
        }
    }

    #endregion

}
#if WITH_NAME_SPACE
}
#endif