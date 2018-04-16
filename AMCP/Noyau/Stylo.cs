using System;
using System.Collections.Generic;
using System.Drawing;
using AMCP.Formes;
using AMCP.InterfaceUtilisateur;

namespace AMCP.Noyau
{
    public class Stylo
    {
        private int ID { get; set; } 
        private Point Position { get; set; } 
        private float Orientation { get; set; } 
        private int Taille { get; set; }

        public Color Couleur { get; set; } 
        private Boolean IsWriting { get; set; }
        private Boolean CanDraw { get; set; }

        private Point StartPosition { get; set; } 
        private List<Point> Points { get; set; }

        internal Stylo()
        {
            this.Position = new Point(Canvas.instance.Width / 2, Canvas.instance.Height / 2);
            this.Taille = 10;
            this.Couleur = Color.FromArgb(0, 0, 0);
            this.Orientation = 0;
        }

        internal Stylo(Point position, int size, int orientation, Color color)
        {
            this.Position = position;
            this.Taille = size;
            this.Orientation = orientation;
            this.Couleur = color;
        }

        /// <summary>
        /// Permet d'arreter l'écriture avec le stylo et de créer la forme en même temps.
        /// </summary>
        /// <returns></returns>
        public Forme LeverStylo()
        {
            if (IsWriting)
            {
                this.Points.Add(new Point(this.Position.X, this.Position.Y));
                FormeLibre forme = new FormeLibre(this.Points, this.Taille, this.Couleur);
                Canvas.instance.Formes.Add(forme);
                this.Points = null;
                this.IsWriting = false;
                return forme;              
            }
            else
            {
                Console.WriteLine("Stylo : Descendre le stylo pour commencer.");
                return null;
            }
        }

        /// <summary>
        /// Permet de commencer l'écriture avec le stylo.
        /// </summary>
        public void DescendreStylo()
        {
            if (!IsWriting)
            {
                this.StartPosition = this.Position;
                this.Points = new List<Point>();
                this.Points.Add(this.StartPosition);
                this.IsWriting = true;
            }
            else
            {
                Console.WriteLine("Stylo : Le stylo est déja descendu et prêt à écrire.");
            }
        }

        /// <summary>
        /// Permet de faire avancer le stylo pendant la phase d'écriture.
        /// </summary>
        /// <param name="pas"></param>
        public void Avancer(int pas)
        {
            if (this.IsWriting)
            {
                double angleRadian = Orientation * Math.PI / 180f;
                this.Position = new Point((int)(this.Position.X + pas * Math.Cos(angleRadian)), (int)(this.Position.Y + pas * Math.Sin(angleRadian)));
                this.CanDraw = true;               
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Le stylo doit être descendu pour utiliser 'Avancer'.");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Permet de tourner le stylo pendant la phase d'écriture.
        /// </summary>
        /// <param name="angle"></param>
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

        /// <summary>
        /// Permet de déplacer le stylo en dehors de la phase d'écriture.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
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

    }
}