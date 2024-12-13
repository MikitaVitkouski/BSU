using System;

namespace BinaryRepresentation
{
    public static class BitsManipulation
    {
        public static string GetMemoryDumpOf(long number)
        {
            int numBits = sizeof(long) * 8;

            char[] binary = new char[numBits];

            for (int i = 0; i < numBits; i++)
            {
                if ((number & (1L << i)) != 0)
                {
                    binary[numBits - 1 - i] = '1';
                }
                else
                {
                    binary[numBits - 1 - i] = '0';
                }
            }

            return new string(binary);
        }
    }
}
