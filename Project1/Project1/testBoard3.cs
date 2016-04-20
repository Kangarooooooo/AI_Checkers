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
            Boolean cap;
            Board board = new Board();
            MoveGenerator mg = new MoveGenerator(board);
            LinkedList<Move> legalActions,legalMoves=new LinkedList<Move>(),legalCaptures;
            board.startState3();
            Console.WriteLine("This is the current board:\n");
            int n, choice,testCount;
            while (Math.Abs(board.evaluate()) < 1000) //no one is a winrar yet
            {
                testCount = 0;
                cap = true;
                do
                {
                    if (testCount > 0)
                    {
                        Console.WriteLine("Red do-while went through a second time!");
                    }
                    board.showBoard();
                    Console.WriteLine("Red player must now choose a possible move:\n");
                    legalCaptures = mg.legalCapturesRedNow();
                    if (legalCaptures.Count == 0)
                    {
                        cap = false;
                        legalMoves = mg.legalMovesRedNow();
                    }
                    else
                    {
                        legalMoves = new LinkedList<Move>();
                    }
                    legalActions = new LinkedList<Move>(legalMoves.Concat(legalCaptures));
                    n = 1;
                    foreach (Move move in legalActions)
                    {
                        Console.WriteLine("   " + n + ". move: " + move.getString() + "\n");
                        n++;
                    }
                    Console.WriteLine("\nWhich move will red player choose? enter a number");
                    choice = Int32.Parse(Console.ReadLine());
                    board.doMove(legalActions.ElementAt(choice - 1));
                    testCount++;
                }
                while (cap && mg.canPieceCapture(board.copyCurrent(), legalActions.ElementAt(choice - 1).getEndX(), legalActions.ElementAt(choice - 1).getEndY()));

                testCount = 0;
                cap = true;
                do {
                    if (testCount > 0)
                    {
                        Console.WriteLine("Red do-while went through a second time!");
                    }
                    board.showBoard();
                    Console.WriteLine("Black player must now choose a possible move:\n");
                    legalCaptures = mg.legalCapturesBlackNow();
                    if (legalCaptures.Count == 0)
                    {
                        cap = false;
                        legalMoves = mg.legalMovesBlackNow();
                    }
                    else
                    {
                        legalMoves = new LinkedList<Move>();
                    }
                    legalActions = new LinkedList<Move>(legalMoves.Concat(legalCaptures));
                    n = 1;
                    foreach (Move move in legalActions)
                    {
                        Console.WriteLine("   " + n + ". move: " + move.getString() + "\n");
                        n++;
                    }
                    Console.WriteLine("\nWhich move will black player choose? enter a number");
                    choice = Int32.Parse(Console.ReadLine());
                    board.doMove(legalActions.ElementAt(choice - 1));
                    testCount++;
                } while (cap && mg.canPieceCapture(board.copyCurrent(), legalActions.ElementAt(choice - 1).getEndX(), legalActions.ElementAt(choice - 1).getEndY()));
            }
            board.showBoard();
            Console.WriteLine("Loop terminated, win?");
            Console.ReadLine();
        }
    }
}
