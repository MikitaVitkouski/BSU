namespace Bools
{
    public static class LogicalPuzzles
    {
        public static bool Puzzle1(bool b1, bool b2)
        {
            return !b1 || b2;
        }

        public static bool Puzzle2(bool b1, bool b2)
        {
            return !b1 && b2;
        }

        public static bool Puzzle3(bool b1, bool b2)
        {
            return b1 || !b2;
        }

        public static bool Puzzle4(bool b1, bool b2)
        {
            return b1 && !b2;
        }

        public static bool Puzzle5(bool b1, bool b2)
        {
            return !b1 && !b2;
        }

        public static bool Puzzle6(bool b1, bool b2)
        {
            return !b1 || !b2;
        }

        public static bool Puzzle7(bool b1, bool b2)
        {
            return b2 == b1;
        }
    }
}
