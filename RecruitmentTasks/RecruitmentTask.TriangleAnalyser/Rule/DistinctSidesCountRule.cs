using RecruitmentTask.TriangleAnalyser.Interface;
using RecruitmentTask.TriangleAnalyser.Model;

namespace RecruitmentTask.TriangleAnalyser.Rule;

internal abstract class DistinctSidesCountRule(int distinctSides, CountMode countMode = CountMode.Exactly)
    : IAnalysisRule<Triangle, TriangleKind>
{
    public virtual bool BreakIfFulfilled => false;
    public abstract TriangleKind Result { get; }

    public virtual bool FulfillsCriteria(Triangle triangle)
    {
        var triangleDistinctSides = GetSides(triangle).Distinct().Count();

        return countMode switch
        {
            CountMode.Exactly => triangleDistinctSides == distinctSides,
            CountMode.AtLeast => triangleDistinctSides <= distinctSides,
            _ => throw new ArgumentOutOfRangeException(null, countMode,
                $"Unsupported value provided for ${nameof(countMode)} parameter")
        };
    }

    private static IEnumerable<int> GetSides(Triangle triangle)
    {
        return [triangle.SideA, triangle.SideB, triangle.SideC];
    }
}