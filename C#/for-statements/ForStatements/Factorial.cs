namespace ForStatements
{
    public static class Factorial
    {
        public static int GetFactorial(int n)
        {
            int ftr = 1;
            for (int i = 1; i <= n; i++)
            {
                ftr *= i;
            }

            return ftr;
        }

        public static int SumFactorialDigits(int n)
        {
            int sum = 0;
            int ftr = 1;
            for (int i = 1; i <= n; i++)
            {
                ftr *= i;
            }

            for (; ftr > 0; ftr /= 10)
            {
                sum += ftr % 10;
            }

            return sum;
        }
    }
}
