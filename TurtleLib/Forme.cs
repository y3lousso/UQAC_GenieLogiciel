using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCP
{
    internal class Forme
    {
        int Id { get; set; }
        List<Vector2> Points { get; set; }

        protected void Dessiner()
        {

        }

        protected void Tourner(float angle)
        {

        }

        protected void Translater(Vector2[] points)
        {

        }

        protected void Homothetie(Vector2[] points, int taille)
        {

        }

        protected void ColorierForme(string color)
        {

        }

        protected void ColorierForme(int r, int g, int b)
        {

        }
    }
}
