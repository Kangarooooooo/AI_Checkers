using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class AI
    {
        MoveGenerator mg;
        Board board;
        public AI(MoveGenerator mg)
        {
            this.mg = mg;
            this.board = mg.boardReference;
        }
        
        public void MaximizerStart()
        //Author: Kasper
        //Call this first, then the Maximizer will be called until it is no longer relevant
        {

        }
        public int Maximizer(int[,] move)
        {
            return 0;
        }

        public void MinimizerStart()
        //Author: Kasper
        //Call this first, then the Maximizer will be called until it is no longer relevant
        {

        }
        public int Minimizer(int[,] move)
        {
            return 0;
        }
    }
}
