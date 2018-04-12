using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using AMCP.InterfaceUtilisateur;

namespace AMCP.Formes
{
    internal class Image : Forme
    {
        string ImageName { get; set; }
        Bitmap CurrentImage { get; set; }

        internal Image(Point position, string imageName)
        {
            this.ID = Canvas.prochainID();
            this.Position = position;
            this.ImageName = imageName;
            this.CurrentImage = (Bitmap)System.Drawing.Image.FromFile(this.ImageName);
            this.Type = "Image    "; 
        }

        internal override void Afficher()
        {
            if(CurrentImage == null)
            {
                Console.WriteLine(Type + " " + ID + " : Chargement de l'image erroné.");
            }
            else if(!EstDehors(Position.X,Position.Y, 0, 0)) // TODO : centrer l'image sur la position
            {
                Matrix matrix = new Matrix();

                //Rotate the graphics object the required amount around this point
                matrix.RotateAt(this.Orientation, new PointF(Position.X + CurrentImage.Width / 2, Position.Y + CurrentImage.Height / 2));
                Canvas.instance.Graphic.Transform = matrix;
                
                Canvas.instance.Graphic.DrawImage(this.CurrentImage, this.Position);
                Console.WriteLine(Type + " " + ID + " : Affichage effectué.");

                //Rotate back to normal around the same point</pre>
                matrix.RotateAt(-this.Orientation, new PointF(Position.X + CurrentImage.Width / 2, Position.Y + CurrentImage.Height / 2));
                Canvas.instance.Graphic.Transform = matrix;
            }
            else
            {
                Console.WriteLine(Type + " " + ID + " : Hors canvas.");
            }
        }

        public override Forme Dupliquer(int positionX, int positionY)
        {            
            Forme forme = new Image(new Point(positionX, positionY), this.ImageName);
            forme.Color = this.Color;
            forme.Orientation = this.Orientation;
            Canvas.instance.Formes.Add(forme);
            Console.WriteLine(Type + " " + ID + " : Duplication réussie.");
            return new Image(new Point(positionX, positionY), this.ImageName);
        }

        public override void Colorier(int r, int g, int b)
        {
            base.Colorier(r, g, b);
            Console.WriteLine(Type + " " + ID + " : Impossible d'appliquer un filtre de couleur. (Non implémenté)");
        }

        public override void Dimensionner(float taille)
        {
            int newWidth = (int)(this.CurrentImage.Width * taille);
            int newHeight = (int)(this.CurrentImage.Height * taille);
            this.CurrentImage = new Bitmap(this.CurrentImage, new Size(newWidth, newHeight) );
            Console.WriteLine(Type + " " + ID + " : Dimensionnement par un facteur " + taille + " effectué."); // TODO : this
        }
    }
}
