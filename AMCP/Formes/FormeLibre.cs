using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using AMCP.InterfaceUtilisateur;

namespace AMCP.Formes
{
    internal class FormeLibre : Forme
    {
        List<Point> Points { get; set; } = new List<Point>(); 
        int TailleStylo { get; set; }

        internal FormeLibre(List<Point> points, int taille)
        {
            this.ID = Canvas.prochainID();
            this.Position = points[0];
            // Put all the points in the local base
            foreach(Point p in points) 
            {
                this.Points.Add(new Point(p.X - Position.X, p.Y - Position.Y));
            }
            this.Points = points;
            this.Color = Color.Black;
            this.TailleStylo = taille;
            this.Type = "Forme libre";
        }

        internal FormeLibre(List<Point> points, int taille, Color color )
        {
            this.ID = Canvas.prochainID();
            this.Position = points[0];
            foreach (Point p in points)
            {
                this.Points.Add(new Point(p.X - Position.X, p.Y - Position.Y));
            }
            this.Color = color;
            this.TailleStylo = taille;
            this.Type = "Forme libre";
        }

        internal override void Afficher()
        {
            if (!EstDehors(this.Position.X, this.Position.Y, 0, 0))
            {
                Pen pen = new Pen(this.Color, this.TailleStylo);
                Point point1, point2;

                Matrix matrix = new Matrix();

                //Rotate the graphics object the required amount around this point
                matrix.RotateAt(this.Orientation, new PointF(Position.X, Position.Y));
                Canvas.instance.Graphic.Transform = matrix;

                for (int i = 0; i < this.Points.Count - 1; i++)
                {
                    point1 = new Point(this.Position.X + this.Points[i].X, this.Position.Y + this.Points[i].Y);
                    point2 = new Point(this.Position.X + this.Points[i + 1].X, this.Position.Y + this.Points[i + 1].Y);
                    Canvas.instance.Graphic.DrawLine(pen, point1, point2);
                }
                Console.WriteLine(Type + " " + ID + " : Affichage effectué.");

                //Rotate back to normal around the same point</pre>
                matrix.RotateAt(-this.Orientation, new PointF(Position.X, Position.Y));
                Canvas.instance.Graphic.Transform = matrix;
            }
            else
            {
                Console.WriteLine(Type + " " + ID + " : Hors canvas.");
            }
        }

        public override Forme Dupliquer(int positionX, int positionY)
        {
            Forme forme = new FormeLibre(new List<Point>(this.Points), this.TailleStylo, this.Color);
            forme.Deplacer(positionX, positionY);
            Canvas.instance.Formes.Add(forme);
            Console.WriteLine(Type + " " + ID + " : Duplication réussie.");
            return forme;
        }

        public override void Dimensionner(float taille)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                Point newPoint = new Point((int)(this.Points[i].X * taille), (int)(this.Points[i].Y * taille));
                this.Points[i] = newPoint;
            }
            Console.WriteLine(Type + " " + ID + " : Dimensionnement par un facteur " + taille + " effectué.");
        }
    }
}
