namespace IfStatements
{
    public static class Task1
    {
        public static int DoSomething(int i)
        {
            int result = i;

            if (result < 0)
            {
                result = 0;
            }

            return result;
        }
    }
}
