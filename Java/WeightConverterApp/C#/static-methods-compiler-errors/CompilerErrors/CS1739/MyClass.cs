namespace CompilerErrors.CS1739
{
    public static class MyClass
    {
        public static int MyMethod()
        {
            return ReturnInt(intParameter: 9_389_572);
        }

        public static int ReturnInt(int intParameter)
        {
            return intParameter;
        }
    }
}
