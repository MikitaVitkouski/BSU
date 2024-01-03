namespace Exceptions
{
    public static class ThrowingArgument
    {
        public static int CheckParameterAndThrowException1(int i)
        {
            if (i % 2 != 0)
            {
                throw new ArgumentException("i should not be odd.", nameof(i));
            }

            return i;
        }

        public static ushort CheckParameterAndThrowException2(ushort s)
        {
            if (s == 0)
            {
                throw new ArgumentException("s should not equals zero.", nameof(s));
            }

            return s;
        }

        public static long CheckParameterAndThrowException3(long l)
        {
            if (l % 2 == 0)
            {
                throw new ArgumentException("l should not be even.", nameof(l));
            }

            return l;
        }

        public static int CheckParameterAndThrowException4(float[] floats)
        {
            if (floats is null)
            {
                throw new ArgumentNullException(nameof(floats));
            }

            if (floats.Length == 0)
            {
                throw new ArgumentException("floats array has no elements.", nameof(floats));
            }

            return floats.Length;
        }

        public static int CheckParameterAndThrowException5(string s)
        {
            if (s == string.Empty)
            {
                throw new ArgumentException("s string is empty.", nameof(s));
            }

            if (s is null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            return s.Length;
        }
    }
}
