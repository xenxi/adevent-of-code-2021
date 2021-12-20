namespace GiantSquid;

public class BingoGame
{
    private List<Board> _boards = new List<Board>();
    private RandomNumberGenerator numberGenerator;

    public BingoGame(RandomNumberGenerator numberGenerator)
    {
        this.numberGenerator = numberGenerator;
    }

    public IReadOnlyList<Board> Boards => _boards.AsReadOnly();

    public void AddBoard(Board board) => _boards.Add(board);
    public Board Play()
    {
        Board? winner = null;

        while (winner == null)
        {
            var number = numberGenerator.Next();
            _boards.ForEach(board => board.Play(number));
            winner = _boards.FirstOrDefault(board => board.Bingo());
        }

       return winner;
    }
}
