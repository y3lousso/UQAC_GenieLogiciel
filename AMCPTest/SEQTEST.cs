﻿using System;
using System.IO;
using AMCP;
using AMCP.Formes;
using AMCP.InterfaceUtilisateur;
using AMCP.Noyau;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AMCPTest
{
    [TestClass]
    public class SEQTEST
    {
        ModeSequentiel i;
        Int32 displayTime = 2;
        int posXMid = 1200 / 2;
        int posYMid = 700 / 2;

        [TestInitialize()]
        public void Initialize()
        {
            new PrivateType(typeof(IMode)).SetStaticFieldOrProperty("instance", null);
            new PrivateType(typeof(Canvas)).SetStaticField("instance", null);
        }

        [TestMethod]
        public void SEQListerFonctions()
        {
            i = new ModeSequentiel();
            i.ListerFonctions();
        }

        [TestMethod]
        public void SEQLogON()
        {
            i = new ModeSequentiel();
            //i.AfficherHistoriqueActions(true);
            int testEllipse = -1;
            testEllipse = i.CreerRectangle(posXMid, posYMid, 100, 100);
            i.Afficher();
            i.TournerForme(testEllipse, 50);
            i.Afficher();
        }

        [TestMethod]
        public void SEQLogOFF()
        {
            i = new ModeSequentiel();
            i.AfficherHistoriqueActions(false);
            int testEllipse = -1;
            testEllipse = i.CreerRectangle(posXMid, posYMid, 100, 100);
            i.Afficher();
            i.TournerForme(testEllipse,50);
            i.Afficher();
        }

        /************************************************************************************************************
         * ********************************************* Stylo ***************************************************
         * *********************************************************************************************************/
        #region Stylo
        [TestMethod]
        public void SEQBaisserLeverStylo()
        {
            i = new ModeSequentiel();
            int testFormeLibre = -1;
            i.DescendreStylo();
            testFormeLibre = i.LeverStylo();
            Assert.AreNotEqual(-1, testFormeLibre);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQLeverStyloSansBaisser()
        {
            i = new ModeSequentiel();
            i.LeverStylo();
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQAvancerStyloDe50()
        {
            i = new ModeSequentiel();
            int testFormeLibre = -1;
            i.DescendreStylo();
            i.AvancerStylo(50);
            testFormeLibre = i.LeverStylo();
            Assert.AreNotEqual(-1, testFormeLibre);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQAvancerStyloDe50SansBaisser()
        {
            i = new ModeSequentiel();
            i.AvancerStylo(50);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQTournerStyloDe90()
        {
            i = new ModeSequentiel();
            int testFormeLibre = -1;
            i.DescendreStylo();
            i.AvancerStylo(50);
            i.TournerStylo(90);
            i.AvancerStylo(50);
            testFormeLibre = i.LeverStylo();
            Assert.AreNotEqual(-1, testFormeLibre);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQTournerStyloDe450()
        {
            i = new ModeSequentiel();
            int testFormeLibre = -1;
            i.DescendreStylo();
            i.AvancerStylo(50);
            i.TournerStylo(450);
            i.AvancerStylo(50);
            testFormeLibre = i.LeverStylo();
            Assert.AreNotEqual(-1, testFormeLibre);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQChangerCouleurStylo()
        {
            i = new ModeSequentiel();
            int testFormeLibre = -1;
            i.ColorierStylo(255, 0, 0);
            i.DescendreStylo();
            i.AvancerStylo(50);
            testFormeLibre = i.LeverStylo();
            Assert.AreNotEqual(-1, testFormeLibre);
            i.Afficher(displayTime);
        }
        #endregion

        /************************************************************************************************************
         * ************************************** Dessiner Formes ***************************************************
         * *********************************************************************************************************/
        #region Dessiner Formes
        [TestMethod]
        public void SEQDessinerCarree100x100()
        {
            i = new ModeSequentiel();
            int testEllipse = -1;
            testEllipse = i.CreerRectangle(posXMid, posYMid, 100, 100);
            Assert.AreNotEqual(-1, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQDessinerCercleR20()
        {
            i = new ModeSequentiel();
            int testEllipse = -1;
            testEllipse = i.CreerCercle(posXMid, posYMid, 20);
            Assert.AreNotEqual(-1, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQDessinerRectangle50x100()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerRectangle(posXMid, posYMid, 50, 100);
            i.Afficher(displayTime);
            Assert.AreNotEqual(-1, testPolygone);
            i.Afficher(displayTime); // Pourquoi l'afficher deux fois ?
        }

        [TestMethod]
        public void SEQDessinerEtoileR5()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerEtoile(posXMid, posYMid, 40, 80, 5);
            i.Afficher(displayTime);
            Assert.AreNotEqual(-1, testPolygone);
            i.Afficher(displayTime); // Pourquoi l'afficher deux fois ?
        }

        [TestMethod]
        public void SEQDessinerEllipseR50x80()
        {
            i = new ModeSequentiel();
            int testEllipse = -1;
            testEllipse = i.CreerEllipse(posXMid, posYMid, 50, 80);
            Assert.AreNotEqual(-1, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQDessinerTriangle20()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerTriangle(posXMid, posYMid, 20);
            Assert.AreNotEqual(-1, testPolygone);
            i.Afficher(displayTime);

        }

        [TestMethod]
        public void SEQDessinerTriangleLibre()
        {
            i = new ModeSequentiel();
            int testTriangleLibre = -1;
            i.DescendreStylo();
            i.AvancerStylo(50);
            i.TournerStylo(120);
            i.AvancerStylo(50);
            i.TournerStylo(120);
            i.AvancerStylo(50);
            testTriangleLibre = i.LeverStylo();
            Assert.AreNotEqual(-1, testTriangleLibre);
            i.Afficher(displayTime);
        }
        #endregion

        /************************************************************************************************************
         * ************************************** Hors Canvas *******************************************************
         * *********************************************************************************************************/
        #region Dessiner Hors Canvas
        [TestMethod]
        public void SEQDessinerCarreeHorsCanvas()
        {
            i = new ModeSequentiel();
            int testEllipse = -1;
            testEllipse = i.CreerRectangle(posXMid + 1000, posYMid + 1000, 10000, 10000);
            i.Afficher(displayTime);// Ne doit rien afficher
        }

        [TestMethod]
        public void SEQDessinerCercleHorsCanvas()
        {
            i = new ModeSequentiel();
            int testEllipse = -1;
            testEllipse = i.CreerCercle(posXMid + 1000, posYMid + 1000, 200000);
            i.Afficher(displayTime);// Ne doit rien afficher
        }

        [TestMethod]
        public void SEQDessinerRectangleHorsCanvas()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerRectangle(posXMid + 1000, posYMid + 1000, 500000, 10000000);
            i.Afficher(displayTime);// Ne doit rien afficher
        }

        [TestMethod]
        public void SEQDessinerEtoileHorsCanvas()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerEtoile(posXMid + 1000, posYMid + 1000, 40000, 80000, 5);
            i.Afficher(displayTime);// Ne doit rien afficher
        }

        [TestMethod]
        public void SEQDessinerEllipseHorsCanvas()
        {
            i = new ModeSequentiel();
            int testEllipse = -1;
            testEllipse = i.CreerEllipse(posXMid + 1000, posYMid + 1000, 50000, 80000);
            i.Afficher(displayTime);// Ne doit rien afficher
        }

        // Pas développée
        [TestMethod]
        public void SEQDessinerTriangleHorsCanvas()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerTriangle(posXMid + 1000, posYMid + 1000, 200000);
            i.Afficher(displayTime);// Ne doit rien afficher

        }

        [TestMethod]
        public void SEQDessinerFormeLibreHorsCanvas()
        {
            i = new ModeSequentiel();
            int testFormeLibre = -1;
            i.DeplacerStylo(-2000, 300);
            i.DescendreStylo();
            i.AvancerStylo(2000);
            testFormeLibre = i.LeverStylo(); // Ne doit rien afficher
            Assert.AreNotEqual(-1, testFormeLibre);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQDessinerFormeLibreDepasseHorsCanvas()
        {
            i = new ModeSequentiel();
            int testFormeLibre = -1;
            i.DescendreStylo();
            i.AvancerStylo(2000);
            testFormeLibre = i.LeverStylo(); // Doit afficher
            Assert.AreNotEqual(-1, testFormeLibre);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQEcrireTexteHorsCanvas()
        {
            i = new ModeSequentiel();
            int texte = i.CreerTexte(posXMid+2000, posYMid-2000, 60, "THIS IS A TEST");
            Assert.IsTrue(texte > 0);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQImporterImageHorsCanvas()
        {
            i = new ModeSequentiel();
            string fileName = "pikachu.png";
            string rootPath = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
            string path = Path.Combine(rootPath, @"assets\", fileName);
            int img = i.CreerImage(2000, 6000, path);
            i.DimensionnerForme(img, .5f);
            Assert.IsTrue(img > 0);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQDupliquerPolygoneHorsCanvas()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerTriangle(posXMid, posYMid, 20);
            Assert.IsTrue(testPolygone > 0);
            int polygoneDuplique = i.DupliquerForme(testPolygone, posXMid + 3000, posYMid - 17000);
            Assert.AreNotEqual(testPolygone, polygoneDuplique);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQDupliquerEllipseHorsCanvas()
        {
            i = new ModeSequentiel();
            int testCercle = -1;
            testCercle = i.CreerCercle(posXMid, posYMid, 20);
            Assert.IsTrue(testCercle > 0);
            int cercleDuplique = i.DupliquerForme(testCercle, posXMid + 3000, posYMid + 3000);
            Assert.AreNotEqual(testCercle, cercleDuplique);
            i.Afficher(displayTime);
        }

        #endregion

        /************************************************************************************************************
         * ************************************** Dupliquer ***********************************************************
         * *********************************************************************************************************/

        #region Dupliquer
        [TestMethod]
        public void SEQDupliquerPolygone()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerTriangle(posXMid, posYMid, 20);
            Assert.IsTrue(testPolygone > 0);
            int polygoneDuplique = i.DupliquerForme(testPolygone, posXMid + 30, posYMid + 30);
            Assert.AreNotEqual(testPolygone, polygoneDuplique);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQDupliquerEllipse()
        {
            i = new ModeSequentiel();
            int testCercle = -1;
            testCercle = i.CreerCercle(posXMid, posYMid, 20);
            Assert.IsTrue(testCercle > 0);
            int cercleDuplique = i.DupliquerForme(testCercle, posXMid + 30, posYMid + 30);
            Assert.AreNotEqual(testCercle, cercleDuplique);
            i.Afficher(displayTime);
        }
        #endregion

        /************************************************************************************************************
        * ************************************** Récupérer forme ***********************************************************
        * *********************************************************************************************************/
        #region Recuperer forme
        public class TestRecupererForme : ModeSequentiel
        {
            public Forme IdentifierFormeTest(int id)
            {
                return this.IdentifierForme(id);
            }
        }

        [TestMethod]
        public void SEQRecupererFormeAvecId()
        {
            TestRecupererForme j = new TestRecupererForme();
            int testPolygone = -1;
            testPolygone = j.CreerRectangle(posXMid, posYMid, 100, 100);

            Forme testIdReturn = j.IdentifierFormeTest(testPolygone);

            Assert.AreNotEqual(null, testIdReturn);
            j.Afficher(displayTime);
        }
        #endregion

        /************************************************************************************************************
         * ************************************** Ecrire Texte/Importer Image ***********************************************************
         * *********************************************************************************************************/
        #region Ecrire Texte/Importer Image
        [TestMethod]
        public void SEQEcrireTexte()
        {
            i = new ModeSequentiel();
            int texte = i.CreerTexte(posXMid, posYMid, 60, "THIS IS A TEST");
            Assert.IsTrue(texte > 0);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQImporterImage()
        {
            i = new ModeSequentiel();
            string fileName = "pikachu.png";
            string rootPath = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
            string path = Path.Combine(rootPath, @"assets\", fileName);
            int img = i.CreerImage(100, 100, path);
            i.DimensionnerForme(img, .5f);
            Assert.IsTrue(img > 0);
            i.Afficher(displayTime);
        }
        #endregion

        /************************************************************************************************************
        * ************************************** Rotation/translation/homothétie d'une forme *******************************************************
        * *********************************************************************************************************/

        #region Rotation/translation/homothétie d'une forme
        [TestMethod]
        public void SEQRotationPolygoneRectangle()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerRectangle(posXMid, posYMid, 100, 100);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            i.TournerForme(testPolygone, -300000);
            i.Afficher(displayTime);

        }

        [TestMethod]
        public void SEQRotationPolygoneTriangle()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerTriangle(posXMid, posYMid, 20);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            i.TournerForme(testPolygone, 30);
            i.Afficher(displayTime);

        }

        [TestMethod]
        public void SEQRotationPolygoneEtoile()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerEtoile(posXMid, posYMid, 30, 50, 5);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            i.TournerForme(testPolygone, -300000);
            i.Afficher(displayTime);

        }

        [TestMethod]
        public void SEQRotationPolygoneLosange()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerLosange(posXMid, posYMid, 30, 50);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            i.TournerForme(testPolygone, -300000);
            i.Afficher(displayTime);

        }

        [TestMethod]
        public void SEQRotationEllipse()
        {
            i = new ModeSequentiel();
            int testEllipse = -1;
            testEllipse = i.CreerEllipse(posXMid, posYMid, 50, 80);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            i.TournerForme(testEllipse, -30);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQRotationFormeLibre()
        {
            i = new ModeSequentiel();
            int testFormeLibre = -1;
            i.DescendreStylo();
            i.AvancerStylo(50);
            testFormeLibre = i.LeverStylo();
            i.Afficher(displayTime);
            i.NettoyerEcran();
            i.TournerForme(testFormeLibre, -30);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQTranslationPolygoneRectangle()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerRectangle(posXMid, posYMid, 100, 100);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            i.DeplacerForme(testPolygone, 200, 200);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQTranslationPolygoneTriangle()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerTriangle(posXMid, posYMid, 20);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            i.DeplacerForme(testPolygone, 200, 200);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQTranslationPolygoneEtoile()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerEtoile(posXMid, posYMid, 30, 50, 5);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            i.DeplacerForme(testPolygone, 200, 200);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQTranslationPolygoneLosange()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerLosange(posXMid, posYMid, 30, 50);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            i.DeplacerForme(testPolygone, 200, 200);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQTranslationEllipse()
        {
            i = new ModeSequentiel();
            int testEllipse = -1;
            testEllipse = i.CreerEllipse(posXMid, posYMid, 50, 80);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            i.DeplacerForme(testEllipse, 200, 200);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQTranslationFormeLibre()
        {
            i = new ModeSequentiel();
            int testFormeLibre = -1;
            i.DescendreStylo();
            i.AvancerStylo(50);
            testFormeLibre = i.LeverStylo();
            i.Afficher(displayTime);
            i.NettoyerEcran();
            i.DeplacerForme(testFormeLibre, 200, 200);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQHomothetiePolygoneRectangle()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerRectangle(posXMid, posYMid, 100, 100);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            i.DimensionnerForme(testPolygone, 2);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQHomothetiePolygoneTriangle()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerTriangle(posXMid, posYMid, 90);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            i.DimensionnerForme(testPolygone, 2);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQHomothetiePolygoneEtoile()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerEtoile(posXMid, posYMid, 30, 50, 5);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            i.DimensionnerForme(testPolygone, 2);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQHomothetiePolygoneLosange()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerLosange(posXMid, posYMid, 30, 50);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            i.DimensionnerForme(testPolygone, 2);
            i.Afficher(displayTime);
        }


        [TestMethod]
        public void SEQHomothetieEllipse()
        {
            i = new ModeSequentiel();
            int testEllipse = -1;
            testEllipse = i.CreerEllipse(posXMid, posYMid, 50, 80);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            i.DimensionnerForme(testEllipse, 2);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQHomothétieFormeLibre()
        {
            i = new ModeSequentiel();
            int testFormeLibre = -1;
            i.DescendreStylo();
            i.AvancerStylo(50);
            testFormeLibre = i.LeverStylo();
            i.Afficher(displayTime);
            i.NettoyerEcran();
            i.DimensionnerForme(testFormeLibre, 2);
            i.Afficher(displayTime);
        }
        #endregion
    }
}
 