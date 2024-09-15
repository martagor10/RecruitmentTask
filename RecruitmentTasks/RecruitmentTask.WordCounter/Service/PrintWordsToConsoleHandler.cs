using RecruitmentTask.WordCounter.Interface;

namespace RecruitmentTask.WordCounter.Service;

public class PrintWordsToConsoleHandler : ICountResultHandler
{
    public async Task HandleResult(IEnumerable<KeyValuePair<string, int>> result)
    {
        await Console.Out.WriteLineAsync("Word counting finished, result:");

        foreach (var wordCount in result)
        {
            await Console.Out.WriteLineAsync($"{wordCount.Key}: {wordCount.Value}");
        }
    }
}