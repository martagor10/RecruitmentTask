using RecruitmentTask.WordCounter.Service;
using Xunit;
using Xunit.Categories;

namespace RecruitmentTask.WordCounter.Tests;

[UnitTest]
public class CaseInsensitiveWordCounterTests
{
    private readonly CaseInsensitiveWordCounter _target = new ();

    [Fact]
    public void Count_CaseInsensitiveWordCounter()
    {
        // arrange
        const string firstWord = "One";
        var secondWord = firstWord.ToLower();
        List<string> words =
        [
            firstWord,
            firstWord,
            secondWord
        ];
        
        var expected = new Dictionary<string, int>
        {
            {firstWord, words.Count}
        };
        
        // act
        var result = _target.Count(words);
        
        // assert
        Assert.Equal(expected.OrderBy(x => x.Key), result.OrderBy(x => x.Key));
    }
}