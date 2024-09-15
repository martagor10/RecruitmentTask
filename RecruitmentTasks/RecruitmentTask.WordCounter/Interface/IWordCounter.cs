namespace RecruitmentTask.WordCounter.Interface;

public interface IWordCounter
{
    IEnumerable<KeyValuePair<string, int>> Count(IEnumerable<string> words);
}