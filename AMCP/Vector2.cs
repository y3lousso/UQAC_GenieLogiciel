using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCP
{
    public class Vector2
    {
        public int X { get; set; } //TODO pas de majuscule cf 6.6
        public int Y { get; set; } //TODO pas de majuscule cf 6.6

        public Vector2(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
