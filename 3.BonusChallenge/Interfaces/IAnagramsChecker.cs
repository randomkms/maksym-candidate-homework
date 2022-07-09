using System.Collections.Generic;

namespace _3.BonusChallenge.Interfaces
{
    public interface IAnagramsChecker
    {
        IEnumerable<IEnumerable<string>> GetAnagrams(IEnumerable<string> words);
    }
}
