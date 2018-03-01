using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCP
{
    public class Ellipse : Forme
    {
        float PetitRayon { get; set; }
        float GrandRayon { get; set; }
            
        internal Ellipse(Point position, int rayon1, int rayon2)
        {
            this.Position = position;
            this.PetitRayon = rayon1;
            this.GrandRayon = rayon2;
        }

        internal override void Afficher()
        {
            Canvas.instance.Graphic.DrawEllipse(new Pen(Color.Black), Position.X, Position.Y, PetitRayon, GrandRayon);
            if (PetitRayon == GrandRayon)
            {
                Console.WriteLine("Un cercle a été dessiné.");
            }
            else
            {
                Console.WriteLine("Une ellipse a été dessiné.");
            }
        }

        public override void Dupliquer(int positionX, int positionY)
        {

        }

        public override void Colorier(int r, int g, int b)
        {
            // Different from other shape
        }

        public override void Tourner(int angle)
        {
            // Different from other shape
        }

        public override void Deplacer(int positionX, int positionY)
        {
            Position = new Point(positionX, positionY);
        }

        public override void Dimensionner(float taille)
        {

        }
    }
}
