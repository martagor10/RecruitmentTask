namespace RecruitmentTask.TriangleAnalyser.Interface;

public interface IAnalysisRule<in T, out TResult>
{
    bool BreakIfFulfilled { get; }
    TResult Result { get; }
    bool FulfillsCriteria(T value);
}