using RecruitmentTask.WordCounter.Interface;
using RecruitmentTask.WordCounter.Model;

namespace RecruitmentTask.WordCounter.Service;

public class WordCounterFactory : IWordCounterFactory
{
    public IWordCounter Create(ComparisonMode comparisonMode)
    {
        return comparisonMode switch
        {
            ComparisonMode.Default => new BasicWordCounter(),
            ComparisonMode.CaseInsensitive => new CaseInsensitiveWordCounter(),
            _ => throw new ArgumentOutOfRangeException(nameof(comparisonMode), comparisonMode, null)
        };
    }
}