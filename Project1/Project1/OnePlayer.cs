using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class OnePlayer
    {
        Boolean cap;
        Board board;
        MoveGenerator mg;
        Move latestMove;
        LinkedList<Move> legalActions, legalMoves, legalCaptures;
        int n, choice, testCount;

        public OnePlayer()
        {
            board = new Board();
            mg = new MoveGenerator(board);
            latestMove = new Move();
            legalCaptures = new LinkedList<Move>();
            int n, choice, testCount;
            board.startState();
            Console.WriteLine("Do you want to play first or not? 1 for first, 0 for second");
            choice = Int32.Parse(Console.ReadLine());

            if (choice == 1)
            {
                playerFirstLoop();
            }
            else
            {
                AIFirstLoop();
            }
        }

        void playerFirstLoop()
        {
            while (Math.Abs(board.evaluate()) < 1000) //no one is a winrar yet
            {
                playred();
                checkWin();
                if (checkWin() != 0)
                {
                    break;
                }
                AIblack();
                if (checkWin() != 0)
                {
                    break;
                }
            }
        }

        void AIFirstLoop()
        {
            while (Math.Abs(board.evaluate()) < 1000) //no one is a winrar yet
            {
                playblack();
                checkWin();
                if (checkWin() != 0)
                {
                    break;
                }
                AIred();
            }
        }

        int checkWin()
        {
            if (board.evaluate() > 1000)
            {
                return 1; //starting player/AI wins
            }
            else if(board.evaluate() < -1000)
            {
                return -1; //non-starting player/AI wins
            }
            else
            {
                return 0;
            }
        }
    }
}
