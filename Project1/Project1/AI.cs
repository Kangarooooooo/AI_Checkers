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
            Maximizer(board.copyCurrent(), maxDepth, 0, -11000, 11000);
        }
        public Move Maximizer(int[,] currentState, int maxDepth, int currentDepth, int alpha, int beta)
        {
            return null;
        }

        public void MinimizerStart(int maxDepth)
        //Author: Kasper
        //Call this first, then the Maximizer will be called until it is no longer relevant
        {
            Minimizer(board.copyCurrent(), maxDepth, 0, -11000, 11000);
        }
        public int Minimizer(int [,] currentState, int maxDepth, int currentDepth, int alpha, int beta)
        {
            if (maxDepth == currentDepth)
            {
                return board.evaluate(currentState);
            }
            LinkedList<Move> moves = mg.legalCapturesBlackAI(currentState);
            if (moves.Count != 0)
            {


            }
            moves = mg.legalMovesBlack(currentState);
            if (moves.Count != 0)
            {

            }
            return 10000;
        }
    }
}
