﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCP
{
    public class Ellipse : Forme
    {
        public Vector2 position { get; set; }
        float PetitRayon { get; set; }
        float GrandRayon { get; set; }
            
        internal Ellipse(Vector2 position, int rayon1, int rayon2)
        {
            this.position = position;
            this.PetitRayon = rayon1;
            this.GrandRayon = rayon2;
        }
    }
}