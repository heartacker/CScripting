using System.Numerics;

namespace S;
public static class System
{
    public static string hex<T>(T num, int? width = null) where T : INumber<T>
    {
        if (width == null || width <= 0)
        {
            return string.Format("0x{0:X}", num);
        }
        else
        {
            string format = "{0:" + "X" + width + "}";
            return string.Format(format, num);
        }
    }
}
