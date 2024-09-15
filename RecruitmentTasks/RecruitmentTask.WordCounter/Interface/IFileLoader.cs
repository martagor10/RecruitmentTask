namespace RecruitmentTask.WordCounter.Interface;

public interface IFileLoader
{
    Task<string> Load(string path);
}