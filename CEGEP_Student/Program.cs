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

                        i.Stylo.Deplacer(100, 100);
                        i.Stylo.DescendreStylo();
                        i.Stylo.Tourner(45);
                        i.Stylo.Avancer(100);
                        i.Stylo.Tourner(-45);
                        i.Stylo.Avancer(100);
                        i.Stylo.Tourner(-45);
                        i.Stylo.Avancer(100);
                        Forme forme = i.Stylo.LeverStylo();

                        for (int j = 0; j < 100; j++)
                        {
                            p1.Tourner(5);
                            forme.Tourner(5);
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
                        int cercle2 = i.CreerCercle(posX + 200, posY + 200, 50);
                        int cercle3 = i.DupliquerForme(cercle2, posX + 300, posY + 300);
                        int rectangle = i.CreerCarre(50 + posX, 50 + posY, 100);

                        int r2 = i.DupliquerForme(rectangle, 125, 125);

                        i.ColorierForme(cercle2, 255, 0, 0);

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
                        
                        Forme img = i.CreerImage(400, 300, "C:/Users/nicolas/Desktop/ciel.jpg");
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
                case 10:
                    {
                        ModeSequentiel i = new ModeSequentiel();

                        //ciel
                        int idimg = i.CreerImage(0, 0, "C:/Users/nicolas/Documents/Uqac/Génie_logiciel/UQAC_GenieLogiciel-master/ciel.jpg");
                        i.DimensionnerForme(idimg, 2.5f);

                        // herbe
                        int idHerbe = i.CreerRectangle(0, 400, 1860, 300);
                        i.ColorierForme(idHerbe, 5, 108, 5);

                        //route
                        int posYRoute = 550;
                        int idRoute = i.CreerRectangle(0, posYRoute, 1860, 100);
                        i.ColorierForme(idRoute, 115, 115, 115);

                        for (int iTrait = 0; iTrait < 12; iTrait++)
                        {
                            int idTraitCourant = i.CreerRectangle(iTrait * (50 + 30), posYRoute, 50, 10);
                            i.ColorierForme(idTraitCourant, 255, 255, 255);
                        }

                        //maison
                        int posXMaison = 500;
                        int posYMaison = 300;
                        int idMurs = i.CreerRectangle(posXMaison, posYMaison, 200, 150);
                        i.ColorierForme(idMurs, 242, 242, 242);

                        int idToit = i.CreerTriangle(posXMaison, posYMaison + 20, 100);
                        i.TournerForme(idToit, 180);
                        i.DeplacerForme(idToit, posXMaison, posYMaison / 3 + 25);
                        i.ColorierForme(idToit, 179, 95, 53);

                        int idPorte = i.CreerRectangle(posXMaison, posYMaison + 50, 25, 50);
                        i.ColorierForme(idPorte, 179, 11, 11);

                        int idFenetreUn = i.CreerCercle(posXMaison - 60, posYMaison - 40, 35);
                        i.ColorierForme(idFenetreUn, 175, 206, 247);

                        int idFenetreDeux = i.DupliquerForme(idFenetreUn, posXMaison + 60, posYMaison - 40);

                        int idFenetreTrois = i.CreerRectangle(posXMaison - 60, posYMaison + 30, 30, 30);
                        i.ColorierForme(idFenetreTrois, 175, 206, 247);

                        //voiture 
                        int posX = 100;
                        int posY = 530;

                        int idVoiture = i.CreerRectangle(posX, posY, 200, 50);
                        int idToitVoiture = i.CreerRectangle(posX, posY - 40, 120, 30);
                        i.ColorierForme(idVoiture, 255, 0, 0);
                        i.ColorierForme(idToitVoiture, 255, 0, 0);

                        int idRoueUn = i.CreerCercle(posX - 70, posY + 40, 40);
                        int idRoueDeux = i.DupliquerForme(idRoueUn, posX + 70, posY + 40);

                        for (int iDeplacement = 0; iDeplacement < 14; iDeplacement++)
                        {
                            i.Afficher();
                            i.Attendre(0.2f);
                            posX += 50;
                            i.DeplacerForme(idVoiture, posX, posY);
                            i.DeplacerForme(idRoueUn, posX - 70, posY + 40);
                            i.DeplacerForme(idRoueDeux, posX + 70, posY + 40);
                            i.DeplacerForme(idToitVoiture, posX, posY - 38);

                            i.NettoyerEcran();
                        }

                        i.Afficher();
                        i.Pause();

                        break;
                    }
                case 11:
                    {
                        ModeOrienteObjet i = new ModeOrienteObjet();

                        //ciel
                        Forme ciel = i.CreerImage(0, 0, "C:/Users/nicolas/Documents/Uqac/Génie_logiciel/UQAC_GenieLogiciel-master/ciel.jpg");
                        ciel.Dimensionner(2.5f);

                        // herbe
                        Forme idHerbe = i.CreerRectangle(0, 400, 1860, 300);
                        idHerbe.Colorier(5, 108, 5);

                        //route
                        int posYRoute = 550;
                        Forme route= i.CreerRectangle(0, posYRoute, 1860, 100);
                        route.Colorier(115, 115, 115);

                        for (int iTrait = 0; iTrait < 12; iTrait++)
                        {
                            Forme traitSecurite = i.CreerRectangle(iTrait * (50 + 30), posYRoute, 50, 10);
                            traitSecurite.Colorier(255, 255, 255);
                        }

                        //maison
                        int posXMaison = 500;
                        int posYMaison = 300;
                        Forme murs = i.CreerRectangle(posXMaison, posYMaison, 200, 150);
                        murs.Colorier(242, 242, 242);

                        Forme toit = i.CreerTriangle(posXMaison, posYMaison + 20, 100);
                        toit.Tourner(180);
                        toit.Deplacer(posXMaison, posYMaison / 3 + 25);
                        toit.Colorier(179, 95, 53);

                        Forme porte = i.CreerRectangle(posXMaison, posYMaison + 50, 25, 50);
                        porte.Colorier(179, 11, 11);

                        Forme fenetreUn = i.CreerCercle(posXMaison - 60, posYMaison - 40, 35);
                        fenetreUn.Colorier(175, 206, 247);

                        Forme fenetreDeux = fenetreUn.Dupliquer(posXMaison + 60, posYMaison - 40);

                        Forme idFenetreTrois = i.CreerRectangle(posXMaison - 60, posYMaison + 30, 30, 30);
                        idFenetreTrois.Colorier(175, 206, 247);

                        //voiture 
                        int posX = 100;
                        int posY = 530;

                        Forme voiture = i.CreerRectangle(posX, posY, 200, 50);
                        Forme toitVoiture = i.CreerRectangle(posX, posY - 40, 120, 30);
                        voiture.Colorier(255, 0, 0);
                        toitVoiture.Colorier(255, 0, 0);

                        Forme idRoueUn = i.CreerCercle(posX - 70, posY + 40, 40);
                        Forme idRoueDeux = idRoueUn.Dupliquer(posX + 70, posY + 40);

                        for (int iDeplacement = 0; iDeplacement < 14; iDeplacement++)
                        {
                            i.Afficher();
                            i.Attendre(0.2f);
                            posX += 50;
                            voiture.Deplacer(posX, posY);
                            toitVoiture.Deplacer(posX, posY - 38);
                            idRoueUn.Deplacer(posX - 70, posY + 40);
                            idRoueDeux.Deplacer(posX + 70, posY + 40);

                            i.NettoyerEcran();
                        }

                        i.Afficher();
                        i.Pause();

                        break;
                    }
                case 12:
                    {
                        ModeOrienteObjetBoosted i = new ModeOrienteObjetBoosted();

                        //ciel
                        Forme ciel = i.CreerImage(0, 0, "C:/Users/nicolas/Documents/Uqac/Génie_logiciel/UQAC_GenieLogiciel-master/ciel.jpg");
                        ciel.Dimensionner(2.5f);

                        // herbe
                        Forme idHerbe = i.CreerRectangle(0, 400, 1860, 300);
                        idHerbe.Colorier(5, 108, 5);

                        //route
                        int posYRoute = 550;
                        Forme route = i.CreerRectangle(0, posYRoute, 1860, 100);
                        route.Colorier(115, 115, 115);

                        for (int iTrait = 0; iTrait < 12; iTrait++)
                        {
                            Forme traitSecurite = i.CreerRectangle(iTrait * (50 + 30), posYRoute, 50, 10);
                            traitSecurite.Colorier(255, 255, 255);
                        }

                        //maison
                        int posXMaison = 500;
                        int posYMaison = 300;
                        Forme murs = i.CreerRectangle(posXMaison, posYMaison, 200, 150);
                        murs.Colorier(242, 242, 242);

                        Forme toit = i.CreerTriangle(posXMaison, posYMaison + 20, 100);
                        toit.Tourner(180);
                        toit.Deplacer(posXMaison, posYMaison / 3 + 25);
                        toit.Colorier(179, 95, 53);

                        Forme porte = i.CreerRectangle(posXMaison, posYMaison + 50, 25, 50);
                        porte.Colorier(179, 11, 11);

                        Forme fenetreUn = i.CreerCercle(posXMaison - 60, posYMaison - 40, 35);
                        fenetreUn.Colorier(175, 206, 247);

                        Forme fenetreDeux = fenetreUn.Dupliquer(posXMaison + 60, posYMaison - 40);

                        Forme idFenetreTrois = i.CreerRectangle(posXMaison - 60, posYMaison + 30, 30, 30);
                        idFenetreTrois.Colorier(175, 206, 247);

                        //voiture
                        Forme voiture = i.CreerVoiture(80, 510);

                        for (int x = 0; x < 12; x++)
                        {
                            voiture.Deplacer(voiture.Position.X + 50, voiture.Position.Y);
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
            Console.WriteLine("9 -> Extra DLL : voiture");
            Console.WriteLine("10 -> sequenciel : voiture + déplacement");
            Console.WriteLine("11 -> objet :  voiture + déplacement");
            Console.WriteLine("12 -> Extra DLL :  voiture + déplacement");
            Console.WriteLine("*****************************\n");
            Console.Write("Votre choix : ");
            int testID = int.Parse(Console.ReadLine());
            PlayTest(testID);      
        }
     
    }
}









