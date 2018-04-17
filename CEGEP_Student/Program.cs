using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AMCP.Noyau; 
using AMCP_ExtraModule.Formes;
using AMCP_ExtraModule.NoyauOverlay;
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
                        i.ListerContributeurs();
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
                            i.TournerForme(etoileId, 20);
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
                        i.Stylo.DescendreStylo();
                        i.Stylo.Tourner(45);
                        i.Stylo.Avancer(100);
                        i.Stylo.Tourner(-45);
                        i.Stylo.Avancer(100);
                        i.Stylo.Tourner(-45);
                        i.Stylo.Avancer(100);
                        Forme toit = i.Stylo.LeverStylo();

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
                        ModeSequentiel i = new ModeSequentiel();

                        i.DeplacerStylo(50, 50);
                        i.DescendreStylo();
                        i.AvancerStylo(50);
                        i.TournerStylo(20);
                        i.AvancerStylo(50);
                        i.LeverStylo();

                        i.Afficher();
                        i.Pause();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("------ Car demo -------");
                        ModeOrienteObjet i = new ModeOrienteObjet();
                        
                        i.ChangerDimension(1000, 500);

                        int posX = 100;
                        int posY = 350;
                        
                        Forme background = i.CreerRectangle(500, 250, 1000, 500);
                        background.Colorier(0, 255, 255);
                        Forme road = i.CreerRectangle(500, 450, 1000, 100);
                        road.Colorier(50, 50, 50);

                        Forme car = i.CreerRectangle(posX, posY, 200, 50);
                        car.Colorier(255, 0, 0);
                        Forme wheel1 = i.CreerCercle(posX - 85, posY + 50, 50);
                        wheel1.Colorier(0, 0, 0);
                        Forme wheel2 = wheel1.Dupliquer(posX + 85, posY + 50);
                        wheel2.Colorier(0, 0, 0);

                        Forme p = i.CreerCarre(1, 1, 5);
                        p.Colorier(255, 0, 0);

                        // Toit de la voiture
                        i.Stylo.Deplacer(posX - 200, posY - 200);
                        i.Stylo.DescendreStylo();
                        i.Stylo.Tourner(-45);
                        i.Stylo.Avancer(50);
                        i.Stylo.Tourner(45);
                        i.Stylo.Avancer(50);
                        i.Stylo.Tourner(45);
                        i.Stylo.Avancer(50);
                        Forme toit = i.Stylo.LeverStylo();

                        for (int j = 0; j < 50; j++)
                        {
                            i.Afficher();
                            i.Attendre(0.1f);
                            posX += 10;
                            car.Deplacer(posX, posY);
                            p.Deplacer(posX - 85, posY + 50);
                            wheel1.Deplacer(posX - 85, posY + 50);
                            wheel2.Deplacer(posX + 85, posY + 50);
                            toit.Deplacer(posX - 50, posY - 20);
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
                        int cercle3 = i.DupliquerForme(cercle2, posX + 100, posY + 100);
                        int rectangle = i.CreerCarre(50 + posX, 50 + posY, 100);


                        int r2 = i.DupliquerForme(rectangle, 125, 125);
                        i.ColorierForme(-1, 255, 0, 0);
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

                        Forme c = i.CreerCarre(450, 500, 5);
                        c.Colorier(255, 0, 0);

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
                            title.Dimensionner(0.9f);
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
                case 9:
                    {
                        Console.WriteLine("------ OOP -------");
                        ModeOrienteObjetBoosted i = new ModeOrienteObjetBoosted();

                        Forme voiture = i.CreerVoiture(200, 200);

                        for (int x = 0; x < 100; x++)
                        {
                            voiture.Tourner(5);
                            voiture.Deplacer(voiture.Position.X + 5, voiture.Position.Y);
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
            Console.WriteLine("3 -> stylo seq");
            Console.WriteLine("4 -> car demo poo");
            Console.WriteLine("5 -> test pour les id");
            Console.WriteLine("6 ->rotate ellipse");
            Console.WriteLine("7 -> text");
            Console.WriteLine("8 -> image");
            Console.WriteLine("9 -> Extra DLL : voiture");
            Console.WriteLine("*****************************\n");
            Console.Write("Votre choix : ");
            int testID = int.Parse(Console.ReadLine());
            PlayTest(testID);      
        }
     
    }
}









