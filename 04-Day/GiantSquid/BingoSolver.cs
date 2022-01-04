namespace GiantSquid;

public class BingoSolver
{
    private readonly StringBoardRepository _boardRepository;
    private readonly StringRandomNumberGenerator _randomNumberGenerator;
    private  readonly IList<Board> _solvedBoards;
    public BingoSolver(string input)
    {
       _boardRepository = new StringBoardRepository(input);
        _randomNumberGenerator = new StringRandomNumberGenerator(input);
        _solvedBoards = SolveBoards().ToList();
    }

    public int CalculeWinnerScore()
    {
        return _solvedBoards.First().Score();
    }

    private IEnumerable<Board> SolveBoards()
    {
        var game = new BingoGame(_randomNumberGenerator);

        foreach (var board in _boardRepository.GetAll())
            game.AddBoard(board);

        var playedBoards = game.Play();
        return playedBoards;
    }

    public int CalculeLoserScore()
    {
        return _solvedBoards.Last().Score();
    }
}
