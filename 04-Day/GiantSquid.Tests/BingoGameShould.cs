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
            numberGenerator.Next().Returns(22, 13, 17, 11, 0);

            var winner = game.Play();

            winner.Should().Be(aGivenBoard);
        }
        [Test]
        public void return_second_board_as_the_winner()
        {
            var firtsBoard = GivenAnyBoard();
            var secondBoard = Board.From(new int[,] { { 3, 15, 0, 2, 22 }, { 9, 18, 13, 17, 5 }, { 19, 8, 7, 25, 23 }, { 20, 11, 10, 24, 4 }, { 14, 21, 16, 12, 6 } });
            game.AddBoard(firtsBoard);
            game.AddBoard(secondBoard);
            numberGenerator.Next().Returns(3, 15, 0, 2, 22);
           
            var winner = game.Play();

            winner.Should().Be(secondBoard);
        }

        [SetUp]
        public void SetUp()
        {
            numberGenerator = Substitute.For<RandomNumberGenerator>();
            game = new BingoGame(numberGenerator);
        }

        private static Board GivenAnyBoard()
            =>  Board.From(new int[,] { { 22, 13, 17, 11, 0 }, { 8, 2, 23, 4, 24 }, { 21, 9, 14, 16, 7 }, { 6, 10, 3, 18, 5 }, { 1, 12, 20, 15, 19 } });
    }
}