using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMCP;
using AMCP.Formes;

namespace AMCP
{
    public class Pointeur
    {
        protected int Id { get; set; }
        protected Point Position { get; set; }
        protected int TailleBrosse { get; set; }
        protected Color Color { get; set; }
        protected Boolean PointeurBas { get; set; }
        protected float Angle { get; set; }
        protected List<Point> Points { get; set; }

        private Point StartPosition { get; set; }

        public Pointeur(Point position, int taille, int angle, Color color)
        {
            this.Position = position;
            this.TailleBrosse = taille;
            this.Angle = angle;
            this.Color = color;
        }

        public Pointeur()
        {
            this.Position = new Point(Canvas.instance.Width / 2, Canvas.instance.Height / 2);
            this.TailleBrosse = 10;
            this.Color = Color.FromArgb(0, 0, 0);
            this.Angle = 0;
        }

        public FormeLibre Dessiner()
        {
            if (Points != null)
            {
                FormeLibre forme = new FormeLibre(this.Points, this.TailleBrosse, this.Color);
                Canvas.instance.Formes.Add(forme);
                Points = null;
                return forme;
            }
            else
            {
                Console.WriteLine("Abaisser le pointeur pour commencer a dessiner");
                return null;
            }
        }

        public void LeverPointeur()
        {
            Points.Add(new Point(this.Position.X - StartPosition.X, this.Position.Y - StartPosition.Y));            
            PointeurBas = false;
        }

        public void DescendrePointeur()
        {
            StartPosition = this.Position;
            Points = new List<Point>();
            Points.Add(new Point(0, 0));
        }

        public void Avancer(int pas)
        {
            double angleRadian = Angle * Math.PI / 180f;
            this.Position = new Point((int)(this.Position.X + pas * Math.Cos(angleRadian)), (int)(this.Position.Y + pas * Math.Sin(angleRadian)));
        }

        public void Tourner(int angle)
        {
            Points.Add(new Point(this.Position.X - StartPosition.X, this.Position.Y - StartPosition.Y));
            this.Angle += angle;
        }

        public void Deplacer(int positionX, int positionY)
        {
            this.Position = new Point(positionX, positionY);

        }
    }
}