namespace TurtleLib
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    public class Turtle
    {

        Vector2 position = new Vector2(0, 0);
        double orientation = 0f;

        /// <summary>
        /// Turtle empty constructor
        /// </summary>
        public Turtle()
        {
            
        }

        /// <summary>
        /// Turtle constructor without rotation
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        public Turtle(int posX, int posY)
        {
            this.position = new Vector2(posX, posY);
        }

        /// <summary>
        /// Turtle constructor with position and rotation
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="orientation"></param>
        public Turtle(int posX, int posY, double orientation)
        {
            this.position = new Vector2(posX, posY);
            this.orientation = orientation;
        }

        /// <summary>
        /// Move forward the turtle
        /// </summary>
        /// <param name="distance"></param>
        public void Forward(int distance)
        {
            double orientationRadian = this.orientation * Math.PI / 180f;

            int finalPositionX = (int)(this.position.X + (distance * Math.Cos(orientationRadian)));
            int finalPositionY = (int)(this.position.Y + (distance * Math.Sin(orientationRadian)));

            Vector2 finalPosition = new Vector2(finalPositionX, finalPositionY);
            Window.instance.DrawLine(this.position, finalPosition);
            this.position = finalPosition;
        }

        /// <summary>
        /// Turn the turtle left of "angle" degrees
        /// </summary>
        /// <param name="angle"></param>
        public void TurnLeft(double angle)
        {
            this.orientation -= angle;
        }

        /// <summary>
        /// Turn the turtle right of "angle" degrees
        /// </summary>
        /// <param name="angle"></param>
        public void TurnRight(double angle)
        {
            this.orientation += angle;
        }
    }
}
