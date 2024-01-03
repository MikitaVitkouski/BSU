using NUnit.Framework;
using static LanguageGame.Translator;

namespace LanguageGame.Tests
{
    public class TranslatorTests
    {
        [TestCase("apple", ExpectedResult = "appleyay")]
        [TestCase("ear", ExpectedResult = "earyay")]
        [TestCase("Igloo", ExpectedResult = "Iglooyay")]
        [TestCase("object", ExpectedResult = "objectyay")]
        [TestCase("under", ExpectedResult = "underyay")]
        [TestCase("Eat", ExpectedResult = "Eatyay")]
        [TestCase("Omelet", ExpectedResult = "Omeletyay")]
        [TestCase("are", ExpectedResult = "areyay")]
        [TestCase("egg", ExpectedResult = "eggyay")]
        [TestCase("explain", ExpectedResult = "explainyay")]
        [TestCase("always", ExpectedResult = "alwaysyay")]
        [TestCase("ends", ExpectedResult = "endsyay")]
        [TestCase("I", ExpectedResult = "Iyay")]
        public string TranslateToPigLatin_WordBeginsWithAVowelSound(string phrase)
        {
            return TranslateToPigLatin(phrase);
        }

        [TestCase("Koala", ExpectedResult = "Oalakay")]
        [TestCase("xenon", ExpectedResult = "enonxay")]
        [TestCase("Smile", ExpectedResult = "Ilesmay")]
        [TestCase("string", ExpectedResult = "ingstray")]
        [TestCase("stupid", ExpectedResult = "upidstay")]
        [TestCase("Glove", ExpectedResult = "Oveglay")]
        [TestCase("Trash", ExpectedResult = "Ashtray")]
        [TestCase("floor", ExpectedResult = "oorflay")]
        [TestCase("store", ExpectedResult = "orestay")]
        public string TranslateToPigLatin_WordBeginsWithConsonantSoundsInWord(string phrase)
        {
            return TranslateToPigLatin(phrase);
        }

        [TestCase("Quick - fast - run!", ExpectedResult = "Uickqay - astfay - unray!")]
        [TestCase(
            "   This is an example of Hog Latin.    As you can see, it’s silly, but lots of fun for children.",
            ExpectedResult = "   Isthay isyay anyay exampleyay ofyay Oghay Atinlay.    Asyay ouyay ancay eesay, it’syay illysay, utbay otslay ofyay unfay orfay ildrenchay.")]
        [TestCase(
            "Pig Latin is not really a proper language, it is a pseudo language spoken by English-speaking people, and adored by children.",
            ExpectedResult = "Igpay Atinlay isyay otnay eallyray ayay operpray anguagelay, ityay isyay ayay eudopsay anguagelay okenspay byay Englishyay-eakingspay eoplepay, andyay adoredyay byay ildrenchay.")]
        public string TranslateToPigLatin_WithAWholePhrase(string phrase)
        {
            return TranslateToPigLatin(phrase);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void TranslateToPigLatin_StringIsNullOrEmptyOrWhiteSpace_ThrowArgumentException(string phrase)
        {
            Assert.Throws<ArgumentException>(() => TranslateToPigLatin(phrase), "Source string cannot be null or empty or whitespace.");
        }
    }
}
