using System.Globalization;

namespace StyleIssues.CA1304
{
    public static class MyClass
    {
        public static string MyMethod(string str)
        {
            return "K-" + str.ToUpper(CultureInfo.InvariantCulture);
        }
    }
}
