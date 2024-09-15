using RecruitmentTask.TriangleAnalyser.Model;

namespace RecruitmentTask.TriangleAnalyser.Interface;

public interface IAnalysisResultHandler<T, TResult>
{
    Task Handle(AnalysisResult<T, TResult> result);
}