using NUnit.Framework;

namespace LouVuiDateCode.Tests
{
    [TestFixture]
    public sealed class DateCodeParserTests
    {
        [TestCase(null)]
        [TestCase("")]
        public void ParseEarly1980Code_DateCodeIsNullOrEmpty_ThrowsArgumentNullException(string dateCode)
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => DateCodeParser.ParseEarly1980Code(dateCode, out uint _, out uint _));
        }

        [TestCase("83")]
        [TestCase("83678")]
        [TestCase("800")]
        [TestCase("8013")]
        [TestCase("791")]
        [TestCase("901")]
        public void ParseEarly1980Code_DateCodeIsInvalid_ThrowsArgumentException(string dateCode)
        {
            // Assert
            Assert.Throws<ArgumentException>(() => DateCodeParser.ParseEarly1980Code(dateCode, out uint _, out uint _));
        }

        [TestCase("801", 1980u, 1u)]
        [TestCase("8010", 1980u, 10u)]
        [TestCase("812", 1981u, 2u)]
        [TestCase("836", 1983u, 6u)]
        [TestCase("8312", 1983u, 12u)]
        [TestCase("864", 1986u, 4u)]
        [TestCase("8611", 1986u, 11u)]
        public void ParseEarly1980Code_DateCodeIsValid_ReturnsResult(string dateCode, uint expectedProductionYear, uint expectedProductionMonth)
        {
            // Act
            DateCodeParser.ParseEarly1980Code(dateCode, out uint actualProductionYear, out uint actualProductionMonth);

            // Assert
            Assert.AreEqual(expectedProductionYear, actualProductionYear);
            Assert.AreEqual(expectedProductionMonth, actualProductionMonth);
        }

        [TestCase(null)]
        [TestCase("")]
        public void ParseLate1980Code_DateCodeIsNullOrEmpty_ThrowsArgumentNullException(string dateCode)
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => DateCodeParser.ParseLate1980Code(dateCode, out Country[] _, out string _, out uint _, out uint _));
        }

        [TestCase("87VX")]
        [TestCase("87451VX")]
        [TestCase("800VX")]
        [TestCase("8013VX")]
        [TestCase("791VX")]
        [TestCase("901VX")]
        [TestCase("801QQ")]
        public void ParseLate1980Code_DateCodeIsInvalid_ThrowsArgumentException(string dateCode)
        {
            // Assert
            Assert.Throws<ArgumentException>(() => DateCodeParser.ParseLate1980Code(dateCode, out Country[] _, out string _, out uint _, out uint _));
        }

        [TestCase("861TH", new Country[] { Country.France }, "TH", 1986u, 1u)]
        [TestCase("8710SD", new Country[] { Country.France, Country.USA }, "SD", 1987u, 10u)]
        [TestCase("874VX", new Country[] { Country.France }, "VX", 1987u, 4u)]
        [TestCase("889FC", new Country[] { Country.USA }, "FC", 1988u, 9u)]
        [TestCase("8912FL", new Country[] { Country.France, Country.USA }, "FL", 1989u, 12u)]
        public void ParseLate1980Code_DateCodeIsValid_ReturnsResult(string dateCode, Country[] expectedCountries, string expectedFactoryLocationCode, uint expectedProductionYear, uint expectedProductionMonth)
        {
            // Act
            DateCodeParser.ParseLate1980Code(dateCode, out Country[] actualCountries, out string actualFactoryLocationCode, out uint actualProductionYear, out uint actualProductionMonth);

            // Assert
            Assert.AreEqual(expectedFactoryLocationCode, actualFactoryLocationCode);
            Assert.AreEqual(expectedProductionYear, actualProductionYear);
            Assert.AreEqual(expectedProductionMonth, actualProductionMonth);
            Assert.AreEqual(expectedCountries.Length, actualCountries.Length);

            foreach (var expectedCountry in expectedCountries)
            {
                Assert.Contains(expectedCountry, actualCountries);
            }
        }

        [TestCase(null)]
        [TestCase("")]
        public void Parse1990Code_DateCodeIsNullOrEmpty_ThrowsArgumentNullException(string dateCode)
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => DateCodeParser.Parse1990Code(dateCode, out Country[] _, out string _, out uint _, out uint _));
        }

        [TestCase("R0017")]
        [TestCase("RI00170")]
        [TestCase("RI1930")]
        [TestCase("RI0819")]
        [TestCase("RI0017")]
        [TestCase("RI0900")]
        [TestCase("QQ0910")]
        public void Parse1990Code_DateCodeIsInvalid_ThrowsArgumentException(string dateCode)
        {
            // Assert
            Assert.Throws<ArgumentException>(() => DateCodeParser.Parse1990Code(dateCode, out Country[] _, out string _, out uint _, out uint _));
        }

        [TestCase("TH0910", new Country[] { Country.France }, "TH", 1990u, 1u)]
        [TestCase("FC0935", new Country[] { Country.USA }, "FC", 1995u, 3u)]
        [TestCase("SD1001", new Country[] { Country.France, Country.USA }, "SD", 2001u, 10u)]
        [TestCase("VI1025", new Country[] { Country.France }, "VI", 2005u, 12u)]
        public void Parse1990Code_DateCodeIsValid_ReturnsResult(string dateCode, Country[] expectedCountries, string expectedFactoryLocationCode, uint expectedProductionYear, uint expectedProductionMonth)
        {
            // Act
            DateCodeParser.Parse1990Code(dateCode, out Country[] actualCountries, out string actualFactoryLocationCode, out uint actualProductionYear, out uint actualProductionMonth);

            // Assert
            Assert.AreEqual(expectedFactoryLocationCode, actualFactoryLocationCode);
            Assert.AreEqual(expectedProductionYear, actualProductionYear);
            Assert.AreEqual(expectedProductionMonth, actualProductionMonth);
            Assert.AreEqual(expectedCountries.Length, actualCountries.Length);

            foreach (var expectedCountry in expectedCountries)
            {
                Assert.Contains(expectedCountry, actualCountries);
            }
        }

        [TestCase(null)]
        [TestCase("")]
        public void Parse2007Code_DateCodeIsNullOrEmpty_ThrowsArgumentNullException(string dateCode)
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => DateCodeParser.Parse2007Code(dateCode, out Country[] _, out string _, out uint _, out uint _));
        }

        [TestCase("R0017")]
        [TestCase("RI00170")]
        [TestCase("RI5137")]
        [TestCase("RI5138")]
        [TestCase("RI5139")]
        [TestCase("RI0016")]
        [TestCase("RI0007")]
        [TestCase("QQ0017")]
        public void Parse2007Code_DateCodeIsInvalid_ThrowsArgumentException(string dateCode)
        {
            // Assert
            Assert.Throws<ArgumentException>(() => DateCodeParser.Parse2007Code(dateCode, out Country[] _, out string _, out uint _, out uint _));
        }

        [TestCase("RI0017", new Country[] { Country.France }, "RI", 2007u, 1u)]
        [TestCase("RC1100", new Country[] { Country.Italy }, "RC", 2010u, 10u)]
        [TestCase("SD2057", new Country[] { Country.France, Country.USA }, "SD", 2007u, 25u)]
        [TestCase("OL2105", new Country[] { Country.Germany }, "OL", 2015u, 20u)]
        [TestCase("GI5230", new Country[] { Country.Spain }, "GI", 2020u, 53u)]
        public void Parse2007Code_DateCodeIsValid_ReturnsResult(string dateCode, Country[] expectedCountries, string expectedFactoryLocationCode, uint expectedProductionYear, uint expectedProductionWeek)
        {
            // Act
            DateCodeParser.Parse2007Code(dateCode, out Country[] actualCountries, out string actualFactoryLocationCode, out uint actualProductionYear, out uint actualProductionWeek);

            // Assert
            Assert.AreEqual(expectedFactoryLocationCode, actualFactoryLocationCode);
            Assert.AreEqual(expectedProductionYear, actualProductionYear);
            Assert.AreEqual(expectedProductionWeek, actualProductionWeek);
            Assert.AreEqual(expectedCountries.Length, actualCountries.Length);

            foreach (var expectedCountry in expectedCountries)
            {
                Assert.Contains(expectedCountry, actualCountries);
            }
        }
    }
}
