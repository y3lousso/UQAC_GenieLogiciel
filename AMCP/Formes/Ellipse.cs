using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using AMCP.InterfaceUtilisateur;

namespace AMCP.Formes
{
    internal class Ellipse : Forme
    {
        int PetitRayon { get; set; } 
        int GrandRayon { get; set; } 

        internal Ellipse(Point position, int rayon1, int rayon2)
        {
            Point center = new Point(position.X - rayon1 / 2, position.Y - rayon2 / 2);
            this.ID = Canvas.prochainID();
            this.Position = center;
            this.Orientation = 0;
            this.PetitRayon = rayon1;
            this.GrandRayon = rayon2;
            this.Color = Color.Black;
        }

        internal Ellipse(Point position, int rayon1, int rayon2, int r, int g, int b)
        {
            this.ID = Canvas.prochainID();
            this.Position = position;
            this.Orientation = 0;
            this.PetitRayon = rayon1;
            this.GrandRayon = rayon2;
            this.Color = Color.FromArgb(255, r, g, b);
        }

        internal override void Afficher()
        {
            Matrix matrix = new Matrix();

            //Rotate the graphics object the required amount around this point
            matrix.RotateAt(this.Orientation, new PointF(Position.X + PetitRayon/2, Position.Y+ GrandRayon/2));
            Canvas.instance.Graphic.Transform = matrix;

            //Draw the rotated ellipse
            Rectangle r = new Rectangle(Position.X, Position.Y, PetitRayon, GrandRayon);
            Canvas.instance.Graphic.FillEllipse(new SolidBrush(this.Color), r);

            //Rotate back to normal around the same point</pre>
            matrix.RotateAt(-this.Orientation, new PointF(Position.X + PetitRayon/2, Position.Y + GrandRayon/2));
            Canvas.instance.Graphic.Transform = matrix;

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
            forme.Orientation = this.Orientation;
            Canvas.instance.Formes.Add(forme);
            return forme;
        }

        public override void Colorier(int r, int g, int b)
        {
            this.Color = Color.FromArgb(255, r, g, b);
        }

        public override void Tourner(int angle)
        {
            Orientation += angle;
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
