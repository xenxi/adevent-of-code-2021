using System;
using System.Collections.Generic;

namespace GiantSquid.Tests
{
    public class BingoGame
    {
        private List<Board> _boards = new List<Board>();
        public void AddBoard(Board board) => _boards.Add(board);

        public IReadOnlyList<Board> Boards => _boards.AsReadOnly();
    }
}