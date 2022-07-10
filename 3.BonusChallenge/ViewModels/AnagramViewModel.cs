using System.Collections.Generic;
using System.Linq;

namespace _3.BonusChallenge.ViewModels
{
    public class AnagramViewModel
    {
        public AnagramViewModel(IEnumerable<string> words)
        {
            AnagramWords = words?.ToList() ?? new List<string>();
            HasPhrases = AnagramWords.Any(w => w.Any(c => char.IsWhiteSpace(c)));
        }

        public IReadOnlyList<string> AnagramWords { get; }

        public bool HasPhrases { get; }

    }
}