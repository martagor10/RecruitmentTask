using System.Text.RegularExpressions;
using RecruitmentTask.WordCounter.Interface;

namespace RecruitmentTask.WordCounter.Service;

internal partial class RegexWordExtractor : IWordExtractor
{
    public IEnumerable<string> Extract(string text)
    {
        return WordRegex().Matches(text).Select(m => m.Value);
    }

    [GeneratedRegex(@"[\w'-]+")]
    private static partial Regex WordRegex();
}