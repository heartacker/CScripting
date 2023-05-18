public static class StringExternsion
{
    public static string FixLens(this string str, int length = 16, string sep = " ")
    {
        var diff = length - str.Length;
        if (diff > 0)
        {
            for (int i = 0; i < diff; i++)
            {
                str += sep;
            }
        }
        return str;
    }
}

public static class StringHelper
{

}
