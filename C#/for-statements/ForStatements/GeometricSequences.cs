namespace ForStatements
{
    public static class GeometricSequences
    {
        public static ulong GetGeometricSequenceTermsProduct(uint a, uint r, uint n)
        {
            ulong product = 1;

            for (int i = 0; i < n; i++)
            {
                uint rpow = 1;
                for (int j = 0; j < i; j++)
                {
                    rpow *= r;
                }

                product *= a * rpow;
            }

            return product;
        }

        public static ulong SumGeometricSequenceTerms(uint n)
        {
            ulong product = 0;
            uint a = 5, r = 3;
            for (int i = 0; i < n; i++)
            {
                uint rpow = 1;
                for (int j = 0; j < i; j++)
                {
                    rpow *= r;
                }

                product += a * rpow;
            }

            return product;
        }

        public static ulong CountGeometricSequenceTerms1(uint a, uint r, uint maxTerm)
        {
            uint tmp = a;
            ulong count = 0;
            for (; tmp <= maxTerm;)
            {
                count++;
                uint rpow = 1;
                for (ulong j = 0; j < count; j++)
                {
                    rpow *= r;
                }

                tmp = a * rpow;
            }

            return count;
        }

        public static ulong CountGeometricSequenceTerms2(uint a, uint r, uint n, uint minTerm)
        {
            ulong i = n - 1;

            for (; ;)
            {
                uint rpow = 1;
                for (ulong j = 0; j < i; j++)
                {
                    rpow *= r;
                }

                ulong tmp = a * rpow;

                if (tmp < minTerm && i == n - 1)
                {
                    return 0;
                }

                if (tmp <= minTerm || i == 0)
                {
                    break;
                }

                i--;
            }

            return n - i;
        }
    }
}
