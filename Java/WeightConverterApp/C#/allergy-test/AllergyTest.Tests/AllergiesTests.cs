using NUnit.Framework;

namespace AllergyTest.Tests
{
    [TestFixture]
    public class AllergiesTests
    {
        [Test]
        public void IsAllergicTo_ScoreIs1_AllergicToEggs()
        {
            var sut = new Allergies(1);
            Assert.True(sut.IsAllergicTo(Allergens.Eggs));
        }

        [Test]
        public void IsAllergicTo_ScoreIs5_AllergicToEggsAndShellfish()
        {
            var sut = new Allergies(5);
            Assert.Multiple(() =>
            {
                Assert.True(sut.IsAllergicTo(Allergens.Eggs));
                Assert.True(sut.IsAllergicTo(Allergens.Shellfish));
                Assert.False(sut.IsAllergicTo(Allergens.Strawberries));
                Assert.False(sut.IsAllergicTo(Allergens.Cats));
                Assert.False(sut.IsAllergicTo(Allergens.Chocolate));
                Assert.False(sut.IsAllergicTo(Allergens.Peanuts));
                Assert.False(sut.IsAllergicTo(Allergens.Tomatoes));
                Assert.False(sut.IsAllergicTo(Allergens.Pollen));
            });
        }

        [Test]
        public void IsAllergicTo_ScoreIs160_AllergicToChocolateAndCats()
        {
            var sut = new Allergies(160);
            Assert.Multiple(() =>
            {
                Assert.True(sut.IsAllergicTo(Allergens.Cats | Allergens.Chocolate));
                Assert.False(sut.IsAllergicTo(Allergens.Pollen | Allergens.Eggs | Allergens.Peanuts |
                                              Allergens.Shellfish | Allergens.Strawberries | Allergens.Tomatoes));
            });
        }

        [Test]
        public void IsAllergicTo_ScoreIs0_NotAllergic()
        {
            var sut = new Allergies(0);
            Assert.False(sut.IsAllergicTo(Allergens.Cats | Allergens.Chocolate | Allergens.Pollen | Allergens.Eggs |
                                          Allergens.Peanuts | Allergens.Shellfish | Allergens.Strawberries |
                                          Allergens.Tomatoes));
        }

        [Test]
        public void AllergensList_ScoreIs0_ReturnEmptyList()
        {
            var sut = new Allergies(0);
            Assert.IsEmpty(sut.AllergensList());
        }

        [Test]
        public void AllergensList_ScoreIs1_ReturnsOnlyEggs()
        {
            var sut = new Allergies(1);
            var expected = new[] { Allergens.Eggs };
            Assert.AreEqual(expected, sut.AllergensList());
        }

        [Test]
        public void AllergensList_ScoreIs2_ReturnsOnlyPeanuts()
        {
            var sut = new Allergies(2);
            var expected = new[] { Allergens.Peanuts };
            Assert.AreEqual(expected, sut.AllergensList());
        }

        [Test]
        public void AllergensList_ScoreIs8_ReturnsOnlyStrawberries()
        {
            var sut = new Allergies(8);
            var expected = new[] { Allergens.Strawberries };
            Assert.AreEqual(expected, sut.AllergensList());
        }

        [Test]
        public void AllergensList_ScoreIs3_ReturnsEggsAndPeanuts()
        {
            var sut = new Allergies(3);
            var expected = new[] { Allergens.Eggs, Allergens.Peanuts };
            Assert.AreEqual(expected, sut.AllergensList());
        }

        [Test]
        public void AllergensList_ScoreIs248_ReturnsLotsOfStuff()
        {
            var sut = new Allergies(248);
            var expected = new[]
            {
                Allergens.Strawberries, Allergens.Tomatoes, Allergens.Chocolate, Allergens.Pollen, Allergens.Cats,
            };
            Assert.AreEqual(expected, sut.AllergensList());
        }

        [Test]
        public void AllergensList_ScoreIs255_ReturnsEverything()
        {
            var sut = new Allergies(255);
            var expected = new[]
            {
                Allergens.Eggs, Allergens.Peanuts, Allergens.Shellfish, Allergens.Strawberries, Allergens.Tomatoes,
                Allergens.Chocolate, Allergens.Pollen, Allergens.Cats,
            };
            Assert.AreEqual(expected, sut.AllergensList());
        }

        [TestCase(256)]
        [TestCase(512)]
        [TestCase(1024)]
        [TestCase(2048)]
        public void AllergensList_AllergensNotListed_ReturnsEmptyArray(int score)
        {
            var sut = new Allergies(score);
            var expected = Array.Empty<Allergens>();
            Assert.AreEqual(expected, sut.AllergensList());
        }

        [Test]
        public void AllergensList_ScoreIs259_IgnoreNonAllergenScore()
        {
            var sut = new Allergies(259);
            var expected = new[] { Allergens.Eggs, Allergens.Peanuts };
            Assert.AreEqual(expected, sut.AllergensList());
        }

        [Test]
        public void AllergensList_ScoreIs509_IgnoreNonAllergenScore()
        {
            var sut = new Allergies(509);
            var expected = new[]
            {
                Allergens.Eggs, Allergens.Shellfish, Allergens.Strawberries, Allergens.Tomatoes,
                Allergens.Chocolate, Allergens.Pollen, Allergens.Cats,
            };
            Assert.AreEqual(expected, sut.AllergensList());
        }

        [TestCase(-100)]
        [TestCase(-4)]
        public void AllergiesCtor_ScoreIsNegative_ThrowArgumentException(int score)
        {
            Assert.Throws<ArgumentException>(() => new Allergies(score), $"Size of matrix '{score}' cannot be less than zero.");
        }
    }
}
