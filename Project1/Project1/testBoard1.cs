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
            Console.WriteLine("Size of legalMoves is: " + legalMoves.Count());
            Board tempBoard;
            int n = 1;
            //*
            
            if (mg.canPieceCapture(board.copyCurrent(), 2, 2))
            {
                Console.WriteLine("We can capture");
            }
            /*/                       
            
            foreach (Move move in legalMoves){
                Console.WriteLine("After-move-state number "+n+":\n");
                tempBoard = new Board(move.getState());
                tempBoard.showBoardCustom(ConsoleColor.Green);
                n++;
            }
            //*/
            Console.WriteLine("Now make a choice: (except you cant, yet)");
            Console.ReadLine(); //press enter to close, dimwit
        }
    }
}