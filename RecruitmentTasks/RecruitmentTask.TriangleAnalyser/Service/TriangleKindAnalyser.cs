using RecruitmentTask.TriangleAnalyser.Interface;
using RecruitmentTask.TriangleAnalyser.Model;

namespace RecruitmentTask.TriangleAnalyser.Service;

public class TriangleKindAnalyser : IAnalyser<Triangle, TriangleKind>
{
    private readonly Queue<IAnalysisRule<Triangle, TriangleKind>> _rules = new();

    public void AddRule(IAnalysisRule<Triangle, TriangleKind> rule)
    {
        _rules.Enqueue(rule);
    }

    public AnalysisResult<Triangle, TriangleKind> Analyse(Triangle value)
    {
        return new AnalysisResult<Triangle, TriangleKind>(value, PerformAnalysis(value));
    }

    private IEnumerable<TriangleKind> PerformAnalysis(Triangle value)
    {
        while (_rules.Count > 0)
        {
            var rule = _rules.Dequeue();

            if (!rule.FulfillsCriteria(value)) continue;

            yield return rule.Result;
            if (rule.BreakIfFulfilled) yield break;
        }
    }
}