using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class OnePlayer
    {
        Boolean cap;
        Board board;
        MoveGenerator mg;
        Move latestMove;
        LinkedList<Move> legalActions, legalMoves, legalCaptures;
        int n, choice, testCount;

        public OnePlayer()
        {
            playLoop();
        }

        void playLoop()
        {
        }
}
