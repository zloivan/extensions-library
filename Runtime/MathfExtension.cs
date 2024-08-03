using System;
using JetBrains.Annotations;
using UnityEngine;
#if ENABLED_UNITY_MATHEMATICS
using Unity.Mathematics;
#endif

namespace IKhom.ExtensionsLibrary.Runtime
{
    public static class MathfExtension
    {
#if ENABLED_UNITY_MATHEMATICS
        [PublicAPI]public static half Min(half a, half b) {
            return (a < b) ? a : b;
        }

        [PublicAPI]public static half Min(params half[] values) {
            var num = values.Length;
            if (num == 0) {
                return (half) 0;
            }

            half num2 = values[0];
            for (var i = 1; i < num; i++) {
                if (values[i] < num2) {
                    num2 = values[i];
                }
            }

            return num2;
        }
#endif

        /// <summary>
        /// Returns the minimum value from a collection of double values.
        /// </summary>
        /// <param name="values">An array of double values.</param>
        /// <returns>The minimum value from the array.</returns>
        [PublicAPI]
        public static double Min(params double[] values)
        {
            var num = values.Length;
            if (num == 0)
            {
                return 0f;
            }

            var num2 = values[0];
            for (var i = 1; i < num; i++)
            {
                if (values[i] < num2)
                {
                    num2 = values[i];
                }
            }

            return num2;
        }

#if ENABLED_UNITY_MATHEMATICS
        [PublicAPI]public static half Max(half a, half b) {
            return (a > b) ? a : b;
        }

        [PublicAPI]public static half Max(params half[] values) {
            int num = values.Length;
            if (num == 0) {
                return (half) 0;
            }

            half num2 = values[0];
            for (int i = 1; i < num; i++) {
                if (values[i] > num2) {
                    num2 = values[i];
                }
            }

            return num2;
        }
#endif

        /// <summary>
        /// Returns the maximum value from a collection of double values.
        /// </summary>
        /// <param name="values">An array of double values.</param>
        /// <returns>The maximum value from the array.</returns>
        [PublicAPI]
        public static double Max(params double[] values)
        {
            var num = values.Length;
            if (num == 0)
            {
                return 0f;
            }

            var num2 = values[0];
            for (var i = 1; i < num; i++)
            {
                if (values[i] > num2)
                {
                    num2 = values[i];
                }
            }

            return num2;
        }

        /// <summary>Distance from a point to a line.</summary>
        [PublicAPI]
        public static float PointDistanceToLine(Vector3 point, Vector3 a, Vector3 b)
        {
            return Mathf.Abs((float)((b.x - (double)a.x) * (a.y - (double)point.y) -
                                     (a.x - (double)point.x) * (b.y - (double)a.y))) /
                   Mathf.Sqrt(Mathf.Pow(b.x - a.x, 2f) + Mathf.Pow(b.y - a.y, 2f));
        }

        /// <summary>
        /// Returns a smooth value between start and end based on t.
        /// </summary>
        /// <param name="start">First point.</param>
        /// <param name="end">Second point.</param>
        /// <param name="t">Position between 0 and 1.</param>
        [PublicAPI]
        public static float Hermite(float start, float end, float t)
        {
            return Mathf.Lerp(start, end, (float)(t * (double)t * (3.0 - 2.0 * t)));
        }

        /// <summary>
        /// Returns a smooth value between start and end based on t.
        /// </summary>
        /// <param name="start">First point.</param>
        /// <param name="end">Second point.</param>
        /// <param name="t">Position between 0 and 1.</param>
        /// <param name="count">Number of interpolations to make.</param>
        [PublicAPI]
        public static float StackHermite(float start, float end, float t, int count)
        {
            for (var index = 0; index < count; ++index)
                t = Hermite(start, end, t);
            return t;
        }

        /// <summary>Returns the fractional of the value.</summary>
        /// <param name="value">The value to get the fractional of.</param>
        [PublicAPI]
        public static float Fract(float value) => value - (float)Math.Truncate(value);

        /// <summary>Returns the fractional of the value.</summary>
        /// <param name="value">The value to get the fractional of.</param>
        [PublicAPI]
        public static Vector2 Fract(Vector2 value)
        {
            return new Vector3(Fract(value.x), Fract(value.y));
        }

