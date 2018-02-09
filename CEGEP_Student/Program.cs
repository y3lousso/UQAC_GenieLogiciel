using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleLib;

namespace CEGEP_Student
{
    class Program
    {
        static void Main(string[] args)
        {
            Window window = new Window(500,500);
            Turtle turtle = new Turtle(250, 250,0);


            for (int i = 1; i < 20; i++)
            {
                turtle.Forward(i*10);
                turtle.TurnRight(144);
            }

            window.WaitForExit();
        }
    }
}
