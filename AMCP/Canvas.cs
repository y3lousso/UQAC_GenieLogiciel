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
        internal static Canvas instance;
        internal Graphics Graphic { get; set; } // TODO : Les internal sont en Camel

        internal List<Forme> Formes { get; set; } // TODO : Les internal sont en Camel

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

                this.Graphic.ScaleTransform(1, -1);
                // TODO : trouver un fix à ce truc de merde :)
                this.Graphic.TranslateTransform(0, -Height+39);

                this.Formes = new List<Forme>();
                this.Show();
            }
            else
            {
                throw new Exception("Can't create multiple instance of Canvas");
            }
        }

        public void ChangerDimension(int sizeX, int sizeY)
        {
            this.Size = new Size(sizeX, sizeY);
        }
        
        public void ChargerImage(string cheminImage, int positionX, int positionY)
        {

        }
    }
}
