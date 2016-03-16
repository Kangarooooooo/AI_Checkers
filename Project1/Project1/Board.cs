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
        int[,] b; //2D array 'b' stores an int that represents 
        public Board()
        {
            b = new int[8, 8]; //8x8 spaces representing the 64 field gameboard.
        }

        public Boolean redPawnSet(int x, int y) //places red pawn on the field (x,y) returns true if it succeeds
        {
            Boolean truth = false; //assumes that functioncall fails
            if (b[x, y] == 0) //checks if field is empty, represented by 0
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
            if (b[x, y] == 0) //checks if field is empty, represented by 0
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
            if(b[x,y] == 0) //checks if field is empty, represented by 0
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
            if (b[x, y] == 0) //checks if field is empty, represented by 0
            {
                truth = true; //success
                b[x, y] = -2; //place king pawn, represented by -1;
            }
            //should position (x,y) not be empty, no overwriting is made 
            return truth; //returns boolean representing success of this functioncall
        }

    }
}
