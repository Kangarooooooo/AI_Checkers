using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class testBoard3
    {
        static void Main(string[] args)
        {
            Boolean pigs = true, ableToFly = false;
            Board board = new Board();
            MoveGenerator mg = new MoveGenerator(board);
            LinkedList<Move> legalMoves;
            board.startState();
            Console.WriteLine("This is the current board:\n");
            board.showBoard();
            int n, choice;
            while (pigs != ableToFly)
            {
                Console.WriteLine("Red player must now choose a possible move:\n");
                legalMoves = mg.legalMovesRedNow();
                n = 1;
                foreach (Move move in legalMoves)
                {
                    Console.WriteLine("   "+n+". move: " + move.getString() + "\n");
                    n++;
                }
                Console.WriteLine("\nWhich move will red player choose? enter a number");
                choice = Int32.Parse(Console.ReadLine());
                board.doMove(legalMoves.ElementAt(choice - 1));

                Console.WriteLine("Black player must now choose a possible move:\n");
                legalMoves = mg.legalMovesBlackNow();
                n = 1;
                foreach (Move move in legalMoves)
                {
                    Console.WriteLine("   " + n + ". move: " + move.getString() + "\n");
                    n++;
                }
                Console.WriteLine("\nWhich move will black player choose? enter a number");
                choice = Int32.Parse(Console.ReadLine());
                board.doMove(legalMoves.ElementAt(choice - 1));
            }
        }
    }
}
