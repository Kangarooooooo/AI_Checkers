using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class testBoard1
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            MoveGenerator mg = new MoveGenerator(board);
            Console.WriteLine("This is the current board:\n");
            board.showBoard();
            Console.WriteLine("NOW we attempt to fetch the new moves:");
            LinkedList<Move> legalMoves = mg.legalMovesRedNow();
            Console.WriteLine("Size of legalMoves is: " + legalMoves.Count()+"\n");
            int n = 1;
            /*
            if (board.canPieceCapture(board.copyCurrent(), 2, 2))
            {
                Console.WriteLine("We can capture");
            }
            */
            foreach(Move move in legalMoves){
                Console.WriteLine("After-move-state number "+n+":");
                Console.WriteLine("moveString: "+move.getString()+"\n");
                n++;
            }
            Console.WriteLine("Now make a choice: (except you cant, yet)");
            Console.ReadLine(); //press enter to close, dimwit
        }
    }
}