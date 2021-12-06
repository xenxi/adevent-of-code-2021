using BinaryDiagnostic;

Print("### WELCOME TO: HEALTH CHECKS 2001 ###", highlight: true);
Wait();
var ratesStr = File.ReadAllText("input.txt");
Print(ratesStr);

var repository = new StringRates(ratesStr);
var cheker = new HealthChecker(repository);
var report = cheker.GenerateReport();
Print($"PowerConsumption: {report.PowerConsumption}");

static void Print(string text, bool highlight = false)
{
    Console.ResetColor();
    if (highlight)
        Console.ForegroundColor = ConsoleColor.DarkMagenta;

    Console.WriteLine(text);
}


static void Wait()
{
    Console.WriteLine();
    Print("Press enter to continue...");
    Console.ReadLine();
}