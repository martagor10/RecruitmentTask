using RecruitmentTask.TriangleAnalyser.Model;

namespace RecruitmentTask.TriangleAnalyser.Rule;

internal class EquilateralTriangleRule() : DistinctSidesCountRule(1)
{
    public override TriangleKind Result => TriangleKind.Equilateral;
}