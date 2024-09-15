namespace RecruitmentTask.WordCounter.Interface;

public interface ICountResultHandler
{
    Task HandleResult(IEnumerable<KeyValuePair<string, int>> result);
}