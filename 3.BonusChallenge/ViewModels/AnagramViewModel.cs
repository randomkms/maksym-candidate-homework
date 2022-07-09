using System.Collections.Generic;
using System.Linq;

namespace _3.BonusChallenge.ViewModels
{
    public class AnagramViewModel
    {
        public AnagramViewModel(IEnumerable<string> words)
        {
            Words = words?.ToList() ?? new List<string>();
        }

        public List<string> Words { get; set; }

        public override string ToString()
        {
            return string.Join(", ", Words);
        }
    }
}