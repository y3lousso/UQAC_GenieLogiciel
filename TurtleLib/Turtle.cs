namespace AMCP
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
/*
        public Vector2 Position { get; set; } = new Vector2(0, 0);
        public float Orientation { get; set; }  = 0f;

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
            this.Position = new Vector2(posX, posY);
        }

        /// <summary>
        /// Turtle constructor with position and rotation
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="orientation"></param>
        public Turtle(int posX, int posY, float orientation)
        {
            this.Position = new Vector2(posX, posY);
            this.Orientation = orientation;
        }

        /// <summary>
        /// Move forward the turtle
        /// </summary>
        /// <param name="distance"></param>
        public void Forward(int distance)
        {
            double orientationRadian = this.Orientation * Math.PI / 180f;
            
            int finalPositionX = (int)(this.Position.X + (distance * Math.Cos(orientationRadian)));
            int finalPositionY = (int)(this.Position.Y + (distance * Math.Sin(orientationRadian)));
            Console.WriteLine(this.Position.X + (distance * Math.Cos(orientationRadian)));
            Console.WriteLine((int)(this.Position.X + (distance * Math.Cos(orientationRadian))));

            Vector2 finalPosition = new Vector2(finalPositionX, finalPositionY);
            Window.Instance.DrawLine(this.Position, finalPosition);            
            this.Position = finalPosition;
        }

        /// <summary>
        /// Turn the turtle left of "angle" degrees
        /// </summary>
        /// <param name="angle"></param>
        public void TurnLeft(float angle)
        {
            this.Orientation += angle;
        }

        /// <summary>
        /// Turn the turtle right of "angle" degrees
        /// </summary>
        /// <param name="angle"></param>
        public void TurnRight(float angle)
        {
            this.Orientation -= angle;
        }*/
    }
}
