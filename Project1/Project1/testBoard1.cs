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
            Console.WriteLine("Testing the board\n");
            board.showBoard();
            Console.ReadLine(); //press enter to close, dimwit
        }
    }
}