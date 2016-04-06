using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Author: Kasper
This manages the game, as in checkers rules are enforced from here.
*/

namespace Project1
{
    public class GameManager
    {
        Board board;
        public GameManager()
        //Author: Kasper
        {
            board = new Board();
            Console.WriteLine("Welcome to checkers. A game for the cleverestest of people!");
            Console.WriteLine("Which color does the player have? 1 for white, 2 for black");
            int color;
            String s = Console.ReadLine();
            if (Int32.TryParse(s, out color))
                Console.WriteLine("Color chosen.");
            else
                Console.WriteLine("String \""+s+"\" could not be interpreted as a number! YouDonGoofed");
            board.showBoard();
            playLoop(color);
        }

        private playLoop(int color)
        //Author: Kasper
        {

        }
    }
}
