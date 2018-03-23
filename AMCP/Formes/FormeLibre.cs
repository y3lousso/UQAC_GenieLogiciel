using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCP.Formes
{
    public class FormeLibre : Forme
    {
        List<Point> Points { get; set; } = new List<Point>(); // TODO : Camel case
        int TailleStylo { get; set; } // TODO : Camel case

        internal FormeLibre(List<Point> points, int taille)
        {
            this.Position = points[0];
            this.Points = points;
            this.Color = Color.Black;
            this.TailleStylo = taille;
        }

        internal FormeLibre(List<Point> points, int taille, Color color )
        {
            this.Points = points;
            this.Color = color;
            this.TailleStylo = taille;
        }

        public override void Colorier(int r, int g, int b)
        {
            this.Color = Color.FromArgb(1, r, g, b);
        }

        public override void Deplacer(int positionX, int positionY)
        {
            this.Position = new Point(positionX, positionY);
        }

        public override void Dimensionner(float taille)
        {
            throw new NotImplementedException();
        }

        public override Forme Dupliquer(int positionX, int positionY)
        {
            Forme forme = new FormeLibre(new List<Point>(this.Points), this.TailleStylo, this.Color);
            forme.Deplacer(positionX, positionY);
            Canvas.instance.Formes.Add(forme);

            return forme;
        }

        public override void Tourner(int angle)
        {

            double angleRadian = angle * Math.PI / 180f;
            Point rotationAxe = this.Points[0];
            Point tmpPoint;

            for (int i = 1; i < Points.Count; i++)
            {
                int X = this.Points[i].X - rotationAxe.X;
                int Y = this.Points[i].Y - rotationAxe.Y;

                tmpPoint = new Point();
                tmpPoint.X = (int)(rotationAxe.X + X * Math.Cos(angleRadian) - Y * Math.Sin(angleRadian));
                tmpPoint.Y = (int)(rotationAxe.X + X * Math.Sin(angleRadian) + Y * Math.Cos(angleRadian));

                Points[i] = tmpPoint;
            }
        }

        internal override void Afficher()
        {
            Pen pen = new Pen(this.Color, this.TailleStylo);
            Point point1;
            Point point2;
            for (int i = 0; i < this.Points.Count-1; i++)
            {
                point1 = new Point(this.Position.X + this.Points[i].X, this.Position.Y + this.Points[i].Y);
                point2 = new Point(this.Position.X + this.Points[i + 1].X, this.Position.Y + this.Points[i + 1].Y);
                Canvas.instance.Graphic.DrawLine(pen, point1, point2);
            }
        }
    }
}
