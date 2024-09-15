using RecruitmentTask.WordCounter.Service;
using Xunit;
using Xunit.Categories;
// ReSharper disable PossibleMultipleEnumeration

namespace RecruitmentTask.WordCounter.Tests;

[UnitTest]
public class BasicWordCounterTests
{
    private readonly BasicWordCounter _target = new();
    
    [Fact]
    public void Count_ShouldReturnCorrectNumberOfEachWord()
    {
        // arrange
        const string firstWord = "one";
        const string secondWord = "One";
        List<string> words =
        [
            firstWord,
            firstWord,
            secondWord
        ];
        
        var expected = new Dictionary<string, int>
        {
            {firstWord, 2},
            {secondWord, 1}
        };
        
        // act
        var result = _target.Count(words);
        
        // assert
        Assert.Equal(expected.OrderBy(x => x.Key), result.OrderBy(x => x.Key));
    }
}