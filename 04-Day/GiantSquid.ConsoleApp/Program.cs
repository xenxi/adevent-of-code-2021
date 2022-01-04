using GiantSquid;

Print("### WELCOME TO: BINGO SOLVER 1999 ###", highlight: true);
Wait();
var input = File.ReadAllText("input.txt");
Print(input);

var bingoSolver = new BingoSolver(input);

//Print($"Winner score: {bingoSolver.CalculeWinnerScore()}");
Print($"Loser score: {bingoSolver.CalculeLoserScore()}");

static void Print(string text, bool highlight = false)
{
    Console.ResetColor();
    if (highlight)
        Console.ForegroundColor = ConsoleColor.Red;

    Console.WriteLine(text);
}


static void Wait()
{
    Console.WriteLine();
    Print("Press enter to continue...");
    Console.ReadLine();
}