        /// <summary>Returns the fractional of the value.</summary>
        /// <param name="value">The value to get the fractional of.</param>
        [PublicAPI]
        public static Vector3 Fract(Vector3 value)
        {
            return new Vector3(Fract(value.x), Fract(value.y),
                Fract(value.z));
        }

        /// <summary>
        /// Returns a value based on t, that bounces faster and faster.
        /// </summary>
        /// <param name="t">The value to bounce.</param>
        [PublicAPI]
        public static float BounceEaseInFastOut(float t)
        {
            return (float)(Mathf.Cos((float)(t * (double)t * 3.1415927410125732 * 2.0)) * -0.5 + 0.5);
        }

        /// <summary>Returns a smooth value between 0 and 1 based on t.</summary>
        /// <param name="t">Position between 0 and 1.</param>
        [PublicAPI]
        public static float Hermite01(float t)
        {
            return Mathf.Lerp(0.0f, 1f, (float)(t * (double)t * (3.0 - 2.0 * t)));
        }

        /// <summary>Returns a smooth value between 0 and 1 based on t.</summary>
        /// <param name="t">Position between 0 and 1.</param>
        /// <param name="count">Number of interpolations to make.</param>
        [PublicAPI]
        public static float StackHermite01(float t, int count)
        {
            for (var index = 0; index < count; ++index)
                t = Hermite01(t);
            return t;
        }

        /// <summary>
        /// Returns an unclamped linear interpolation of two vectors.
        /// </summary>
        /// <param name="from">The first vector.</param>
        /// <param name="to">The second vector.</param>
        /// <param name="amount">The interpolation factor.</param>
        [PublicAPI]
        public static Vector3 LerpUnclamped(Vector3 from, Vector3 to, float amount)
        {
            return from + (to - from) * amount;
        }

        /// <summary>
        /// Returns an unclamped linear interpolation of two vectors.
        /// </summary>
        /// <param name="from">The first vector.</param>
        /// <param name="to">The second vector.</param>
        /// <param name="amount">The interpolation factor.</param>
        [PublicAPI]
        public static Vector2 LerpUnclamped(Vector2 from, Vector2 to, float amount)
        {
            return from + (to - from) * amount;
        }

        /// <summary>
        /// Returns a value that bounces between 0 and 1 based on value.
        /// </summary>
        /// <param name="value">The value to bounce.</param>
        [PublicAPI]
        public static float Bounce(float value)
        {
            return Mathf.Abs(Mathf.Sin((float)(value % 1.0 * 3.1415927410125732)));
        }

        /// <summary>Returns a value that eases in elasticly.</summary>
        /// <param name="value">The value to ease in elasticly.</param>
        /// <param name="amplitude">The amplitude.</param>
        /// <param name="length">The length.</param>
        [PublicAPI]
        public static float EaseInElastic(float value, float amplitude = 0.25f, float length = 0.6f)
        {
            value = Mathf.Clamp01(value);
            var num1 = Mathf.Clamp01(value * 7.5f);
            var num2 = (float)(1.0 - num1 * (double)num1 * (3.0 - 2.0 * num1));
            var num3 = Mathf.Pow(1f - Mathf.Sin(Mathf.Min(value * (1f - length), 0.5f) * 3.1415927f), 2f);
            return (float)(1.0 +
                           (Mathf.Cos((float)(3.1415927410125732 + value * 23.0)) * (double)amplitude +
                            num2 * -(1.0 - amplitude)) * num3);
        }

        /// <summary>Returns a value that eases out elasticly.</summary>
        /// <param name="value">The value to ease out elasticly.</param>
        /// <param name="amplitude">The amplitude.</param>
        /// <param name="length">The length.</param>
        [PublicAPI]
        public static float EaseOutElastic(float value, float amplitude = 0.25f, float length = 0.6f)
        {
            return 1f - EaseInElastic(1f - value, amplitude, length);
        }

