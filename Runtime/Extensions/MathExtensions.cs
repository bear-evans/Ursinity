using UnityEngine;

namespace TheBearDev.Ursinity.Runtime.Extensions
{
    public static class MathExtensions
    {
        /// <summary>
        /// Converts an angle from degrees to radians.
        /// </summary>
        /// <param name="degrees">The angle in degrees.</param>
        /// <returns>The angle converted to radians.</returns>
        public static float ToRadians(this float degrees)
        {
            return degrees * Mathf.Deg2Rad;
        }

        /// <summary>
        /// Calculates a point on the circumference of a circle given a center point, radius, and angle.
        /// </summary>
        /// <param name="center">The center point of the circle.</param>
        /// <param name="distance">The radius or distance from the center point to the calculated point.</param>
        /// <param name="angle">The angle in degrees at which to calculate the point.</param>
        /// <returns>The calculated point on the circle as a Vector2.</returns>
        public static Vector2 GetPointOnCircle(this Vector2 center, float distance, float angle)
        {
            Vector2 result;
            result.x = center.x + distance * Mathf.Cos(angle * Mathf.Deg2Rad);
            result.y = center.y + distance * Mathf.Sin(angle * Mathf.Deg2Rad);

            return result;
        }
    }
}