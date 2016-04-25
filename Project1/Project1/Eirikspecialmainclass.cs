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
            board.startState2();
            board.showBoard();
            legalCaptures = mg.legalCapturesRedAI(board.copyCurrent());
            foreach(Move move in legalCaptures)
            {
                board.doMove(move);
                board.showBoard();
            }

            Console.ReadLine();
        }
    }
}
