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
        int Id { get; set; } // TODO : Les abréviations sont en UPPER
        public Point Position { get; internal set; }
        public Color Color { get; internal set; }

        internal abstract void Afficher();

        public abstract Forme Dupliquer(int positionX, int positionY);

        public abstract void Colorier(int r, int g, int b);

        public abstract void Deplacer(int positionX, int positionY);

        public abstract void Dimensionner(float taille);

        public abstract void Tourner(int angle);

        //public abstract void Supprimer();

        public int getId()
        {
            return Id;
        }
    }
}
