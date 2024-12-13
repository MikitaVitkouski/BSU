namespace CompilerErrors.CS7036
{
    public static class MyClass
    {
        public static int MyMethod()
        {
            return ReturnInt(5_689_375);
        }

        public static int ReturnInt(int intParameter)
        {
            return intParameter;
        }
    }
}
