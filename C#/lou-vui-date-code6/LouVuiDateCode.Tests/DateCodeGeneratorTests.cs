using NUnit.Framework;

namespace LouVuiDateCode.Tests
{
    [TestFixture]
    public sealed class DateCodeGeneratorTests
    {
        private static readonly object[][] GenerateEarly1980CodeOutOfRangeData =
        {
            new object[] { new DateTime(1979, 12, 1), },
            new object[] { new DateTime(1990, 1, 1), },
        };

        private static readonly object[][] GenerateEarly1980CodeData =
        {
            new object[] { new DateTime(1980, 1, 1), "801" },
            new object[] { new DateTime(1980, 12, 1), "8012" },
            new object[] { new DateTime(1983, 6, 1), "836" },
            new object[] { new DateTime(1986, 1, 1), "861" },
            new object[] { new DateTime(1986, 12, 1), "8612" },
        };

        private static readonly object[][] GenerateLate1980CodeOutOfRangeData =
        {
            new object[] { "bc", new DateTime(1979, 12, 1), },
            new object[] { "vx", new DateTime(1990, 1, 1), },
        };

        private static readonly object[][] GenerateLate1980CodeData =
        {
            new object[] { "bc", new DateTime(1987, 1, 1), "871BC" },
            new object[] { "lp", new DateTime(1987, 12, 1), "8712LP" },
            new object[] { "Vx", new DateTime(1987, 4, 1), "874VX" },
            new object[] { "FC", new DateTime(1989, 2, 1), "892FC" },
            new object[] { "dI", new DateTime(1989, 12, 1), "8912DI" },
        };

        private static readonly object[][] Generate1990CodeOutOfRangeData =
        {
            new object[] { "bc", new DateTime(1989, 12, 1), },
            new object[] { "bc", new DateTime(2007, 1, 1), },
        };

        private static readonly object[][] Generate1990CodeData =
        {
            new object[] { "th", new DateTime(1990, 1, 1), "TH0910" },
            new object[] { "mb", new DateTime(1995, 3, 1), "MB0935" },
            new object[] { "Ct", new DateTime(2001, 10, 1), "CT1001" },
            new object[] { "VI", new DateTime(2005, 12, 1), "VI1025" },
            new object[] { "rC", new DateTime(2006, 7, 1), "RC0076" },
        };

        private static readonly object[][] Generate2007CodeOutOfRangeData =
        {
            new object[] { "bo", new DateTime(2006, 12, 1), },
        };

        private static readonly object[][] Generate2007CodeData =
        {
            new object[] { "th", new DateTime(2007, 1, 1), "TH0017" },
            new object[] { "th", new DateTime(2007, 1, 7), "TH0017" },
            new object[] { "sd", new DateTime(2007, 6, 18), "SD2057" },
            new object[] { "sd", new DateTime(2007, 6, 24), "SD2057" },
            new object[] { "et", new DateTime(2010, 10, 4), "ET4100" },
            new object[] { "et", new DateTime(2010, 10, 10), "ET4100" },
            new object[] { "vi", new DateTime(2015, 12, 21), "VI5125" },
            new object[] { "mb", new DateTime(2013, 11, 25), "MB4183" },
            new object[] { "rc", new DateTime(2020, 12, 6), "RC4290" },
            new object[] { "rc", new DateTime(2020, 12, 7), "RC5200" },
            new object[] { "rc", new DateTime(2015, 1, 1), "RC0115" },
            new object[] { "rc", new DateTime(2015, 1, 4), "RC0115" },
            new object[] { "rc", new DateTime(2015, 1, 5), "RC0125" },
            new object[] { "rc", new DateTime(2016, 1, 1), "RC5135" },
            new object[] { "rc", new DateTime(2016, 1, 3), "RC5135" },
            new object[] { "rc", new DateTime(2016, 1, 4), "RC0116" },
            new object[] { "rc", new DateTime(2017, 1, 1), "RC5126" },
            new object[] { "rc", new DateTime(2017, 1, 2), "RC0117" },
            new object[] { "rc", new DateTime(2020, 12, 27), "RC5220" },
            new object[] { "rc", new DateTime(2020, 12, 28), "RC5230" },
            new object[] { "rc", new DateTime(2020, 12, 31), "RC5230" },
        };

