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
            // 4 -> reverse Y axis test
            // 5 -> car demo

            int test = 5;

            switch (test)
            {
                case 0:
                    {
                        Console.WriteLine("------ Sequenciel -------");
                        InterfaceSequencielle i = new InterfaceSequencielle();

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
                        InterfaceOrienteeObjet i = new InterfaceOrienteeObjet();

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
                        InterfaceSequencielle i = new InterfaceSequencielle();

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
                        InterfaceOrienteeObjet i = new InterfaceOrienteeObjet();

                        i.Pause();

                        int posX = 250;
                        int posY = 250;
                        Forme p1 = i.DessinerEtoile(posX, posY + 100, 40, 80, 5);
                        for (int j = 0; j < 100; j++)
                        {                       
                            p1.Tourner(20);
                            i.Afficher(100);
                            i.NettoyerEcran();
                        } 

                        i.Pause();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("------ Reverse Y Axis Test -------");
                        InterfaceOrienteeObjet i = new InterfaceOrienteeObjet();

                        int posX = 0;
                        int posY = 0;

                        Forme rectangle = i.DessinerCarre(50+posX, 50+posY, 100);
                        Forme cercle = i.DessinerCercle(posX+100, posY+100, 50);

                        i.Afficher();
                        i.Pause();
                        break;
                    }

                case 5:
                    {
                        Console.WriteLine("------ Car demo -------");
                        InterfaceOrienteeObjet i = new InterfaceOrienteeObjet();

                        int posX = 100;
                        int posY = 100;

                        i.Pause();

                        Forme background = i.DessinerRectangle(600, 600, 1500, 1500);
                        background.Colorier(0,255, 255);                       
                        Forme road = i.DessinerRectangle(600, 25, 1500, 50);
                        road.Colorier(50, 50, 50);
                        Forme car = i.DessinerRectangle(posX, posY, 200, 50);
                        car.Colorier(255, 0, 0);
                        Forme wheel1 = i.DessinerCercle(posX - 85, posY - 50, 50);
                        wheel1.Colorier(0, 0, 0);
                        Ellipse wheel2 = (Ellipse)wheel1.Dupliquer(posX + 85, posY - 50);
                        wheel2.Colorier(0, 0, 0);

                        // Toit de la voiture
                        i.Pointeur.Deplacer(posX-50, posY+20);
                        i.Pointeur.DescendrePointeur();
                        i.Pointeur.Tourner(45);
                        i.Pointeur.Avancer(50);
                        i.Pointeur.Tourner(-45);
                        i.Pointeur.Avancer(50);
                        i.Pointeur.Tourner(-45);
                        i.Pointeur.Avancer(50);
                        i.Pointeur.LeverPointeur();
                        Forme toit = i.Pointeur.Dessiner();

                        for (int j = 0; j < 50; j++)
                        {
                            i.AfficherTout(100);
                            posX += 10;
                            car.Deplacer(posX, posY);
                            wheel1.Deplacer(posX - 85, posY - 50);
                            wheel2.Deplacer(posX + 85, posY - 50);
                            toit.Deplacer(posX-50, posY + 20);
                            i.NettoyerEcran();
                        }

                        i.AfficherTout();
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