        /// <summary>
        /// Returns a smooth value betweeen that peaks at t=0.5 and then comes back down again.
        /// </summary>
        /// <param name="t">A value between 0 and 1.</param>
        [PublicAPI]
        public static float EaseInOut(float t)
        {
            t = 1f - Mathf.Abs((float)(Mathf.Clamp01(t) * 2.0 - 1.0));
            t = (float)(t * (double)t * (3.0 - 2.0 * t));
            return t;
        }

        /// <summary>Computes a hash for a byte array.</summary>
        /// <param name="data">The byte array.</param>
        [PublicAPI]
        public static int ComputeByteArrayHash(byte[] data)
        {
            var num1 = -2128831035;
            for (var index = 0; index < data.Length; ++index)
                num1 = (num1 ^ data[index]) * 16777619;
            var num2 = num1 + (num1 << 13);
            var num3 = num2 ^ num2 >> 7;
            var num4 = num3 + (num3 << 3);
            var num5 = num4 ^ num4 >> 17;
            return num5 + (num5 << 5);
        }

        /// <summary>Gives a smooth path between a collection of points.</summary>
        /// <param name="path">The collection of point.</param>
        /// <param name="t">The current position in the path. 0 is at the start of the path, 1 is at the end of the path.</param>
        [PublicAPI]
        public static Vector3 InterpolatePoints(Vector3[] path, float t)
        {
            t = Mathf.Clamp01(t * (float)(1.0 - 1.0 / path.Length));
            var b = path.Length - 1;
            var num1 = Mathf.FloorToInt(t * path.Length);
            var num2 = t * path.Length - num1;
            int num3;
            var vector3_1 = path[Mathf.Max(0, num3 = num1 - 1)];
            var vector3_2 = path[Mathf.Min(num3 + 1, b)];
            var vector3_3 = path[Mathf.Min(num3 + 2, b)];
            var vector3_4 = path[Mathf.Min(num3 + 3, b)];
            return 0.5f * ((-vector3_1 + 3f * vector3_2 - 3f * vector3_3 + vector3_4) * (num2 * num2 * num2) +
                           (2f * vector3_1 - 5f * vector3_2 + 4f * vector3_3 - vector3_4) * (num2 * num2) +
                           (-vector3_1 + vector3_3) * num2 + 2f * vector3_2);
        }

        /// <summary>
        /// Checks if two given lines intersect with one another and returns the intersection point (if
        /// any) in an out parameter.
        /// Source: http://stackoverflow.com/questions/3746274/line-intersection-with-aabb-rectangle.
        /// Edited to implement Cohen-Sutherland type pruning for efficiency.
        /// </summary>
        /// <param name="a1">Starting point of line a.</param>
        /// <param name="a2">Ending point of line a.</param>
        /// <param name="b1">Starting point of line b.</param>
        /// <param name="b2">Ending point of line b.</param>
        /// <param name="intersection">
        /// The out parameter which contains the intersection point if there was any.
        /// </param>
        /// <returns>True if the two lines intersect, otherwise false.</returns>
        [PublicAPI]
        public static bool LineIntersectsLine(Vector2 a1,
            Vector2 a2,
            Vector2 b1,
            Vector2 b2,
            out Vector2 intersection)
        {
            intersection = Vector2.zero;
            var vector2_1 = new Vector2(b1.x < (double)b2.x ? b1.x : b2.x,
                b1.y > (double)b2.y ? b1.y : b2.y);
            var vector2_2 = new Vector2(b1.x > (double)b2.x ? b1.x : b2.x,
                b1.y < (double)b2.y ? b1.y : b2.y);
            if (a1.x < (double)vector2_1.x && a2.x < (double)vector2_1.x ||
                a1.y > (double)vector2_1.y && a2.y > (double)vector2_1.y ||
                a1.x > (double)vector2_2.x && a2.x > (double)vector2_2.x ||
                a1.y < (double)vector2_2.y && a2.y < (double)vector2_2.y)
                return false;
            var vector2_3 = a2 - a1;
            var vector2_4 = b2 - b1;
            var num1 = (float)(vector2_3.x * (double)vector2_4.y - vector2_3.y * (double)vector2_4.x);
            if (num1 == 0.0)
                return false;
            var vector2_5 = b1 - a1;
            var num2 =
                (float)(vector2_5.x * (double)vector2_4.y - vector2_5.y * (double)vector2_4.x) /
                num1;
            if (num2 < 0.0 || num2 > 1.0)
                return false;
            var num3 =
                (float)(vector2_5.x * (double)vector2_3.y - vector2_5.y * (double)vector2_3.x) /
                num1;
            if (num3 < 0.0 || num3 > 1.0)
                return false;
            intersection = a1 + num2 * vector2_3;
            return true;
        }

