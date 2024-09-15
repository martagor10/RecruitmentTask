using System.CommandLine;

namespace RecruitmentTask.TriangleAnalyser;

public class AnalyseTriangleCommand : Command
{
    public AnalyseTriangleCommand() : base("analyse-triangle", "Analyse a triangle based on the lengths of its sides")
    {
        AddAlias("at");

        var sides = new[] { "A", "B", "C" };

        foreach (var side in sides)
            AddArgument(new Argument<int>($"side{side}", $"Length of side {side} of the triangle"));
    }
}