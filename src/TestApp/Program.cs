using TestApp;

var choice = string.Empty;
var valid = new[] { "C", "L", "F" };

while (!valid.Contains(choice))
{
    Console.Write("Console, Logger or File [C/L/F]: ");
    choice = Console.ReadLine()?.ToUpperInvariant();
}

Console.Clear();

switch (choice)
{
    case "C":
        await ConsoleScenario.RunAsync();
        break;
    case "L":
        await LogScenario.RunAsync();
        break;
    case "F":
        await FileScenario.RunAsync();
        break;
}