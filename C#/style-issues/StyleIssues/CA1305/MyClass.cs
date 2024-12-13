using System.Globalization;

namespace StyleIssues.CA1305
{
    public static class MyClass
    {
        public static string MyMethod(int i)
        {
            return "X" + i.ToString(CultureInfo.InvariantCulture);
        }
    }
}
