﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using AMCP.Formes;

namespace AMCP.InterfaceUtilisateur
{
    public class Canvas : Form
    {
        internal static Canvas instance;
        internal Graphics Graphic { get; set; } 

        internal List<Forme> Formes { get; set; } 

        private static int dernierID;

        public Canvas(int sizeX, int sizeY)
        {
            if (instance == null)
            {
                instance = this;
                this.Size = new Size(sizeX, sizeY);
                this.Graphic = this.CreateGraphics();
                this.Graphic.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphic.Clear(Color.White);
                this.CenterToScreen();
                dernierID = 0;// On set les id a 0.

                Console.WriteLine("Surface dessinable : " + this.Graphic.VisibleClipBounds);
                this.Formes = new List<Forme>();
                this.Show();
            }
            else
            {
                throw new Exception("Impossible de créer plusieurs instances du Canvas !");
            }
        }
        
        //TODO : Manque NettoyerCanvas() et EffacerForme(int index)
        
        public void ChangerDimension(int sizeX, int sizeY)
        {
            this.Size = new Size(sizeX, sizeY);
        }

        public static int prochainID()
        {
            dernierID += 1;
            return dernierID;
        }
    }
}
