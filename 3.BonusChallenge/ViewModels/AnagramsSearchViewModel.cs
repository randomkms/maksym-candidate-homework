using System.Collections.Generic;

namespace _3.BonusChallenge.ViewModels
{
    public class AnagramsSearchViewModel
    {
        public List<string> InputWords { get; set; } = new List<string>();

        public List<AnagramViewModel> FoundAnagrams { get; set; } = new List<AnagramViewModel>();
    }
}