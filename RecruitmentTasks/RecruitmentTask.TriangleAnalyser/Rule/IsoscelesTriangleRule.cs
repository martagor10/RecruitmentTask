using RecruitmentTask.TriangleAnalyser.Model;

namespace RecruitmentTask.TriangleAnalyser.Rule;

internal class IsoscelesTriangleRule() : DistinctSidesCountRule(2, CountMode.AtLeast)
{
    public override TriangleKind Result => TriangleKind.Isosceles;
}