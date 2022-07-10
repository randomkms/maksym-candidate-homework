using _3.BonusChallenge.Interfaces;
using _3.BonusChallenge.ViewModels;
using AnagramsShared.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace _3.BonusChallenge.Controllers
{
    public class AnagramController : Controller
    {
        private readonly IAnagramsChecker _anagramsChecker;
        private readonly IConfigHandler _configHandler;

        public AnagramController(IAnagramsChecker anagramsChecker, IConfigHandler configHandler)
        {
            _anagramsChecker = anagramsChecker;
            _configHandler = configHandler;
        }

        public ActionResult FindAnagrams()
        {
            return View(new AnagramsSearchViewModel());
        }

        [HttpPost]
        public ActionResult FindAnagrams(string wordsInput)
        {
            var wordsInputList = wordsInput.Split(Constants.WordsToSearchForAnagramsSeparator);

            return View("FindAnagrams", GetAnagramsSearchResults(wordsInputList));
        }

        public ActionResult SimpleAnagrams()
        {
            return View("Anagrams", GetAnagramsSearchResults(_configHandler.SimpleAnagramsList));
        }

        public ActionResult HardAnagrams()
        {
            return View("Anagrams", GetAnagramsSearchResults(_configHandler.HardAnagramsList));
        }

        private AnagramsSearchViewModel GetAnagramsSearchResults(IEnumerable<string> normalizedWordsInput)
        {
            var anagrams = _anagramsChecker.GetAnagrams(normalizedWordsInput)
                .Select(words => new AnagramViewModel(words));

            return new AnagramsSearchViewModel
            {
                InputWords = normalizedWordsInput.ToList(),
                FoundAnagrams = anagrams.ToList()
            };
        }
    }
}