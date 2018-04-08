using System;
using System.Collections.Generic;
using System.Drawing;
using AMCP.Formes;
using AMCP.InterfaceUtilisateur;

namespace AMCP.Noyau
{
    public class Stylo
    {
        private int ID { get; set; } // TODO : Les abréviations sont en UPPER
        private Point Position { get; set; } // TODO : Les private sont en Camel
        private float Orientation { get; set; } // TODO : Les private sont en Camel
        private int Taille { get; set; } // TODO : Les private sont en Camel

        private Color Couleur { get; set; } // TODO : Les private sont en Camel
        private Boolean IsWriting { get; set; } // TODO : Les private sont en Camel
        private Boolean CanDraw { get; set; }

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

        public Forme Dessiner()
        {
            if (Points != null)
            {
                if (CanDraw)
                {
                    FormeLibre forme = new FormeLibre(this.Points, this.Taille, this.Couleur);
                    Canvas.instance.Formes.Add(forme);
                    this.Points = null;
                    return forme;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("On ne peut pas dessiner en dehors du Canvas");
                    Console.ResetColor();
                    return null;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Abaisser le pointeur pour commencer a dessiner");
                Console.ResetColor();
                return null;
            }
        }

        public void LeverPointeur()
        {
            if (this.IsWriting)
            {
                this.Points.Add(new Point(this.Position.X, this.Position.Y));
                this.IsWriting = false;
            }
        }

        public void DescendrePointeur()
        {
            this.StartPosition = this.Position;
            this.Points = new List<Point>();
            this.Points.Add(this.StartPosition);
            this.IsWriting = true;
        }

        public void Avancer(int pas)
        {
            if (this.IsWriting)
            {
                double angleRadian = Orientation * Math.PI / 180f;
                if (!this.EstDehors(this.Position.X, this.Position.Y))
                {
                    this.Position = new Point((int)(this.Position.X + pas * Math.Cos(angleRadian)), (int)(this.Position.Y + pas * Math.Sin(angleRadian)));
                    this.CanDraw = true;
                }
                else
                {
                    this.CanDraw = false;
                }
                    
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Le stylo doit être descendu pour utiliser 'Avancer'.");
                Console.ResetColor();
            }
        }

        public void Tourner(int angle)
        {
            if (this.IsWriting)
            {
                this.Points.Add(new Point(this.Position.X, this.Position.Y));
                this.Orientation += angle;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Le stylo doit être descendu pour utiliser 'Tourner'.");
                Console.ResetColor();
            }
        }

        public void Deplacer(int positionX, int positionY)
        {
            if (!this.IsWriting)
            {
                this.Position = new Point(positionX, positionY);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Le stylo doit être levé pour utiliser 'Déplacer'.");
                Console.ResetColor();
            }
        }
        internal Boolean EstDehors(int positionX, int positionY)
        {
            if (positionX < 0
                || positionX > Canvas.instance.Graphic.VisibleClipBounds.Width
                || positionY < 0
                || positionY > Canvas.instance.Graphic.VisibleClipBounds.Height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}