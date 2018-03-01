using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AMCP;


namespace CEGEP_Student
{
    class Program
    {
        static void Main(string[] args)
        {

            // 0 -> démo séquenciel
            // 1 -> démo OOP
            // 2 -> sequenciel rotation
            // 3 -> opp rotation

            int test = 2;

            switch (test)
            {
                case 0:
                    {
                        Console.WriteLine("------ Sequenciel -------");
                        InterfaceSequenciel i = new InterfaceSequenciel();

                        for (int x = 0; x < 5; x++)
                        {
                            int posX = 20 * x + 80;
                            int posY = (20 * x) + x + 80;
                            i.DessinerRectangle(posX, posY, 50, 70);
                            i.DessinerEtoile(posX, posY + 100, 40, 80, 5);
                            i.DessinerCercle(100 + posX, posY, 20);
                            i.DessinerEllipse(posX, posY + 250, 20, 50);
                        }

                        i.Afficher(200);
                        break;
                    }

                case 1:
                    {
                        Console.WriteLine("------ OOP -------");
                        InterfaceOrienteObjet i = new InterfaceOrienteObjet();

                        for (int x = 0; x < 5; x++)
                        {
                            int posX = 20 * x + 80;
                            int posY = (20 * x) + x + 80;
                            i.DessinerRectangle(posX, posY, 50, 70);
                            i.DessinerEtoile(posX, posY + 100, 40, 80, 5);
                            i.DessinerCercle(100 + posX, posY, 20);
                            i.DessinerEllipse(posX, posY + 250, 20, 50);
                        }

                        i.Afficher(200);

                        break;
                    }

                case 2:
                    {
                        Console.WriteLine("------ Sequentiel : rotation -------");
                        InterfaceSequenciel i = new InterfaceSequenciel();

                        i.Pause();

                        int posX = 250;
                        int posY = 250;

                        int etoileID = i.DessinerEtoile(posX, posY + 100, 40, 80, 5);

                        for (int j = 0; j < 100; j++)
                        {
                            i.Tourner(etoileID, 20);
                            i.Afficher(100);
                            i.NettoyerEcran();
                        }

                        i.Pause();

                        break;
                    }

                case 3:
                    {
                        Console.WriteLine("------ OOP : rotation -------");
                        InterfaceOrienteObjet i = new InterfaceOrienteObjet();

                        i.Pause();

                        int posX = 250;
                        int posY = 250;
                        Polygone p1 = i.DessinerEtoile(posX, posY + 100, 40, 80, 5);
                        for (int j = 0; j < 100; j++)
                        {                       
                            p1.Tourner(20);
                            i.Afficher(100);
                            i.NettoyerEcran();
                        } 

                        i.Pause();
                        break;
                    }

                default:
                    Console.WriteLine("Select a correct test");
                    break;
            }
            
        }
    }
}









