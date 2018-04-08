﻿using System;
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
        }

        internal override void Afficher()
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

            //Rotate back to normal around the same point</pre>
            matrix.RotateAt(-this.Orientation, new PointF(Position.X, Position.Y));
            Canvas.instance.Graphic.Transform = matrix;

            Canvas.instance.Graphic.TextRenderingHint = TextRenderingHint.AntiAlias;
            
        }

        public override Forme Dupliquer(int positionX, int positionY)
        {
            Forme forme = new Texte( new Point(positionX, positionY),  this.TaillePolice, this.Contenu);
            Canvas.instance.Formes.Add(forme);
            return forme;
        }

        public override void Colorier(int r, int g, int b)
        {
            this.Color = Color.FromArgb(255, r, g, b);
        }

        public override void Deplacer(int positionX, int positionY)
        {
            if (!EstDehors(positionX, positionY, 1,1))
            {
                this.Position = new Point(positionX, positionY);
            }
            else
            {
                Console.WriteLine("Déplacement impossible");
            }               
        }

        public override void Dimensionner(float taille)
        {
            TaillePolice = (int)taille * TaillePolice;
        }

        public override void Tourner(int angle)
        {
            this.Orientation += angle;
        }
    }
}
