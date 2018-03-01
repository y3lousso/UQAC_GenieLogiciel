using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCP
{
    public class Polygone : Forme
    {
        // local position of each point
        List<Point> Points { get; set; } = new List<Point>();

        internal Polygone()
        {

        }

        internal override void Afficher()
        {
            for (int i = 0; i < Points.Count - 1; i++)
            {
                Canvas.instance.Graphic.DrawLine(new Pen(Color.Black), new Point(Position.X + Points[i].X, Position.Y + Points[i].Y), new Point(Position.X + Points[i+1].X, Position.Y + Points[i+1].Y));
            }
            // Close the Polygone
            Canvas.instance.Graphic.DrawLine(new Pen(Color.Black), new Point(Position.X + Points[Points.Count-1].X, Position.Y + Points[Points.Count - 1].Y), new Point(Position.X + Points[0].X, Position.Y + Points[0].Y));
        }

        public override void Dupliquer(int positionX, int positionY)
        {

        }

        public override void Colorier(int r, int g, int b)
        {

        }

        public override void Tourner(int angle)
        {
            double angleRadian = angle * Math.PI / 180f;
            double v00 = Math.Cos(angleRadian); double v01 = Math.Sin(-angleRadian);
            double v10 = Math.Sin(angleRadian); double v11 = Math.Cos(angleRadian);

            Point tmpPoint = new Point();

            for (int i = 0; i < Points.Count; i++)
            {
                tmpPoint.X = (int)(v00 * Points[i].X + v01 * Points[i].Y);
                tmpPoint.Y = (int)(v10 * Points[i].X + v11 * Points[i].Y);
                Points[i] = tmpPoint;
            }
        }

        public override void Deplacer(int positionX, int positionY)
        {
            Position = new Point(positionX, positionY);
        }

        public override void Dimensionner(float taille)
        {

        }

        public void SetRectangle(Point position, int largeur, int hauteur)
        {
            Position = position;
            Points.Add(new Point(-largeur / 2, -hauteur / 2)); // bottom left
            Points.Add(new Point(-largeur / 2, hauteur / 2));  // top left
            Points.Add(new Point(largeur / 2, hauteur / 2));   // top right
            Points.Add(new Point(largeur / 2, -hauteur / 2));  // bottom right
        }

        public void SetTriangle(Point position, int taille)
        {
            Position = position;
            Points.Add(new Point(-taille / 2, -taille / 2)); // bottom left
            Points.Add(new Point(0, taille / 2));            // top
            Points.Add(new Point(taille / 2, taille / 2));   // bottom right
        }

        public void SetLosange(Point position, int largeur, int hauteur)
        {
            Position = position;
            Points.Add(new Point(-largeur / 2, 0)); // left
            Points.Add(new Point(0, hauteur / 2));  // top
            Points.Add(new Point(largeur / 2, 0));   // right
            Points.Add(new Point(0, -hauteur / 2)); // bottom
        }

        public void SetEtoile(Point position, int rayonInterieur, int rayonExterieur, int nbSommet)
        {
            Position = position;
            for (int i = 0; i < nbSommet; i++)
            {
                double halfAngle = 2 * Math.PI / (2 * nbSommet); // the angle between outside and inside points

                Point v1 = new Point();
                Point v2 = new Point();

                v1.X = (int)(rayonExterieur * Math.Cos(2 * i * halfAngle));
                v2.X = (int)(rayonInterieur * Math.Cos((2 * i + 1) * halfAngle));
                v1.Y = (int)(rayonExterieur * Math.Sin(2 * i * halfAngle));
                v2.Y = (int)(rayonInterieur * Math.Sin((2 * i + 1) * halfAngle));

                Points.Add(v1);
                Points.Add(v2);
            }
        }
    }
}

