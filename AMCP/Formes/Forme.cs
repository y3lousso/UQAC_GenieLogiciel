using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCP
{
    public abstract class Forme
    {
        public int Id { get; protected set; }
        public Point Position { get; internal set; }
        public Color Color { get; internal set; }

        internal abstract void Afficher();

        public abstract Forme Dupliquer(int positionX, int positionY);

        public abstract void Colorier(int r, int g, int b);

        public abstract void Deplacer(int positionX, int positionY);

        public abstract void Dimensionner(float taille);

        public abstract void Tourner(int angle);

        //public abstract void Supprimer();

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
