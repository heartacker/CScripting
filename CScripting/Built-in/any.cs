using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

#if WITH_NAME_SPACE
namespace CScripting
{
#endif

public partial class CScripting
{
    #region any
    /// <summary>
    ///  <see cref="Enumerable"/>
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="iterable"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static bool Any<TSource>(IEnumerable<TSource> iterable, Func<TSource, bool> predicate = null)
        => Any(iterable, predicate);





#if OBSOLETE
        [Obsolete("This method is deprecated, use `{nameof(Any)}` instead.")]
#endif
    public static bool any<TSource>(IEnumerable<TSource> iterable, Func<TSource, bool> predicate = null)
    {
        if (predicate == null)
            return iterable.Any();
        else
            return iterable.Any(predicate);
    }

    #endregion

}
#if WITH_NAME_SPACE
}
#endif