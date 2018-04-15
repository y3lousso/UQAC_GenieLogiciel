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
            this.ID = Canvas.ProchainID();
            this.Position = position;
            this.Orientation = 0;
            this.Largeur = largeur;
            this.Hauteur = hauteur;
            this.Color = Color.Black;

            if(this.Largeur == this.Hauteur)
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
            this.ID = Canvas.ProchainID();
            this.Position = position;
            this.Orientation = 0;
            this.Largeur = largeur;
            this.Hauteur = hauteur;
            this.Color = Color.FromArgb(255, r, g, b);

            if (this.Largeur == this.Hauteur)
            {
                this.Type = "Cercle   ";
            }
            else
            {
                this.Type = "Ellipse  ";
            }
        }

        public override void Afficher()
        {
            if (!EstDehors(this.Position.X, this.Position.Y, 0, 0))  
            { 
                Matrix matrix = new Matrix();

                //Rotate the graphics object the required amount around this point
                matrix.RotateAt(this.Orientation, new PointF(this.Position.X, this.Position.Y));
                Canvas.instance.Graphic.Transform = matrix;

                //Draw the rotated ellipse
                Rectangle r = new Rectangle(this.Position.X- this.Largeur /2, this.Position.Y- this.Hauteur /2, this.Largeur, this.Hauteur);
                Canvas.instance.Graphic.FillEllipse(new SolidBrush(this.Color), r);
                Console.WriteLine(this.Type + " " + this.ID + " : Affichage effectué.");

                //Rotate back to normal around the same point</pre>
                matrix.RotateAt(-this.Orientation, new PointF(this.Position.X, this.Position.Y));
                Canvas.instance.Graphic.Transform = matrix;
            }
            else
            {
                Console.WriteLine(this.Type + " " + this.ID + " : Hors canvas.");
            }
        }

        public override Forme Dupliquer(int positionX, int positionY)
        {
            Ellipse forme = new Ellipse(new Point(positionX, positionY), this.Largeur, this.Hauteur);
            forme.Color = this.Color;
            forme.Orientation = this.Orientation;
            Canvas.instance.Formes.Add(forme);
            Console.WriteLine(this.Type + " " + this.ID + " : Duplication réussie.");
            return forme;
        }

        public override void Deplacer(int positionX, int positionY)
        {
            this.Position = new Point(positionX, positionY);
            Console.WriteLine(this.Type + " " + this.ID + " : Déplacement de (" + this.Position.X + ", " + this.Position.Y + ") à (" + positionX + ", " + positionY + ")  effectué.");
        }

        public override void Dimensionner(float taille)
        {
            this.Largeur = (int)(this.Largeur * taille);
            this.Hauteur = (int)(this.Hauteur * taille);
            Console.WriteLine(this.Type + " " + this.ID + " : Dimensionnement par un facteur " + taille + " effectué.");
        }
    }
}
