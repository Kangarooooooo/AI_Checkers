using System;
using System.Collections.Generic;
/*
Author: Kasper
Designed to represent the board and its knowledge about the pieces
*/

namespace Project1
{
    class Board
    {
        int[,] b; //2D array 'b' stores an int that represents the state of a given position on the board
        int boardSize;
        ConsoleColor //Color variables. Change to personal preferences if you like.
            curBase,
            P1 = ConsoleColor.Cyan,
            P2 = ConsoleColor.Red,
            king = ConsoleColor.Yellow,
            baseColor = ConsoleColor.Gray;
        LinkedList<int[,]> list = new LinkedList<int[,]>();
        public Board()
        //Author: Kasper
        {
            //Console.ForegroundColor = baseColor;
            boardSize = 8;
            b = new int[boardSize, boardSize]; //8x8 spaces representing the 64 field gameboard.
            startState(); //sets the pieces in the correct position
        }

        public Board(int[,] board)
        {
            //Console.ForegroundColor = baseColor;
            boardSize = 8;
            b = board; //8x8 spaces representing the 64 field gameboard.
        }
        //Author Kangarooooooo
        public int[,] copy(int[,] board)//Method that returns a new copy of the argument
        {
            int[,] copy = new int[boardSize, boardSize];

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    copy[i, j] = board[i, j];
                }
            }
            return copy;
        }

        public int[,] copyCurrent()
        //Author: Kasper
        {
            return copy(b);
        }

        //Author Kangarooooooo
        public Boolean canPieceCapture(int[,] currentState, int x, int y)
        {
            if (currentState[x, y] > 0)
            {
                if (x < boardSize - 2)//Can capture forward
                {
                    if (y > 1)//Can capture to left
                    {
                        if ((currentState[x + 1, y - 1] < 0) && currentState[x + 2, y - 2] == 0)//Piece to capture, and space to do it.
                        {
                            return true;
                        }
                    }
                    if (y < boardSize - 2)//Can capture to right
                    {
                        if (currentState[x + 1, y + 1] < 0 && currentState[x + 2, y + 2] == 0)//Piece to capture and space to do it.
                        {
                            return true;
                        }
                    }
                }
            }
            if (currentState[x, y] > -1)//Is king
            {
                if (x > 1)//Can capture backwards
                {
                    if (y > 1)//Can capture to left
                    {
                        if ((currentState[x - 1, y - 1] < 0) && currentState[x - 2, y - 2] == 0)//Piece to capture, and space to do it.
                        {
                            return true;
                        }
                    }
                    if (y < boardSize - 2)//Can capture to the right
                    {
                        if (currentState[x - 1, y + 1] < 0 && currentState[x - 2, y + 2] == 0)//Piece to capture and space to do it.
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //Author Kangarooooooo
        /// <summary>
        /// Method takes a boardstate and returns a list of legal boardstates, representating the legal captures given the current boardstate.List is empty if no legal moves exist.
        /// </summary>
        /// <param name="currentState"></param>
        /// <returns></returns>
        public LinkedList<int[,]> legalCapturesRed(int[,] currentState)//return list of legalmoves
        {
            LinkedList<int[,]> legalCapturesRed = new LinkedList<int[,]>();
            int[,] temp = new int[boardSize, boardSize];
            for (int i = 0; i < boardSize; i++)//Check for legal captures
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (currentState[i, j] > 0)
                    {
                        if (i < boardSize - 2)//Can capture forward
                        {
                            if (j > 1)//Can capture to left
                            {
                                if ((currentState[i + 1, j - 1] < 0) && currentState[i + 2, j - 2] == 0)//Piece to capture, and space to do it.
                                {
                                    temp = copy(currentState);
                                    temp[i + 2, j - 2] = temp[i, j];
                                    if (i == (boardSize - 2))
                                    {
                                        temp[i + 2, j - 2] = 2;
                                    }
                                    temp[i, j] = 0;
                                    legalCapturesRed.AddLast(temp);
                                }
                            }
                            if (j < boardSize - 2)//Can capture to right
                            {
                                if (currentState[i + 1, j + 1] < 0 && currentState[i + 2, j + 2] == 0)//Piece to capture and space to do it.
                                {
                                    return null;
                                }
                            }
                        }
                    }
                    if (currentState[i, j] > -1)//Is king
                    {
                        if (i > 1)//Can capture backwards
                    {
                            if (j > 1)//Can capture to left
                            {
                                if ((currentState[i - 1, j - 1] < 0) && currentState[i - 2, j - 2] == 0)//Piece to capture, and space to do it.
                                {
                                    return null;
                                }
                            }
                            if (j < boardSize - 2)//Can capture to the right
                        {
                                if (currentState[i - 1, j + 1] < 0 && currentState[i - 2, j + 2] == 0)//Piece to capture and space to do it.
                            {
                                    return null;
                                }
                            }
                        }
                    }
                    return null;
                }
            }
            return legalCapturesRed;
        }
        //Author Kangarooooooo
        /// <summary>
        /// Method takes a boardstate and returs a list of legal boardtates, representing the legal moves given the curent boardstate. List is empty if no legal moves exist.
        /// </summary>
        /// <param name="currentState"></param>
        /// <returns></returns>
        public LinkedList<int[,]> legalMovesRed(int[,] currentState)//return list of legalmoves
        {
            LinkedList<int[,]> legalMovesRed = new LinkedList<int[,]>();
            int[,] temp = new int[boardSize, boardSize];
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (currentState[i, j] > 0)//Current collors piece is present
                    {
                        if ((i < (boardSize - 1)) && (j > 0))//Check move above to left
                        {
                            if (currentState[i + 1, j - 1] == 0)
                            {
                                temp = copy(currentState);
                                temp[i + 1, j - 1] = temp[i, j];
                                if (i == (boardSize - 2))
                                {
                                    temp[i + 1, j - 1] = 2;
                                }
                                temp[i, j] = 0;
                                legalMovesRed.AddLast(temp);
                            }
                        }
                        if ((i < (boardSize - 1)) && (j < (boardSize - 1)))//Check move above to right
                        {
                            if (currentState[i + 1, j + 1] == 0)
                            {
                                temp = copy(currentState);
                                temp[i + 1, j + 1] = temp[i, j];
                                if (i == (boardSize - 2))
                                {
                                    temp[i + 1, j + 1] = 2;
                                }
                                temp[i, j] = 0;
                                legalMovesRed.AddLast(temp);
                            }
                        }
                    }
                    if (currentState[i, j] > 1)//Current collors piece is present and a king
                    {

                        if (i > 0)
                        {
                            if (j > 0)
                            {
                                if (currentState[i - 1, j - 1] == 0)
                                {
                                    temp = copy(currentState);
                                    temp[i - 1, j - 1] = temp[i, j];
                                    temp[i, j] = 0;
                                    legalMovesRed.AddLast(temp);
                                }
                            }
                            if (j < boardSize - 1)
                            {
                                if (currentState[i - 1, j + 1] == 0)
                                {
                                    temp = copy(currentState);
                                    temp[i - 1, j + 1] = temp[i, j];
                                    temp[i, j] = 0;
                                    legalMovesRed.AddLast(temp);
                                }
                            }
                        }
                    }
                }
            }
            return legalMovesRed;
        }

        public LinkedList<int[,]> legalMovesRedNow()
        //Author: Kasper
        {
            return legalMovesRed(copyCurrent());
        }

        public Boolean redManSet(int x, int y) //places red pawn on the field (x,y) returns true if it succeeds
        //Author: Kasper
        {
            Boolean truth = false; //assumes that functioncall fails
            if (read(x, y) == 0) //checks if field is empty, represented by 0
            {
                truth = true; //success
                b[x, y] = 1; //place red pawn, represented by 1;
            }
            //should position (x,y) not be empty, no overwriting is made 
            return truth; //returns boolean representing success of this functioncall
        }

        public Boolean redKingSet(int x, int y) //places red king on the field (x,y) returns true if it succeeds
        //Author: Kasper
        {
            Boolean truth = false; //assumes that functioncall fails
            if (read(x, y) == 0) //checks if field is empty, represented by 0
            {
                truth = true; //success
                b[x, y] = 2; //place red king, represented by 2;
            }
            //should position (x,y) not be empty, no overwriting is made 
            return truth; //returns boolean representing success of this functioncall
        }

        public Boolean blackManSet(int x, int y) //places black pawn on the field (x,y) returns true if it succeeds
        //Author: Kasper
        {
            Boolean truth = false; //assumes that functioncall fails
            if (read(x, y) == 0) //checks if field is empty, represented by 0
            {
                truth = true; //success
                b[x, y] = -1; //place black pawn, represented by -1;
            }
            //should position (x,y) not be empty, no overwriting is made 
            return truth; //returns boolean representing success of this functioncall
        }

        public Boolean blackKingSet(int x, int y) //places black king on the field (x,y) returns true if it succeeds
        //Author: Kasper
        {
            Boolean truth = false; //assumes that functioncall fails
            if (read(x, y) == 0) //checks if field is empty, represented by 0
            {
                truth = true; //success
                b[x, y] = -2; //place king pawn, represented by -2;
            }
            //should position (x,y) not be empty, no overwriting is made 
            return truth; //returns boolean representing success of this functioncall
        }

        public void moveString(int[,] moveState)
        /*Author: Kasper
        MIGHT NOT BE NEEDED
        designed to receive a list of 2D arrays, each array representing a new board state.
        Each new state has a change, from this change, it can be seen which move
        */
        {

        }

        private void startState() //call this to place all the starting pieces in their correct positions
        //Author: Kasper
        {
            for (int i = 0; i < boardSize; i = i + 2)
            {
                redManSet(0, i);
                redKingSet(1, i + 1); //should ofcourse be a pawn, but king is set just to test it
                redManSet(2, i);

                blackManSet(5, i + 1);
                blackKingSet(6, i); //should ofcourse be a pawn, but king is set just to test it
                blackManSet(7, i + 1);
            }
        }

        private void startState2() //TestingStart for testing tests
        //Author: Kasper
        {

            redKingSet(2, 2);
        }

        public int read(int x, int y) //returns integer defining the type of piece on the specific field of the board
        //Author: Kasper
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
        //Author: Kasper
        //it counts the number of red pieces on the board and subtracts the black pieces. Kings count for double!
        {
            int returnVal = 0; //board score
            for (int i = 0; i < boardSize; i++) //for each row
            {
                for (int j = 0; j < boardSize; j++) //for each column
                {
                    returnVal = returnVal + read(i, j); //add the piece value to the board score 
                }
            }
            return returnVal; //send back result
        }

        public Boolean remove(int x, int y) //designed to remove a piece from the board
        //Author: Kasper
        {
            Boolean truth = false; //assumes that there is nothing to delete
            if (read(x, y) != 0) //if there is a piece
            {
                truth = true; //success
                b[x, y] = 0; //force-clears the field
            }
            return truth;
        }

        public void showBoard()
        //Author: Kasper
        {
            showBoardCustom(baseColor);
        }

        public void showBoardCustom(ConsoleColor color)
        //Author: Kasper
        {
            curBase = color;
            Console.ForegroundColor = curBase;
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
            Console.WriteLine("");
            Console.ForegroundColor = baseColor;
        }

        //a lot of functions used JUST for drawing..
        private void showFullLine()
        //Author: Kasper
        {
            Console.Write(" #"); //leading char for the new line
            for (int i = 0; i < boardSize; i++)
            {
                Console.Write("########"); //eight chars (+ the first char to begin. 9 chars with 7 empty spaces to encircle where there is room for the 5x3 piece-art)
            }
            Console.WriteLine(""); //newLine
        }

        private void showEmptyLine()
        //Author: Kasper
        {
            Console.Write(" #"); //leading char for the new line
            for (int i = 0; i < boardSize; i++)
            {
                Console.Write("       #"); //7 spaces + a char
            }
            Console.WriteLine(""); //newLine
        }

        private void showTopBot(int i) //top row of 5x3 ASCII art
        //Author: Kasper
        {
            Console.Write(" #"); //leading char for the new line
            for (int j = 0; j < boardSize; j++)
            {
                int piece = read(i, j);
                switch (piece)
                {
                    case (-2):
                        Console.ForegroundColor = P1;
                        Console.Write("  xxx  ");
                        Console.ForegroundColor = curBase;
                        break;
                    case (-1):
                        Console.ForegroundColor = P1;
                        Console.Write("  xxx  ");
                        Console.ForegroundColor = curBase;
                        break;
                    case (0):
                        Console.Write("       ");
                        break;
                    case (1):
                        Console.ForegroundColor = P2;
                        Console.Write("  ooo  ");
                        Console.ForegroundColor = curBase;
                        break;
                    case (2):
                        Console.ForegroundColor = P2;
                        Console.Write("  ooo  ");
                        Console.ForegroundColor = curBase;
                        break;
                    default:
                        //NOTHING, ERROR!
                        break;
                }
                Console.Write("#");
            }
            Console.WriteLine(""); //newLine
        }

        private void showMiddle(int i)
        //Author: Kasper
        {
            Console.Write(" #"); //leading char for the new line
            for (int j = 0; j < boardSize; j++)
            {
                int piece = read(i, j);
                switch (piece)
                {
                    case (-2):
                        Console.ForegroundColor = P1;
                        Console.Write(" x ");
                        Console.ForegroundColor = king;
                        Console.Write("K");
                        Console.ForegroundColor = P1;
                        Console.Write(" x ");
                        Console.ForegroundColor = curBase;
                        break;
                    case (-1):
                        Console.ForegroundColor = P1;
                        Console.Write(" x   x ");
                        Console.ForegroundColor = curBase;
                        break;
                    case (0):
                        Console.Write("       ");
                        break;
                    case (1):
                        Console.ForegroundColor = P2;
                        Console.Write(" o   o ");
                        Console.ForegroundColor = curBase;
                        break;
                    case (2):
                        Console.ForegroundColor = P2;
                        Console.Write(" o ");
                        Console.ForegroundColor = king;
                        Console.Write("K");
                        Console.ForegroundColor = P2;
                        Console.Write(" o ");
                        Console.ForegroundColor = curBase;
                        break;
                    default:
                        //NOTHING, ERROR!
                        break;
                }
                Console.Write("#");
            }
            Console.WriteLine(""); //newLine
        }

        //no more functions made for use in showing the board
    }
}
