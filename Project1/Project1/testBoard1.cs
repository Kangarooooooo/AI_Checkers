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
            Console.WriteLine("This is the current board:\n");
            board.showBoard();
            Console.WriteLine("NOW we attempt to fetch the new moves:");
            LinkedList<int[,]> legalMoves = board.legalMovesRedNow();
            Console.WriteLine("Size of legalMoves is: " + legalMoves.Count());
            Board tempBoard;
            int n = 1;
            foreach(int[,] matrix in legalMoves){
                Console.WriteLine("After-move-state number "+n);
                tempBoard = new Board(matrix);
                tempBoard.showBoard();
                n++;
            }
            Console.WriteLine("Now make a choice: (except you cant, yet)");
            Console.ReadLine(); //press enter to close, dimwit
        }
    }
}