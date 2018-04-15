using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using AMCP.InterfaceUtilisateur;

namespace AMCP.Formes
{
    internal class Polygone : Forme
    {     
        List<Point> Points { get; set; } = new List<Point>(); // Local position of each point

        internal Polygone(Point position)
        {
            this.ID = Canvas.ProchainID();
            this.Position = position;
            this.Color = Color.Black;
            this.Type = "Polygone";
        }

        internal Polygone(Point position, List<Point> points, string type)
        {
            this.ID = Canvas.ProchainID();
            this.Position = position;
            this.Color = Color.Black;
            this.Points = points;
            this.Type = type;
        }

        public override void Afficher()
        {
            if (!EstDehors(this.Position.X, this.Position.Y, 0, 0))
            {
                Matrix matrix = new Matrix();

                //Rotate the graphics object the required amount around this point
                matrix.RotateAt(this.Orientation, new PointF(this.Position.X, this.Position.Y));
                Canvas.instance.Graphic.Transform = matrix;

                // Create solid brush.
                SolidBrush brush = new SolidBrush(this.Color);
                GraphicsPath graphPath = new GraphicsPath();

                List<Point> absolutePoints = new List<Point>();
                foreach (Point p in this.Points)
                {
                    absolutePoints.Add(new Point(this.Position.X + p.X, this.Position.Y + p.Y));
                }

                graphPath.AddPolygon(absolutePoints.ToArray());
                Canvas.instance.Graphic.FillPath(brush, graphPath);
                Console.WriteLine(this.Type + " " + this.ID + " : Affichage effectué.");

                //Rotate back to normal around the same point</pre>
                matrix.RotateAt(-this.Orientation, new PointF(this.Position.X, this.Position.Y));
                Canvas.instance.Graphic.Transform = matrix;
            }
            else
            {
                Console.WriteLine(this.Type + " " + this.ID + " : Hors canvas.");
            }            
        }

        public override Forme Dupliquer(int positionX, int positionY)
        {
            Forme forme = new Polygone(this.Position, this.Points, this.Type);
            forme.Color = this.Color;
            forme.Orientation = this.Orientation;
            Canvas.instance.Formes.Add(forme);           
            Console.WriteLine(this.Type + " " + this.ID + " : Duplication réussie.");
            return forme;
        }

        public override void Dimensionner(float taille)
        {
            for (int i = 0; i < this.Points.Count; i++)
            {
                Point newPoint = new Point((int)(this.Points[i].X * taille), (int)(this.Points[i].Y * taille));
                this.Points[i] = newPoint;
            }
            Console.WriteLine(this.Type + " " + this.ID + " : Dimensionnement par un facteur " + taille + " effectué.");
        }

        internal void SetRectangle(int largeur, int hauteur)
        {
            if (largeur == hauteur)
            {
                this.Type = "Carre    ";
            }
            else
            {
                this.Type = "Rectangle";
            }
            this.Points.Add(new Point(-largeur / 2, -hauteur / 2)); // bottom left
            this.Points.Add(new Point(-largeur / 2, hauteur / 2));  // top left
            this.Points.Add(new Point(largeur / 2, hauteur / 2));   // top right
            this.Points.Add(new Point(largeur / 2, -hauteur / 2));  // bottom right           
        }

        internal void SetTriangle(int taille)
        {
            this.Type = "Triangle ";
            this.Points.Add(new Point(-taille  , -taille )); // bottom left
            this.Points.Add(new Point(0, taille));            // top
            this.Points.Add(new Point(taille, -taille));   // bottom right
        }

        internal void SetLosange(int largeur, int hauteur)
        {
            this.Type = "Losange  ";
            this.Points.Add(new Point(-largeur / 2, 0)); // left
            this.Points.Add(new Point(0, hauteur / 2));  // top
            this.Points.Add(new Point(largeur / 2, 0));   // right
            this.Points.Add(new Point(0, -hauteur / 2)); // bottom
        }

        internal void SetEtoile(int rayonInterieur, int rayonExterieur, int nbSommet)
        {
            this.Type = "Etoile   ";
            for (int i = 0; i < nbSommet; i++)
            {
                double halfAngle = 2 * Math.PI / (2 * nbSommet); // the angle between outside and inside Points

                Point v1 = new Point();
                Point v2 = new Point();

                v1.X = (int)(rayonExterieur * Math.Cos(2 * i * halfAngle));
                v2.X = (int)(rayonInterieur * Math.Cos((2 * i + 1) * halfAngle));
                v1.Y = (int)(rayonExterieur * Math.Sin(2 * i * halfAngle));
                v2.Y = (int)(rayonInterieur * Math.Sin((2 * i + 1) * halfAngle));

                this.Points.Add(v1);
                this.Points.Add(v2);
            }
        }

    }
}