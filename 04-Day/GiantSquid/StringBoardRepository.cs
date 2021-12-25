namespace GiantSquid;

public class StringBoardRepository
{
    private string input;

    public StringBoardRepository(string input)
    {
        this.input = input;
    }

    public IList<Board> GetAll()
    {
        var strLines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var lines = new List<List<int>>();
        foreach (var line in strLines)
        {
            var strNumbersInLine = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (strNumbersInLine.Count() == 5)
                lines.Add(strNumbersInLine.Select(x => int.Parse(x)).ToList());
        }
        var boards = new List<Board>();
        var group = lines.Take(5);

        while (group.Any())
        {
            boards.Add(new Board(group.ToList()));
            group = lines.Skip(5 * boards.Count).Take(5);
        }

        return boards;
    }
}