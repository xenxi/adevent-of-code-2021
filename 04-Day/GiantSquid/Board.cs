namespace GiantSquid;

public class Board : IEquatable<Board?>
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

    public override bool Equals(object? obj)
    {
        return Equals(obj as Board);
    }

    public bool Equals(Board? other)
    {
        return other != null 
               && AllLinesAreEquals(lines, other.lines);
    }

    private bool AllLinesAreEquals(List<List<int>> lines1, List<List<int>> lines2)
    {
       if(lines1.Count != lines2.Count)
            return false;

        for (int i = 0; i < lines1.Count; i++)
        {
            var line1 = lines1.ElementAt(i);
            var line2 = lines2.ElementAt(i);

            if(!line1.SequenceEqual(line2))
                return false;
        }

        return true;
    }

    public void Play(int number)
    {
        calledNumbers.Add(number);
    }

    public static bool operator ==(Board? left, Board? right)
    {
        return EqualityComparer<Board>.Default.Equals(left, right);
    }

    public static bool operator !=(Board? left, Board? right)
    {
        return !(left == right);
    }
}