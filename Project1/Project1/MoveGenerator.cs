using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class MoveGenerator
    {
        Board boardReference;
        int boardSize;

        public MoveGenerator(Board board)
        {
            boardReference = board;
            boardSize = boardReference.getBoardSize();         
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
                                    temp = boardReference.copy(currentState);
                                    temp[i + 2, j - 2] = temp[i, j];
                                    if (i == (boardSize - 1))
                                    {
                                        temp[i + 2, j - 2] = 2;
                                    }
                                    temp[i, j] = 0;
                                    temp[i + 1, j - 1] = 0;
                                    legalCapturesRed.AddLast(temp);
                                }
                            }
                            if (j < boardSize - 2)//Can capture to right
                            {
                                if (currentState[i + 1, j + 1] < 0 && currentState[i + 2, j + 2] == 0)//Piece to capture and space to do it.
                                {
                                    temp = boardReference.copy(currentState);
                                    temp[i + 2, j + 2] = temp[i, j];
                                    if (i == (boardSize - 1))
                                    {
                                        temp[i + 2, j + 2] = 2;
                                    }
                                    temp[i, j] = 0;
                                    temp[i + 1, j + 1] = 0;
                                    legalCapturesRed.AddLast(temp);
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
                                    temp = boardReference.copy(currentState);
                                    temp[i - 2, j - 2] = temp[i, j];
                                    temp[i, j] = 0;
                                    temp[i - 1, j - 1] = 0;
                                    legalCapturesRed.AddLast(temp);
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
                                    legalCapturesRed.AddLast(temp);
                                }
                            }
                        }
                    }
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
                                temp = boardReference.copy(currentState);
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
                                temp = boardReference.copy(currentState);
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
                                    temp = boardReference.copy(currentState);
                                    temp[i - 1, j - 1] = temp[i, j];
                                    temp[i, j] = 0;
                                    legalMovesRed.AddLast(temp);
                                }
                            }
                            if (j < boardSize - 1)
                            {
                                if (currentState[i - 1, j + 1] == 0)
                                {
                                    temp = boardReference.copy(currentState);
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
            return legalMovesRed(boardReference.copyCurrent());
        }

    }
}