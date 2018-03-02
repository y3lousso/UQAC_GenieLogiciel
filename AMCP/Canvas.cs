using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AMCP
{
    public class Canvas : Form
    {
        public static Canvas instance;

        public Graphics Graphic { get; set; } 
        public List<Forme> Formes { get; set; } 

        public Canvas(int sizeX, int sizeY)
        {
            if(instance == null)
            {
                instance = this;
                this.Size = new Size(sizeX, sizeY);
                this.Graphic = this.CreateGraphics();              
                this.Graphic.SmoothingMode = SmoothingMode.AntiAlias;
                this.Formes = new List<Forme>();
                this.Show();
            }
            else
            {
            //TODO chaine de description en Anglais
                throw new Exception("Can't create multiple instance of Canvas");
            }
        }


        public void ChangerDimension(int sizeX, int sizeY)
        {
            this.Size = new Size(sizeX, sizeY);
        }

        public void ChargerImage(string cheminImage)
        {

        }
    }
}
