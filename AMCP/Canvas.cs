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

        public Graphics Graphic { get; set; }
        public List<Forme> Formes { get; set; }
        public int tailleX { get;set;}
        public int tailleY { get; set; }

        public Canvas(int sizeX, int sizeY)
        {
            this.tailleX = sizeX;
            this.tailleY = sizeY;

            if (instance == null)
            {
                instance = this;
                this.Size = new Size(sizeX, sizeY);
                this.Graphic = this.CreateGraphics();
                this.Graphic.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphic.Clear(Color.White);
                this.CenterToScreen();

                this.Graphic.ScaleTransform(1, -1);
                this.Graphic.TranslateTransform(0, -Height+45);

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