        [TestCase(1979u, 1u)]
        [TestCase(1990u, 1u)]
        [TestCase(1980u, 13u)]
        public void GenerateEarly1980Code_ParameterIsOutOfRange_ThrowsArgumentOutOfRangeException(uint manufacturingYear, uint manufacturingMonth)
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DateCodeGenerator.GenerateEarly1980Code(manufacturingYear, manufacturingMonth));
        }

        [TestCase(1980u, 1u, ExpectedResult = "801")]
        [TestCase(1980u, 12u, ExpectedResult = "8012")]
        [TestCase(1983u, 6u, ExpectedResult = "836")]
        [TestCase(1986u, 1u, ExpectedResult = "861")]
        [TestCase(1986u, 12u, ExpectedResult = "8612")]
        public string GenerateEarly1980Code_ParametersAreValid_ReturnsResult(uint manufacturingYear, uint manufacturingMonth)
        {
            // Act & Assert
            return DateCodeGenerator.GenerateEarly1980Code(manufacturingYear, manufacturingMonth);
        }

        [TestCaseSource(nameof(GenerateEarly1980CodeOutOfRangeData))]
        public void GenerateEarly1980Code_DateTime_ParameterIsOutOfRange_ThrowsArgumentOutOfRangeException(object[] data)
        {
            // Arrange
            DateTime dateTime = (DateTime)data[0];

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DateCodeGenerator.GenerateEarly1980Code(dateTime));
        }

        [TestCaseSource(nameof(GenerateEarly1980CodeData))]
        public void GenerateEarly1980Code_DateTime_ParametersAreValid_ReturnsResult(object[] data)
        {
            // Arrange
            DateTime dateTime = (DateTime)data[0];
            string expectedResult = (string)data[1];

            // Act
            string actualResult = DateCodeGenerator.GenerateEarly1980Code(dateTime);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(1979u, 1u)]
        [TestCase(1990u, 1u)]
        [TestCase(1980u, 13u)]
        public void GenerateLate1980Code_ProductionYearOrMonthIsOutOfRange_ThrowsArgumentOutOfRangeException(uint manufacturingYear, uint manufacturingMonth)
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DateCodeGenerator.GenerateLate1980Code("BC", manufacturingYear, manufacturingMonth));
        }

        [TestCase(null)]
        [TestCase("")]
        public void GenerateLate1980Code_FactoryLocationCodeIsNullOrEmpty_ThrowsArgumentNullException(string factoryLocationCode)
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => DateCodeGenerator.GenerateLate1980Code(factoryLocationCode, 1986, 1));
        }

        [TestCase("79")]
        [TestCase("b9")]
        [TestCase("7b")]
        [TestCase("abc")]
        [TestCase("b")]
        public void GenerateLate1980Code_ParameterIsOutOfRange_ThrowsArgumentException(string factoryLocationCode)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => DateCodeGenerator.GenerateLate1980Code(factoryLocationCode, 1986, 1));
        }

        [TestCase("bc", 1987u, 1u, ExpectedResult = "871BC")]
        [TestCase("vx", 1987u, 4u, ExpectedResult = "874VX")]
        [TestCase("lw", 1989u, 9u, ExpectedResult = "899LW")]
        public string GenerateLate1980Code_ParametersAreValid_ReturnsResult(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            // Act
            return DateCodeGenerator.GenerateLate1980Code(factoryLocationCode, manufacturingYear, manufacturingMonth);
        }

        [TestCaseSource(nameof(GenerateLate1980CodeOutOfRangeData))]
        public void GenerateLate1980Code_DateTime_ParameterIsOutOfRange_ThrowsArgumentOutOfRangeException(object[] data)
        {
            // Arrange
            string factoryLocationCode = (string)data[0];
            DateTime dateTime = (DateTime)data[1];

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DateCodeGenerator.GenerateLate1980Code(factoryLocationCode, dateTime));
        }

        [TestCase(null)]
        [TestCase("")]
        public void GenerateLate1980Code_DateTime_FactoryLocationCodeIsNullOrEmpty_ThrowsArgumentNullException(string factoryLocationCode)
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => DateCodeGenerator.GenerateLate1980Code(factoryLocationCode, new DateTime(1986, 1, 1)));
        }

        [TestCase("79")]
        [TestCase("b9")]
        [TestCase("7c")]
        [TestCase("abc")]
        [TestCase("b")]
        public void GenerateLate1980Code_DateTime_ParameterIsOutOfRange_ThrowsArgumentException(string factoryLocationCode)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => DateCodeGenerator.GenerateLate1980Code(factoryLocationCode, new DateTime(1986, 1, 1)));
        }

        [TestCaseSource(nameof(GenerateLate1980CodeData))]
        public void GenerateLate1980Code_DateTime_ParametersAreValid_ReturnsResult(object[] data)
        {
            // Arrange
            string factoryLocationCode = (string)data[0];
            DateTime dateTime = (DateTime)data[1];
            string expectedResult = (string)data[2];

            // Act
            string actualResult = DateCodeGenerator.GenerateLate1980Code(factoryLocationCode, dateTime);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(1989u, 1u)]
        [TestCase(2007u, 1u)]
        [TestCase(1990u, 13u)]
        public void Generate1990Code_ProductionYearOrMonthIsOutOfRange_ThrowsArgumentOutOfRangeException(uint manufacturingYear, uint manufacturingMonth)
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DateCodeGenerator.Generate1990Code("BC", manufacturingYear, manufacturingMonth));
        }

        [TestCase(null)]
        [TestCase("")]
        public void Generate1990Code_FactoryLocationCodeIsNullOrEmpty_ThrowsArgumentNullException(string factoryLocationCode)
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => DateCodeGenerator.Generate1990Code(factoryLocationCode, 1990, 1));
        }

        [TestCase("79")]
        [TestCase("b9")]
        [TestCase("7c")]
        [TestCase("abc")]
        [TestCase("b")]
        public void Generate1990Code_ParameterIsOutOfRange_ThrowsArgumentException(string factoryLocationCode)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => DateCodeGenerator.Generate1990Code(factoryLocationCode, 1990, 1));
        }

        [TestCase("th", 1990u, 1u, ExpectedResult = "TH0910")]
        [TestCase("mb", 1995u, 3u, ExpectedResult = "MB0935")]
        [TestCase("ct", 2001u, 10u, ExpectedResult = "CT1001")]
        [TestCase("vi", 2005u, 12u, ExpectedResult = "VI1025")]
        public string Generate1990Code_ParametersAreValid_ReturnsResult(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            // Act
            return DateCodeGenerator.Generate1990Code(factoryLocationCode, manufacturingYear, manufacturingMonth);
        }

        [TestCaseSource(nameof(Generate1990CodeOutOfRangeData))]
        public void Generate1990Code_DateTime_ParameterIsOutOfRange_ThrowsArgumentOutOfRangeException(object[] data)
        {
            // Arrange
            string factoryLocationCode = (string)data[0];
            DateTime dateTime = (DateTime)data[1];

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DateCodeGenerator.Generate1990Code(factoryLocationCode, dateTime));
        }

        [TestCase(null)]
        [TestCase("")]
        public void Generate1990Code_DateTime_FactoryLocationCodeIsNullOrEmpty_ThrowsArgumentNullException(string factoryLocationCode)
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => DateCodeGenerator.Generate1990Code(factoryLocationCode, new DateTime(1990, 1, 1)));
        }

        [TestCase("79")]
        [TestCase("b9")]
        [TestCase("7c")]
        [TestCase("abc")]
        [TestCase("b")]
        public void Generate1990Code_DateTime_ParameterIsOutOfRange_ThrowsArgumentException(string factoryLocationCode)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => DateCodeGenerator.Generate1990Code(factoryLocationCode, 1990, 1));
        }

        [TestCaseSource(nameof(Generate1990CodeData))]
        public void Generate1990Code_DateTime_ParametersAreValid_ReturnsResult(object[] data)
        {
            // Arrange
            string factoryLocationCode = (string)data[0];
            DateTime dateTime = (DateTime)data[1];
            string expectedResult = (string)data[2];

            // Act
            string actualResult = DateCodeGenerator.Generate1990Code(factoryLocationCode, dateTime);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(2006u, 1u)]
        [TestCase(2007u, 0u)]
        [TestCase(2007u, 54u)]
        [TestCase(2017u, 53u)]
        [TestCase(2018u, 53u)]
        [TestCase(2019u, 53u)]
        public void Generate2007Code_ProductionYearOrWeekIsOutOfRange_ThrowsArgumentOutOfRangeException(uint manufacturingYear, uint productionWeek)
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DateCodeGenerator.Generate2007Code("BC", manufacturingYear, productionWeek));
        }

        [TestCase(null)]
        [TestCase("")]
        public void Generate2007Code_FactoryLocationCodeIsNullOrEmpty_ThrowsArgumentNullException(string factoryLocationCode)
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => DateCodeGenerator.Generate2007Code(factoryLocationCode, 2007, 1));
        }

        [TestCase("79")]
        [TestCase("b9")]
        [TestCase("7c")]
        [TestCase("abc")]
        [TestCase("b")]
        public void Generate2007Code_ParameterIsOutOfRange_ThrowsArgumentException(string factoryLocationCode)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => DateCodeGenerator.Generate2007Code(factoryLocationCode, 2007, 1));
        }

        [TestCase("ri", 2007u, 1u, ExpectedResult = "RI0017")]
        [TestCase("rc", 2010u, 10u, ExpectedResult = "RC1100")]
        [TestCase("sd", 2007u, 25u, ExpectedResult = "SD2057")]
        [TestCase("ol", 2015u, 20u, ExpectedResult = "OL2105")]
        [TestCase("gi", 2020u, 53u, ExpectedResult = "GI5230")]
        [TestCase("gi", 2015u, 53u, ExpectedResult = "GI5135")]
        public string Generate2007Code_ParametersAreValid_ReturnsResult(string factoryLocationCode, uint manufacturingYear, uint productionWeek)
        {
            // Act
            return DateCodeGenerator.Generate2007Code(factoryLocationCode, manufacturingYear, productionWeek);
        }

        [TestCaseSource(nameof(Generate2007CodeOutOfRangeData))]
        public void Generate2007Code_DateTime_ParameterIsOutOfRange_ThrowsArgumentOutOfRangeException(object[] data)
        {
            // Arrange
            string factoryLocationCode = (string)data[0];
            DateTime dateTime = (DateTime)data[1];

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DateCodeGenerator.Generate2007Code(factoryLocationCode, dateTime));
        }

        [TestCase(null)]
        [TestCase("")]
        public void Generate2007Code_DateTime_FactoryLocationCodeIsNullOrEmpty_ThrowsArgumentNullException(string factoryLocationCode)
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => DateCodeGenerator.Generate2007Code(factoryLocationCode, new DateTime(2007, 1, 1)));
        }

        [TestCase("79")]
        [TestCase("b9")]
        [TestCase("7c")]
        [TestCase("abc")]
        [TestCase("b")]
        public void Generate2007Code_DateTime_ParameterIsOutOfRange_ThrowsArgumentException(string factoryLocationCode)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => DateCodeGenerator.Generate2007Code(factoryLocationCode, new DateTime(2007, 1, 1)));
        }

        [TestCaseSource(nameof(Generate2007CodeData))]
        public void Generate2007Code_DateTime_ParametersAreValid_ReturnsResult(object[] data)
        {
            // Arrange
            string factoryLocationCode = (string)data[0];
            DateTime dateTime = (DateTime)data[1];
            string expectedResult = (string)data[2];

            // Act
            string actualResult = DateCodeGenerator.Generate2007Code(factoryLocationCode, dateTime);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
