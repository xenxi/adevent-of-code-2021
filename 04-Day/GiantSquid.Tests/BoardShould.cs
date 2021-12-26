using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GiantSquid.Tests
{
    [TestFixture]
    public class BoardShould 
    { 
        [Test]
        public void have_0_as_initial_score()
        {
            var board = GivenAnyBoard();

            var score = board.Score();

            score.Should().Be(0);
        }
        [Test]
        public void have_0_while_a_line_has_not_been_completed()
        {
            var board = GivenAnyBoard();
            foreach (var line in GivenAnyLines())
            {
                foreach (var number in line.Take(4))
                {
                    board.Play(number);
                }
            }

            var score = board.Score();

            score.Should().Be(0);
        }

        [Test]
        public void have_score_of_2607()
        {
            var board = GivenAnyBoard();
            board.Play(0);
            board.Play(13);
            board.Play(22);
            board.Play(17);
            board.Play(11);

            var score = board.Score();

            score.Should().Be(2607);
        }
        [Test]
        public void have_score_of_4488()
        {
            var board = GivenAnyBoard();
            board.Play(0);
            board.Play(13);
            board.Play(22);
            board.Play(17);
            board.Play(8);
            board.Play(2);
            board.Play(23);
            board.Play(4);
            board.Play(24);

            var score = board.Score();

            score.Should().Be(4488);
        }
        private static List<List<int>> GivenAnyLines() => new List<List<int>> { new List<int> { 22, 13, 17, 11, 0 }, new List<int> { 8, 2, 23, 4, 24 }, new List<int> { 21, 9, 14, 16, 7 }, new List<int> { 6, 10, 3, 18, 5 }, new List<int> { 1, 12, 20, 15, 19 } };
        private static Board GivenAnyBoard()
            => new Board(GivenAnyLines());

    }
}
