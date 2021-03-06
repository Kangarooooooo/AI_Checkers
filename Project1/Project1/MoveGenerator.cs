﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class MoveGenerator
    {
        public Board boardReference;
        int boardSize;

        public MoveGenerator(Board board)
        {
            boardReference = board;
            board.setMoveGenerator(this);
            boardSize = boardReference.getBoardSize();         
        }

        //Author Kangarooooooo
        public Boolean canPieceCapture(int[,] currentState, int x, int y)
        {
            //Console.WriteLine("canPieceCapture called with x=" + x + " and y=" + y);
            if (currentState[x, y] > 0)//Is red
            {
                //Console.Write("RedMan");
                if (x < boardSize - 2)//Can capture forward
                {
                    //Console.Write("Up");
                    if (y > 1)//Can capture to left
                    {
                        //Console.Write("Left");
                        if ((currentState[x + 1, y - 1] < 0) && (currentState[x + 2, y - 2] == 0))//Piece to capture, and space to do it.
                        {
                            //Console.Write("-TRUE");
                            return true;
                        }
                    }
                    if (y < boardSize - 2)//Can capture to right
                    {
                        //Console.Write("Right");
                        if ((currentState[x + 1, y + 1] < 0) && (currentState[x + 2, y + 2] == 0))//Piece to capture and space to do it.
                        {
                            //Console.Write("-TRUE");
                            return true;
                        }
                    }
                }
            }
            if (currentState[x, y] > 1)//Is king
            {
                if (x > 1)//Can capture backwards
                {
                    if (y > 1)//Can capture to left
                    {
                        if ((currentState[x - 1, y - 1] < 0) && (currentState[x - 2, y - 2] == 0))//Piece to capture, and space to do it.
                        {
                            return true;
                        }
                    }
                    if (y < boardSize - 2)//Can capture to the right
                    {
                        if ((currentState[x - 1, y + 1] < 0) && (currentState[x - 2, y + 2] == 0))//Piece to capture and space to do it.
                        {
                            return true;
                        }
                    }
                }
            }
            if (currentState[x, y] < 0)//Is black
            {
                // Console.Write("BlackMan");
                if (x > 1)//Can capture downwards
                {
                    //Console.Write("Down");
                    if (y > 1)//Can capture to left
                    {
                        //Console.Write("Left");
                        if ((currentState[x - 1, y - 1] > 0) && (currentState[x - 2, y - 2] == 0))//Piece to capture, and space to do it.
                        {
                            //Console.Write("-TRUE");
                            return true;
                        }
                    }
                    if (y < boardSize - 2)//Can capture to the right
                    {
                        //Console.Write("Right");
                        if ((currentState[x - 1, y + 1] > 0) && (currentState[x - 2, y + 2] == 0))//Piece to capture and space to do it.
                        {
                            //Console.Write("-TRUE");
                            return true;
                        }
                    }
                }
            }
            if (currentState[x, y] < -1)//Is black king
            {
                if (x < boardSize - 2)//Can capture forward
                {
                    if (y > 1)//Can capture to left
                    {
                        if ((currentState[x + 1, y - 1] > 0) && (currentState[x + 2, y - 2] == 0))//Piece to capture, and space to do it.
                        {
                            return true;
                        }
                    }
                    if (y < boardSize - 2)//Can capture to right
                    {
                        if ((currentState[x + 1, y + 1] > 0) && (currentState[x + 2, y + 2] == 0))//Piece to capture and space to do it.
                        {
                            return true;
                        }
                    }
                }
            }
            //Console.WriteLine("CanPieceCapture never found TRUE\n");
            return false;
        }

        //Author Kangarooooooo
        public LinkedList<Move> legalCapturesRedAI(int [,] currentState)
        {
            LinkedList<Move>  moves = legalCapturesRed(currentState);
            Boolean b = false;
            do
            {
                LinkedList<Move> chain = new LinkedList<Move>();
                b = false;
                foreach (Move move in moves)
                {
                    if (canPieceCapture(move.getState(), move.getEndX(), move.getEndY()))
                    {
                        chain.AddLast(move);
                        b = true;
                    }
                }
                foreach (Move move in chain)
                {
                    LegalCapturesRedPiece(move.getState(), moves, move.getEndX(), move.getEndY());
                    moves.Remove(move);
                }
            }
            while (b);
            return moves;
        }
        public LinkedList<Move> legalCapturesBlackAI(int[,] currentState)
        {
            LinkedList<Move> moves = legalCapturesBlack(currentState);
            Boolean b = false;
            do
            {
                LinkedList<Move> chain = new LinkedList<Move>();
                b = false;
                foreach (Move move in moves)
                {
                    if (canPieceCapture(move.getState(), move.getEndX(), move.getEndY()))
                    {
                        chain.AddLast(move);
                        b = true;
                    }
                }
                foreach (Move move in chain)
                {
                    LegalCapturesBlackPiece(move.getState(), moves, move.getEndX(), move.getEndY());
                    moves.Remove(move);
                }
            }
            while (b);
            return moves;
        }

        //Author Kangarooooooo
        /// <summary>
        /// Method takes a boardstate and returns a list of legal boardstates, representating the legal captures given the current boardstate.List is empty if no legal moves exist.
        /// </summary>
        /// <param name="currentState"></param>
        /// <returns></returns>
        public LinkedList<Move> legalCapturesRed(int[,] currentState)
        {
            LinkedList<Move> legalCapturesRed = new LinkedList<Move>();
            //LinkedList<int[,]> legalCapturesRed = new LinkedList<int[,]>();
            int[,] temp = new int[boardSize, boardSize];
            for (int i = 0; i < boardSize; i++)//Check for legal captures
            {
                for (int j = 0; j < boardSize; j = j +2)
                {
                    LegalCapturesRedPiece(currentState, legalCapturesRed, i, j);
                }
                i++;
                for (int j = 1; j < boardSize; j = j + 2)
                {
                    LegalCapturesRedPiece(currentState, legalCapturesRed, i, j);
                }
            }
            return legalCapturesRed;
        }

        public void LegalCapturesRedPiece(int[,] currentState, LinkedList<Move> legalCapturesRed, int i, int j)
        {
            int[,] temp = new int[boardSize, boardSize];
            if (currentState[i, j] > 0)
            {
                if (i < boardSize - 2)//Can capture forward
                {
                    if (j > 1)//Can capture to left
                    {
                        if ((currentState[i + 1, j - 1] < 0) && (currentState[i + 2, j - 2] == 0))//Piece to capture, and space to do it.
                        {
                            temp = boardReference.copy(currentState);
                            temp[i + 2, j - 2] = temp[i, j];
                            if (i == (boardSize - 3))
                            {
                                temp[i + 2, j - 2] = 2;
                            }
                            temp[i, j] = 0;
                            temp[i + 1, j - 1] = 0;
                            legalCapturesRed.AddLast(new Move(temp, PlyToString(i, j, i + 2, j - 2), i + 2, j - 2));
                        }
                    }
                    if (j < boardSize - 2)//Can capture to right
                    {
                        if (currentState[i + 1, j + 1] < 0 && currentState[i + 2, j + 2] == 0)//Piece to capture and space to do it.
                        {
                            temp = boardReference.copy(currentState);
                            temp[i + 2, j + 2] = temp[i, j];
                            
                            if (i == (boardSize - 3))
                            {
                                temp[i + 2, j + 2] = 2;
                            }
                            temp[i, j] = 0;
                            temp[i + 1, j + 1] = 0;
                            legalCapturesRed.AddLast(new Move(temp, PlyToString(i, j, i + 2, j + 2), i + 2, j + 2));
                        }
                    }
                }
            }
            if (currentState[i, j] > 1)//Is red king
            {
                if (i > 1)//Can capture backwards
                {
                    if (j > 1)//Can capture to left
                    {
                        if ((currentState[i - 1, j - 1] < 0) && currentState[i - 2, j - 2] == 0)//Piece to capture, and space to do it.
                        {
                            temp = boardReference.copy(currentState);
                            temp[i - 2, j - 2] = temp[i, j];
                            temp[i, j] = 0;
                            temp[i - 1, j - 1] = 0;
                            legalCapturesRed.AddLast(new Move(temp, PlyToString(i, j, i - 2, j - 2), i - 2, j - 2));
                        }
                    }
                    if (j < boardSize - 2)//Can capture to the right
                    {
                        if (currentState[i - 1, j + 1] < 0 && currentState[i - 2, j + 2] == 0)//Piece to capture and space to do it.
                        {
                            temp = boardReference.copy(currentState);
                            temp[i - 2, j + 2] = temp[i, j];
                            temp[i, j] = 0;
                            temp[i - 1, j + 1] = 0;
                            legalCapturesRed.AddLast(new Move(temp, PlyToString(i, j, i - 2, j + 2), i - 2, j + 2));
                        }
                    }
                }
            }
        }

        public bool redHasFreeRun(int[,] boardState, int i, int j)
        {
            int w = 1;
            for (int y = i; y < boardSize; y++)
            {
                for (int x = j; x < boardSize && w > x - j; x++)
                {
                    if (0>boardState[y,x])
                    {
                        return false;
                    }

                }
                for (int x = j; x > -1&&w>Math.Abs(-x+j); x--)
                {
                    if (0 > boardState[y, x])
                    {
                        return false;
                    }
                }
                w++;
            }
            return true;
        }

        public bool blackHasFreeRun(int[,] boardState, int i, int j)
        {
            int w = 1;
            for (int y = i; y > -1; y--)
            {
                for (int x = j; x < boardSize && w > x - j; x++)
                {
                    if (0 < boardState[y, x])
                    {
                        return false;
                    }

                }
                for (int x = j; x > -1 && w > Math.Abs(-x + j); x--)
                {
                    if (0 < boardState[y, x])
                    {
                        return false;
                    }
                }
                w++;
            }
            return true;
        }

        public LinkedList<Move> legalCapturesRedNow()
        //Author: Kasper
        {
            return legalCapturesRed(boardReference.copyCurrent());
        }

        //Author Kangarooooooo
        /// <summary>
        /// Method takes a boardstate and returns a list of legal boardstates, representating the legal captures given the current boardstate.List is empty if no legal moves exist.
        /// </summary>
        /// <param name="currentState"></param>
        /// <returns></returns>
        public LinkedList<Move> legalCapturesBlack(int[,] currentState)
        {
            LinkedList<Move> legalCapturesBlack = new LinkedList<Move>();
            //LinkedList<int[,]> legalCapturesBlack = new LinkedList<int[,]>();
            for (int i = 0; i < boardSize; i++)//Check for legal captures
            {
                for (int j = 0; j < boardSize; j = j + 2)
                {
                    LegalCapturesBlackPiece(currentState, legalCapturesBlack, i, j);
                }
                i++;
                for (int j = 1; j < boardSize; j=j+2)
                {
                    LegalCapturesBlackPiece(currentState, legalCapturesBlack, i, j);
                }
            }
            return legalCapturesBlack;
        }

        public void LegalCapturesBlackPiece(int[,] currentState, LinkedList<Move> legalCapturesBlack, int i, int j)
        {
            int[,] temp = new int[boardSize, boardSize];
            if (currentState[i, j] < 0)//Is black
            {
                if (i > 1)//Can capture backwards
                {
                    if (j > 1)//Can capture to left
                    {
                        if ((currentState[i - 1, j - 1] > 0) && currentState[i - 2, j - 2] == 0)//Piece to capture, and space to do it.
                        {
                            temp = boardReference.copy(currentState);
                            temp[i - 2, j - 2] = temp[i, j];
                            if (i == 2)
                            {
                                temp[i - 2, j - 2] = -2;
                            }
                            temp[i, j] = 0;
                            temp[i - 1, j - 1] = 0;
                            legalCapturesBlack.AddLast(new Move(temp, PlyToString(i, j, i - 2, j - 2), i - 2, j - 2));
                        }
                    }
                    if (j < boardSize - 2)//Can capture to the right
                    {
                        if (currentState[i - 1, j + 1] > 0 && currentState[i - 2, j + 2] == 0)//Piece to capture and space to do it.
                        {
                            temp = boardReference.copy(currentState);
                            temp[i - 2, j + 2] = temp[i, j];
                            if (i == 2)
                            {
                                temp[i - 2, j + 2] = -2;
                            }
                            temp[i, j] = 0;
                            temp[i - 1, j + 1] = 0;
                            legalCapturesBlack.AddLast(new Move(temp, PlyToString(i, j, i - 2, j + 2), i - 2, j + 2));
                        }
                    }
                }
            }
            if (currentState[i, j] < -1)//Is black king
            {
                if (i < boardSize - 2)//Can capture forward
                {
                    if (j > 1)//Can capture to left
                    {
                        if ((currentState[i + 1, j - 1] > 0) && currentState[i + 2, j - 2] == 0)//Piece to capture, and space to do it.
                        {
                            temp = boardReference.copy(currentState);
                            temp[i + 2, j - 2] = temp[i, j];
                            temp[i, j] = 0;
                            temp[i + 1, j - 1] = 0;
                            legalCapturesBlack.AddLast(new Move(temp, PlyToString(i, j, i + 2, j - 2), i + 2, j - 2));
                        }
                    }
                    if (j < boardSize - 2)//Can capture to right
                    {
                        if (currentState[i + 1, j + 1] > 0 && currentState[i + 2, j + 2] == 0)//Piece to capture and space to do it.
                        {
                            temp = boardReference.copy(currentState);
                            temp[i + 2, j + 2] = temp[i, j];
                            temp[i, j] = 0;
                            temp[i + 1, j + 1] = 0;
                            legalCapturesBlack.AddLast(new Move(temp, PlyToString(i, j, i + 2, j + 2), i + 2, j + 2));
                        }
                    }
                }
            }
        }

        public LinkedList<Move> legalCapturesBlackNow()
        //Author: Kasper
        {
            return legalCapturesBlack(boardReference.copyCurrent());
        }

        //Author Kangarooooooo
        /// <summary>
        /// Method takes a boardstate and returs a list of legal boardtates, representing the legal moves given the curent boardstate. List is empty if no legal moves exist.
        /// </summary>
        /// <param name="currentState"></param>
        /// <returns></returns>
        public LinkedList<Move> legalMovesRed(int[,] currentState)//return list of legalmoves
        {
            LinkedList<Move> legalMovesRed = new LinkedList<Move>();
            
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j = j + 2)
                {
                    legalMovesRedPiece(currentState, legalMovesRed, i, j);
                }
                i++;
                for (int j = 1; j < boardSize; j = j + 2)
                {
                    legalMovesRedPiece(currentState, legalMovesRed, i, j);
                }
            }
            return legalMovesRed;
        }

        private void legalMovesRedPiece(int[,] currentState, LinkedList<Move> legalMovesRed, int i, int j)
        {
            int[,] temp;
            if (currentState[i, j] > 0)//Current collors piece is present
            {
                if ((i < (boardSize - 1)) && (j > 0))//Check move above to left
                {
                    if (currentState[i + 1, j - 1] == 0)
                    {
                        temp = boardReference.copy(currentState);
                        temp[i + 1, j - 1] = temp[i, j];
                        if (i == (boardSize - 2))
                        {
                            temp[i + 1, j - 1] = 2; //upgrade if in endzone
                        }
                        temp[i, j] = 0;
                        legalMovesRed.AddLast(new Move(temp, PlyToString(i, j, i + 1, j - 1), i + 1, j - 1));
                    }
                }
                if ((i < (boardSize - 1)) && (j < (boardSize - 1)))//Check move above to right
                {
                    if (currentState[i + 1, j + 1] == 0)
                    {
                        temp = boardReference.copy(currentState);
                        temp[i + 1, j + 1] = temp[i, j];
                        if (i == (boardSize - 2))
                        {
                            temp[i + 1, j + 1] = 2; //upgrade if in endzone
                        }
                        temp[i, j] = 0;

                        legalMovesRed.AddLast(new Move(temp, PlyToString(i, j, i + 1, j + 1), i + 1, j + 1));
                    }
                }
            }
            if (currentState[i, j] > 1)//Current collors piece is present and a king
            {

                if (i > 0)
                {
                    if (j > 0)
                    {
                        if (currentState[i - 1, j - 1] == 0) //checking down left
                        {
                            temp = boardReference.copy(currentState);
                            temp[i - 1, j - 1] = temp[i, j];
                            temp[i, j] = 0;
                            legalMovesRed.AddLast(new Move(temp, PlyToString(i, j, i - 1, j - 1), i - 1, j - 1));
                        }
                    }
                    if (j < boardSize - 1)
                    {
                        if (currentState[i - 1, j + 1] == 0) //checking down right
                        {
                            temp = boardReference.copy(currentState);
                            temp[i - 1, j + 1] = temp[i, j];
                            temp[i, j] = 0;
                            legalMovesRed.AddLast(new Move(temp, PlyToString(i, j, i - 1, j + 1), i - 1, j + 1));
                        }
                    }
                }
            }
        }

        public LinkedList<Move> legalMovesRedNow()
        //Author: Kasper
        {
            return legalMovesRed(boardReference.copyCurrent());
        }

        //Author Kasper
        /// <summary>
        /// Method takes a boardstate and returs a list of legal boardtates, representing the legal moves given the curent boardstate. List is empty if no legal moves exist.
        /// </summary>
        /// <param name="currentState"></param>
        /// <returns></returns>
        public LinkedList<Move> legalMovesBlack(int[,] currentState)//return list of legalmoves
        {
            LinkedList<Move> legalMovesBlack = new LinkedList<Move>();
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j = j + 2)
                {
                    legalMovesBlackPiece(currentState, legalMovesBlack, i, j);
                }
                i++;
                for (int j = 1; j < boardSize; j = j + 2)
                {
                    legalMovesBlackPiece(currentState, legalMovesBlack, i, j);
                }
            }
            return legalMovesBlack;
        }

        private void legalMovesBlackPiece(int[,] currentState, LinkedList<Move> legalMovesBlack, int i, int j)
        {

            int[,] temp; ;
            if (currentState[i, j] < 0)//Current collors piece is present
            {
                if ((i > 0) && (j > 0))//Check move down left
                {
                    if (currentState[i - 1, j - 1] == 0)
                    {
                        temp = boardReference.copy(currentState);
                        temp[i - 1, j - 1] = temp[i, j];
                        if (i == 1)
                        {
                            temp[i - 1, j - 1] = -2; //upgrade if in endzone
                        }
                        temp[i, j] = 0;
                        legalMovesBlack.AddLast(new Move(temp, PlyToString(i, j, i - 1, j - 1), i - 1, j - 1));
                    }
                }
                if ((i > 0) && (j < (boardSize - 1)))//Check move down right
                {
                    if (currentState[i - 1, j + 1] == 0)
                    {
                        temp = boardReference.copy(currentState);
                        temp[i - 1, j + 1] = temp[i, j];
                        if (i == 1)
                        {
                            temp[i - 1, j + 1] = 2; //upgrade if in endzone
                        }
                        temp[i, j] = 0;

                        legalMovesBlack.AddLast(new Move(temp, PlyToString(i, j, i - 1, j + 1), i - 1, j + 1));
                    }
                }
            }
            if (currentState[i, j] < -1)//Current collors piece is present and a king
            {

                if (i < (boardSize - 1))
                {
                    if (j > 0)
                    {
                        if (currentState[i + 1, j - 1] == 0) //checking up left
                        {
                            temp = boardReference.copy(currentState);
                            temp[i + 1, j - 1] = temp[i, j];
                            temp[i, j] = 0;
                            legalMovesBlack.AddLast(new Move(temp, PlyToString(i, j, i + 1, j - 1), i + 1, j - 1));
                        }
                    }
                    if (j < (boardSize - 1))
                    {
                        if (currentState[i + 1, j + 1] == 0) //checking up right
                        {
                            temp = boardReference.copy(currentState);
                            temp[i + 1, j + 1] = temp[i, j];
                            temp[i, j] = 0;
                            legalMovesBlack.AddLast(new Move(temp, PlyToString(i, j, i + 1, j + 1), i + 1, j + 1));
                        }
                    }
                }
            }
        }

        public LinkedList<Move> legalMovesBlackNow()
        //Author: Kasper
        {
            return legalMovesBlack(boardReference.copyCurrent());
        }

        public String PlyToString(int oldx, int oldy, int newx, int newy)
        //Author: Kasper
        {
            String s = ""; //init string

            switch (oldy) //first number added here
            {
                case 0:
                    s = s + "a";
                    break;
                case 1:
                    s = s + "b";
                    break;
                case 2:
                    s = s + "c";
                    break;
                case 3:
                    s = s + "d";
                    break;
                case 4:
                    s = s + "e";
                    break;
                case 5:
                    s = s + "f";
                    break;
                case 6:
                    s = s + "g";
                    break;
                case 7:
                    s = s + "h";
                    break;
                default:
                    break;
            }

            s = s + "" + (oldx + 1)+" to "; //adding the second number + some more

            switch (newy) //third number added here
            {
                case 0:
                    s = s + "a";
                    break;
                case 1:
                    s = s + "b";
                    break;
                case 2:
                    s = s + "c";
                    break;
                case 3:
                    s = s + "d";
                    break;
                case 4:
                    s = s + "e";
                    break;
                case 5:
                    s = s + "f";
                    break;
                case 6:
                    s = s + "g";
                    break;
                case 7:
                    s = s + "h";
                    break;
                default:
                    break;
            }

            s = s + "" + (newx + 1);
            return s;
        }
        int charToInt(char s)
        {
            switch (s) { 
                case 'a':
                return 0;
                case 'b':
                    return 1;
                case 'c':
                    return 2;
                case 'd':
                    return 3;
                case 'e':
                    return 4;
                case 'f':
                    return 5;
                case 'g':
                    return 6;
                case 'h':
                    return 7;
                default:
                    return 0;
            }
        }
    }
}