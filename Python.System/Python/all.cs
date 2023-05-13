using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Python
{
    public static partial class System
    {
        #region all
        /// <summary>
        ///  <see cref="Enumerable"/>
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="iterable"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool All<TSource>(IEnumerable<TSource> iterable, Func<TSource, bool> predicate = null)
            => All(iterable, predicate);





#if OBSOLETE
        [Obsolete("This method is deprecated, use `{nameof(All)}` instead.")]
#endif
        public static bool all<TSource>(IEnumerable<TSource> iterable, Func<TSource, bool> predicate = null)
        {
            if (predicate == null)
                return iterable.All(a => Convert.ToBoolean(a));
            else
                return iterable.All(predicate);
        }


        #endregion

    }
}
