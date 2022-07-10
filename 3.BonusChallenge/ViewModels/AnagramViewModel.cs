using System.Collections.Generic;
using System.Linq;

namespace _3.BonusChallenge.ViewModels
{
    public class AnagramViewModel
    {
        public AnagramViewModel(IEnumerable<string> words)
        {
            AnagramWords = words?.ToList() ?? new List<string>();
        }

        public List<string> AnagramWords { get; set; }

    }
}