using FluentAssertions;
using NUnit.Framework;

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
        private static Board GivenAnyBoard()
          => new Board(new int[,] { { 22, 13, 17, 11, 0 }, { 8, 2, 23, 4, 24 }, { 21, 9, 14, 16, 7 }, { 6, 10, 3, 18, 5 }, { 1, 12, 20, 15, 19 } });

    }
}
