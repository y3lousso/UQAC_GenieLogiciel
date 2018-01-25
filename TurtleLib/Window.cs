using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Numerics;

namespace TurtleLib
{
    public class Window
    {
        public Window(int sizeX, int sizeY)
        {
            Form form = new Form();
            form.Size = new Size(sizeX, sizeY);
            form.Show();
        }
    }
}
