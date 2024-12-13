namespace IfStatements
{
    public static class Task6
    {
        public static int DoSomething(int i)
        {
            int result = 0;

            if (i < -8)
            {
                result = i * i;
            }
            else
            {
                if (i >= 7)
                {
                    result = i * 2;
                }
                else
                {
                    if (i <= -2)
                    {
                        result = i * 3;
                    }
                    else
                    {
                        if (i > 3)
                        {
                            result = i * (i - 1) * -1;
                        }
                        else
                        {
                            result = (i * 2) + (i * i);
                        }
                    }
                }
            }

            return result;
        }
    }
}
