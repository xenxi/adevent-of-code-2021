using FluentAssertions;
using NUnit.Framework;

namespace GiantSquid.Tests
{
    [TestFixture]
    public class BingoSolverFeature
    {
        [TestCase("7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1\r\n\r\n22 13 17 11  0\r\n 8  2 23  4 24\r\n21  9 14 16  7\r\n 6 10  3 18  5\r\n 1 12 20 15 19\r\n\r\n 3 15  0  2 22\r\n 9 18 13 17  5\r\n19  8  7 25 23\r\n20 11 10 24  4\r\n14 21 16 12  6\r\n\r\n14 21 17 24  4\r\n10 16 15  9 19\r\n18  8 23 26 20\r\n22 11 13  6  5\r\n 2  0 12  3  7", 4512)]
        [TestCase("4,77,78,12,91,82,48,59,28,26,34,10,71,89,54,63,66,75,15,22,39,55,83,47,81\r\n\r\n64 75 20 77 82\r\n46 63 83 69 41\r\n44 15 73 35 61\r\n99 71  4 43 72\r\n76 81 93 23  0", 69579)]
        public void calcule_score_of_winner_board(string input, int expectedScore)
        {
            var solver = new BingoSolver(input);

            var winnerScore = solver.CalculeWinnerScore();

            winnerScore.Should().Be(expectedScore);
        }

        [Test]
        public void calcule_score_of_loser_board()
        {
            var solver = new BingoSolver("7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1\r\n\r\n22 13 17 11  0\r\n 8  2 23  4 24\r\n21  9 14 16  7\r\n 6 10  3 18  5\r\n 1 12 20 15 19\r\n\r\n 3 15  0  2 22\r\n 9 18 13 17  5\r\n19  8  7 25 23\r\n20 11 10 24  4\r\n14 21 16 12  6\r\n\r\n14 21 17 24  4\r\n10 16 15  9 19\r\n18  8 23 26 20\r\n22 11 13  6  5\r\n 2  0 12  3  7");

            var loserScore = solver.CalculeLoserScore();

            loserScore.Should().Be(1924);
        }
    }
}
