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

        [OutputCache(Duration = Constants.OneDayInSeconds)]
        public ActionResult FindAnagrams()
        {
            return View(new AnagramsSearchViewModel());
        }

        [HttpPost]
        public ActionResult FindAnagrams(string wordsInput)
        {
            if (string.IsNullOrWhiteSpace(wordsInput))
                return RedirectToAction(nameof(FindAnagrams));

            var wordsInputList = wordsInput.Split(Constants.InputWordsSeparator);
            if (wordsInputList.All(w => string.IsNullOrWhiteSpace(w)))
                return RedirectToAction(nameof(FindAnagrams));

            return View(GetAnagramsSearchResults(wordsInputList));
        }

        [OutputCache(Duration = Constants.OneDayInSeconds)]
        public ActionResult SimpleAnagrams()
        {
            return View("SampleAnagrams", GetAnagramsSearchResults(_configHandler.SimpleAnagramsList));
        }

        [OutputCache(Duration = Constants.OneDayInSeconds)]
        public ActionResult HardAnagrams()
        {
            return View("SampleAnagrams", GetAnagramsSearchResults(_configHandler.HardAnagramsList));
        }

        private AnagramsSearchViewModel GetAnagramsSearchResults(IReadOnlyCollection<string> normalizedWordsInput)
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