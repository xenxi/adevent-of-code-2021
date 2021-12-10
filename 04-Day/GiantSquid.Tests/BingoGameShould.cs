using FluentAssertions;
using NUnit.Framework;

namespace GiantSquid.Tests
{
    [TestFixture]
    public class BingoGameShould
    {
        [Test]
        public void add_board()
        {
            var aGivenBoard = new Board();
            var game = new BingoGame();

            game.AddBoard(aGivenBoard);

            game.Boards.Should().OnlyContain(board => board == aGivenBoard);
        }
    }
}