using System;

public class testBoard2
{
    static void Main(string[] args)
    {
        Board board = new Board();
        MoveGenerator = new Movegenerator(board);

        Console.WriteLine("This is the current board:\n");
        board.showBoard();
        Console.WriteLine("NOW we attempt to fetch the new moves:");
        LinkedList<int[,]> legalCaptures = board.
        LinkedList<int[,]> legalMoves = board.legalMovesRedNow();
        Console.WriteLine("Size of legalMoves is: " + legalMoves.Count());
        Board tempBoard;
        int n = 1;

        board.moveString();

        Console.WriteLine("Now make a choice: (except you cant, yet)");
        Console.ReadLine(); //press enter to close, dimwit
    }
}
