namespace WhileStatements
{
    public static class PrimeNumbers
    {
        public static bool IsPrimeNumber(uint n)
        {
            if (n <= 1)
            {
                return false;
            }

            uint divisor = 2;
            while (divisor <= Math.Sqrt(n))
            {
                if (n % divisor == 0)
                {
                    return false;
                }

                divisor++;
            }

            return true;
        }

        public static uint GetLastPrimeNumber(uint n)
        {
            if (n <= 1)
            {
                return 0;
            }

            uint latestPrime = 0;
            uint number = 2;

            while (number <= n)
            {
                bool isPrime = true;
                uint divisor = 2;

                while (divisor * divisor <= number)
                {
                    if (number % divisor == 0)
                    {
                        isPrime = false;
                        break;
                    }

                    divisor++;
                }

                if (isPrime)
                {
                    latestPrime = number;
                }

                number++;
            }

            return latestPrime;
        }

        public static uint SumLastPrimeNumbers(uint n, uint count)
        {
            if (n <= 1)
            {
                return 0;
            }

            uint latestPrime = 0;
            uint number = 2;
            uint sum = 0;
            List<uint> dynamicArray = new List<uint>();

            while (number <= n)
                {
                    bool isPrime = true;
                    uint divisor = 2;

                    while (divisor * divisor <= number)
                    {
                        if (number % divisor == 0)
                        {
                            isPrime = false;
                            break;
                        }

                        divisor++;
                    }

                    if (isPrime)
                    {
                    latestPrime = number;
                    dynamicArray.Add(latestPrime);
                    }

                    number++;
                }

            int index = dynamicArray.Count - 1;
            int counter = 0;
            while (counter < count && index >= 0)
            {
                sum += dynamicArray[index];
                counter++;
                index--;
            }

            return sum;
        }
    }
}
