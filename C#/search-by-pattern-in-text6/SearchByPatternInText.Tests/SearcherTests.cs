using NUnit.Framework;

namespace SearchByPatternInText.Tests
{
    [TestFixture]
    public class SearcherTests
    {
        [TestCase("aababAba baabba Aba", "aba", false, ExpectedResult = new[] { 2, 6, 17 })]
        [TestCase("aabababa baabba aba", "aba", true, ExpectedResult = new[] { 2, 4, 6, 17 })]
        [TestCase(
            "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
            "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
            "when an unknown printer took a galley of type and scrambled it to make a type specimen book." +
            " It has survived not only five centuries, but also the leap into electronic typesetting, " +
            "remaining essentially unchanged. It was popularised in the 1960s with the release of " +
            "Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing " +
            "software like Aldus PageMaker including versions of Lorem Ipsum.",
            "Lorem",
            false,
            ExpectedResult = new[] { 1, 76, 447, 563 })]
        [TestCase(
            "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
            "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
            "when an unknown printer took a galley of type and scrambled it to make a type specimen book." +
            " It has survived not only five centuries, but also the leap into electronic typesetting, " +
            "remaining essentially unchanged. It was popularised in the 1960s with the release of " +
            "Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing " +
            "software like Aldus PageMaker including versions of Lorem Ipsum.",
            "int",
            false,
            ExpectedResult = new[] { 43, 172, 306 })]
        [TestCase(
            "   It was popularised in the 1960s with the release of " +
            "Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing " +
            "software like Aldus PageMaker including versions of Lorem Ipsum.",
            "it",
            false,
            ExpectedResult = new[] { 4, 37, 124 })]
        [TestCase(
            "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
            "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
            "when an unknown printer took a galley of type and scrambled it to make a type specimen book." +
            " It has survived not only five centuries, but also the leap into electronic typesetting, " +
            "remaininig essentially unchanged. It was popularised in the 1960s with the release of " +
            "Letraset sheets containinig Lorem Ipsum passages, and more recently with desktop publishing " +
            "software like Aldus PageMaker including versions of Lorem Ipsum.",
            "ini",
            true,
            ExpectedResult = new[] { 339, 341, 442, 444 })]
        public int[] SearchPatternString_Tests(string text, string pattern, bool behind)
        {
            return text.SearchPatternString(pattern, behind);
        }

        [Test]
        public void SearchPatternString_TextIsNull_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Searcher.SearchPatternString(null, "pattern", false), "Source string cannot be null.");
        }

        [Test]
        public void SearchPatternString_PatternIsNull_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => "source text".SearchPatternString(null, false), "Pattern string cannot be null.");
        }
    }
}
