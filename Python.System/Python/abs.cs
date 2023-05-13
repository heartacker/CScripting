using System;
using System.Numerics;

namespace Python
{
    public static partial class System
    {
        #region abs
        public const double e = Math.E;
        public const double pi = Math.PI;

        /// <summary>
        /// 将复数转为绝对值
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static double Abs(Complex num) => Math.Abs(num.Magnitude);

        /// <see cref=" Math.Abs"/>
        public static decimal Abs(decimal value) => Math.Abs(value);

        /// <see cref=" Math.Abs"/>
        public static double Abs(double value) => Math.Abs(value);

        /// <see cref=" Math.Abs"/>
        public static short Abs(short value) => Math.Abs(value);

        /// <see cref=" Math.Abs"/>
        public static int Abs(int value) => Math.Abs(value);

        /// <see cref=" Math.Abs"/>
        public static long Abs(long value) => Math.Abs(value);

        /// <see cref=" Math.Abs"/>
        public static sbyte Abs(sbyte value) => Math.Abs(value);

        /// <see cref=" Math.Abs"/>
        public static float Abs(float value) => Math.Abs(value);

#if OBSOLETE
        [Obsolete("This method is deprecated, use `Abs` instead.")]
#endif
        public static double abs(Complex num) => Math.Abs(num.Magnitude);

#if OBSOLETE
        [Obsolete("This method is deprecated, `using static System.Math;` and use `Abs` instead.")]
#endif
        public static double abs(double num) => Math.Abs(num);

#if OBSOLETE
        [Obsolete("This method is deprecated, `using static System.Math;` and use `Abs` instead.")]
#endif
        public static decimal abs(decimal num) => Math.Abs(num);

#if OBSOLETE
        [Obsolete("This method is deprecated, `using static System.Math;` and use `Abs` instead.")]
#endif
        public static short abs(short num) => Math.Abs(num);

#if OBSOLETE
        [Obsolete("This method is deprecated, `using static System.Math;` and use `Abs` instead.")]
#endif
        public static int abs(int num) => Math.Abs(num);
#if OBSOLETE
        [Obsolete("This method is deprecated, `using static System.Math;` and use `Abs` instead.")]
#endif
        public static long abs(long num) => Math.Abs(num);
#if OBSOLETE
        [Obsolete("This method is deprecated, `using static System.Math;` and use `Abs` instead.")]
#endif
        public static sbyte abs(sbyte num) => Math.Abs(num);

#if OBSOLETE
        [Obsolete("This method is deprecated, `using static System.Math;` and use `Abs` instead.")]
#endif
        public static float abs(float num) => Math.Abs(num);

        #endregion

    }
}
