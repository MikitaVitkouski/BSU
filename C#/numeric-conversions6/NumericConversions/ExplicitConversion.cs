namespace NumericConversions
{
    public static class ExplicitConversion
    {
        public static int LongToInt(long longValue)
        {
            return (int)longValue;
        }

        public static int FloatToInt(float floatValue)
        {
            return (int)floatValue;
        }

        public static int DoubleToInt(double doubleValue)
        {
            return (int)doubleValue;
        }

        public static int DecimalToInt(decimal decimalValue)
        {
            return (int)decimalValue;
        }

        public static long FloatToLong(float floatValue)
        {
            return (long)floatValue;
        }

        public static long DoubleToLong(double doubleValue)
        {
            return (long)doubleValue;
        }

        public static long DecimalToLong(decimal decimalValue)
        {
            return (long)decimalValue;
        }

        public static byte ShortToByte(short shortValue)
        {
            return (byte)shortValue;
        }

        public static byte IntToByte(int intValue)
        {
            return (byte)intValue;
        }

        public static short IntToShort(int intValue)
        {
            return (short)intValue;
        }
    }
}
