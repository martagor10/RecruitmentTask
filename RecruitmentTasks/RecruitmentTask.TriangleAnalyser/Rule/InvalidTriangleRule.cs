using RecruitmentTask.TriangleAnalyser.Interface;
using RecruitmentTask.TriangleAnalyser.Model;

namespace RecruitmentTask.TriangleAnalyser.Rule;

internal class InvalidTriangleRule : IAnalysisRule<Triangle, TriangleKind>
{
    public bool BreakIfFulfilled => true;

    public TriangleKind Result => TriangleKind.Invalid;

    public bool FulfillsCriteria(Triangle triangle)
    {
        IEnumerable<int[]> sidesCombinations =
        [
            [triangle.SideA, triangle.SideB, triangle.SideC],
            [triangle.SideA, triangle.SideC, triangle.SideB],
            [triangle.SideB, triangle.SideC, triangle.SideA]
        ];

        return sidesCombinations.Any(x => x[0] + x[1] <= x[2]);
    }
}