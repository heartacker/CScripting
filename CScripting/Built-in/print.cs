using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

#if WITH_NAME_SPACE
namespace CScripting
{
#endif

public partial class CScripting
{
    #region print

    public static void Print(object @object,
                             string sep = " ",
                             string end = "\r\n",
                             StreamWriter file = null,
                             bool flush = false) => print(@object, sep, end, file, flush);


    public static void Print(IEnumerable @object,
                             string sep = " ",
                             string end = "\r\n",
                             StreamWriter file = null,
                             bool flush = false) => print(@object, sep, end, file, flush);





#if OBSOLETE
        [Obsolete("This method is deprecated, use `{nameof(Print)}` instead.")]
#endif
    public static void print(object @object,
                             string sep = " ",
                             string end = "\r\n",
                             StreamWriter file = null,
                             bool flush = false)
    {
        var _file = file ?? Console.Out;

        _file.Write(@object);
        _file.Write(end);
        if (flush) _file.Flush();
    }

#if OBSOLETE
        [Obsolete("This method is deprecated, use `{nameof(Print)}` instead.")]
#endif
    public static void print(IEnumerable @object,
                             string sep = " ",
                             string end = "\r\n",
                             StreamWriter file = null,
                             bool flush = false)
    {
        var _file = file ?? Console.Out;
        if (@object is String)
        {
            _file.Write(@object);
            _file.Write(end);
        }
        else if ((@object is Array && sep == " "))
        {
            dynamic objs = @object;
            var isString = false;
            if ((objs as Array).Length >= 1)
                isString = ((dynamic)objs)[0] is string;
            string str = "{";
            foreach (var item in objs)
            {
                if (isString) str += "\"";
                str += item.ToString();
                if (isString) str += "\"";
                str += ", ";
            }
            str = str.Remove(str.Length - ", ".Length, ", ".Length);
            str += "}";
            _file.Write(str);
            _file.Write(end);
        }
        else if ((@object is IList && sep == " "))
        {
            dynamic objs = @object;
            var isString = false;
            if ((objs as IList).Count >= 1)
                isString = ((dynamic)objs)[0] is string;
            string str = "{";
            foreach (var item in objs)
            {
                if (isString) str += "\"";
                str += item.ToString();
                if (isString) str += "\"";
                str += ", ";
            }
            str = str.Remove(str.Length - ", ".Length, ", ".Length);
            str += "}";
            _file.Write(str);
            _file.Write(end);
        }
        else if ((@object is IDictionary))
        {
            IDictionary objs = @object as IDictionary;
            var isKeyString = false;
            var isValueString = false;
            foreach (var item in (dynamic)objs)
            {
                isKeyString = item.Key is string;
                isValueString = item.Value is string;
                break;
            }
            string str = "{";
            foreach (var item in (dynamic)objs)
            {
                str += "{";
                if (isKeyString) str += "\"";
                str += item.Key.ToString();
                if (isKeyString) str += "\"";
                str += ", ";

                if (isValueString) str += "\"";
                str += item.Value.ToString();
                if (isValueString) str += "\"";
                str += "}";
                str += ", ";
            }
            str = str.Remove(str.Length - ", ".Length, ", ".Length);
            str += "}";
            _file.Write(str);
            _file.Write(end);
        }
        else
        {
            string str = "";
            foreach (var item in @object)
            {
                str += item.ToString();
                str += sep;
            }

            str = str.Remove(str.Length - sep.Length, sep.Length);

            _file.Write(str);
            _file.Write(end);
        }
        if (flush) _file.Flush();
    }
    #endregion

}
#if WITH_NAME_SPACE
}
#endif