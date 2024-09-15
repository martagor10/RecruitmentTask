using RecruitmentTask.WordCounter.Model;

namespace RecruitmentTask.WordCounter.Interface;

public interface IWordCounterFactory
{
    IWordCounter Create(ComparisonMode comparisonMode);
}