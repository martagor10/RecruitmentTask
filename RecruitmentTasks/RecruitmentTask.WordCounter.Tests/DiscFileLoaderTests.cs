using RecruitmentTask.WordCounter.Service;
using Xunit;
using Xunit.Categories;

namespace RecruitmentTask.WordCounter.Tests;

[UnitTest]
public class DiscFileLoaderTests
{
    private readonly DiscFileLoader _discFileLoader = new();

    [Fact]
    public async Task ShouldLoadFileAndReturnSomeText()
    {
        // arrange
        var path = "Test1.txt";
        string text = await File.ReadAllTextAsync(path);
        
        // act
        var result = await _discFileLoader.Load(path);
        
        // assert
        Assert.Equal(text, result);
    }
    
    [Fact]
    public async Task ShouldThrowExceptionIfPathToFileDoesNotExist()
    {
        // arrange
        var path = "Test10.txt";

        // act & assert
        await Assert.ThrowsAsync<FileNotFoundException>(() => _discFileLoader.Load(path));
    }
}