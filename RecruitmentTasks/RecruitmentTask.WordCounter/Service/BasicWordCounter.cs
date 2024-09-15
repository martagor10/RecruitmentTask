using RecruitmentTask.WordCounter.Interface;

namespace RecruitmentTask.WordCounter.Service;

internal class BasicWordCounter : IWordCounter
{
    protected virtual IEqualityComparer<string> Comparer => StringComparer.CurrentCulture;

    public IEnumerable<KeyValuePair<string, int>> Count(IEnumerable<string> words)
    {
        return words.GroupBy(x => x, (word, group) => new KeyValuePair<string, int>(word, group.Count()), Comparer);
    }
}