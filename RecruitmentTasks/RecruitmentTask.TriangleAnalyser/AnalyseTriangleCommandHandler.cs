using System.CommandLine.Invocation;
using JetBrains.Annotations;
using RecruitmentTask.TriangleAnalyser.Interface;
using RecruitmentTask.TriangleAnalyser.Model;

namespace RecruitmentTask.TriangleAnalyser;

public class AnalyseTriangleCommandHandler(
    IEnumerable<IAnalysisRule<Triangle, TriangleKind>> rules,
    IAnalyser<Triangle, TriangleKind> analyser,
    IAnalysisResultHandler<Triangle, TriangleKind> resultHandler) : ICommandHandler
{
    [UsedImplicitly] public int SideA { get; init; }
    [UsedImplicitly] public int SideB { get; init; }
    [UsedImplicitly] public int SideC { get; init; }

    public int Invoke(InvocationContext context) => throw new NotImplementedException();

    public async Task<int> InvokeAsync(InvocationContext context)
    {
        var triangle = new Triangle(SideA, SideB, SideC);

        foreach (var rule in rules) analyser.AddRule(rule);

        var result = analyser.Analyse(triangle);

        await resultHandler.Handle(result);

        return 0;
    }
}