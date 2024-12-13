using System;

namespace PopulationTask
{
    public static class Population
    {
        public static int GetYears(int initialPopulation, double percent, int visitors, int currentPopulation)
        {
            if (initialPopulation <= 0)
            {
                throw new ArgumentException("Initial population must be greater than 0.");
            }

            if (percent < 0 || percent > 100)
            {
                throw new ArgumentOutOfRangeException("Percent must be between 0 and 100.");
            }

            if (visitors < 0)
            {
                throw new ArgumentException("Visitor count cannot be negative.");
            }

            if (currentPopulation <= 0)
            {
                throw new ArgumentException("Current population must be greater than 0.");
            }

            if (currentPopulation <= initialPopulation)
            {
                throw new ArgumentException("Current population must be greater than initial population.");
            }

            int years = 0;
            int population = initialPopulation;

            while (population <= currentPopulation)
            {
                population += (int)(population * percent / 100) + visitors;
                years++;
            }

            return years;
        }
    }
}
