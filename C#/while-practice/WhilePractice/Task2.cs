namespace WhilePractice
{
    public static class Task2
    {
        public static double SumSequenceElements(int n)
        {
            double sum = 0.0;
            double i = 1.0;
            double sign = 1.0;
            while (i <= n)
            {
                sum += sign * 1 / (i * (i + 1));
                sign *= -1.0;
                i++;
            }

            return sum;
        }
    }
}
