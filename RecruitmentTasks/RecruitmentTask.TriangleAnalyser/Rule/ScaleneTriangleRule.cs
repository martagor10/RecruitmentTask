using RecruitmentTask.TriangleAnalyser.Model;

namespace RecruitmentTask.TriangleAnalyser.Rule;

internal class ScaleneTriangleRule() : DistinctSidesCountRule(3)
{
    public override TriangleKind Result => TriangleKind.Scalene;
}