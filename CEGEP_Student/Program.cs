using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AMCP.Noyau;
using AMCP.Formes;

namespace CEGEP_Student
{
    class Program
    {
        static void PlayTest(int id)
        {
            switch (id)
            {
                case 0:
                    {
                        ModeSequentiel i = new ModeSequentiel();
                        i.ListerContributeur();
                        i.Pause();
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("------ Sequentiel : rotation -------");
                        ModeSequentiel i = new ModeSequentiel();

                        i.Pause();

                        int posX = 250;
                        int posY = 250;

                        int etoileId = i.CreerEtoile(posX, posY + 100, 40, 80, 5);

                        for (int j = 0; j < 20; j++)
                        {
                            i.Tourner(etoileId, 20);
                            i.Afficher();
                            i.Attendre(0.1f);
                            i.NettoyerEcran();
                        }

                        i.Pause();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("------ OOP : rotation -------");
                        ModeOrienteObjet i = new ModeOrienteObjet();

                        i.Pause();

                        Forme p1 = i.CreerEtoile(100, 100, 40, 80, 5);

                        // Toit de la voiture
                        i.Stylo.Deplacer(100, 100);
                        i.Stylo.DescendrePointeur();
                        i.Stylo.Tourner(45);
                        i.Stylo.Avancer(100);
                        i.Stylo.Tourner(-45);
                        i.Stylo.Avancer(100);
                        i.Stylo.Tourner(-45);
                        i.Stylo.Avancer(100);
                        i.Stylo.LeverPointeur();
                        Forme toit = i.Stylo.Dessiner();

                        for (int j = 0; j < 100; j++)
                        {
                            p1.Tourner(5);
                            toit.Tourner(5);
                            i.Afficher();
                            i.Attendre(0.1f);
                            i.NettoyerEcran();
                        }

                        i.Pause();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("------ Reverse Y Axis Test -------");
                        ModeOrienteObjet i = new ModeOrienteObjet();

                        int posX = 0;
                        int posY = 0;

                        Forme rectangle = i.CreerCarre(50 + posX, 50 + posY, 100);
                        Forme cercle = i.CreerCercle(posX + 100, posY + 100, 50);

                        i.Afficher();
                        i.Pause();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("------ Car demo -------");
                        ModeOrienteObjet i = new ModeOrienteObjet();

                        int posX = 200;
                        int posY = 120;

                        //i.Pause();

                        Forme background = i.CreerRectangle(592, 330, 1184, 660);
                        background.Colorier(0, 255, 255);
                        Forme road = i.CreerRectangle(592, 25, 1184, 50);
                        road.Colorier(50, 50, 50);
                        Forme car = i.CreerRectangle(posX, posY, 200, 50);
                        car.Colorier(255, 0, 0);
                        Forme wheel1 = i.CreerCercle(posX - 85, posY - 50, 50);
                        wheel1.Colorier(0, 0, 0);
                        Forme wheel2 = wheel1.Dupliquer(posX + 85, posY - 50);
                        wheel2.Colorier(0, 0, 0);

                        // Toit de la voiture
                        i.Stylo.Deplacer(posX - 200, posY - 120);
                        i.Stylo.DescendrePointeur();
                        i.Stylo.Tourner(45);
                        i.Stylo.Avancer(50);
                        i.Stylo.Tourner(-45);
                        i.Stylo.Avancer(50);
                        i.Stylo.Tourner(-45);
                        i.Stylo.Avancer(50);
                        i.Stylo.LeverPointeur();
                        Forme toit = i.Stylo.Dessiner();

                        for (int j = 0; j < 50; j++)
                        {
                            i.Afficher();
                            i.Attendre(0.1f);
                            posX += 10;
                            car.Deplacer(posX, posY);
                            wheel1.Deplacer(posX - 85, posY - 50);
                            wheel2.Deplacer(posX + 85, posY - 50);
                            toit.Deplacer(posX - 50, posY + 20);
                            i.NettoyerEcran();
                        }

                        i.Afficher();
                        i.Pause();
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("------ ID Form Test -------");
                        ModeSequentiel i = new ModeSequentiel();

                        int posX = 0;
                        int posY = 0;


                        int cercle = i.CreerCercle(posX + 100, posY + 100, 50);
                        int cercle2 = i.CreerCercle(posX + 100, posY + 100, 50);
                        int cercle3 = i.Dupliquer(cercle2, posX + 100, posY + 100);
                        int rectangle = i.CreerCarre(50 + posX, 50 + posY, 100);


                        int r2 = i.Dupliquer(rectangle, 125, 125);
                        i.Colorier(-1, 255, 0, 0);
                        i.Afficher();

                        i.Pause();
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("------ OOP -------");
                        ModeOrienteObjet i = new ModeOrienteObjet();

                        Forme p = i.CreerRectangle(450, 500, 100, 200);
                        p.Colorier(50, 50, 50);
                        Forme e = i.CreerEllipse(450, 300, 500, 400);
                        e.Colorier(0, 150, 0);
                        Forme e1 = i.CreerEllipse(600, 300, 100, 200);
                        Forme e2 = e1.Dupliquer(300, 300);

                        for (int x = 0; x < 50; x++)
                        {
                            e1.Tourner(5);
                            e2.Tourner(-5);
                            i.Afficher();
                            i.Attendre(.1f);
                            i.NettoyerEcran();
                        }

                        i.Afficher();
                        i.Pause();

                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("------ OOP -------");
                        ModeOrienteObjet i = new ModeOrienteObjet();

                        Forme title = i.CreerTexte(400, 300, 80, "ACMP");

                        for (int x = 0; x < 50; x++)
                        {
                            title.Tourner(5);
                            i.Afficher();
                            i.Attendre(.1f);
                            i.NettoyerEcran();
                        }

                        i.Afficher();
                        i.Pause();

                        break;
                    }
                case 8:
                    {
                        Console.WriteLine("------ OOP -------");
                        ModeOrienteObjet i = new ModeOrienteObjet();

                        
                        Forme img = i.CreerImage(400, 300, "C:/dotnetlogo.png");
                        img.Dimensionner(.5f);

                        i.Pause();

                        for (int x = 0; x < 50; x++)
                        {
                            img.Tourner(5);
                            img.Deplacer(img.Position.X + 20, img.Position.Y);
                            i.Afficher();
                            i.Attendre(.1f);
                            i.NettoyerEcran();
                        }

                        i.Afficher();
                        i.Pause();

                        break;
                    }
                default:
                    Console.WriteLine("Select a correct test");
                    break;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("************ DEMO ***********");
            Console.WriteLine("0 -> Lister contributeurs");
            Console.WriteLine("1 -> sequenciel rotation");
            Console.WriteLine("2 -> opp rotation");
            Console.WriteLine("3 -> reverse Y axis test");
            Console.WriteLine("4 -> car demo");
            Console.WriteLine("5 -> test pour les id");
            Console.WriteLine("6 ->rotate ellipse");
            Console.WriteLine("7 -> text");
            Console.WriteLine("8 -> image");
            Console.WriteLine("*****************************\n");
            Console.Write("Votre choix : ");
            int testID = int.Parse(Console.ReadLine());
            PlayTest(testID);      
        }
     
    }
}









