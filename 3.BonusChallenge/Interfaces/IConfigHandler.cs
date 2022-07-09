using System.Collections.Generic;

namespace _3.BonusChallenge.Interfaces
{
    public interface IConfigHandler
    {
        IReadOnlyList<string> HardAnagramsList { get; }
        IReadOnlyList<string> SimpleAnagramsList { get; }
    }
}