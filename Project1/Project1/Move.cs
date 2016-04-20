using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Move
    {
        int[,] state;
        String stateString;

        public int[,] getState()
        {
            return state;
        }

        public String getStateString()
        {
            return stateString;
        }
    }
}