        /// <summary>Returns the collision point between two infinite lines.</summary>
        [PublicAPI]
        public static Vector2 InfiniteLineIntersect(Vector2 ps1,
            Vector2 pe1,
            Vector2 ps2,
            Vector2 pe2)
        {
            var num1 = pe1.y - ps1.y;
            var num2 = ps1.x - pe1.x;
            var num3 = (float)(num1 * (double)ps1.x + num2 * (double)ps1.y);
            var num4 = pe2.y - ps2.y;
            var num5 = ps2.x - pe2.x;
            var num6 = (float)(num4 * (double)ps2.x + num5 * (double)ps2.y);
            var num7 = (float)(num1 * (double)num5 - num4 * (double)num2);
            if (num7 == 0.0)
                throw new Exception("Lines are parallel");
            return new Vector2((float)(num5 * (double)num3 - num2 * (double)num6) / num7,
                (float)(num1 * (double)num6 - num4 * (double)num3) / num7);
        }

        /// <summary>Distance from line to plane.</summary>
        /// <param name="planeOrigin">Position of the plane.</param>
        /// <param name="planeNormal">Surface normal of the plane.</param>
        /// <param name="lineOrigin">Origin of the line.</param>
        /// <param name="lineDirectionNormalized">Line direction normal.</param>
        [PublicAPI]
        public static float LineDistToPlane(Vector3 planeOrigin,
            Vector3 planeNormal,
            Vector3 lineOrigin,
            Vector3 lineDirectionNormalized)
        {
            return Vector3.Dot(lineDirectionNormalized, planeNormal) * Vector3.Distance(planeOrigin, lineOrigin);
        }

        /// <summary>Distance from ray to plane.</summary>
        /// <param name="ray">The ray.</param>
        /// <param name="plane">The plane.</param>
        [PublicAPI]
        public static float RayDistToPlane(Ray ray, Plane plane)
        {
            var f = Vector3.Dot(plane.normal, ray.direction);
            if (Mathf.Abs(f) < 9.999999974752427E-07)
                return 0.0f;
            var num = Vector3.Dot(plane.normal, ray.origin);
            return (-plane.distance - num) / f;
        }

        /// <summary>
        /// Interpolates t between a and b to a value between 0 and 1 using a Hermite polynomial.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <param name="t">The position value.</param>
        /// <returns>A smoothed value between 0 and 1.</returns>
        [PublicAPI]
        public static float SmoothStep(float a, float b, float t)
        {
            t = Mathf.Clamp01((float)((t - (double)a) / (b - (double)a)));
            return (float)(t * (double)t * (3.0 - 2.0 * t));
        }

        /// <summary>
        /// Interpolates t between a and b to a value between 0 and 1.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <param name="t">The position value.</param>
        /// <returns>Linear value between 0 and 1.</returns>
        [PublicAPI]
        public static float LinearStep(float a, float b, float t)
        {
            return Mathf.Clamp01((float)((t - (double)a) / (b - (double)a)));
        }

        /// <summary>Wraps a value between min and max.</summary>
        /// <param name="value">The value to wrap.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        [PublicAPI]
        public static double Wrap(this double value, double min, double max)
        {
            var num1 = max - min;
            var num2 = num1 < 0.0 ? -num1 : num1;
            if (value < min)
                return value + num2 * Math.Ceiling(Math.Abs(value / num2));
            return value >= max ? value - num2 * Math.Floor(Math.Abs(value / num2)) : value;
        }

        /// <summary>Wraps a value between min and max.</summary>
        /// <param name="value">The value to wrap.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        [PublicAPI]
        public static float Wrap(this float value, float min, float max)
        {
            var num1 = max - min;
            var num2 = num1 < 0.0 ? -num1 : num1;
            if (value < (double)min)
                return value + num2 * (float)Math.Ceiling(Math.Abs(value / num2));
            return value >= (double)max
                ? value - num2 * (float)Math.Floor(Math.Abs(value / num2))
                : value;
        }

