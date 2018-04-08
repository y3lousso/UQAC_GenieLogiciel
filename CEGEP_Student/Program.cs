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
        static void Main(string[] args)
        {

            // 0 -> tests bords séquentiel
            // 1 -> démo OOP
            // 2 -> sequenciel rotation
            // 3 -> opp rotation
            // 4 -> reverse Y axis test
            // 5 -> car demo
            // 6 -> test pour les id
            // 7 -> rotate ellipse
            // 8 -> text

            int test = 8;

            switch (test)
            {
                case 0:
                    {
                        Console.WriteLine("------ Sequentiel -------");
                        ModeSequentiel i = new ModeSequentiel();

                        /*for (int x = 0; x < 5; x++)
                        {
                            int posX = 20 * x + 80;
                            int posY = (20 * x) + x + 80;
                            i.DessinerRectangle(posX, posY, 50, 70);
                            i.DessinerEtoile(posX, posY + 100, 40, 80, 5);
                            i.DessinerCercle(100 + posX, posY, 20);
                            i.DessinerEllipse(posX, posY + 250, 20, 50);
                        }*/

                        //IN
                        int form;
                        i.DessinerLosange(316, 170, 632, 340); //Bas-Gauche
                        //i.DessinerEtoile(316, 510, 170, 340, 8); //Haut-Gauche
                        form=i.DessinerEllipse(948, 170, 632, 340); //Bas-Droite       
                        i.DessinerTriangle(948, 510, 170); // Haut-Droite
                        i.Deplacer(form, 316, 510);
                        //OUT
                        //i.DessinerLosange(315, 170, 632, 340); //Bas-Gauche
                        //i.DessinerEtoile(316, 512, 170, 340, 8); //Bas-Gauche
                        //i.DessinerEllipse(949, 170, 632, 340); //Bas-Droite
                        //i.DessinerEtoile(948, 512, 170, 340, 8); //Haut-Droite
                        //i.DessinerTriangle(948, 510, 172); // Haut-Droite



                        i.Afficher();
                        i.Pause();
                        break;
                    }

                case 1:
                    {
                        Console.WriteLine("------ OOP -------");
                        ModeOrienteObjet i = new ModeOrienteObjet();

                        /*for (int x = 0; x < 5; x++)
                        {
                            int posX = 20 * x + 80;
                            int posY = (20 * x) + x + 80;
                            i.DessinerRectangle(posX, posY, 50, 70);
                            i.DessinerEtoile(posX, posY + 100, 40, 80, 5);
                            i.DessinerCercle(100 + posX, posY, 20);
                            i.DessinerEllipse(posX, posY + 250, 20, 50);
                        }*/

                        //IN
                        /* Forme losa = i.DessinerLosange(316, 170, 632, 340); //Bas-Gauche
                        losa.Deplacer(316, 510);
                        losa.Deplacer(948, 510);
                        losa.Deplacer(948, 170);
                        losa.Deplacer(950, 170);*/ //Deplacement en dehors

                        /*Forme elli = i.DessinerEllipse(948, 170, 632, 340);
                        elli.Deplacer(316, 170);
                        elli.Deplacer(316, 510);
                        elli.Deplacer(948, 510);
                        elli.Deplacer(949, 510);*/ //Deplacement en dehors

                        Forme cer = i.DessinerCercle(948, 170, 340);
                        cer.Deplacer(316, 170);
                        cer.Deplacer(316, 510);
                        cer.Deplacer(948, 510);
                        cer.Deplacer(948, 510); //Deplacement en dehors



                        //i.DessinerEtoile(316, 510, 170, 340); //Haut-Gauche
                        //i.DessinerEllipse(948, 170, 632, 340); //Bas-Droite       
                        //i.DessinerTriangle(948, 510, 170); // Haut-Droite
                        //OUT
                        //i.DessinerLosange(315, 170, 632, 340); //Bas-Gauche
                        //i.DessinerEtoile(316, 512, 170, 340, 8); //Bas-Gauche
                        //i.DessinerEllipse(949, 170, 632, 340); //Bas-Droite
                        //i.DessinerEtoile(948, 512, 170, 340, 8); //Haut-Droite
                        //i.DessinerTriangle(948, 510, 172); // Haut-Droite

                        i.Afficher();
                        i.Pause();

                        break;
                    }

                case 2:
                    {
                        Console.WriteLine("------ Sequentiel : rotation -------");
                        ModeSequentiel i = new ModeSequentiel();

                        i.Pause();

                        int posX = 250;
                        int posY = 250;

                        int etoileId = i.DessinerEtoile(posX, posY + 100, 40, 80, 5);

                        for (int j = 0; j < 100; j++)
                        {
                            i.Tourner(etoileId, 20);
                            i.Afficher();
                            i.Attendre(0.1f);
                            i.NettoyerEcran();
                        }

                        i.Pause();

                        break;
                    }

                case 3:
                    {
                        Console.WriteLine("------ OOP : rotation -------");
                        ModeOrienteObjet i = new ModeOrienteObjet();

                        i.Pause();

                        int posX = 250;
                        int posY = 250;
                        Forme p1 = i.DessinerEtoile(posX, posY + 100, 40, 80, 5);
                        for (int j = 0; j < 100; j++)
                        {                       
                            p1.Tourner(20);
                            i.Afficher();
                            i.Attendre(0.1f);
                            i.NettoyerEcran();
                        } 

                        i.Pause();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("------ Reverse Y Axis Test -------");
                        ModeOrienteObjet i = new ModeOrienteObjet();

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
                        ModeOrienteObjet i = new ModeOrienteObjet();

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
                        Forme wheel2 = wheel1.Dupliquer(posX + 85, posY - 50);
                        wheel2.Colorier(0, 0, 0);

                        // Toit de la voiture
                        i.Stylo.Deplacer(posX-50, posY+20);
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
                            toit.Deplacer(posX-50, posY + 20);
                            i.NettoyerEcran();
                        }

                        i.Afficher();
                        i.Pause();
                        break;
                    }

                case 6:
                    {
                        Console.WriteLine("------ ID Form Test -------");
                        ModeSequentiel i = new ModeSequentiel();

                        int posX = 0;
                        int posY = 0;

                      
                        int cercle = i.DessinerCercle(posX + 100, posY + 100, 50);
                        int cercle2 = i.DessinerCercle(posX + 100, posY + 100, 50);
                        int cercle3 = i.Dupliquer(cercle2, posX + 100, posY + 100);
                        int rectangle = i.DessinerCarre(50 + posX, 50 + posY, 100);
                        

                        int r2 = i.Dupliquer(rectangle, 125, 125);
                        i.Colorier(-1,255,0,0);
                        i.Afficher();

                        i.Pause();
                        break;
                    }

                case 7:
                    {
                        Console.WriteLine("------ OOP -------");
                        ModeOrienteObjet i = new ModeOrienteObjet();

                        Forme p = i.DessinerRectangle(450,500,100,200);
                        p.Colorier(50, 50, 50);
                        Forme e = i.DessinerEllipse(450, 300, 500, 400);
                        e.Colorier(0, 150, 0);
                        Forme e1 = i.DessinerEllipse(600, 300, 100, 200);
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

                case 8:
                    {
                        Console.WriteLine("------ OOP -------");
                        ModeOrienteObjet i = new ModeOrienteObjet();

                        Forme title = i.DessinerTexte(400, 300, 80, "ACMP");

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

                default:
                    Console.WriteLine("Select a correct test");
                    break;
            }
            
        }
    }
}









