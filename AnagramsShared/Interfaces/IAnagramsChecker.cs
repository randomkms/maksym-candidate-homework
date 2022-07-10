using System.Collections.Generic;

namespace AnagramsShared.Interfaces
{
    public interface IAnagramsChecker
    {
        IEnumerable<IEnumerable<string>> GetAnagrams(IEnumerable<string> words);
    }
}
