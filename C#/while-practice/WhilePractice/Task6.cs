namespace WhilePractice
{
    public static class Task6
    {
        public static double SumSequenceElements(int n)
        {
            double sum = 0.0;
            int i = 1;
            int sign = -1;

            while (i <= n)
            {
                double term = sign / ((2.0 * i) + 1);
                sum += term;
                sign *= -1;
                i++;
            }

            return sum;
        }
    }
}
