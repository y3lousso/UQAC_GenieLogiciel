using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCP
{
    public class Ellipse : Forme
    {
        int PetitRayon { get; set; } // TODO : Camel case
        int GrandRayon { get; set; } // TODO : Camel case

        internal Ellipse(Point position, int rayon1, int rayon2)
        {
            Point center = new Point(position.X - rayon1 / 2, position.Y - rayon2 / 2);
            this.Position = center;

            this.PetitRayon = rayon1;
            this.GrandRayon = rayon2;
            this.Color = Color.Black;
        }

        internal Ellipse(Point position, int rayon1, int rayon2, int r, int g, int b)
        {
            this.Position = position;
            this.PetitRayon = rayon1;
            this.GrandRayon = rayon2;
            this.Color = Color.FromArgb(255, r, g, b);
        }

        internal override void Afficher()
        {
            Canvas.instance.Graphic.DrawEllipse(new Pen(this.Color), this.Position.X, this.Position.Y, this.PetitRayon, this.GrandRayon);

            // Fill with this.Color
            SolidBrush brush = new SolidBrush(this.Color);
            Canvas.instance.Graphic.FillEllipse(brush, this.Position.X, this.Position.Y, this.PetitRayon, this.GrandRayon);

            if (this.PetitRayon == this.GrandRayon)
            {
                Console.WriteLine("Un cercle a été dessiné.");
            }
            else
            {
                Console.WriteLine("Une ellipse a été dessiné.");
            }
        }

        public override Forme Dupliquer(int positionX, int positionY)
        {
            Ellipse forme = new Ellipse(new Point(positionX, positionY), this.PetitRayon, this.GrandRayon);
            forme.Color = this.Color;
            Canvas.instance.Formes.Add(forme);
            return forme;
        }

        public override void Colorier(int r, int g, int b)
        {
            this.Color = Color.FromArgb(255, r, g, b);
        }

        public override void Tourner(int angle)
        {
            // Different from other shape
        }

        public override void Deplacer(int positionX, int positionY)
        {
            Point center = new Point(positionX - this.PetitRayon / 2, positionY - this.GrandRayon / 2);
            if (!EstDehors(positionX, positionY, this.PetitRayon, this.GrandRayon))
                this.Position = center;
            else
                Console.WriteLine("Déplacement impossible");
        }

        public override void Dimensionner(float taille)
        {
            this.PetitRayon = (int)(this.PetitRayon * taille);
            this.GrandRayon = (int)(this.GrandRayon * taille);
        }
        

    }
}
