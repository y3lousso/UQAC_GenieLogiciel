using System;
using System.Drawing;
using AMCP.InterfaceUtilisateur;

namespace AMCP.Formes
{
    public abstract class Forme
    {
        public int ID { get; protected set; }
        public Point Position { get; internal set; }
        public int Orientation { get; internal set; }
        public Color Color { get; internal set; }
        public string Type { get; set; } = "Forme";

        internal abstract void Afficher();

        public abstract Forme Dupliquer(int positionX, int positionY);

        public virtual void Colorier(int r, int g, int b)
        {
            this.Color = Color.FromArgb(255, r, g, b);
            Console.WriteLine(Type + " " + ID + " : Couleur changée."); // TODO : this
        }

        public virtual void Deplacer(int positionX, int positionY)
        {
            this.Position = new Point(positionX, positionY);
            Console.WriteLine(Type + " " + ID + " : Déplacement de (" + Position.X + ", " + Position.Y + ") à (" + positionX + ", " + positionY + ")  effectué."); // TODO : this
        }

        public abstract void Dimensionner(float taille);

        public virtual void Tourner(int angle)
        {
            this.Orientation += angle;
            Console.WriteLine(Type + " " + ID + " : Rotation d'un angle de " + angle + "(degrées) effectuée."); // TODO : this
        }

        internal Boolean EstDehors(float positionX, float positionY, float tailleX, float tailleY)
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
