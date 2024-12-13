using System;
using System.Collections.Generic;
using System.Globalization;

namespace Anagrams
{
    public class Anagram
    {
        private string sourceWord;

        public Anagram(string? sourceWord)
        {
            if (sourceWord == null)
            {
                throw new ArgumentNullException(nameof(sourceWord));
            }

            if (sourceWord.Length == 0)
            {
                throw new ArgumentException("Source word cannot be empty.", nameof(sourceWord));
            }

            this.sourceWord = sourceWord.ToLower(); // Convert source word to lowercase for case-insensitive comparison
        }

        public string[] FindAnagrams(string[]? candidates)
        {
            if (candidates == null)
            {
                throw new ArgumentNullException(nameof(candidates));
            }

            List<string> anagrams = new List<string>();

            foreach (string candidate in candidates)
            {
                if (!this.IsSameWord(candidate) && this.IsAnagram(candidate))
                {
                    anagrams.Add(candidate);
                }
            }

            return anagrams.ToArray();
        }

        private bool IsSameWord(string candidate)
        {
            return candidate.ToLower() == this.sourceWord;
        }

        private bool IsAnagram(string candidate)
        {
            if (candidate.Length != this.sourceWord.Length)
            {
                return false;
            }

            int[] letterCount = new int[26]; // Assuming input contains only lowercase English letters

            foreach (char c in this.sourceWord)
            {
                letterCount[c - 'a']++;
            }

            foreach (char c in candidate.ToLower()) // Convert candidate to lowercase for case-insensitive comparison
            {
                int index = c - 'a';
                letterCount[index]--;

                if (letterCount[index] < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
