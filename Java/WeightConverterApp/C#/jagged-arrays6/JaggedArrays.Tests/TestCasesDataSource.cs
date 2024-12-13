using NUnit.Framework;

namespace JaggedArrays.Tests
{
    internal static class TestCasesDataSource
    {
        public static IEnumerable<TestCaseData> TestCasesForSumByAscending
        {
            get
            {
                yield return new TestCaseData(
                    new[] { new[] { 2, -40, 55 }, new[] { 1 }, new[] { 1, 1 }, null, null },
                    new[] { null, null, new[] { 1 }, new[] { 1, 1 }, new[] { 2, -40, 55 } });
                yield return new TestCaseData(
                    new[] { new[] { 1, 2, 3 }, null, new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 1, 3 }, new[] { 1 } },
                    new[] { null, new[] { 1 }, new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 3 }, new[] { 1, 2, 1, 3 } });
                yield return new TestCaseData(
                    new[] { new[] { 1, 2, 3 }, null, new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 1, 3 }, new[] { 1 }, new[] { 10, 10, 1, 90, 1 } },
                    new[] { null, new[] { 1 }, new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 3 }, new[] { 1, 2, 1, 3 }, new[] { 10, 10, 1, 90, 1 } });
                yield return new TestCaseData(
                    new[] { new[] { 1, 2, 3 }, new[] { 10987, 2, 3 }, null, new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 1, 3 }, new[] { 1 }, new[] { 10, 10, 1, 90, 1 }, null },
                    new[] { null, null, new[] { 1 }, new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 3 }, new[] { 1, 2, 1, 3 }, new[] { 10, 10, 1, 90, 1 }, new[] { 10987, 2, 3 } });
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForSumByDescending
        {
            get
            {
                yield return new TestCaseData(
                    new[] { new[] { 2, -40, 55 }, new[] { 1 }, new[] { 1, 1 }, null, null },
                    new[] { new[] { 2, -40, 55 }, new[] { 1, 1 }, new[] { 1 }, null, null });
                yield return new TestCaseData(
                    new[] { new[] { 1, 2, 3 }, null, new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 1, 3 }, new[] { 1 } },
                    new[] { new[] { 1, 2, 1, 3 }, new[] { 1, 2, 3 }, new[] { 1, 1, 1, 1, 1 }, new[] { 1 }, null });
                yield return new TestCaseData(
                    new[] { new[] { 1, 2, 3 }, null, new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 1, 3 }, new[] { 1 }, new[] { 10, 10, 1, 90, 1 } },
                    new[] { new[] { 10, 10, 1, 90, 1 }, new[] { 1, 2, 1, 3 }, new[] { 1, 2, 3 }, new[] { 1, 1, 1, 1, 1 }, new[] { 1 }, null });
                yield return new TestCaseData(
                    new[] { new[] { 1, 2, 3 }, new[] { 10987, 2, 3 }, null, new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 1, 3 }, new[] { 1 }, new[] { 10, 10, 1, 90, 1 }, null },
                    new[] { new[] { 10987, 2, 3 }, new[] { 10, 10, 1, 90, 1 }, new[] { 1, 2, 1, 3 }, new[] { 1, 2, 3 }, new[] { 1, 1, 1, 1, 1 }, new[] { 1 }, null, null });
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForMaxAscending
        {
            get
            {
                yield return new TestCaseData(
                    new[] { null, null, new[] { 2, -40, 55 }, new[] { 12 }, new[] { 1, 1 }, null, null, new[] { 0 } },
                    new[] { null, null, null, null, new[] { 0 }, new[] { 1, 1 }, new[] { 12 }, new[] { 2, -40, 55 } });
                yield return new TestCaseData(
                    new[] { new[] { 10, 2, 3 }, null, new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 1, 3 }, new[] { 0 } },
                    new[] { null, new[] { 0 }, new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 1, 3 }, new[] { 10, 2, 3 } });
                yield return new TestCaseData(
                    new[] { new[] { 10, 10, 1, 100, 1 }, new[] { 1, 2, 21, 3 }, new[] { 1, 2, 3 }, new[] { 10, 1, 1, 1, 1 }, new[] { 90 }, null },
                    new[] { null, new[] { 1, 2, 3 }, new[] { 10, 1, 1, 1, 1 }, new[] { 1, 2, 21, 3 }, new[] { 90 }, new[] { 10, 10, 1, 100, 1 } });
                yield return new TestCaseData(
                    new[] { new[] { 1, 2, 3 }, new[] { 10987, 2, 3 }, null, new[] { 1, 1, 101, 1, 1 }, new[] { 609, 2, 1, 3 }, new[] { 0 }, new[] { 10, 10, 1, 90, 1 }, null },
                    new[] { null, null, new[] { 0 }, new[] { 1, 2, 3 }, new[] { 10, 10, 1, 90, 1 }, new[] { 1, 1, 101, 1, 1 }, new[] { 609, 2, 1, 3 }, new[] { 10987, 2, 3 } });
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForMaxDescending
        {
            get
            {
                yield return new TestCaseData(
                    new[] { new[] { 2, -40, 55 }, new[] { 12 }, new[] { 1, 1 }, null, null, new[] { 0 } },
                    new[] { new[] { 2, -40, 55 }, new[] { 12 }, new[] { 1, 1 }, new[] { 0 }, null, null });
                yield return new TestCaseData(
                    new[] { new[] { 1, 2, 3 }, null, new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 9, 3 }, new[] { 1 } },
                    new[] { new[] { 1, 2, 9, 3 }, new[] { 1, 2, 3 }, new[] { 1, 1, 1, 1, 1 }, new[] { 1 }, null });
                yield return new TestCaseData(
                    new[] { new[] { 1, 2, 3 }, null, new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 21, 3 }, new[] { 0 }, new[] { 10, 10, 1, 90, 1 } },
                    new[] { new[] { 10, 10, 1, 90, 1 }, new[] { 1, 2, 21, 3 }, new[] { 1, 2, 3 }, new[] { 1, 1, 1, 1, 1 }, new[] { 0 }, null });
                yield return new TestCaseData(
                    new[] { new[] { 1, 2, 3 }, new[] { 10987, 2, 3 }, null, new[] { 1, 1, 1, 1, 1 }, new[] { 6, 2, 1, 3 }, new[] { 0 }, new[] { 10, 10, 1, 90, 1 }, null },
                    new[] { new[] { 10987, 2, 3 }, new[] { 10, 10, 1, 90, 1 }, new[] { 6, 2, 1, 3 }, new[] { 1, 2, 3 }, new[] { 1, 1, 1, 1, 1 }, new[] { 0 }, null, null });
            }
        }
    }
}
