using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace GiantSquid.Tests
{
    [TestFixture]
    public class BingoGameShould
    {
        [Test]
        public void add_board()
        {
            var numberGenerator = Substitute.For<RandomNumberGenerator>();
            var game = new BingoGame(numberGenerator);
            var aGivenBoard = GivenAnyBoard();

            game.AddBoard(aGivenBoard);

            game.Boards.Should().OnlyContain(board => board == aGivenBoard);
        }

        [Test]
        public void return_winner_board()
        {
            var numberGenerator = Substitute.For<RandomNumberGenerator>();
            var game = new BingoGame(numberGenerator);
            var aGivenBoard = GivenAnyBoard();
            game.AddBoard(aGivenBoard);

            var winner = game.Play();

            winner.Should().Be(aGivenBoard);
        }

        private static Board GivenAnyBoard()
            => new Board(new int[,] { { 22, 13, 17, 11, 0 }, { 8, 2, 23, 4, 24 }, { 21, 9, 14, 16, 7 }, { 6, 10, 3, 18, 5 }, { 1, 12, 20, 15, 19 } });
    }
}