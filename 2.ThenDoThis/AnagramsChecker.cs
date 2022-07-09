using System.Collections.Generic;
using System.Linq;

namespace _2.Puzzle.Medium
{
    public class AnagramsChecker
    {
        public IEnumerable<IEnumerable<string>> GetAnagrams(IEnumerable<string> words)
        {
            var output = new List<List<string>>();

            var stringsToCheck = words
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => s.Trim())
                .ToHashSet();
            var normalizedWords = stringsToCheck.ToArray();

            foreach (var str in normalizedWords)
            {
                if (!stringsToCheck.Contains(str))
                    continue;

                var anagrams = stringsToCheck.Where(s => IsAnagram(s, str)).Distinct().ToList();
                if (!anagrams.Any())
                    continue;

                anagrams.Sort();
                output.Add(anagrams);

                foreach (var anagram in anagrams)
                    stringsToCheck.Remove(anagram);
            }

            output.Sort((l1, l2) => l1.First().CompareTo(l2.First()));

            return output;
        }

        //private static bool IsAnagram(string str1, string str2) // LINQ way
        //{
        //    str1 = str1.Replace(" ", string.Empty);
        //    str2 = str2.Replace(" ", string.Empty);
        //    if (str1.Length != str1.Length)
        //        return false;

        //    var charFreqSet1 = str1.ToLowerInvariant().GroupBy(c => c).Select(g => (symbol: g.Key, frequency: g.Count())).Distinct().ToArray();
        //    var charFreqSet2 = str2.ToLowerInvariant().GroupBy(c => c).Select(g => (symbol: g.Key, frequency: g.Count())).ToHashSet();
        //    if (charFreqSet1.Length != charFreqSet2.Count)
        //        return false;

        //    foreach (var charFreq in charFreqSet1)
        //    {
        //        if (!charFreqSet2.Contains(charFreq))
        //            return false;
        //    }

        //    return true;
        //}

        private static bool IsAnagram(string a, string b)
        {
            a = a.Replace(" ", string.Empty);
            b = b.Replace(" ", string.Empty);
            if (a.Length != b.Length)
                return false;

            var aCharsFrequency = GetCharsFrequency(a.ToLowerInvariant());
            var bCharsFrequency = GetCharsFrequency(b.ToLowerInvariant());

            if (aCharsFrequency.Count != bCharsFrequency.Count)
                return false;

            foreach (var (aChar, aFreq) in aCharsFrequency)
            {
                if (!bCharsFrequency.TryGetValue(aChar, out var bFreq) || aFreq != bFreq)
                    return false;
            }

            return true;
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
