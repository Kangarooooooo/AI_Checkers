using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Author: Repsack
Designed to represent the board and its knowledge about the pieces
*/

namespace Project1
{
    class Board
    {
        int[,] b; //2D array 'b' stores an int that represents the state of a given position on the board
        int boardSize;
        public Board()
        {
            boardSize = 8;
            b = new int[boardSize, boardSize]; //8x8 spaces representing the 64 field gameboard.
            startState(); //sets the pieces in the correct position
        }

        public Boolean redPawnSet(int x, int y) //places red pawn on the field (x,y) returns true if it succeeds
        {
            Boolean truth = false; //assumes that functioncall fails
            if (read(x, y) == 0) //checks if field is empty, represented by 0
            {
                truth = true; //success
                b[x, y] = 1; //place red pawn, represented by -1;
            }
            //should position (x,y) not be empty, no overwriting is made 
            return truth; //returns boolean representing success of this functioncall
        }

        public Boolean redKingSet(int x, int y) //places red king on the field (x,y) returns true if it succeeds
        {
            Boolean truth = false; //assumes that functioncall fails
            if (read(x, y) == 0) //checks if field is empty, represented by 0
            {
                truth = true; //success
                b[x, y] = 2; //place red king, represented by -1;
            }
            //should position (x,y) not be empty, no overwriting is made 
            return truth; //returns boolean representing success of this functioncall
        }

        public Boolean blackPawnSet(int x, int y) //places black pawn on the field (x,y) returns true if it succeeds
        {
            Boolean truth = false; //assumes that functioncall fails
            if(read(x, y) == 0) //checks if field is empty, represented by 0
            {
                truth = true; //success
                b[x, y] = -1; //place black pawn, represented by -1;
            }
            //should position (x,y) not be empty, no overwriting is made 
            return truth; //returns boolean representing success of this functioncall
        }

        public Boolean blackKingSet(int x, int y) //places black king on the field (x,y) returns true if it succeeds
        {
            Boolean truth = false; //assumes that functioncall fails
            if (read(x, y) == 0) //checks if field is empty, represented by 0
            {
                truth = true; //success
                b[x, y] = -2; //place king pawn, represented by -1;
            }
            //should position (x,y) not be empty, no overwriting is made 
            return truth; //returns boolean representing success of this functioncall
        }

        private void startState() //call this to place all the starting pieces in their correct positions
        {
            for (int i = 0; i < boardSize; i=i+2)
            {
                redPawnSet(0, i);
                redPawnSet(1, i+1); //should ofcourse be a pawn, but king is set just to test it
                redPawnSet(2, i);

                blackPawnSet(5, i+1);
                blackPawnSet(6, i); //should ofcourse be a pawn, but king is set just to test it
                blackPawnSet(7, i+1);
            }
        }

        public int read(int x, int y) //returns integer defining the type of piece on the specific field of the board
        /*
        -2 means black king
        -1 means black pawn
         0 means empty field
         1 means red pawn
         2 means red king
        */
        {
            return b[x, y];
        }
        
        public int evaluate() //evaluates the board with the red player as the maximizer.
        //it counts the number of red pieces on the board and subtracts the black pieces. Kings count for double!
        {
            int returnVal = 0; //board score
            for (int i = 0; i < boardSize; i++) //for each row (or is it row..?)
            {
                for (int j = 0; j < boardSize; j++) //for each column (or is it column..?)
                {
                    returnVal = returnVal + read(i, j); //add the piece value to the board score 
                }
            }
            return returnVal; //send back result
        }

        public Boolean remove(int x, int y) //designed to remove a piece from the board
        {
            Boolean truth = false; //assumes that there is nothing to delete
            if(read(x, y) != 0) //if there is a piece
            {
                truth = true; //success
                b[x, y] = 0; //force-clears the field
            }
            return truth; 
        }

        public void showBoard()
        {
            /*
            shows the board using the puUURtiest 5x3 ASCII artwork
            
            black pawn and king:
            xxxxx   xxxxx
            x   x   x k x
            xxxxx   xxxxx

            red pawn and king:
             ooo     ooo
            o   o   o k o
             ooo     ooo

            */

            //first we write the very top row (just a line encircling the entire board)
            showFullLine(); //draws a horizontal row
            

            //then we write all the rows that exist in between
            for (int i = boardSize - 1; i >= 0; i--)
            /*
            here we must count backwards! Due to the nature of typing out text, the top row must be made first
            we start from boardSize-1 because we can only read from entry 0 to 7 and not 8 inclusive
            */
            {
                showEmptyLine(); //draws a line with only vertical rows
                showTopBot(i); //draws the top/bottom row of the 5x3 artstyle for all spaces in row i. Top and bottom of the ASCII art are identical!
                showMiddle(i); //draws the middle row of the 5x3 artstyle for all spaces in row i
                showTopBot(i); 
                showEmptyLine();
                showFullLine();
            }
        }

        //a lot of functions used JUST for drawing..
        private void showFullLine()
        {
            Console.Write(" #"); //leading char for the new line
            for (int i = 0; i < boardSize; i++)
            {
                Console.Write("########"); //eight chars (+ the first char to begin. 9 chars with 7 empty spaces to encircle where there is room for the 5x3 piece-art)
            }
            Console.WriteLine(""); //newLine
        }

        private void showEmptyLine()
        {
            Console.Write(" #"); //leading char for the new line
            for (int i = 0; i < boardSize; i++)
            {
                Console.Write("       #"); //7 spaces + a char
            }
            Console.WriteLine(""); //newLine
        }

        private void showTopBot(int i) //top row of 5x3 ASCII art
        {
            Console.Write(" #"); //leading char for the new line
            for (int j = 0; j < boardSize; j++)
            {
                int piece = read(i, j);
                switch (piece)
                {
                    case (-2):
                        Console.Write(" xxxxx #");
                        break;
                    case (-1):
                        Console.Write(" xxxxx #");
                        break;
                    case (0):
                        Console.Write("       #");
                        break;
                    case (1):
                        Console.Write("  ooo  #");
                        break;
                    case (2):
                        Console.Write("  ooo  #");
                        break;
                    default:
                        //NOTHING, ERROR!
                        break;
                }
            }
            Console.WriteLine(""); //newLine
        }

        private void showMiddle(int i)
        {
            Console.Write(" #"); //leading char for the new line
            for (int j = 0; j < boardSize; j++)
            {
                int piece = read(i, j);
                switch (piece)
                {
                    case (-2):
                        Console.Write(" x K x #");
                        break;
                    case (-1):
                        Console.Write(" x   x #");
                        break;
                    case (0):
                        Console.Write("       #");
                        break;
                    case (1):
                        Console.Write(" o   o #");
                        break;
                    case (2):
                        Console.Write(" o K o #");
                        break;
                    default:
                        //NOTHING, ERROR!
                        break;
                }
            }
            Console.WriteLine(""); //newLine
        }

        //no more functions made for use in showing the board
    }
}
