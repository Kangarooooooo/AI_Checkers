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
        int depth, maxDepth;
        Boolean isMaximizer;
        Move bestSuggestion;

        public AI(MoveGenerator mg)
        {
            depth = 0;
            maxDepth = 1;
            this.mg = mg;
            this.board = mg.boardReference;
        }
        
        public int[,] MaximizerStart(int maxDepth)
        //Author: Kasper
        //Call this first, then the Maximizer will be called until it is no longer relevant
        {

            Maximizer(board.copyCurrent(), maxDepth, 0, -11000, 11000);
            return null;
        }
        private int Maximizer(int[,] currentState, int maxDepth, int currentDepth, int alpha, int beta)
        {
            if (maxDepth == currentDepth)
            {
                return board.evaluate(currentState);
            }
            LinkedList<Move> moves = mg.legalCapturesBlackAI(currentState);
            if (moves.Count == 0)
            {
                moves = mg.legalMovesBlack(currentState);
            }

            if (moves.Count != 0)
            {
                while (alpha < beta)
                {
                    Move move = moves.First();
                    moves.RemoveFirst();
                    int v = Maximizer(move.getState(), maxDepth, currentDepth + 1, alpha, beta);
                    if (v > alpha)
                    {
                        alpha = v;
                    }
                }
                return alpha;
            }
            return -10000;
        }

        public int[,] MinimizerStart(int maxDepth)
        //Author: Kasper
        //Call this first, then the Maximizer will be called until it is no longer relevant
        {
            LinkedList<Move> moves = mg.legalCapturesBlackAI(board.copyCurrent());
            Minimizer(board.copyCurrent(), maxDepth, 0, -11000, 11000);
            return null;
        }
        private int Minimizer(int [,] currentState, int maxDepth, int currentDepth, int alpha, int beta)
        {
            
            if (maxDepth == currentDepth)
            {
                return board.evaluate(currentState);
            }
            LinkedList<Move> moves = mg.legalCapturesBlackAI(currentState);
            if (moves.Count == 0)
            {
               moves = mg.legalMovesBlack(currentState);
            }
            
            if (moves.Count != 0)
            {
                while (alpha < beta)
                {
                    Move move = moves.First();
                    moves.RemoveFirst();
                    int v = Maximizer(move.getState(), maxDepth, currentDepth + 1, alpha, beta);
                    if (v < beta)
                    {
                        beta = v;
                    }
                }
                return beta;
            }
            return 10000;
        }

        public void threadCode(Boolean isMaximizer)
        //Author: Kasper
        //Code to be called in a thread
        {

        }
    }
}
