namespace IfStatements
{
    public static class Task2
    {
        public static int DoSomething1(bool b1, bool b2)
        {
            int result = 0;

            if (b1)
            {
                if (b2)
                {
                    result = 123;
                }

                if (!b2)
                {
                    result = -345;
                }
            }

            if (!b1)
            {
                if (b2)
                {
                    result = -567;
                }

                if (!b2)
                {
                    result = 789;
                }
            }

            return result;
        }

        public static int DoSomething2(bool b1, bool b2)
        {
            int result = 0;

            if (b1)
            {
                if (b2)
                {
                    result = 123;
                }
                else
                {
                    result = -345;
                }
            }
            else
            {
                if (b2)
                {
                    result = -567;
                }
                else
                {
                    result = 789;
                }
            }

            return result;
        }
    }
}
