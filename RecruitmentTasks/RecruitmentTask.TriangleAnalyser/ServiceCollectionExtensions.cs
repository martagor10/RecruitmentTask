using Microsoft.Extensions.DependencyInjection;
using RecruitmentTask.TriangleAnalyser.Interface;
using RecruitmentTask.TriangleAnalyser.Model;
using RecruitmentTask.TriangleAnalyser.Rule;
using RecruitmentTask.TriangleAnalyser.Service;

namespace RecruitmentTask.TriangleAnalyser;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTriangleAnalyser(this IServiceCollection services)
    {
        services.AddSingleton<IAnalysisRule<Triangle, TriangleKind>, InvalidTriangleRule>(); // should be first
        services.AddSingleton<IAnalysisRule<Triangle, TriangleKind>, IsoscelesTriangleRule>();
        services.AddSingleton<IAnalysisRule<Triangle, TriangleKind>, EquilateralTriangleRule>();
        services.AddSingleton<IAnalysisRule<Triangle, TriangleKind>, ScaleneTriangleRule>();

        services.AddSingleton<IAnalyser<Triangle, TriangleKind>, TriangleKindAnalyser>();
        services.AddSingleton<IAnalysisResultHandler<Triangle, TriangleKind>, PrintToConsoleResultHandler>();

        return services;
    }
}