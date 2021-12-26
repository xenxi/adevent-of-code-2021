namespace GiantSquid;

public class BingoSolver
{
    private readonly StringBoardRepository _boardRepository;
    private readonly StringRandomNumberGenerator _randomNumberGenerator;

    public BingoSolver(string input)
    {
       _boardRepository = new StringBoardRepository(input);
        _randomNumberGenerator = new StringRandomNumberGenerator(input);
    }

    public int CalculeWinnerScore()
    {
        var game = new BingoGame(_randomNumberGenerator);

        foreach (var board in _boardRepository.GetAll())
            game.AddBoard(board);

        var winner = game.Play();

        return winner.Score();
    }
}
