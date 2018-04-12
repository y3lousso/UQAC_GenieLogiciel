using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using AMCP.InterfaceUtilisateur;

namespace AMCP.Formes
{
    internal class Texte : Forme
    {
        int TaillePolice { get; set; }
        internal string Contenu { get; set; }

        internal Texte(Point position, int taillePolice, string contenu)
        {
            this.ID = Canvas.prochainID();
            this.Position = position;
            this.Color = Color.Black;
            this.TaillePolice = taillePolice;
            this.Contenu = contenu;
            this.Type = "Texte    ";
        }

        internal override void Afficher()
        {
            if (!EstDehors(Position.X, Position.Y, 0, 0))
            { 
                var fontFamily = new FontFamily("Arial");
                var font = new Font(fontFamily, this.TaillePolice, FontStyle.Regular, GraphicsUnit.Pixel);
                var solidBrush = new SolidBrush(this.Color);

                Matrix matrix = new Matrix();

                //Rotate the graphics object the required amount around this point
                matrix.RotateAt(this.Orientation, new PointF(Position.X, Position.Y));
                Canvas.instance.Graphic.Transform = matrix;

                //Draw the rotated ellipse
                Canvas.instance.Graphic.DrawString(this.Contenu, font, solidBrush, this.Position);
                Console.WriteLine(Type + " " + ID + " : Affichage effectué."); // TODO : this

                //Rotate back to normal around the same point</pre>
                matrix.RotateAt(-this.Orientation, new PointF(Position.X, Position.Y));
                Canvas.instance.Graphic.Transform = matrix;

                Canvas.instance.Graphic.TextRenderingHint = TextRenderingHint.AntiAlias;
            }
            else
            {
                Console.WriteLine(Type + " " + ID + " : Hors canvas."); // TODO : this
            }
            
        }

        public override Forme Dupliquer(int positionX, int positionY)
        {
            Forme forme = new Texte( new Point(positionX, positionY),  this.TaillePolice, this.Contenu);
            forme.Color = this.Color;
            forme.Orientation = this.Orientation;
            Canvas.instance.Formes.Add(forme);
            Console.WriteLine(Type + " " + ID + " : Duplication réussie."); // TODO : this
            return forme;
        }

        public override void Dimensionner(float taille)
        {
            TaillePolice = (int)taille * TaillePolice;
            Console.WriteLine(Type + " " + ID + " : Dimensionnement par un facteur " + taille + " effectué."); // TODO : this
        }
    }
}
