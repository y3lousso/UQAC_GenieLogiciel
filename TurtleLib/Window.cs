namespace TurtleLib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Numerics;

    public class Window : Form
    {
        public static Window instance;
        private Graphics graphic;

        /// <summary>
        /// Create the windows and the drawing area.
        /// </summary>
        /// <param name="sizeX"></param>
        /// <param name="sizeY"></param>
        public Window(int sizeX, int sizeY)
        {
            if (instance == null)
            {
                instance = this;
                this.Size = new Size(sizeX, sizeY);
                this.graphic = this.CreateGraphics();
                this.Show();
            }
        }

        /// <summary>
        /// Draw a black line from position arg1 to position arg2.
        /// </summary>
        /// <param name="initialPosition"></param>
        /// <param name="finalPosition"></param>
        public void DrawLine(Vector2 initialPosition, Vector2 finalPosition)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 1);

            // Create points that define line.
            Point point1 = new Point((int)initialPosition.X, (int)initialPosition.Y);
            Point point2 = new Point((int)finalPosition.X, (int)finalPosition.Y);

            // Draw line to screen.
            this.graphic.DrawLine(blackPen, point1, point2);
        }

        /// <summary>
        /// Wait that a key is pressed before closing the windows.
        /// </summary>
        public void WaitForExit()
        {
            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }

    }
}
