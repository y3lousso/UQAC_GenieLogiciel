using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using AMCP.InterfaceUtilisateur;
using AMCP.Noyau;

namespace AMCP.Formes
{
    internal class Texte : Forme
    {
        int TaillePolice { get; set; }
        internal string Contenu { get; set; }

        internal Texte(Point position, int taillePolice, string contenu)
        {
            this.ID = Canvas.ProchainID();
            this.Position = position;
            this.Color = Color.Black;
            this.TaillePolice = taillePolice;
            this.Contenu = contenu;
            this.Type = "Texte    ";
        }

        public override void Afficher()
        {
            if (!EstDehors(Position.X, Position.Y, 0, 0))
            { 
                var fontFamily = new FontFamily("Arial");
                var font = new Font(fontFamily, this.TaillePolice, FontStyle.Regular, GraphicsUnit.Pixel);
                var solidBrush = new SolidBrush(this.Color);

                Matrix matrix = new Matrix();

                //Rotate the graphics object the required amount around this point
                matrix.RotateAt(this.Orientation, new PointF(this.Position.X, this.Position.Y));
                Canvas.instance.Graphic.Transform = matrix;

                //Draw the rotated ellipse
                Canvas.instance.Graphic.DrawString(this.Contenu, font, solidBrush, this.Position);
                IMode.instance.Logger(this.Type + " " + this.ID + " : Affichage effectué.", ConsoleColor.Green);

                //Rotate back to normal around the same point</pre>
                matrix.RotateAt(-this.Orientation, new PointF(this.Position.X, this.Position.Y));
                Canvas.instance.Graphic.Transform = matrix;

                Canvas.instance.Graphic.TextRenderingHint = TextRenderingHint.AntiAlias;
            }
            else
            {
                IMode.instance.Logger(this.Type + " " + this.ID + " : Hors canvas.", ConsoleColor.Yellow);
            }
            
        }

        public override Forme Dupliquer(int positionX, int positionY)
        {
            Forme forme = new Texte( new Point(positionX, positionY),  this.TaillePolice, this.Contenu);
            forme.Color = this.Color;
            forme.Orientation = this.Orientation;
            Canvas.instance.Formes.Add(forme);
            IMode.instance.Logger(this.Type + " " + this.ID + " : Duplication réussie.", ConsoleColor.Green);
            return forme;
        }

        public override void Dimensionner(float taille)
        {
            this.TaillePolice = (int)(taille * this.TaillePolice);
            if (this.TaillePolice < 1)
            {
                this.TaillePolice = 1;
            }
            IMode.instance.Logger(this.Type + " " + this.ID + " : Dimensionnement par un facteur " + taille + " effectué.", ConsoleColor.Green);
        }
    }
}
