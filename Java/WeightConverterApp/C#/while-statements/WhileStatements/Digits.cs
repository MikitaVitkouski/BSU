namespace WhileStatements
{
    public static class Digits
    {
        public static ulong GetDigitsSum(ulong n)
        {
            ulong sum = 0;
            while (n != 0)
            {
                ulong temp = n % 10;
                n /= 10;
                sum += temp;
            }

            return sum;
        }

        public static ulong GetDigitsProduct(ulong n)
        {
            ulong prod = 1;
            if (n != 0)
            {
                while (n != 0)
                {
                    ulong temp = n % 10;
                    n /= 10;
                    prod *= temp;
                }
            }
            else
            {
                return 0;
            }

            return prod;
        }
    }
}
