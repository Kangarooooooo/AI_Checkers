using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class AI
    {
        MoveGenerator mg;
        Board board;
        public AI(MoveGenerator mg, Board board)
        {
            this.mg = mg;
            this.board = board;
        }

        public int Minimizer(int[,] move)
        {
            return 0;
        }
        public int Maximizer(int[,] move)
        {
            return 0;
        }
    }
}
