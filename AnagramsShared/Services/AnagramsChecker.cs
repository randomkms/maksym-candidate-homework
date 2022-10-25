using AnagramsShared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramsShared.Services
{
    public class AnagramsChecker : IAnagramsChecker
    {
        public IEnumerable<IEnumerable<string>> GetAnagrams(IEnumerable<string> words) //TODO add unit tests
        {
            if (words == null)
                throw new ArgumentNullException(nameof(words));

            var output = new List<List<string>>();
            var normalizedWords = words
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => s.Trim())
                .ToHashSet();

            while (normalizedWords.Any())
            {
                var word = normalizedWords.First();
                var anagrams = normalizedWords.Where(w => IsAnagram(w, word)).ToList();
                anagrams.Sort((a1, a2) => string.Compare(a1, a2, StringComparison.InvariantCultureIgnoreCase));
                output.Add(anagrams);

                foreach (var anagram in anagrams)
                    normalizedWords.Remove(anagram);
            }

            output.Sort((l1, l2) => string.Compare(l1.First(), l2.First(), StringComparison.InvariantCultureIgnoreCase));

            return output;
        }

        private static bool IsAnagram(string a, string b)
        {
            if (ReferenceEquals(a, b)) // optimization for passing the same string
                return true;

            a = RemoveWhitespaces(a);
            b = RemoveWhitespaces(b);
            if (a.Length != b.Length)
                return false;

            var aCharsFrequency = GetCharsFrequency(a.ToLowerInvariant());
            var bCharsFrequency = GetCharsFrequency(b.ToLowerInvariant());

            if (aCharsFrequency.Count != bCharsFrequency.Count)
                return false;

            foreach (var aCharFreq in aCharsFrequency)
            {
                if (!bCharsFrequency.TryGetValue(aCharFreq.Key, out var bFreq) || aCharFreq.Value != bFreq)
                    return false;
            }

            return true;
        }

        private static string RemoveWhitespaces(string input)
        {
            return new string(input.Where(c => !char.IsWhiteSpace(c)).ToArray());
        }

        private static Dictionary<char, int> GetCharsFrequency(string input)
        {
            var charFreq = new Dictionary<char, int>(input.Length);
            foreach (var c in input)
            {
                if (!charFreq.ContainsKey(c))
                    charFreq.Add(c, 0);

                charFreq[c]++;
            }

            return charFreq;
        }
    }
}
