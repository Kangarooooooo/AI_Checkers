using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class testBoard4
    {

        static void Main(string[] args)
        {
            MoveGenerator mg = new MoveGenerator(new Board());
            mg.boardReference.startState4();
            int evalval = mg.boardReference.evaluate();
            Console.WriteLine("evalval = " + evalval);
            Console.ReadLine();
        }
    }
}
