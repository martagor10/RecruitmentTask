using Microsoft.Extensions.DependencyInjection;
using RecruitmentTask.WordCounter.Interface;
using RecruitmentTask.WordCounter.Service;

namespace RecruitmentTask.WordCounter;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWordCounter(this IServiceCollection services)
    {
        services.AddSingleton<IFileLoader, DiscFileLoader>();
        services.AddSingleton<IWordExtractor, RegexWordExtractor>();
        services.AddSingleton<IWordCounterFactory, WordCounterFactory>();
        services.AddSingleton<ICountResultHandler, PrintWordsToConsoleHandler>();

        return services;
    }
}