using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCP
{
    public class Rectangle : Forme
    {
        public Vector2 Position { get; set; }
        public int Largeur { get; set; }
        public int Hauteur { get; set; }

        internal Rectangle(Vector2 position, int largeur, int hauteur)
        {
            this.Position = position;
            this.Largeur = largeur;
            this.Hauteur = hauteur;
        }
    }
}
