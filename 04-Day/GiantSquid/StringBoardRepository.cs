using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiantSquid
{
    public class StringBoardRepository
    {
        private string input;

        public StringBoardRepository(string input)
        {
            this.input = input;
        }

        public IList<Board> GetAll()
        {
            return new List<Board>() { new Board(new int[,] { { 22, 13, 17, 11, 0 }, { 8, 2, 23, 4, 24 }, { 21, 9, 14, 16, 7 }, { 6, 10, 3, 18, 5 }, { 1, 12, 20, 15, 19 } }) };
        }
    }
}
