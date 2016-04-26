using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project1
{
    class AI
    {
        MoveGenerator mg;
        Board board;
        int depth, maxDepth;
        Boolean isMaximizer,keepGoing;
        Move bestSuggestion;

        public AI(MoveGenerator mg)
        {
            depth = 0;
            maxDepth = 1;
            this.mg = mg;
            this.board = mg.boardReference;
        }
        
        public Move MaximizerStart(int maxDepth)
        //Author: Kasper
        //Call this first, then the Maximizer will be called until it is no longer relevant
        {

            Maximizer(board.copyCurrent(), maxDepth, 0, -11000, 11000);
            return null;
        }
        public int Maximizer(int[,] currentState, int maxDepth, int currentDepth, int alpha, int beta)
        {
            if (maxDepth == currentDepth)
            {
                return board.evaluate(currentState);
            }
            LinkedList<Move> moves = mg.legalCapturesRedAI(currentState);
            if (moves.Count == 0)
            {
                moves = mg.legalMovesRed(currentState);
            }

            if (moves.Count != 0)
            {
                while (alpha > beta)
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

        public Move MinimizerStart(int maxDepth)
        //Author: Kasper
        //Call this first, then the Maximizer will be called until it is no longer relevant
        {
            LinkedList<Move> moves = mg.legalCapturesBlackAI(board.copyCurrent());
            if (moves.Count == 0)
            {
                moves = mg.legalMovesBlack(board.copyCurrent());
            }
            int[] values = new int[moves.Count];
            int i = 0;
            Move bestMove;
            foreach ( Move move in moves)
            {
                int temp = Minimizer(move.getState(), maxDepth, 0, -11000, 11000);
                i++;
            }
            return null;
        }
        public int Minimizer(int [,] currentState, int maxDepth, int currentDepth, int alpha, int beta)
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

        public Move getBestSuggestion()
        {
            return bestSuggestion;
        }

        public void threadCode()
        //Author: Kasper
        //Code to be called in a thread, so that we can interrupt it!
        //this code will run, and will periodically update the value "bestSuggestion"
        //once the thread has been interrupted for any reason, call getBestSuggestion() to retrieve whatever result was most recently aquired
        {
            if (isMaximizer)
            {
                while (keepGoing)
                {
                    bestSuggestion = MaximizerStart(maxDepth);
                    maxDepth++;
                }
            } 
            else
            {
                while (keepGoing)
                {
                    bestSuggestion = MinimizerStart(maxDepth);
                    maxDepth++;
                }
            }
        }

        public void startFindMoveThread(Boolean isMaximizer)
        {
            this.isMaximizer = isMaximizer; //this is a variable that the entire AI object can read. It is needed in the threadCode.
            Thread t = new Thread(new ThreadStart(threadCode));
            t.Start();
        }
    }
}
