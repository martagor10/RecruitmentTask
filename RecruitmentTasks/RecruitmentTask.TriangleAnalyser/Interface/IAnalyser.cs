using RecruitmentTask.TriangleAnalyser.Model;

namespace RecruitmentTask.TriangleAnalyser.Interface;

public interface IAnalyser<T, TResult>
{
    void AddRule(IAnalysisRule<T, TResult> rule);
    AnalysisResult<T, TResult> Analyse(T value);
}