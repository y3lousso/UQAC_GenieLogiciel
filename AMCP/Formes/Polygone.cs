using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCP
{
    public class Polygone : Forme
    {
        // local position of each point
        List<Point> Points { get; set; } = new List<Point>(); // TODO : Camel case

        internal Polygone()
        {
            this.Color = Color.Black;
        }

        internal Polygone (List<Point> points)
        {
            this.Color = Color.Black;
            this.Points = points;
        }

        internal override void Afficher()
        {
            Point point1;
            Point point2;
            //TODO : Préférer while et foreach plutôt que for
            for (int i = 0; i < Points.Count - 1; i++)
            {
                point1 = new Point(this.Position.X + this.Points[i].X, this.Position.Y + this.Points[i].Y);
                point2 = new Point(this.Position.X + this.Points[i + 1].X, this.Position.Y + this.Points[i + 1].Y);
                Canvas.instance.Graphic.DrawLine(new Pen(this.Color), point1, point2);
            }
            // Close the Polygone
            point1 = new Point(this.Position.X + this.Points[this.Points.Count - 1].X, this.Position.Y + this.Points[this.Points.Count - 1].Y);
            point2 = new Point(this.Position.X + this.Points[0].X, this.Position.Y + this.Points[0].Y);
            Canvas.instance.Graphic.DrawLine(new Pen(this.Color), point1, point2);

            // Create solid brush.
            SolidBrush brush = new SolidBrush(this.Color);
            GraphicsPath graphPath = new GraphicsPath();

            List<Point> absolutePoints = new List<Point>();
            foreach(Point p in Points)
            {
                absolutePoints.Add(new Point(this.Position.X + p.X, this.Position.Y + p.Y));
            }

            graphPath.AddPolygon(absolutePoints.ToArray());
            Canvas.instance.Graphic.FillPath(brush, graphPath);
        }

        public override Forme Dupliquer(int positionX, int positionY)
        {
            Forme forme = new Polygone(this.Points);
            forme.Position = new Point(positionX, positionY);
            Canvas.instance.Formes.Add(forme);
            return forme;
        }

        public override void Colorier(int r, int g, int b)
        {
            this.Color = Color.FromArgb(255, r, g, b);
        }

        public override void Tourner(int angle)
        {
            double angleRadian = angle * Math.PI / 180f;
            double v00 = Math.Cos(angleRadian); double v01 = Math.Sin(-angleRadian);
            double v10 = Math.Sin(angleRadian); double v11 = Math.Cos(angleRadian);

            Point tmpPoint = new Point();
            //TODO : Préférer while et foreach plutôt que for
            for (int i = 0; i < Points.Count; i++)
            {
                tmpPoint.X = (int)(v00 * this.Points[i].X + v01 * this.Points[i].Y);
                tmpPoint.Y = (int)(v10 * this.Points[i].X + v11 * this.Points[i].Y);
                this.Points[i] = tmpPoint;
            }
        }

        public override void Deplacer(int positionX, int positionY)
        {
            this.Position = new Point(positionX, positionY);
        }

        public override void Dimensionner(float taille)
        {
            //TODO : Préférer while et foreach plutôt que for
            for (int i = 0; i < Points.Count; i++)
            {
                Point newPoint = new Point((int)(this.Points[i].X * taille), (int)(this.Points[i].Y * taille));
                this.Points[i] = newPoint;
            }
        }

        internal void SetRectangle(Point position, int largeur, int hauteur)
        {
            this.Position = position;
            this.Points.Add(new Point(-largeur / 2, -hauteur / 2)); // bottom left
            this.Points.Add(new Point(-largeur / 2, hauteur / 2));  // top left
            this.Points.Add(new Point(largeur / 2, hauteur / 2));   // top right
            this.Points.Add(new Point(largeur / 2, -hauteur / 2));  // bottom right           
        }

        internal void SetTriangle(Point position, int taille)
        {
            this.Position = position;
            this.Points.Add(new Point(-taille / 2, -taille / 2)); // bottom left
            this.Points.Add(new Point(0, taille / 2));            // top
            this.Points.Add(new Point(taille / 2, taille / 2));   // bottom right
        }

        internal void SetLosange(Point position, int largeur, int hauteur)
        {
            this.Position = position;
            this.Points.Add(new Point(-largeur / 2, 0)); // left
            this.Points.Add(new Point(0, hauteur / 2));  // top
            this.Points.Add(new Point(largeur / 2, 0));   // right
            this.Points.Add(new Point(0, -hauteur / 2)); // bottom
        }

        internal void SetEtoile(Point position, int rayonInterieur, int rayonExterieur, int nbSommet)
        {
            this.Position = position;
            //TODO : Préférer while et foreach plutôt que for
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

