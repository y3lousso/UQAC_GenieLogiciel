using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCP
{
    public class Cercle : Forme
    {
        public Vector2 Position { get; set; } 
        public int Rayon { get; set; } 

        internal Cercle(Vector2 position, int rayon)
        {
            this.Position = position;
            this.Rayon = rayon;
        }
    }
}
