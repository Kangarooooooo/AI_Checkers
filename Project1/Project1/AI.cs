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
        
        public void MaximizerStart(int maxDepth)
        //Author: Kasper
        //Call this first, then the Maximizer will be called until it is no longer relevant
        {
            Move start = new Move(board.copyCurrent(),"",-1, -1);
            Maximizer(start, maxDepth, 0);
        }
        public Move Maximizer(Move move, int maxDepth, int currentDepth)
        {
            return null;
        }

        public void MinimizerStart(int maxDepth)
        //Author: Kasper
        //Call this first, then the Maximizer will be called until it is no longer relevant
        {
            Move start = new Move(board.copyCurrent(), "", -1, -1);
            Minimizer(start, maxDepth, 0);
        }
        public int Minimizer(Move move, int maxDepth, int currentDepth)
        {
            if (maxDepth == currentDepth)
            {
                return board.evaluate(move.getState());

            }
            return 0;
        }
    }
}
