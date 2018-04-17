using System;
using System.Drawing;
using AMCP.InterfaceUtilisateur;

namespace AMCP.Formes
{
    public abstract class Forme
    {
        public int ID { get; set; }
        public Point Position { get; set; }
        public int Orientation { get; set; }
        public Color Color { get; set; }
        public string Type { get; set; } = "Forme";

        public abstract void Afficher();

        /// <summary>
        /// Permet créer une forme, image, texte à partir de l'id d'un objet existant.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <returns></returns>
        public abstract Forme Dupliquer(int positionX, int positionY);

        /// <summary>
        /// Permet de colorier une forme.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        public virtual void Colorier(int r, int g, int b)
        {
            this.Color = Color.FromArgb(255, r, g, b);
            Console.WriteLine(this.Type + " " + this.ID + " : Couleur changée.");
        }

        /// <summary>
        /// Permet de déplacer une forme.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        public virtual void Deplacer(int positionX, int positionY)
        {
            this.Position = new Point(positionX, positionY);
            Console.WriteLine(this.Type + " " + this.ID + " : Déplacement de (" + this.Position.X + ", " + this.Position.Y + ") à (" + positionX + ", " + positionY + ")  effectué."); 
        }

        /// <summary>
        /// Permet de changer la taille d'une forme.
        /// </summary>
        /// <param name="taille"></param>
        public abstract void Dimensionner(float taille);

        /// <summary>
        /// Permet de tourner une forme.
        /// </summary>
        /// <param name="angle"></param>
        public virtual void Tourner(int angle)
        {
            this.Orientation += angle;
            Console.WriteLine(this.Type + " " + this.ID + " : Rotation d'un angle de " + angle + "(degrées) effectuée.");
        }

        /// <summary>
        /// Permet de supprimer une forme.
        /// </summary>
        public virtual void Supprimer()
        {
            Canvas.instance.Formes.Remove(this);
            Console.WriteLine(this.Type + " " + this.ID + " : Suppression effectuée.");
        }

        public Boolean EstDehors(float positionX, float positionY, float tailleX, float tailleY)
        {
            if (positionX - tailleX / 2 < 0
                || positionX + tailleX / 2 > Canvas.instance.Graphic.VisibleClipBounds.Width
                || positionY - tailleY / 2 < 0
                || positionY + tailleY / 2 > Canvas.instance.Graphic.VisibleClipBounds.Height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
