namespace WhilePractice
{
    public static class Task4
    {
        public static double SumSequenceElements(int n)
        {
            double sum = 0.0;
            double i = 1.0;

            while (i <= n)
            {
                double term = 1 / (((2 * i) + 1) * ((2 * i) + 1));
                sum += term;
                i++;
            }

            return sum;
        }
    }
}
