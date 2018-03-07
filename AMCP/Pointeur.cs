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
        protected int PositionX { get; set; }
        protected int PositionY { get; set; }
        protected int TailleBrosse { get; set; }
        protected int R { get; set; }
        protected int G { get; set; }
        protected int B { get; set; }
        protected Boolean PointeurBas { get; set; }
        protected float Angle { get; set; }
        protected List<Point> Points { get; set; }

        public Pointeur(Point position, int taille, int angle, int r, int g, int b)
        {
            this.PositionX = position.X;
            this.PositionY = position.Y;
            this.TailleBrosse = taille;
            this.Angle = angle;
            this.R = r;
            this.B = b;
            this.G = g;
        }

        public Pointeur()
        {
            this.PositionX = Canvas.instance.Width / 2;
            this.PositionX = Canvas.instance.Height / 2;
            this.TailleBrosse = 1;
            R = 0;
            G = 0;
            B = 0;
            this.Angle = 0;
        }

        public FormeLibre Dessiner()
        {
            if (Points != null)
            {
                FormeLibre forme = new FormeLibre(Points, R, G, B, TailleBrosse);
                Canvas.instance.Formes.Add(forme);
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
            Points.Add(new Point(PositionX, PositionY));
            Points = null;
            PointeurBas = false;
        }

        public void DescendrePointeur()
        {
            PointeurBas = true;
            Points = new List<Point>();
            Points.Add(new Point(PositionX, PositionY));
        }

        public void Avancer(int pas)
        {
            double angleRadian = Angle * Math.PI / 180f;
            PositionX = (int)(PositionX + pas * Math.Cos(angleRadian));
            PositionY = (int)(PositionY + pas * Math.Sin(angleRadian));
        }

        public void Tourner(int angle)
        {
            Points.Add( new Point(PositionX,PositionY) );
            this.Angle += angle;
        }
    }
}