        /// <summary>Wraps a value between min and max.</summary>
        /// <param name="value">The value to wrap.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        [PublicAPI]
        public static int Wrap(this int value, int min, int max)
        {
            var num1 = max - min;
            var num2 = num1 < 0 ? -num1 : num1;
            if (value < min)
                return value + num2 * (Math.Abs(value / num2) + 1);
            return value >= max ? value - num2 * Math.Abs(value / num2) : value;
        }

        /// <summary>
        /// Rounds a value based on the specified minimum difference.
        /// </summary>
        /// <param name="valueToRound">The value to round.</param>
        /// <param name="minDifference">The minimum difference to consider for rounding.</param>
        /// <returns>The rounded value based on the specified minimum difference.</returns>
        [PublicAPI]
        public static double RoundBasedOnMinimumDifference(this double valueToRound, double minDifference)
        {
            return minDifference != 0.0
                ? Math.Round(valueToRound, GetNumberOfDecimalsForMinimumDifference(minDifference),
                    MidpointRounding.AwayFromZero)
                : DiscardLeastSignificantDecimal(valueToRound);
        }

        /// <summary>Discards the least significant demicals.</summary>
        /// <param name="v">The value of insignificant decimals.</param>
        /// <returns>Value with significant decimals.</returns>
        [PublicAPI]
        public static double DiscardLeastSignificantDecimal(this double v)
        {
            var digits = Math.Max(0, (int)(5.0 - Math.Log10(Math.Abs(v))));
            try
            {
                return Math.Round(v, digits);
            }
            catch (ArgumentOutOfRangeException)
            {
                return 0.0;
            }
        }

        /// <summary>
        /// Clamps and wraps an angle within a specified range.
        /// </summary>
        /// <param name="angle">The angle to clamp and wrap.</param>
        /// <param name="min">The minimum angle within the range.</param>
        /// <param name="max">The maximum angle within the range.</param>
        /// <returns>The clamped and wrapped angle within the specified range.</returns>
        [PublicAPI]
        public static float ClampWrapAngle(this float angle, float min, float max)
        {
            const float CIRCLE_ANGLE = 360f;
            var num2 = min;
            var num3 = max;
            var num4 = angle;
            if (num2 < 0.0)
                num2 = num2 % CIRCLE_ANGLE + CIRCLE_ANGLE;
            if (num3 < 0.0)
                num3 = num3 % CIRCLE_ANGLE + CIRCLE_ANGLE;
            if (num4 < 0.0)
                num4 = num4 % CIRCLE_ANGLE + CIRCLE_ANGLE;
            var num5 = (int)(Math.Abs(min - max) / (double)CIRCLE_ANGLE) * CIRCLE_ANGLE;
            var num6 = num3 + num5;
            var num7 = num4 + num5;
            if (min > (double)max)
                num6 += CIRCLE_ANGLE;
            if (num7 < (double)num2)
                num7 = num2;
            if (num7 > (double)num6)
                num7 = num6;
            return num7;
        }

        /// <summary>
        /// Gets the number of decimal places to consider for rounding based on the specified minimum difference.
        /// </summary>
        /// <param name="minDifference">The minimum difference to consider for rounding.</param>
        /// <returns>The number of decimal places to consider for rounding.</returns>
        private static int GetNumberOfDecimalsForMinimumDifference(this double minDifference)
        {
            return Mathf.Clamp(-Mathf.FloorToInt(Mathf.Log10(Mathf.Abs((float)minDifference))), 0, 15);
        }

        /// <summary>
        /// Returns the percentage of the given part with respect to the whole.
        /// </summary>
        /// <param name="part">The part of the whole to calculate the percentage for.</param>
        /// <param name="whole">The whole from which the part is taken.</param>
        /// <returns>The percentage of the part with respect to the whole as a float.</returns>
        [PublicAPI]
        public static float PercentageOf(this int part, int whole)
        {
            if (whole == 0) return 0; // Handling division by zero
            return (float)part / whole;
        }

