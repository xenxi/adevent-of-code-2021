Print("### WELCOME TO: DIVE 3000 ###", highlight: true);
Wait();


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