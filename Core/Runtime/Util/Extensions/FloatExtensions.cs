using System;

namespace TheLuxGames.SharedResources.Extensions
{
    public static class FloatExtensions
    {
        public static bool Equals(this float f, float f1, float f2, float tolerance)
        {
            return Math.Abs(f1 - f2) < tolerance;
        }

        public static bool Equals(float f1, float f2, float tolerance)
        {
            return Math.Abs(f1 - f2) < tolerance;
        }
    }
}