using NUnit.Framework;

namespace LouVuiDateCode.Tests
{
    [TestFixture]
    public sealed class CountryParserTests
    {
        [TestCase(null)]
        [TestCase("")]
        public void GetCountry_FactoryLocationCodeIsNullOrEmpty_ThrowsArgumentNullException(string factoryLocationCode)
        {
            Assert.Throws<ArgumentNullException>(() => CountryParser.GetCountry(factoryLocationCode));
        }

        [TestCase("A0", new Country[] { Country.France })]
        [TestCase("A1", new Country[] { Country.France })]
        [TestCase("A2", new Country[] { Country.France })]
        [TestCase("AA", new Country[] { Country.France })]
        [TestCase("AH", new Country[] { Country.France })]
        [TestCase("AN", new Country[] { Country.France })]
        [TestCase("AR", new Country[] { Country.France })]
        [TestCase("AS", new Country[] { Country.France })]
        [TestCase("BA", new Country[] { Country.France })]
        [TestCase("BJ", new Country[] { Country.France })]
        [TestCase("BU", new Country[] { Country.France })]
        [TestCase("DR", new Country[] { Country.France })]
        [TestCase("DU", new Country[] { Country.France })]
        [TestCase("DR", new Country[] { Country.France })]
        [TestCase("DT", new Country[] { Country.France })]
        [TestCase("CO", new Country[] { Country.France })]
        [TestCase("CT", new Country[] { Country.France })]
        [TestCase("CX", new Country[] { Country.France })]
        [TestCase("ET", new Country[] { Country.France })]
        [TestCase("FL", new Country[] { Country.France, Country.USA })]
        [TestCase("LW", new Country[] { Country.France, Country.Spain })]
        [TestCase("MB", new Country[] { Country.France })]
        [TestCase("MI", new Country[] { Country.France })]
        [TestCase("NO", new Country[] { Country.France })]
        [TestCase("RA", new Country[] { Country.France })]
        [TestCase("RI", new Country[] { Country.France })]
        [TestCase("SD", new Country[] { Country.France, Country.USA })]
        [TestCase("SF", new Country[] { Country.France })]
        [TestCase("SL", new Country[] { Country.France })]
        [TestCase("SN", new Country[] { Country.France })]
        [TestCase("SP", new Country[] { Country.France })]
        [TestCase("SR", new Country[] { Country.France })]
        [TestCase("TJ", new Country[] { Country.France })]
        [TestCase("TH", new Country[] { Country.France })]
        [TestCase("TR", new Country[] { Country.France })]
        [TestCase("TS", new Country[] { Country.France })]
        [TestCase("VI", new Country[] { Country.France })]
        [TestCase("VX", new Country[] { Country.France })]
        [TestCase("LP", new Country[] { Country.Germany })]
        [TestCase("OL", new Country[] { Country.Germany })]
        [TestCase("BC", new Country[] { Country.Italy })]
        [TestCase("BO", new Country[] { Country.Italy })]
        [TestCase("CE", new Country[] { Country.Italy })]
        [TestCase("FO", new Country[] { Country.Italy })]
        [TestCase("MA", new Country[] { Country.Italy })]
        [TestCase("OB", new Country[] { Country.Italy })]
        [TestCase("RC", new Country[] { Country.Italy })]
        [TestCase("RE", new Country[] { Country.Italy })]
        [TestCase("SA", new Country[] { Country.Italy })]
        [TestCase("TD", new Country[] { Country.Italy })]
        [TestCase("CA", new Country[] { Country.Spain })]
        [TestCase("LO", new Country[] { Country.Spain })]
        [TestCase("LB", new Country[] { Country.Spain })]
        [TestCase("LM", new Country[] { Country.Spain })]
        [TestCase("GI", new Country[] { Country.Spain })]
        [TestCase("DI", new Country[] { Country.Switzerland })]
        [TestCase("FA", new Country[] { Country.Switzerland })]
        [TestCase("FC", new Country[] { Country.USA })]
        [TestCase("FH", new Country[] { Country.USA })]
        [TestCase("LA", new Country[] { Country.USA })]
        [TestCase("OS", new Country[] { Country.USA })]
        public void GetCountry_FactoryLocationCodeIsValid_ReturnsResult(string factoryLocationCode, Country[] expectedCountries)
        {
            // Act
            Country[] actualCountries = CountryParser.GetCountry(factoryLocationCode);

            // Assert
            foreach (var expectedCountry in expectedCountries)
            {
                Assert.Contains(expectedCountry, actualCountries);
            }
        }
    }
}
