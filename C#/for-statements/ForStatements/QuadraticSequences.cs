namespace ForStatements
{
    public static class QuadraticSequences
    {
        public static uint CountQuadraticSequenceTerms(long a, long b, long c, long maxTerm)
        {
            uint count = 0;
            int n = 0;

            while (true)
            {
                int term = (3 * n * n) + (5 * n) + 7;

                if (term <= maxTerm)
                {
                    count++;
                }
                else
                {
                    break;
                }

                n++;
            }

            return count - 1;
        }

        public static ulong GetQuadraticSequenceTermsProduct1(uint count)
        {
            ulong product = 1;
            for (ulong i = 1; i <= count; i++)
            {
                ulong term = (7 * i * i) + (4 * i) + 2;
                product *= term;
            }

            return product;
        }

        public static ulong GetQuadraticSequenceProduct2(long a, long b, long c, long startN, long count)
        {
            ulong product = 1;
            long n = startN;

            for (int i = 0; i < count; i++)
            {
                long term = (3 * n * n) + (5 * n) + 7;
                product *= (ulong)term;
                n++;
            }

            return product;
        }
    }
}
