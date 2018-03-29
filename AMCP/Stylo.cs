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
    public class Stylo
    {
        private int Id { get; set; } // TODO : Les abréviations sont en UPPER
        private Point Position { get; set; } // TODO : Les private sont en Camel
        private float Orientation { get; set; } // TODO : Les private sont en Camel
        private int Taille { get; set; } // TODO : Les private sont en Camel

        private Color Couleur { get; set; } // TODO : Les private sont en Camel
        private Boolean IsWriting { get; set; } // TODO : Les private sont en Camel

        private Point StartPosition { get; set; } // TODO : Les private sont en Camel
        private List<Point> Points { get; set; } // TODO : Les private sont en Camel

        public Stylo()
        {
            this.Position = new Point(Canvas.instance.Width / 2, Canvas.instance.Height / 2);
            this.Taille = 10;
            this.Couleur = Color.FromArgb(0, 0, 0);
            this.Orientation = 0;
        }

        public Stylo(Point position, int size, int orientation, Color color)
        {
            this.Position = position;
            this.Taille = size;
            this.Orientation = orientation;
            this.Couleur = color;
        }

        public FormeLibre Dessiner()
        {
            if (Points != null)
            {
                FormeLibre forme = new FormeLibre(this.Points, this.Taille, this.Couleur);
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
            IsWriting = false;
        }

        public void DescendrePointeur()
        {
            StartPosition = this.Position;
            Points = new List<Point>();
            Points.Add(StartPosition);
            IsWriting = true;
        }

        public void Avancer(int pas)
        {
            if (IsWriting)
            {
                double angleRadian = Orientation * Math.PI / 180f;
                this.Position = new Point((int)(this.Position.X + pas * Math.Cos(angleRadian)), (int)(this.Position.Y + pas * Math.Sin(angleRadian)));
            }
            else
            {
                throw new Exception("Le stylo doit être descendu pour utiliser 'Avancer'.");
            }
        }

        public void Tourner(int angle)
        {
            if (IsWriting)
            {
                Points.Add(new Point(this.Position.X - StartPosition.X, this.Position.Y - StartPosition.Y));
                this.Orientation += angle;
            }
            else
            {
                throw new Exception("Le stylo doit être descendu pour utiliser 'Tourner'.");
            }
        }

        public void Deplacer(int positionX, int positionY)
        {
            if (!IsWriting)
            {
                this.Position = new Point(positionX, positionY);
            }
            else
            {
                throw new Exception("Le stylo doit être levé pour utiliser 'Tourner'."); // TODO : "Deplacer" et pas "Tourner"
            }
        }
    }
}