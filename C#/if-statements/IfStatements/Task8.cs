namespace IfStatements
{
    public static class Task8
    {
        public static bool DoSomething(bool b, int i)
        {
            bool result = false;
            if (b)
            {
                if ((i >= -3 && i < 0) || i < -6)
                {
                    result = true;
                }

                if ((i <= 3 && i > 0) || i > 6)
                {
                    result = true;
                }
            }

            if (!b)
            {
                result = true;
                if (i == 0)
                {
                    result = false;
                    if ((i <= -3 && i >= -6) || (i >= 3 && i <= 6))
                    {
                        result = false;
                    }
                }

                if ((i <= -3 && i >= -6) || (i >= 3 && i <= 6))
                {
                    result = false;
                }
            }

            return result;
        }
    }
}

