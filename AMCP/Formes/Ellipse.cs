using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using AMCP.InterfaceUtilisateur;

namespace AMCP.Formes
{
    internal class Ellipse : Forme
    {
        int Largeur { get; set; } 
        int Hauteur { get; set; } 

        internal Ellipse(Point position, int largeur, int hauteur)
        {
            this.ID = Canvas.prochainID();
            this.Position = position;
            this.Orientation = 0;
            this.Largeur = largeur;
            this.Hauteur = hauteur;
            this.Color = Color.Black;

            if(Largeur == Hauteur)
            {
                this.Type = "Cercle   ";
            }
            else
            {
                this.Type = "Ellipse  ";
            }
        }

        internal Ellipse(Point position, int largeur, int hauteur, int r, int g, int b)
        {
            this.ID = Canvas.prochainID();
            this.Position = position;
            this.Orientation = 0;
            this.Largeur = largeur;
            this.Hauteur = hauteur;
            this.Color = Color.FromArgb(255, r, g, b);

            if (Largeur == Hauteur)
            {
                this.Type = "Cercle   ";
            }
            else
            {
                this.Type = "Ellipse  ";
            }
        }

        internal override void Afficher()
        {
            Console.WriteLine(Position + " : " + EstDehors(this.Position.X, this.Position.Y, 0, 0));
            if (!EstDehors(this.Position.X, this.Position.Y, 0, 0))  
            { 
                Matrix matrix = new Matrix();

                //Rotate the graphics object the required amount around this point
                matrix.RotateAt(this.Orientation, new PointF(Position.X, Position.Y));
                Canvas.instance.Graphic.Transform = matrix;

                //Draw the rotated ellipse
                Rectangle r = new Rectangle(Position.X-Largeur/2, Position.Y-Hauteur/2, Largeur, Hauteur);
                Canvas.instance.Graphic.FillEllipse(new SolidBrush(this.Color), r);
                Console.WriteLine(Type + " " + ID + " : Affichage effectué.");

                //Rotate back to normal around the same point</pre>
                matrix.RotateAt(-this.Orientation, new PointF(Position.X, Position.Y));
                Canvas.instance.Graphic.Transform = matrix;
            }
            else
            {
                Console.WriteLine(Type + " " + ID + " : Hors canvas.");
            }
        }

        public override Forme Dupliquer(int positionX, int positionY)
        {
            Ellipse forme = new Ellipse(new Point(positionX, positionY), this.Largeur, this.Hauteur);
            forme.Color = this.Color;
            forme.Orientation = this.Orientation;
            Canvas.instance.Formes.Add(forme);
            Console.WriteLine(Type + " " + ID + " : Duplication réussie.");
            return forme;
        }

        public override void Deplacer(int positionX, int positionY)
        {
            this.Position = new Point(positionX, positionY);
            Console.WriteLine(Type + " " + ID + " : Déplacement de (" + Position.X + ", " + Position.Y + ") à (" + positionX + ", " + positionY + ")  effectué.");
        }

        public override void Dimensionner(float taille)
        {
            this.Largeur = (int)(this.Largeur * taille);
            this.Hauteur = (int)(this.Hauteur * taille);
            Console.WriteLine(Type + " " + ID + " : Dimensionnement par un facteur " + taille + " effectué.");
        }
    }
}
