using RecruitmentTask.TriangleAnalyser.Interface;
using RecruitmentTask.TriangleAnalyser.Model;

namespace RecruitmentTask.TriangleAnalyser.Service;

public class PrintToConsoleResultHandler : IAnalysisResultHandler<Triangle, TriangleKind>
{
    public async Task Handle(AnalysisResult<Triangle, TriangleKind> result)
    {
        await Console.Out.WriteAsync("Triangle analysis result: ");
        await Console.Out.WriteLineAsync(
            $"triangle [{result.Value.SideA}, {result.Value.SideB}, {result.Value.SideC}] is {string.Join(", ", result.Result)}");
    }
}