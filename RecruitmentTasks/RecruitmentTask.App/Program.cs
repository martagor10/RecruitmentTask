// See https://aka.ms/new-console-template for more information

using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Parsing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RecruitmentTask.App;
using RecruitmentTask.TriangleAnalyser;
using RecruitmentTask.WordCounter;

var parser = new CommandLineBuilder(new RecruitmentTaskRootCommand())
    .UseHost(
        _ => Host.CreateDefaultBuilder(),
        builder => builder.ConfigureServices((_, services) =>
            {
                services
                    .AddTriangleAnalyser()
                    .AddWordCounter()
                    .AddLogging(c =>
                        c.ClearProviders()); // turn off default logging to console, since we don't use logging in this sample application
            })
            .UseCommandHandler<AnalyseTriangleCommand, AnalyseTriangleCommandHandler>()
            .UseCommandHandler<CountWordsCommand, CountWordsCommandHandler>())
    .UseDefaults()
    .Build();

await parser.InvokeAsync(args);