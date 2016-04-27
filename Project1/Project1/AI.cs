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
        Thread t;

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
            LinkedList<Move> moves = mg.legalCapturesRedAI(board.copyCurrent());
            if (moves.Count == 0)
            {
                moves = mg.legalMovesRed(board.copyCurrent());
            }
            
            int i = 0;
            Move bestMove = null;
            Boolean first = true;
            foreach (Move move in moves)
            {
                int alpha = Maximizer(move.getState(), maxDepth, depth, -11000, 11000);
                if (alpha > i||first)
                {
                    first = false;
                    i = alpha;
                    bestMove = move;
                }
            }
            return bestMove;
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
                while (alpha < beta&& moves.Count != 0)
                {
                    
                    Move move = moves.First();
                    moves.RemoveFirst();
                    int v = Minimizer(move.getState(), maxDepth, (currentDepth + 1), alpha, beta);
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
            int i = 0;
            Move bestMove = null;
            Boolean first = true;
            foreach ( Move move in moves)
            {
                int beta = Minimizer(move.getState(), maxDepth, depth, -11000, 11000);
                if (beta < i||first)
                {
                    first = false;
                    i = beta;
                    bestMove = move;
                }
            }
            return bestMove;
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
                while (alpha < beta&& moves.Count != 0)
                {
                    Move move = moves.First();
                    moves.RemoveFirst();
                    int v = Maximizer(move.getState(), maxDepth, (currentDepth + 1), alpha, beta);
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
        //Author: Kasper
        //call this whenever you wish to start the thread that finds the best move
        {
            this.isMaximizer = isMaximizer; //this is a variable that the entire AI object can read. It is needed in the threadCode.
            keepGoing = true;
            maxDepth = 1;
            t = new Thread(new ThreadStart(threadCode));
            t.Start();
        }

        public void killThread()
        //Author: Kasper
        //Use this to stop the thread
        {
            t.Abort();
            Console.WriteLine("AI searched to depth " + maxDepth);
        }
    }
}
