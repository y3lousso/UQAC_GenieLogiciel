using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using AMCP.InterfaceUtilisateur;
using AMCP.Noyau;

namespace AMCP.Formes
{
    internal class Image : Forme
    {
        string ImageName { get; set; }
        Bitmap CurrentImage { get; set; }

        internal Image(Point position, string imageName)
        {
            this.ID = Canvas.ProchainID();
            this.Position = position;
            this.ImageName = imageName;
            this.CurrentImage = (Bitmap)System.Drawing.Image.FromFile(this.ImageName);
            this.Type = "Image    "; 
        }

        public override void Afficher()
        {
            if(this.CurrentImage == null)
            {
                IMode.instance.Logger(this.Type + " " + this.ID + " : Chargement de l'image erroné.", ConsoleColor.Red);
            }
            else if(!EstDehors(this.Position.X, this.Position.Y, 0, 0))
            {
                Matrix matrix = new Matrix();

                //Rotate the graphics object the required amount around this point
                matrix.RotateAt(this.Orientation, new PointF(this.Position.X, this.Position.Y));
                Canvas.instance.Graphic.Transform = matrix;

                Point centerTweaker = new Point(this.Position.X - this.CurrentImage.Width/2, this.Position.Y - this.CurrentImage.Height/2);
                Canvas.instance.Graphic.DrawImage(this.CurrentImage, centerTweaker);
                IMode.instance.Logger(this.Type + " " + this.ID + " : Affichage effectué.", ConsoleColor.Green);

                //Rotate back to normal around the same point</pre>
                matrix.RotateAt(-this.Orientation, new PointF(this.Position.X, this.Position.Y));
                Canvas.instance.Graphic.Transform = matrix;
            }
            else
            {
                IMode.instance.Logger(this.Type + " " + this.ID + " : Hors canvas.", ConsoleColor.Yellow);
            }
        }

        public override Forme Dupliquer(int positionX, int positionY)
        {            
            Forme forme = new Image(new Point(positionX, positionY), this.ImageName);
            forme.Color = this.Color;
            forme.Orientation = this.Orientation;
            Canvas.instance.Formes.Add(forme);
            IMode.instance.Logger(Type + " " + ID + " : Duplication réussie.", ConsoleColor.Green);
            return new Image(new Point(positionX, positionY), this.ImageName);
        }

        public override void Colorier(int r, int g, int b)
        {
            base.Colorier(r, g, b);
            IMode.instance.Logger(this.Type + " " + this.ID + " : Impossible d'appliquer un filtre de couleur. (Non implémenté)", ConsoleColor.Red);
        }

        public override void Dimensionner(float taille)
        {
            int newWidth = (int)(this.CurrentImage.Width * taille);
            int newHeight = (int)(this.CurrentImage.Height * taille);
            this.CurrentImage = new Bitmap(this.CurrentImage, new Size(newWidth, newHeight) );
            IMode.instance.Logger(this.Type + " " + this.ID + " : Dimensionnement par un facteur " + taille + " effectué.", ConsoleColor.Green);
        }
    }
}
