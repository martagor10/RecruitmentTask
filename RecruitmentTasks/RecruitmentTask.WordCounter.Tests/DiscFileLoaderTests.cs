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
        const string text = "Go do that thing that you do so well";
        var path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "./Test1.txt"));
        
        // act
        var result = await _discFileLoader.Load(path);
        
        // assert
        Assert.Equal(text, result);
    }
    
    [Fact]
    public async Task ShouldThrowExceptionIfPathToFileDoesNotExist()
    {
        // arrange
        var path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "./Test10.txt"));

        // act & assert
        await Assert.ThrowsAsync<FileNotFoundException>(() => _discFileLoader.Load(path));
    }
}