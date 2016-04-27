﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class OnePlayer
    /*
    start this if you only want to play by yourself
    */
    {
        AI ai;
        Boolean cap;
        Board board;
        MoveGenerator mg;
        Move latestMove;
        LinkedList<Move> legalActions, legalMoves, legalCaptures;
        int n, choice, testCount, maxWorkTime;

        public OnePlayer()
        {
            board = new Board();
            mg = new MoveGenerator(board);
            latestMove = new Move();
            ai = new AI(mg);
            legalCaptures = new LinkedList<Move>();
            maxWorkTime = 15000; //means 15 thousand milliseconds of worktime
            board.startState();
            Console.WriteLine("Do you want to play first or not? 1 for first, 0 for second");
            choice = Int32.Parse(Console.ReadLine());
            board.showBoard();
            if (choice == 1)
            {
                playerFirstLoop();
            }
            else
            {
                AIFirstLoop();
            }
        }

        void playerFirstLoop() //player plays first here
        {
            while (Math.Abs(board.evaluate()) < 1000) //no one is a winrar yet
            {
                playred();
                checkWin();
                if (checkWin() != 0)
                {
                    break;
                }
                AIblack();
                if (checkWin() != 0)
                {
                    break;
                }
            }
            endGameMessage();
        }

        void AIFirstLoop() //player plays last here
        {

            while (Math.Abs(board.evaluate()) < 1000) //no one is a winrar yet
            {
                AIred();
                checkWin();
                if (checkWin() != 0)
                {
                    break;
                }
                playblack();
                if (checkWin() != 0)
                {
                    break;
                }
            }
            endGameMessage();
        }

        int checkWin() //used to detect if anyone has definately won
        {
            if (board.evaluate() > 1000)
            {
                return 1; //starting player/AI wins
            }
            else if(board.evaluate() < -1000)
            {
                return -1; //non-starting player/AI wins
            }
            else
            {
                return 0; //no winrar
            }
        }

        void playred() //stolen directly from TwoPlayer
        {
            testCount = 0;
            cap = true;
            do
            {
                if (testCount > 0)
                {
                    Console.WriteLine("Red do-while went through a second time!");
                }
                Console.WriteLine("Red player must now choose a possible move:\n");
                if (testCount < 1)
                {
                    legalCaptures = mg.legalCapturesRedNow();
                }
                else
                {
                    legalCaptures = new LinkedList<Move>();
                    mg.LegalCapturesRedPiece(board.copyCurrent(), legalCaptures, latestMove.getEndX(), latestMove.getEndY());
                }
                if (legalCaptures.Count == 0)
                {
                    cap = false;
                    legalMoves = mg.legalMovesRedNow();
                }
                else
                {
                    legalMoves = new LinkedList<Move>(); //this list must be initialized
                }
                if (testCount > 0) //if this is the second time the loop goes around, there cannot be a legal non-capture move
                {
                    legalMoves = new LinkedList<Move>();
                }

                legalActions = new LinkedList<Move>(legalMoves.Concat(legalCaptures));
                n = 1;
                foreach (Move move in legalActions)
                {
                    Console.WriteLine("   " + n + ". move: " + move.getString());
                    n++;
                }
                if (legalActions.Count > 0)
                {
                    Console.WriteLine("\nWhich move will red player choose? enter a number");
                    choice = Int32.Parse(Console.ReadLine());
                    latestMove = legalActions.ElementAt(choice - 1);
                    board.doMove(latestMove);
                    board.showBoard();
                    testCount++;
                }
            }
            while (cap);
        }

        void playblack() //stolen directly from TwoPlayer
        {
            testCount = 0;
            cap = true;
            do
            {
                if (testCount > 0)
                {
                    Console.WriteLine("Black do-while went through a second time!");
                }
                Console.WriteLine("Black player must now choose a possible move:\n");
                if (testCount < 1)
                {
                    legalCaptures = mg.legalCapturesBlackNow();
                }
                else
                {
                    legalCaptures = new LinkedList<Move>();
                    mg.LegalCapturesBlackPiece(board.copyCurrent(), legalCaptures, latestMove.getEndX(), latestMove.getEndY());
                }
                if (legalCaptures.Count == 0)
                {
                    cap = false;
                    legalMoves = mg.legalMovesBlackNow();
                }
                else
                {
                    legalMoves = new LinkedList<Move>(); //this list must be initialized
                }
                if (testCount > 0) //if this is the second time the loop goes around, there cannot be a legal non-capture move
                {
                    legalMoves = new LinkedList<Move>();

                }

                legalActions = new LinkedList<Move>(legalMoves.Concat(legalCaptures));
                n = 1;
                foreach (Move move in legalActions)
                {
                    Console.WriteLine("   " + n + ". move: " + move.getString());
                    n++;
                }
                if (legalActions.Count > 0)
                {
                    Console.WriteLine("\nWhich move will black player choose? enter a number");
                    choice = Int32.Parse(Console.ReadLine());
                    latestMove = legalActions.ElementAt(choice - 1);
                    board.doMove(latestMove);
                    board.showBoard();
                    testCount++;
                }
            }
            while (cap);
        }

        public void AIred()
        {
            Console.WriteLine("AI is planning its move...\n");
            ai.startFindMoveThread(true);
            System.Threading.Thread.Sleep(maxWorkTime);
            ai.killThread();
            Move suggestion = ai.getBestSuggestion();
            Console.WriteLine("AI has chosen a move\n");
            board.doMove(suggestion);
            board.showBoard();
        }

        public void AIblack()
        {
            Console.WriteLine("AI is planning its move...\n");
            ai.startFindMoveThread(false);
            System.Threading.Thread.Sleep(maxWorkTime);
            ai.killThread();
            Move suggestion = ai.getBestSuggestion();
            Console.WriteLine("AI has chosen a move\n");
            board.doMove(suggestion);
            board.showBoard();
        }

        public void endGameMessage()
        {
            Console.WriteLine("Here is where we call checkWin() to see who won, and where we provide an announcement of the situation");
            Console.ReadLine();
        }
    }
}
