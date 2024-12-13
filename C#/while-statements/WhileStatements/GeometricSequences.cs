namespace WhileStatements
{
    public static class GeometricSequences
    {
        public static uint SumGeometricSequenceTerms1(uint a, uint r, uint n)
        {
            uint sum = 0;
            int i = 0;

            while (i < n)
            {
                int j = 0;
                uint rpow = 1;
                while (j < i)
                {
                    rpow = rpow * r;
                    j = j + 1;
                }

                sum = sum + (a * rpow);
                i = i + 1;
            }

            return sum;
        }

        public static uint SumGeometricSequenceTerms2(uint n)
        {
            uint sum = 0, a = 13, r = 3;
            int i = 0;
            while (i < n)
            {
                int j = 0;
                uint rpow = 1;
                while (j < i)
                {
                    rpow = rpow * r;
                    j = j + 1;
                }

                sum = sum + (a * rpow);
                i = i + 1;
            }

            return sum;
        }

        public static uint CountGeometricSequenceTerms3(uint a, uint r, uint maxTerm)
        {
            uint tmp = a, count = 0;

            while (tmp <= maxTerm)
            {
                tmp *= r;
                count++;
            }

            return count;
        }

        public static uint CountGeometricSequenceTerms4(uint a, uint r, uint n, uint minTerm)
        {
            uint tmp = a, count = 0, j = 0;

            while (j < n)
            {
                if (tmp >= minTerm)
                {
                    count++;
                }

                tmp *= r;
                j++;
            }

            return count;
        }
    }
}
