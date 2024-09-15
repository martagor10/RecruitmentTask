namespace RecruitmentTask.WordCounter.Interface;

public interface IWordExtractor
{
    IEnumerable<string> Extract(string text);
}