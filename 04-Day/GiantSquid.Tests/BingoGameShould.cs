using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace GiantSquid.Tests
{
    [TestFixture]
    public class BingoGameShould
    {
        private BingoGame game;
        private RandomNumberGenerator numberGenerator;
        [Test]
        public void add_board()
        {
            var aGivenBoard = GivenAnyBoard();

            game.AddBoard(aGivenBoard);

            game.Boards.Should().OnlyContain(board => board == aGivenBoard);
        }

        [Test]
        public void return_winner_board()
        {
            var aGivenBoard = GivenAnyBoard();
            game.AddBoard(aGivenBoard);

            var winner = game.Play();

            winner.Should().Be(aGivenBoard);
        }

        [SetUp]
        public void SetUp()
        {
            numberGenerator = Substitute.For<RandomNumberGenerator>();
            game = new BingoGame(numberGenerator);
        }
        private static Board GivenAnyBoard()
            => new Board(new int[,] { { 22, 13, 17, 11, 0 }, { 8, 2, 23, 4, 24 }, { 21, 9, 14, 16, 7 }, { 6, 10, 3, 18, 5 }, { 1, 12, 20, 15, 19 } });
    }
}