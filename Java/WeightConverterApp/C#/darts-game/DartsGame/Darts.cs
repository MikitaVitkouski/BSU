using System;

namespace DartsGame
{
    public static class Darts
    {
        public static int GetScore(double x, double y)
        {
            double distanceFromCenter = Math.Sqrt((x * x) + (y * y));

            if (distanceFromCenter > 10)
            {
                return 0;
            }
            else if (distanceFromCenter > 5)
            {
                return 1;
            }
            else if (distanceFromCenter > 1)
            {
                return 5;
            }
            else
            {
                return 10;
            }
        }
    }
}
