namespace RecruitmentTask.TriangleAnalyser.Model;

public record AnalysisResult<T, TResult>(T Value, IEnumerable<TResult> Result);