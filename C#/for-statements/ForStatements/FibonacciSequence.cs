namespace ForStatements
{
    public static class FibonacciSequence
    {
        public static int GetFibonacciNumber(int n)
        {
            int fib = 0, first = 0, second = 1;
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                for (int i = 2; i <= n; i++)
                {
                    int tmp = first + second;
                    if (i == n)
                    {
                        fib += tmp;
                    }

                    first = second;
                    second = tmp;
                }
            }

            return fib;
        }

        public static ulong GetProductOfFibonacciNumberDigits(ulong n)
        {
            ulong fib = 0, first = 0, second = 1;
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                for (ulong i = 2; i <= n; i++)
                {
                    ulong tmp = first + second;
                    if (i == n && tmp < 10)
                    {
                        fib = tmp;
                    }
                    else if (i == n && tmp >= 10 && tmp < 100)
                    {
                        fib = ((tmp - (tmp % 10)) / 10) * (tmp % 10);
                    }
                    else if (i == n && tmp >= 100)
                    {
                        fib = (tmp - (tmp % 10)) / 100 * ((tmp % 100) - (tmp % 10)) / 10 * (tmp % 10);
                    }

                    first = second;
                    second = tmp;
                }
            }

            return fib;
        }
    }
}
