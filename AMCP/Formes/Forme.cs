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
        int Id { get; set; }
        protected Point Position { get; set; }        

        internal abstract void Afficher();

        public abstract void Dupliquer(int positionX, int positionY);

        public abstract void Colorier(int r, int g, int b);

        public abstract void Tourner(int angle);

        public abstract void Deplacer(int positionX, int positionY);

        public abstract void Dimensionner(float taille);
    }
}
