using Dive;
using Dive.Commands;
using Dive.ConsoleApp;

Print("### WELCOME TO: DIVE 3000 ###", highlight: true);
Wait();
var report = File.ReadAllText("input.txt");
Print(report);


var sender = BuildSender(report);

sender.Send(new BasicDive());

static InstructionSender BuildSender(string commands)
{
    var repository = new StringCommandRepository(commands);
    var notificator = new ConsoleLocatorNotificator((string text) => Print(text, true));
    return new InstructionSender(repository, notificator);
}
static void Print(string text, bool highlight = false)
{
    Console.ResetColor();
    if (highlight)
        Console.ForegroundColor = ConsoleColor.Blue;

    Console.WriteLine(text);
}

static void Wait()
{
    Console.WriteLine();
    Print("Press enter to continue...");
    Console.ReadLine();
}