namespace IfStatements
{
    public static class Task4
    {
        public static bool DoSomething1(bool b1, bool b2)
        {
            bool result = false;
            if (!(b1 && b2))
            {
                if (b1 || b2)
                {
                    result = true;
                    return result;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                return result;
            }
        }

        public static bool DoSomething2(bool b1, bool b2)
        {
            if (!(b1 && b2) && (b1 || b2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
