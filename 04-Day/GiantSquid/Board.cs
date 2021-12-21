namespace GiantSquid;

public class Board
{
    private readonly List<List<int>> lines;
    private List<int> calledNumbers = new List<int>();

    public Board(int[,] numbers)
    {
        this.lines = new List<List<int>>();
        var numOfRows = numbers.GetLength(0);
        var numOfColumns = numbers.GetLength(1);
        for (int i = 0; i < numOfRows; i++)
        {
            var line = new List<int>();
            for (int j = 0; j < numOfColumns; j++)
                line.Add(numbers[i, j]);

            lines.Add(line);
        }
    }

    public bool Bingo()
    {
        foreach (var line in lines)
        {
            if (line.All(number => calledNumbers.Contains(number)))
            {
                return true;
            }
        }
        return false;
    }

    public void Play(int number)
    {
        calledNumbers.Add(number);
    }
}