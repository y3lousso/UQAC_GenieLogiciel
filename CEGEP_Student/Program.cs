using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using AMCP;


namespace CEGEP_Student
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            InterfaceSequenciel i = new InterfaceSequenciel();

            for (int x = 0; x < 20; x++)
            {
                int posX = 20 * x;
                int posY = (20 * x) + x;
                i.DessinerRectangle(posX, posY, 50, 70);
                i.DessinerCercle(posX, posY+50, 20);
                Thread.Sleep(500);
                Canvas.instance.Show();
            }

            Console.ReadLine();
            */

            InterfaceOrienteObjet i = new InterfaceOrienteObjet();

            for (int x = 0; x < 5; x++)
            {
                int posX = 20 * x;
                int posY = (20 * x) + x;               
                i.DessinerRectangle(new Vector2(posX,posY), 50, 70); 
                i.DessinerCercle(new Vector2(100+posX,posY), 20);
                i.DessinerCarre(new Vector2(posX, posY + 150), 30);
                i.DessinerEllipse(new Vector2(posX, posY + 250), 20, 50);
                Thread.Sleep(500);
                Canvas.instance.Show();
            }

            Console.ReadLine();
            
        }
    }
}