        /// <summary>
        /// Checks if the given float values are approximately equal.
        /// </summary>
        /// <param name="f1">The first float value to compare.</param>
        /// <param name="f2">The second float value to compare.</param>
        /// <returns>True if the two float values are approximately equal, otherwise false.</returns>
        [PublicAPI]
        public static bool Approx(this float f1, float f2) => Mathf.Approximately(f1, f2);

        /// <summary>
        /// Checks if the given integer is odd.
        /// </summary>
        /// <param name="i">The integer to check for oddness.</param>
        /// <returns>True if the integer is odd, otherwise false.</returns>
        [PublicAPI]
        public static bool IsOdd(this int i) => i % 2 == 1;

        /// <summary>
        /// Checks if the given integer is even.
        /// </summary>
        /// <param name="i">The integer to check for evenness.</param>
        /// <returns>True if the integer is even, otherwise false.</returns>
        [PublicAPI]
        public static bool IsEven(this int i) => i % 2 == 0;

        /// <summary>
        /// Returns the greater of the given integer and the minimum value.
        /// </summary>
        /// <param name="value">The integer to compare with the minimum value.</param>
        /// <param name="min">The minimum value to compare with.</param>
        /// <returns>The greater of the given integer and the minimum value.</returns>
        [PublicAPI]
        public static int AtLeast(this int value, int min) => Mathf.Max(value, min);

        /// <summary>
        /// Returns the lesser of the given integer and the maximum value.
        /// </summary>
        /// <param name="value">The integer to compare with the maximum value.</param>
        /// <param name="max">The maximum value to compare with.</param>
        /// <returns>The lesser of the given integer and the maximum value.</returns>
        [PublicAPI]
        public static int AtMost(this int value, int max) => Mathf.Min(value, max);

#if ENABLED_UNITY_MATHEMATICS
     /// <summary>
     /// Returns the greater of the given half and the maximum value.
     /// </summary>
     /// <param name="value">The half to compare with the maximum value.</param>
     /// <param name="max">The maximum value to compare with.</param>
     /// <returns>The greater of the given half and the maximum value.</returns>
     [PublicAPI] public static half AtLeast(this half value, half max) => MathfExtension.Max(value, max);

     /// <summary>
     /// Returns the lesser of the given half and the minimum value.
     /// </summary>
     /// <param name="value">The half to compare with the minimum value.</param>
     /// <param name="min">The minimum value to compare with.</param>
     /// <returns>The lesser of the given half and the minimum value.</returns>
     [PublicAPI] public static half AtMost(this half value, half max) => MathfExtension.Min(value, max);
#endif

        /// <summary>
        /// Returns the greater of the given float and the minimum value.
        /// </summary>
        /// <param name="value">The float to compare with the minimum value.</param>
        /// <param name="min">The minimum value to compare with.</param>
        /// <returns>The greater of the given float and the minimum value.</returns>
        [PublicAPI]
        public static float AtLeast(this float value, float min) => Mathf.Max(value, min);

        /// <summary>
        /// Returns the lesser of the given float and the maximum value.
        /// </summary>
        /// <param name="value">The float to compare with the maximum value.</param>
        /// <param name="max">The maximum value to compare with.</param>
        /// <returns>The lesser of the given float and the maximum value.</returns>
        [PublicAPI]
        public static float AtMost(this float value, float max) => Mathf.Min(value, max);

        /// <summary>
        /// Returns the greater of the given double and the minimum value.
        /// </summary>
        /// <param name="value">The double to compare with the minimum value.</param>
        /// <param name="min">The minimum value to compare with.</param>
        /// <returns>The greater of the given double and the minimum value.</returns>
        [PublicAPI]
        public static double AtLeast(this double value, double min) => Max(value, min);

        /// <summary>
        /// Returns the lesser of the given double and the maximum value.
        /// </summary>
        /// <param name="value">The double to compare with the maximum value.</param>
        /// <param name="max">The maximum value to compare with.</param>
        /// <returns>The lesser of the given double and the maximum value.</returns>
        [PublicAPI]
        public static double AtMost(this double value, double max) => Min(value, max);
    }
}