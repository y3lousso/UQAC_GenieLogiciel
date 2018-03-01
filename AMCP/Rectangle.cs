using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCP
{
    public class Rectangle : Forme
    {
        public Vector2 Position { get; set; } //TODO pas de majuscule cf 6.6
        public int Largeur { get; set; } //TODO pas de majuscule cf 6.6
        public int Hauteur { get; set; } //TODO pas de majuscule cf 6.6

        internal Rectangle(Vector2 position, int largeur, int hauteur)
        {
            this.Position = position;
            this.Largeur = largeur;
            this.Hauteur = hauteur;
        }
    }
}
