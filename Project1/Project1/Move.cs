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
        int endX, endY;

        public Move()
        {
            state = new int[8, 8];
        }

        public Move(int[,] newState, String newString, int endX, int endY)
        {
            state = newState;
            stateString = newString;
            setEndX(endX);
            setEndY(endY);
        }

        public void setState(int[,] newState)
        {
            state = newState;
        }

        public void modifyState(int x, int y, int piece)
        {
            state[x, y] = piece;
        }

        public int readStatePos(int x, int y)
        {
            return state[x, y];
        }

        public int[,] getState()
        {
            return state;
        }

        public void setEndX(int setVal)
        {
            endX = setVal;
        }

        public int getEndX()
        {
            return endX;
        }

        public void setEndY(int setVal)
        {
            endY = setVal;
        }

        public int getEndY()
        {
            return endY;
        }

        public String getString()
        {
            return stateString;
        }
    }
}
