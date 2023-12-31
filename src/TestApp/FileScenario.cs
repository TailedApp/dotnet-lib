using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace TestApp;

internal static class FileScenario
{
    public static async Task RunAsync()
    {
        if (File.Exists("test.log"))
            File.Delete("test.log");
        
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.File("test.log")
            .CreateLogger();

        var serviceProvider = new ServiceCollection()
            .AddLogging((loggingBuilder) => loggingBuilder
                .SetMinimumLevel(LogLevel.Debug)
                .AddSerilog(dispose:true)
            )
            .BuildServiceProvider();

        var logger = serviceProvider.GetService<ILoggerFactory>()!.CreateLogger<Foo>();

        Console.WriteLine("Waiting for log monitor..");
        await Task.Delay(10000);
        Console.WriteLine("Logging!");

        logger.LogInformation("Started The Test");

        for (var i = 0; i < 20000; i++)
        {
            logger.Log(TestData.GetRandomLogLevel(), TestData.GetRandomSentence());
            await Task.Delay(100);
        }
    }
}