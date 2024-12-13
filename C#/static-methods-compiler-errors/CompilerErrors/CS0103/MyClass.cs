namespace CompilerErrors.CS0103
{
    public static class MyClass
    {
        public static int MyMethod()
        {
            return ReturnInt(intParameter: 534_947_886);
        }

        public static int ReturnInt(int intParameter)
        {
            return intParameter;
        }
    }
}
