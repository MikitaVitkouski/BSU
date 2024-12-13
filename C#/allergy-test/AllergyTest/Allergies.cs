using System;

namespace AllergyTest
{
    /// <summary>
    /// Encapsulate the information about allergy test score and its analysis.
    /// </summary>
    public class Allergies
    {
        private readonly int score;

        public Allergies(int score)
        {
            if (score < 0)
            {
                throw new ArgumentException("Score cannot be less than zero.", nameof(score));
            }

            this.score = score;
        }

        public bool IsAllergicTo(Allergens allergens)
        {
            return ((int)allergens & this.score) != 0;
        }

        public Allergens[] AllergensList()
        {
            var allergies = new List<Allergens>();

            foreach (Allergens allergen in Enum.GetValues(typeof(Allergens)))
            {
                if (((int)allergen & this.score) != 0)
                {
                    allergies.Add(allergen);
                }
            }

            return allergies.ToArray();
        }
    }
}
