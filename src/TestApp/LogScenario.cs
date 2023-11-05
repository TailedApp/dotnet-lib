using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pastel;
using Tailed.Console;

namespace TestApp;

internal static class LogScenario
{
    public static async Task RunAsync()
    {
        await using var session = new ConsoleSession(true, Constants.Hostname);
        session.Start();

        var serviceProvider = new ServiceCollection()
            .AddLogging((loggingBuilder) => loggingBuilder
                .SetMinimumLevel(LogLevel.Debug)
                .AddConsole()
            )
            .BuildServiceProvider();

        var logger = serviceProvider.GetService<ILoggerFactory>()!.CreateLogger<Foo>();

        logger.LogInformation("Started The Test".Pastel(ConsoleColor.Red).PastelBg(ConsoleColor.Yellow));

        for (var i = 0; i < 50; i++)
        {
            logger.Log(TestData.GetRandomLogLevel(), TestData.GetRandomSentence());
            await Task.Delay(500);

        }
    }
}