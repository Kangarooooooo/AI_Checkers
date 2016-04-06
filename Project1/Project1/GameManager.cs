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

        private void playLoop(int color)
        //Author: Kasper
        {
            int win = 0;
            while (win == 0)
            {
                //pseudocode!!!!
                /*
                player1move();
                board.showBoard();
                win = checkWin();
                if(win!=0){break;}
                player2move();
                board.showBoard();
                win = checkWin();
                */
            }
        }

        private void player1move()
        //Author: Repsack
        {

        }

        private int checkWin()
        //Author: Kasper
        {
            if (board.legalMovesRed(board.copyCurrent()).Count==0)
            {
                return 2; //indicates that p2 wins 
            }
            if (false)
            {
                return 1; //indicates that p1 wins 
            }
            if (checkDraw())
            {
                return -1; //indicates that the game is over with no winners.
            }
            return 0; //no win yet
        }

        private Boolean checkDraw()
        //Author: Kasper
        {
            return false; //it is never a draw! or maybe this needs more work..
        }
    }
}
