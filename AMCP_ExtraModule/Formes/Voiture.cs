using System;
using System.Drawing;
using AMCP.InterfaceUtilisateur;
using AMCP.Formes;
using System.Drawing.Drawing2D;
using AMCP.Noyau;

namespace AMCP_ExtraModule.Formes
{
    public class Voiture : AMCP.Formes.Forme
    {
        public int Size { get; set; } = 1;

        public Voiture(Point position)
        {
            this.ID = Canvas.ProchainID();
            this.Position = position;
            this.Orientation = 0;
            this.Color = Color.Red;
            this.Type = "Voiture  ";
        }

        public Voiture(Point position, int orientation, Color color)
        {
            this.ID = Canvas.ProchainID();
            this.Position = position;
            this.Orientation = orientation;
            this.Color = color;
            this.Type = "Voiture  ";
        }

        public override void Afficher()
        {
            if (!EstDehors(this.Position.X, this.Position.Y, 0, 0))
            {
                Matrix matrix = new Matrix();

                //Rotate the graphics object the required amount around this point
                matrix.RotateAt(this.Orientation, new PointF(Position.X, Position.Y));
                Canvas.instance.Graphic.Transform = matrix;

                Rectangle rBody = new Rectangle(Position.X-40*Size, Position.Y, 100* Size, 30* Size);
                Rectangle rRoueGauche = new Rectangle(Position.X - 40 * Size, Position.Y - 20 * Size, 20 * Size, 20 * Size);
                Rectangle rRoueDroite = new Rectangle(Position.X + 40 * Size, Position.Y - 20 * Size, 20 * Size, 20 * Size);
                Canvas.instance.Graphic.FillRectangle(new SolidBrush(this.Color), rBody);
                Canvas.instance.Graphic.FillEllipse(new SolidBrush(Color.Black), rRoueGauche);
                Canvas.instance.Graphic.FillEllipse(new SolidBrush(Color.Black), rRoueDroite);

                IMode.instance.Logger(this.Type + " " + this.ID + " : Affichage effectué.", ConsoleColor.Green);

                //Rotate back to normal around the same point</pre>
                matrix.RotateAt(-this.Orientation, new PointF(Position.X, Position.Y));
                Canvas.instance.Graphic.Transform = matrix;
            }
            else
            {
                IMode.instance.Logger(this.Type + " " + this.ID + " : Hors canvas.", ConsoleColor.Yellow);
            }
        }

        /// <summary>
        /// Permet créer une forme, image, texte à partir de l'id d'un objet existant.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <returns></returns>
        public override Forme Dupliquer(int positionX, int positionY)
        {
            Voiture newVoiture = new Voiture(new Point(positionX, positionY), this.Orientation, this.Color);
            Canvas.instance.Formes.Add(newVoiture);
            return newVoiture;
        }

        /// <summary>
        /// Permet de colorier une forme.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        public override void Colorier(int r, int g, int b)
        {
            this.Color = Color.FromArgb(255, r, g, b);
            IMode.instance.Logger(this.Type + " " + this.ID + " : Couleur changée.", ConsoleColor.Green);
        }

        /// <summary>
        /// Permet de tourner une forme.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        public override void Deplacer(int positionX, int positionY)
        {
            this.Position = new Point(positionX, positionY);
            IMode.instance.Logger(this.Type + " " + this.ID + " : Déplacement de (" + this.Position.X + ", " + this.Position.Y + ") à (" + positionX + ", " + positionY + ")  effectué.", ConsoleColor.Green);
        }

        /// <summary>
        /// Permet de déplacer une forme.
        /// </summary>
        /// <param name="taille"></param>
        public override void Dimensionner(float taille)
        {

        }

        /// <summary>
        /// Permet de changer la taille d'une forme.
        /// </summary>
        /// <param name="angle"></param>
        public override void Tourner(int angle)
        {
            this.Orientation += angle;
            IMode.instance.Logger(this.Type + " " + this.ID + " : Rotation d'un angle de " + angle + "(degrées) effectuée.", ConsoleColor.Green);
        }

        /// <summary>
        /// Permet de supprimer une forme.
        /// </summary>
        public override void Supprimer()
        {
            Canvas.instance.Formes.Remove(this);
            IMode.instance.Logger(this.Type + " " + this.ID + " : Suppression effectuée.", ConsoleColor.Green);
        }
    }
}
