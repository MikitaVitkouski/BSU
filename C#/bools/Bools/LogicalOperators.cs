namespace Bools
{
    public static class LogicalOperators
    {
        public static bool LogicalAnd1(bool b1, bool b2)
        {
            return b1 && b2;
        }

        public static bool LogicalAnd2(bool b1, bool b2, bool b3)
        {
            return b1 && b2 && b3;
        }

        public static bool LogicalAnd3(bool b1, bool b2, bool b3, bool b4)
        {
            return b1 && b2 && b3 && b4;
        }

        public static bool LogicalOr1(bool b1, bool b2)
        {
            return b1 || b2;
        }

        public static bool LogicalOr2(bool b1, bool b2, bool b3)
        {
            return b1 || b2 || b3;
        }

        public static bool LogicalOr3(bool b1, bool b2, bool b3, bool b4)
        {
            return b1 || b2 || b3 || b4;
        }

        public static bool LogicalXor1(bool b1, bool b2)
        {
            return b1 ^ b2;
        }

        public static bool LogicalXor2(bool b1, bool b2, bool b3)
        {
            return b1 ^ b2 ^ b3;
        }

        public static bool LogicalXor3(bool b1, bool b2, bool b3, bool b4)
        {
            return b1 ^ b2 ^ b3 ^ b4;
        }

        public static bool Negate(bool b)
        {
            return !b;
        }
    }
}
