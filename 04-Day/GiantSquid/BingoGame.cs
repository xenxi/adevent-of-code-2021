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

    public IEnumerable<Board> Play()
    {
        var solvedBoards = new List<Board>();
        var boardsToSolve = Boards.ToList();
        var playedNumbers = new List<int>();
        while (boardsToSolve.Any())
        {
            var number = numberGenerator.Next();
            if (playedNumbers.Contains(number))
                throw new DuplicateNumberException();

            playedNumbers.Add(number);
            boardsToSolve.ForEach(board => board.Play(number));
            var winner = boardsToSolve.FirstOrDefault(board => board.Bingo());

            if (winner != null)
            {
                boardsToSolve.Remove(winner);
                yield return winner;    
                solvedBoards.Add(winner);
            }
        }

        //return solvedBoards;
    }
}