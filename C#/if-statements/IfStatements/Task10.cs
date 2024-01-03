namespace IfStatements
{
    public static class Task10
    {
        public static int DoSomething(bool b1, bool b2, int i)
        {
            int result = i;
            if (b1)
            {
                if (i == 0)
                {
                    result = -1;
                }

                if (i >= 2 && i <= 9)
                {
                    if (b2)
                    {
                        result = 10 - result;
                    }

                    if (!b2)
                    {
                        result = 10 + result;
                    }
                }

                if (i <= -2 && i >= -9)
                {
                    if (b2)
                    {
                        result = 5 + result;
                    }

                    if (!b2)
                    {
                        result = 5 - result;
                    }
                }
            }

            if (!b1)
            {
                if (i == 0)
                {
                    if (b2)
                    {
                        result = 1;
                    }

                    if (!b2)
                    {
                        result = -1;
                    }
                }

                if (b2 && (i <= -10 || i >= 10))
                {
                    result = result + 1;
                }

                if (!b2 && (i <= -10 || i >= 10))
                {
                    result = result - 1;
                }

                if (i != 0 && i > -5 && i < 5)
                {
                    if (b2)
                    {
                        result = result + 10;
                    }

                    if (!b2)
                    {
                        result = result - 10;
                    }
                }
            }

            return result;
        }
    }
}
