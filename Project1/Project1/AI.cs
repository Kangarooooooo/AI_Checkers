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
        int depth, maxdepth;

        public AI(MoveGenerator mg)
        {
            depth = 0;
            maxdepth = 10;
            this.mg = mg;
            this.board = mg.boardReference;
        }
        
        public void MaximizerStart()
        //Author: Kasper
        //Call this first, then the Maximizer will be called until it is no longer relevant
        {
            Move start = new Move(board.copyCurrent(),"",-1, -1);
            Maximizer(start);
        }
        public Move Maximizer(Move move)
        {
            return 0;
        }

        public void MinimizerStart()
        //Author: Kasper
        //Call this first, then the Maximizer will be called until it is no longer relevant
        {
            Move start = new Move(board.copyCurrent(), "", -1, -1);
            Maximizer(start);
        }
        public Move Minimizer(Move move)
        {
            return 0;
        }
    }
}
