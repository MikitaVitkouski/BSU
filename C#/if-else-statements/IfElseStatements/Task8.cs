namespace IfStatements
{
    public static class Task8
    {
        public static int DoSomething(int i1, int i2)
        {
            int result = 0;

            if (i1 >= -4 && i1 < 9 && i2 > 5)
            {
                result = i1 + i2;
            }
            else
            {
                if (i1 >= -4 && i1 < 9 && i2 <= -3)
                {
                    result = (i1 * 2) - i2;
                }
                else
                {
                    if (i1 >= -4 && i1 < 9 && i2 > -3 && i2 <= 5)
                    {
                        result = i2 - (i1 * i1);
                    }
                    else
                    {
                        if (i1 < -4 && i2 >= 7)
                        {
                            result = (i2 * 2) - i1;
                        }
                        else
                        {
                            if (i1 < -4 && i2 < -5)
                            {
                                result = i2 - i1;
                            }
                            else
                            {
                                if (i1 < -4 && i2 >= -5 && i2 < 7)
                                {
                                    result = i1 - i2;
                                }
                                else
                                {
                                    if (i1 >= 9 && i2 >= 7)
                                    {
                                        result = i1 - (i2 * i2);
                                    }
                                    else
                                    {
                                        if (i1 >= 9 && i2 < -7)
                                        {
                                            result = (i1 * 2) - (i2 * 2);
                                        }
                                        else
                                        {
                                            result = i2 * i1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
