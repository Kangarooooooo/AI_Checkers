using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Eirikspecialmainclass
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            MoveGenerator mg = new MoveGenerator(board);
            Move latestMove = new Move();
            LinkedList<Move> legalCaptures = new LinkedList<Move>();
            board.startState22();
            board.showBoard();/*
            legalCaptures = mg.legalCapturesBlackAI(board.copyCurrent());
            foreach(Move move in legalCaptures)
            {
                board.doMove(move);
                board.showBoard();
            }
            */
            for(int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    
                }
            }
            //mg.redHasFreeRun(board.getCurrentState(), 2, 2);
            Console.WriteLine(board.evaluate());
            Console.ReadLine();
        }
    }
}
