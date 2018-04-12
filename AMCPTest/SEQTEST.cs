﻿using System;
using AMCP;
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
            new PrivateType(typeof(IMode)).SetStaticField("instance", null);
            new PrivateType(typeof(Canvas)).SetStaticField("instance", null);
        }

        /************************************************************************************************************
         * ********************************************* Stylo ***************************************************
         * *********************************************************************************************************/

        [TestMethod]
        public void SEQBaisserLeverStylo()
        {
            i = new ModeSequentiel();
            int testFormeLibre = -1;
            i.Stylo.DescendreStylo();
            i.Stylo.LeverStylo();

            throw new Exception("Dessin libre pas encore implémenté");
        }

        [TestMethod]
        public void SEQAvancerStyloDe50()
        {
            i = new ModeSequentiel();
            int testFormeLibre = -1;
            i.Stylo.DescendreStylo();
            i.Stylo.Avancer(50);
            i.Stylo.LeverStylo();

            throw new Exception("Dessin libre pas encore implémenté");
        }

        [TestMethod]
        public void SEQAvancerStyloDe50SansBaisser()
        {
            i = new ModeSequentiel();
            i.Stylo.Avancer(50);
        }

        [TestMethod]
        public void SEQTournerStyloDe90()
        {
            i = new ModeSequentiel();
            int testFormeLibre = -1;
            i.Stylo.DescendreStylo();
            i.Stylo.Avancer(50);
            i.Stylo.Tourner(90);
            i.Stylo.Avancer(50);
            i.Stylo.LeverStylo();

            throw new Exception("Dessin libre pas encore implémenté");
        }

        [TestMethod]
        public void SEQTournerStyloDe450()
        {
            i = new ModeSequentiel();
            int testFormeLibre = -1;
            i.Stylo.DescendreStylo();
            i.Stylo.Avancer(50);
            i.Stylo.Tourner(450);
            i.Stylo.Avancer(50);
            i.Stylo.LeverStylo();

            throw new Exception("Dessin libre pas encore implémenté");
        }

        [TestMethod]
        public void SEQChangerCouleurStylo()
        {
            throw new Exception("Pas encore implémenté");
        }

        /************************************************************************************************************
         * ************************************** Dessiner Formes ***************************************************
         * *********************************************************************************************************/

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
            i.Stylo.DescendreStylo();
            i.Stylo.Avancer(50);
            i.Stylo.Tourner(30);
            i.Stylo.Avancer(50);
            i.Stylo.Tourner(30);
            i.Stylo.Avancer(50);
            i.Stylo.LeverStylo();

            throw new Exception("Dessin libre pas encore implémenté");
        }

        /************************************************************************************************************
         * ************************************** Hors Canvas *******************************************************
         * *********************************************************************************************************/

        [TestMethod]
        public void SEQDessinerCarreeHorsCanvas()
        {
            i = new ModeSequentiel();
            int testEllipse = -1;
            testEllipse = i.CreerRectangle(posXMid + 1000, posYMid + 1000, 10000, 10000);
            i.Afficher(displayTime);
            Assert.AreEqual(-1, testEllipse);
        }

        [TestMethod]
        public void SEQDessinerCercleHorsCanvas()
        {
            i = new ModeSequentiel();
            int testEllipse = -1;
            testEllipse = i.CreerCercle(posXMid + 1000, posYMid + 1000, 200000);
            i.Afficher(displayTime);
            Assert.AreEqual(-1, testEllipse);
        }

        [TestMethod]
        public void SEQDessinerRectangleHorsCanvas()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerRectangle(posXMid + 1000, posYMid + 1000, 500000, 10000000);
            i.Afficher(displayTime);
            Assert.AreEqual(-1, testPolygone);
        }

        [TestMethod]
        public void SEQDessinerEtoileHorsCanvas()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerEtoile(posXMid + 1000, posYMid + 1000, 40000, 80000, 5);
            i.Afficher(displayTime);
            Assert.AreEqual(-1, testPolygone);
        }

        [TestMethod]
        public void SEQDessinerEllipseHorsCanvas()
        {
            i = new ModeSequentiel();
            int testEllipse = -1;
            testEllipse = i.CreerEllipse(posXMid + 1000, posYMid + 1000, 50000, 80000);
            i.Afficher(displayTime);
            Assert.AreEqual(-1, testEllipse);
        }

        // Pas développée
        [TestMethod]
        public void SEQDessinerTriangleHorsCanvas()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerTriangle(posXMid + 1000, posYMid + 1000, 200000);
            i.Afficher(displayTime);
            Assert.AreEqual(-1, testPolygone);

        }

        [TestMethod]
        public void SEQDessinerFormeLibreHorsCanvas()
        {
            i = new ModeSequentiel();
            int testFormeLibre = -1;
            i.Stylo.DescendreStylo();
            i.Stylo.Avancer(20000);
            i.Stylo.LeverStylo();

            throw new Exception("Dessin libre pas encore implémenté");
        }

        /************************************************************************************************************
         * ************************************** Dupliquer ***********************************************************
         * *********************************************************************************************************/

        
        [TestMethod]
        public void SEQDupliquerPolygone()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerTriangle(posXMid, posYMid, 20);
            Assert.IsTrue(testPolygone > 0);
            int polygoneDuplique = i.Dupliquer(testPolygone, posXMid + 30, posYMid + 30);
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
            int cercleDuplique = i.Dupliquer(testCercle, posXMid + 30, posYMid + 30);
            Assert.AreNotEqual(testCercle, cercleDuplique);
            i.Afficher(displayTime);
        }

        /************************************************************************************************************
         * ************************************** Reinitialiser Canvas ***********************************************************
         * *********************************************************************************************************/

        [TestMethod]
        public void SEQReinitialiserCanvas()
        {
            throw new Exception("Pas encore développé");
        }


        /************************************************************************************************************
         * ************************************** Ecrire Texte/Importer Image ***********************************************************
         * *********************************************************************************************************/

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
            throw new Exception("Pas encore développé");
        }

        /************************************************************************************************************
* ************************************** Rotation/translation/homothétie d'une forme *******************************************************
* *********************************************************************************************************/

        [TestMethod]
        public void SEQRotationPolygoneRectangle()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerRectangle(posXMid, posYMid, 100, 100);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            i.Tourner(testPolygone, -300000);
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
            i.Tourner(testPolygone, 30);
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
            i.Tourner(testPolygone, -300000);
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
            i.Tourner(testPolygone, -300000);
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
            i.Tourner(testEllipse, -30);
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
            i.Deplacer(testPolygone, 200, 200);
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
            i.Deplacer(testPolygone, 200, 200);
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
            i.Deplacer(testPolygone, 200, 200);
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
            i.Deplacer(testPolygone, 200, 200);
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
            i.Deplacer(testEllipse, 200, 200);
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
            i.Dimensionner(testPolygone, 2);
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
            i.Dimensionner(testPolygone, 2);
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
            i.Dimensionner(testPolygone, 2);
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
            i.Dimensionner(testPolygone, 2);
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
            i.Dimensionner(testEllipse, 2);
            i.Afficher(displayTime);
        }
    }
}
 