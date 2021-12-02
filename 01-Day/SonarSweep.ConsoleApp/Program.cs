using SonarSweep;

Print("### WELCOME TO: SINKING SPEED CALCULATOR 3000 ###", highlight: true);
Wait();
var report = File.ReadAllText("input.txt");
Print(report);

var increment = new SinkingSpeedCalculator().Calculate(report);
var incrementWithSliceWindows = new SinkingSpeedCalculator().Calculate(report, 3);
Print($"RESULT PART 1: {increment}", highlight: true);
Print($"RESULT PART 2: {incrementWithSliceWindows}", highlight: true);

static void Print(string text, bool highlight = false)
{
    Console.ResetColor();
    if(highlight)
        Console.ForegroundColor = ConsoleColor.Green;

    Console.WriteLine(text);
}

static void Wait()
{
    Console.WriteLine(); 
    Print("Press enter to continue...");
    Console.ReadLine();
}