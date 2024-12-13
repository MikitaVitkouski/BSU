using System;
using System.Collections.Generic;

namespace SearchByPatternInText
{
    public static class Searcher
    {
        /// <summary>
        /// Searches the pattern string inside the text and collects information about all hit positions in the order they appear.
        /// </summary>
        /// <param name="text">Source text.</param>
        /// <param name="pattern">Source pattern text.</param>
        /// <param name="overlap">Flag to overlap:
        /// if overlap flag is true collect every position overlapping included,
        /// if false no overlapping is allowed (next search behind).</param>
        /// <returns>List of positions of occurrence of the pattern string in the text, if any and empty otherwise.</returns>
        /// <exception cref="ArgumentException">Thrown if text or pattern is null.</exception>
        public static int[] SearchPatternString(this string? text, string? pattern, bool overlap)
        {
            if (text is null)
            {
                throw new ArgumentException("Source text cannot be null.", nameof(text));
            }

            if (pattern is null)
            {
                throw new ArgumentException("Pattern string cannot be null.", nameof(pattern));
            }

            if (pattern.Length == 0)
            {
                return Array.Empty<int>();
            }

            var positions = new List<int>();
            int textLength = text.Length;
            int patternLength = pattern.Length;

            for (int i = 0; i <= textLength - patternLength; i++)
            {
                bool found = true;
                for (int j = 0; j < patternLength; j++)
                {
                    if (char.ToLowerInvariant(text[i + j]) != char.ToLowerInvariant(pattern[j]))
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    positions.Add(i + 1);

                    if (!overlap)
                    {
                        i += patternLength;
                    }
                }
            }

            return positions.ToArray();
        }
    }
}
