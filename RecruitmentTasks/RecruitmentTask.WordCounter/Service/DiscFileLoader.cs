using RecruitmentTask.WordCounter.Interface;

namespace RecruitmentTask.WordCounter.Service;

internal class DiscFileLoader : IFileLoader
{
    public async Task<string> Load(string path)
    {
        if (!File.Exists(path)) throw new FileNotFoundException("File not found", path);

        return await File.ReadAllTextAsync(path);
    }
}