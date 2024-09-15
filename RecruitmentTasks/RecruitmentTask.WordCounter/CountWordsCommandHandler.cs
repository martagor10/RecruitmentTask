using System.CommandLine.Invocation;
using JetBrains.Annotations;
using RecruitmentTask.WordCounter.Interface;
using RecruitmentTask.WordCounter.Model;

namespace RecruitmentTask.WordCounter;

public class CountWordsCommandHandler(
    IFileLoader fileLoader,
    IWordExtractor wordExtractor,
    IWordCounterFactory wordCounterFactory,
    ICountResultHandler countResultHandler) : ICommandHandler
{
    [UsedImplicitly] public string[] Files { get; init; } = [];
    [UsedImplicitly] public bool CaseInsensitive { get; init; }

    private ComparisonMode ComparisonMode => CaseInsensitive ? ComparisonMode.CaseInsensitive : ComparisonMode.Default;

    public int Invoke(InvocationContext context) => throw new NotImplementedException();

    public async Task<int> InvokeAsync(InvocationContext context)
    {
        try
        {
            var wordsFromFiles = await Files
                .ToAsyncEnumerable()
                .SelectAwait(async path => await fileLoader.Load(path))
                .Select(wordExtractor.Extract)
                .ToListAsync();

            var wordCounter = wordCounterFactory.Create(ComparisonMode);

            var countResult = wordCounter.Count(wordsFromFiles.SelectMany(x => x));

            await countResultHandler.HandleResult(countResult);

            return 0;
        }
        catch (FileNotFoundException ex)
        {
            await Console.Error.WriteLineAsync($"Error: specified file {ex} was not found");

            return 1;
        }
    }
}