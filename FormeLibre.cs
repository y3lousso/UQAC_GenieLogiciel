using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCP.Formes
{
    public class FormeLibre:Forme
    {

        List<Point> Points { get; set; } = new List<Point>();
        int taille { get; set; }
        Color color { get; set; }


        public FormeLibre(List<Point> Points,int r,int g, int b, int taille)
        {
            this.Points = Points;
            this.color = Color.FromArgb(r, g, b);
            this.taille = taille;
        }

        public override void Colorier(int r, int g, int b)
        {
            
        }

        public override void Deplacer(int positionX, int positionY)
        {
            Point target = new Point(positionX, positionY);
            Point origin = Points[0];

            double distance = (Math.Sqrt(Math.Pow(target.X - origin.X, 2) + Math.Pow(target.X - origin.Y, 2)));
            double angle = Math.Atan2(target.X - origin.X, target.Y - origin.Y);

            for (int i = 0; i < Points.Count; i++)
            {
                Point tmpPoint = new Point();
                tmpPoint.X= (int)(Points[i].X + distance * Math.Cos(angle));
                tmpPoint.Y = (int)(Points[i].Y + distance * Math.Sin(angle));
                Points[i] = tmpPoint;
            }
        }

        public override void Dimensionner(float taille)
        {
            throw new NotImplementedException();
        }

        public override void Dupliquer(int positionX, int positionY)
        {
            List<Point> tmpPoints = new List<Point>();
            int r = this.color.R;
            int g = this.color.G;
            int b = this.color.B;
            int taille = this.taille;
            foreach (Point point in Points)
            {
                tmpPoints.Add(new Point(point.X, point.Y));
            }
            Forme forme = new FormeLibre(tmpPoints,r,g,b,taille);
            forme.Deplacer(positionX, positionY);
            Canvas.instance.Formes.Add(forme);
        }

        public override void Tourner(int angle)
        {

            double angleRadian = angle * Math.PI / 180f;
            Point rotationAxe = Points[0];
            Point tmpPoint;

            for (int i = 1; i < Points.Count; i++)
            {
                int X = Points[i].X - rotationAxe.X;
                int Y = Points[i].Y - rotationAxe.Y;

                tmpPoint = new Point();
                tmpPoint.X = (int)(rotationAxe.X + X * Math.Cos(angleRadian) - Y * Math.Sin(angleRadian));
                tmpPoint.Y = (int)(rotationAxe.X + X * Math.Sin(angleRadian) + Y * Math.Cos(angleRadian));

                Points[i] = tmpPoint;
            }
        }

        internal override void Afficher()
        {
            Pen pen = new Pen(color, taille);
            for (int i = 1; i < Points.Count; i++)
            {
                Canvas.instance.Graphic.DrawLine(pen, Points.ElementAt(i-1),Points.ElementAt(i)) ;
            }
        }
    }
}
