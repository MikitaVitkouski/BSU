using System.Security.Cryptography;

namespace Exceptions
{
    public static class NullCoalescingAssignment
    {
        public static object CheckParameterAndThrowException1(object o)
        {
            o ??= new object();

            return o;
        }

        public static int[] CheckParameterAndThrowException2(int[] integers)
        {
            integers ??= new int[] { 0 };
            return integers;
        }

        public static string CheckParameterAndThrowException3(string s)
        {
            s ??= "Hello, world!";
            return s;
        }

        public static string CheckParametersAndThrowException4(string s1, string s2)
        {
            s1 ??= "Hello";
            s2 ??= "world";
            return $"{s1}, {s2}!";
        }

        public static string CheckParametersAndThrowException5(string s1, int[] integers, string s2)
        {
            s1 ??= "abc";
            integers ??= new int[] { 1, 2, 3 };
            s2 ??= "123";
            return $"{s1}{integers.Length}{s2}";
        }
    }
}
