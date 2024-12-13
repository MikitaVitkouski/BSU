namespace Bools.Tests
{
    [TestFixture]
    public class LogicalOperatorsTests
    {
        [TestCase(false, false, ExpectedResult = false)]
        [TestCase(true, false, ExpectedResult = false)]
        [TestCase(false, true, ExpectedResult = false)]
        [TestCase(true, true, ExpectedResult = true)]
        public static bool LogicalAnd1_ReturnBool(bool b1, bool b2)
        {
            return LogicalOperators.LogicalAnd1(b1, b2);
        }

        [TestCase(false, false, false, ExpectedResult = false)]
        [TestCase(true, false, false, ExpectedResult = false)]
        [TestCase(false, true, false, ExpectedResult = false)]
        [TestCase(false, false, true, ExpectedResult = false)]
        [TestCase(true, true, false, ExpectedResult = false)]
        [TestCase(true, false, true, ExpectedResult = false)]
        [TestCase(false, true, true, ExpectedResult = false)]
        [TestCase(true, true, true, ExpectedResult = true)]
        public static bool LogicalAnd2_ReturnBool(bool b1, bool b2, bool b3)
        {
            return LogicalOperators.LogicalAnd2(b1, b2, b3);
        }

        [TestCase(false, false, false, false, ExpectedResult = false)]
        [TestCase(true, false, false, false, ExpectedResult = false)]
        [TestCase(false, true, false, false, ExpectedResult = false)]
        [TestCase(false, false, true, false, ExpectedResult = false)]
        [TestCase(true, true, false, false, ExpectedResult = false)]
        [TestCase(true, false, true, false, ExpectedResult = false)]
        [TestCase(false, true, true, false, ExpectedResult = false)]
        [TestCase(true, true, true, false, ExpectedResult = false)]
        [TestCase(false, false, false, true, ExpectedResult = false)]
        [TestCase(true, false, false, true, ExpectedResult = false)]
        [TestCase(false, true, false, true, ExpectedResult = false)]
        [TestCase(false, false, true, true, ExpectedResult = false)]
        [TestCase(true, true, false, true, ExpectedResult = false)]
        [TestCase(true, false, true, true, ExpectedResult = false)]
        [TestCase(false, true, true, true, ExpectedResult = false)]
        [TestCase(true, true, true, true, ExpectedResult = true)]
        public static bool LogicalAnd3_ReturnBool(bool b1, bool b2, bool b3, bool b4)
        {
            return LogicalOperators.LogicalAnd3(b1, b2, b3, b4);
        }

        [TestCase(false, false, ExpectedResult = false)]
        [TestCase(true, false, ExpectedResult = true)]
        [TestCase(false, true, ExpectedResult = true)]
        [TestCase(true, true, ExpectedResult = true)]
        public static bool LogicalOr1_ReturnBool(bool b1, bool b2)
        {
            return LogicalOperators.LogicalOr1(b1, b2);
        }

        [TestCase(false, false, false, ExpectedResult = false)]
        [TestCase(true, false, false, ExpectedResult = true)]
        [TestCase(false, true, false, ExpectedResult = true)]
        [TestCase(false, false, true, ExpectedResult = true)]
        [TestCase(true, true, false, ExpectedResult = true)]
        [TestCase(true, false, true, ExpectedResult = true)]
        [TestCase(false, true, true, ExpectedResult = true)]
        [TestCase(true, true, true, ExpectedResult = true)]
        public static bool LogicalOr2_ReturnBool(bool b1, bool b2, bool b3)
        {
            return LogicalOperators.LogicalOr2(b1, b2, b3);
        }

        [TestCase(false, false, false, false, ExpectedResult = false)]
        [TestCase(true, false, false, false, ExpectedResult = true)]
        [TestCase(false, true, false, false, ExpectedResult = true)]
        [TestCase(false, false, true, false, ExpectedResult = true)]
        [TestCase(true, true, false, false, ExpectedResult = true)]
        [TestCase(true, false, true, false, ExpectedResult = true)]
        [TestCase(false, true, true, false, ExpectedResult = true)]
        [TestCase(true, true, true, false, ExpectedResult = true)]
        [TestCase(false, false, false, true, ExpectedResult = true)]
        [TestCase(true, false, false, true, ExpectedResult = true)]
        [TestCase(false, true, false, true, ExpectedResult = true)]
        [TestCase(false, false, true, true, ExpectedResult = true)]
        [TestCase(true, true, false, true, ExpectedResult = true)]
        [TestCase(true, false, true, true, ExpectedResult = true)]
        [TestCase(false, true, true, true, ExpectedResult = true)]
        [TestCase(true, true, true, true, ExpectedResult = true)]
        public static bool LogicalOr3_ReturnBool(bool b1, bool b2, bool b3, bool b4)
        {
            return LogicalOperators.LogicalOr3(b1, b2, b3, b4);
        }

        [TestCase(false, false, ExpectedResult = false)]
        [TestCase(true, false, ExpectedResult = true)]
        [TestCase(false, true, ExpectedResult = true)]
        [TestCase(true, true, ExpectedResult = false)]
        public static bool LogicalXor1_ReturnBool(bool b1, bool b2)
        {
            return LogicalOperators.LogicalXor1(b1, b2);
        }

        [TestCase(false, false, false, ExpectedResult = false)]
        [TestCase(true, false, false, ExpectedResult = true)]
        [TestCase(false, true, false, ExpectedResult = true)]
        [TestCase(false, false, true, ExpectedResult = true)]
        [TestCase(true, true, false, ExpectedResult = false)]
        [TestCase(true, false, true, ExpectedResult = false)]
        [TestCase(false, true, true, ExpectedResult = false)]
        [TestCase(true, true, true, ExpectedResult = true)]
        public static bool LogicalXor2_ReturnBool(bool b1, bool b2, bool b3)
        {
            return LogicalOperators.LogicalXor2(b1, b2, b3);
        }

        [TestCase(false, false, false, false, ExpectedResult = false)]
        [TestCase(true, false, false, false, ExpectedResult = true)]
        [TestCase(false, true, false, false, ExpectedResult = true)]
        [TestCase(false, false, true, false, ExpectedResult = true)]
        [TestCase(true, true, false, false, ExpectedResult = false)]
        [TestCase(true, false, true, false, ExpectedResult = false)]
        [TestCase(false, true, true, false, ExpectedResult = false)]
        [TestCase(true, true, true, false, ExpectedResult = true)]
        [TestCase(false, false, false, true, ExpectedResult = true)]
        [TestCase(true, false, false, true, ExpectedResult = false)]
        [TestCase(false, true, false, true, ExpectedResult = false)]
        [TestCase(false, false, true, true, ExpectedResult = false)]
        [TestCase(true, true, false, true, ExpectedResult = true)]
        [TestCase(true, false, true, true, ExpectedResult = true)]
        [TestCase(false, true, true, true, ExpectedResult = true)]
        [TestCase(true, true, true, true, ExpectedResult = false)]
        public static bool LogicalXor3_ReturnBool(bool b1, bool b2, bool b3, bool b4)
        {
            return LogicalOperators.LogicalXor3(b1, b2, b3, b4);
        }

        [TestCase(false, ExpectedResult = true)]
        [TestCase(true, ExpectedResult = false)]
        public static bool Negate_ReturnBool(bool b)
        {
            return LogicalOperators.Negate(b);
        }
    }
}
