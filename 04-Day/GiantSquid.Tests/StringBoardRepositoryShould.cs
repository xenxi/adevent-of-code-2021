using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace GiantSquid.Tests
{
    public class StringBoardRepositoryShould
    {
        [Test]
        public void return_a_board()
        {
            var input = "22 13 17 11  0\r\n 8  2 23  4 24\r\n21  9 14 16  7\r\n 6 10  3 18  5\r\n 1 12 20 15 19";
            var generator = new StringBoardRepository(input);

            var boards = generator.GetAll();

            var expectedBoard = GivenAnyBoard();
            boards.Should().OnlyContain(board => board == expectedBoard);
        }
        [TestCase("7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1\r\n\r\n22 13 17 11  0\r\n 8  2 23  4 24\r\n21  9 14 16  7\r\n 6 10  3 18  5\r\n 1 12 20 15 19")]
        [TestCase("7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1\n22 13 17 11  0\r\n 8  2 23  4 24\r\n21  9 14 16  7\r\n 6 10  3 18  5\r\n 1 12 20 15 19")]
        public void return_a_board_ignore_rolls(string input)
        {
            var generator = new StringBoardRepository(input);

            var boards = generator.GetAll();

            var expectedBoard = GivenAnyBoard();
            boards.Should().OnlyContain(board => board == expectedBoard);
        }
        [Test]
        public void return_two_boards()
        {
            var input = "22 13 17 11  0\r\n 8  2 23  4 24\r\n21  9 14 16  7\r\n 6 10  3 18  5\r\n 1 12 20 15 19\r\n\r\n 3 15  0  2 22\r\n 9 18 13 17  5\r\n19  8  7 25 23\r\n20 11 10 24  4\r\n14 21 16 12  6";
            var generator = new StringBoardRepository(input);

            var boards = generator.GetAll();

            var expectedBoards = new List<Board> { GivenAnyBoard(), GivenAnyOtherBoard()};
            boards.Should().BeEquivalentTo(expectedBoards);
        }

        private static Board GivenAnyBoard()
          =>  Board.From(new int[,] { { 22, 13, 17, 11, 0 }, { 8, 2, 23, 4, 24 }, { 21, 9, 14, 16, 7 }, { 6, 10, 3, 18, 5 }, { 1, 12, 20, 15, 19 } });

        private static Board GivenAnyOtherBoard() => Board.From(new int[,] { { 3, 15, 0, 2, 22 }, { 9, 18, 13, 17, 5 }, { 19, 8, 7, 25, 23 }, { 20, 11, 10, 24, 4 }, { 14, 21, 16, 12, 6 } });

    }
}
