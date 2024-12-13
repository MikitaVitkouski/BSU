namespace IfStatements
{
    public static class Task13
    {
        public static int DoSomething(bool b, int i)
        {
            if (b && (i < -8 || (i >= -4 && i < 0)))
            {
                return 5 + i;
            }

            if (b && (i >= -8 && i < -4))
            {
                return i;
            }

            if (b && i == 0)
            {
                return 10;
            }

            if (b && (i > 0 && i <= 3))
            {
                return i - 5;
            }

            if ((b && i > 3) || (!b && ((i <= -5) || (i > 5))))
            {
                return i * -1;
            }

            if (!b && (i > -5 && i <= 5))
            {
                return 10 - i;
            }

            return i;
        }
    }
}
