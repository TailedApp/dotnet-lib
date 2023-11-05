using Tailed.Console;

namespace TestApp;

internal static class ConsoleScenario
{
    public static async Task RunAsync()
    {
        await using var session = new ConsoleSession(false, Constants.Hostname);
        session.Start();

        Console.WriteLine("Hello world!");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("In red!");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("In green!");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.Write("Blue on yellow! ");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine("Yellow on blue! ");

        Console.ResetColor();
        Console.Write("Type something: ");
        var read = Console.ReadLine();

        Console.WriteLine($"You said: {read}");
    }
}