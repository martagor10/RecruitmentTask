using System.CommandLine;
using RecruitmentTask.TriangleAnalyser;
using RecruitmentTask.WordCounter;

namespace RecruitmentTask.App;

public class RecruitmentTaskRootCommand : RootCommand
{
    public RecruitmentTaskRootCommand()
    {
        AddCommand(new AnalyseTriangleCommand());
        AddCommand(new CountWordsCommand());
    }
}