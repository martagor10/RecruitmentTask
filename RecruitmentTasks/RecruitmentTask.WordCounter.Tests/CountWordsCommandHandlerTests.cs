using Moq;
using RecruitmentTask.WordCounter.Interface;
using RecruitmentTask.WordCounter.Model;
using RecruitmentTask.WordCounter.Service;
using Xunit;
using Xunit.Categories;

namespace RecruitmentTask.WordCounter.Tests;

[UnitTest]
public class CountWordsCommandHandlerTests
{
    private readonly Mock<IFileLoader> _fileLoaderMock = new();
    private readonly Mock<IWordExtractor> _wordExtractorMock = new();
    private readonly Mock<IWordCounterFactory> _wordCounterFactoryMock = new();
    private readonly Mock<ICountResultHandler> _countResultHandlerMock = new();

    private const string TestPath = "./Test1.txt";

    [Fact]
    public async Task ShouldReturnZeroIfSuccessful_BasicWordCounter()
    {
        // arrange
        var basicWordCounter = new Mock<BasicWordCounter>();
        _wordCounterFactoryMock.Setup(x => x.Create(ComparisonMode.Default)).Returns(basicWordCounter.Object);
        CountWordsCommandHandler countWordsHandler = new(
            _fileLoaderMock.Object,
            _wordExtractorMock.Object,
            _wordCounterFactoryMock.Object,
            _countResultHandlerMock.Object)
        {
            Files = [TestPath]
        };
        
        // act
        var result = await countWordsHandler.InvokeAsync(default!);

        // assert
        Assert.Equal(0, result);
    }
    
    [Fact]
    public async Task ShouldReturnZeroIfSuccessful_CaseInsensitiveWordCounter()
    {
        // arrange
        var caseInsensitiveWordCounter = new Mock<CaseInsensitiveWordCounter>();
        _wordCounterFactoryMock.Setup(x => x.Create(ComparisonMode.CaseInsensitive)).Returns(caseInsensitiveWordCounter.Object);
        CountWordsCommandHandler countWordsHandler = new(
            _fileLoaderMock.Object,
            _wordExtractorMock.Object,
            _wordCounterFactoryMock.Object,
            _countResultHandlerMock.Object)
        {
            Files = [TestPath],
            CaseInsensitive = true
        };
        
        // act
        var result = await countWordsHandler.InvokeAsync(default!);

        // assert
        Assert.Equal(0, result);
    }
    
    [Fact]
    public async Task ShouldReturnOneIfError()
    {
        // arrange
        var basicWordCounter = new Mock<BasicWordCounter>();
        _wordCounterFactoryMock.Setup(x => x.Create(ComparisonMode.Default)).Returns(basicWordCounter.Object);
        _fileLoaderMock.Setup(x => x.Load(TestPath))
            .ThrowsAsync(new FileNotFoundException("File not found", TestPath));
        CountWordsCommandHandler countWordsHandler = new(
            _fileLoaderMock.Object,
            _wordExtractorMock.Object,
            _wordCounterFactoryMock.Object,
            _countResultHandlerMock.Object)
        {
            Files = [TestPath]
        };
        
        // act
        var result = await countWordsHandler.InvokeAsync(default!);

        // assert
        Assert.Equal(1, result);
    }
}