﻿using System;
using AMCP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AMCPTest
{
    [TestClass]
    public class SEQTEST
    {
        ModeSequentiel i;
        Int32 displayTime = 2;
        int posXMid = 1280 / 2;
        int posYMid = 720 / 2;

        [TestInitialize()]
        public void Initialize()
        {
            new PrivateType(typeof(IMode)).SetStaticField("instance", null);
            new PrivateType(typeof(Canvas)).SetStaticField("instance", null);
        }

        /************************************************************************************************************
         * ********************************************* Pointeur ***************************************************
         * *********************************************************************************************************/

        [TestMethod]
        public void SEQBaisserLeverPointeur()
        {
            i = new ModeSequentiel();
            int testFormeLibre = -1;
            i.Stylo.DescendrePointeur();
            i.Stylo.LeverPointeur();

            throw new Exception("Dessin libre pas encore implémenté");
        }

        [TestMethod]
        public void SEQAvancerPointeurDe50()
        {
            i = new ModeSequentiel();
            int testFormeLibre = -1;
            i.Stylo.DescendrePointeur();
            i.Stylo.Avancer(50);
            i.Stylo.LeverPointeur();

            throw new Exception("Dessin libre pas encore implémenté");
        }

        [TestMethod]
        public void SEQAvancerPointeurDe50SansBaisser()
        {
            i = new ModeSequentiel();
            i.Stylo.Avancer(50);
        }

        [TestMethod]
        public void SEQTournerPointeurDe90()
        {
            i = new ModeSequentiel();
            int testFormeLibre = -1;
            i.Stylo.DescendrePointeur();
            i.Stylo.Avancer(50);
            i.Stylo.Tourner(90);
            i.Stylo.Avancer(50);
            i.Stylo.LeverPointeur();

            throw new Exception("Dessin libre pas encore implémenté");
        }

        [TestMethod]
        public void SEQTournerPointeurDe450()
        {
            i = new ModeSequentiel();
            int testFormeLibre = -1;
            i.Stylo.DescendrePointeur();
            i.Stylo.Avancer(50);
            i.Stylo.Tourner(450);
            i.Stylo.Avancer(50);
            i.Stylo.LeverPointeur();

            throw new Exception("Dessin libre pas encore implémenté");
        }

        [TestMethod]
        public void SEQChangerCouleurPointeur()
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
            testEllipse = i.DessinerRectangle(posXMid, posYMid, 100, 100);
            Assert.AreNotEqual(-1, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQDessinerCercleR20()
        {
            i = new ModeSequentiel();
            int testEllipse = -1;
            testEllipse = i.DessinerCercle(posXMid, posYMid, 20);
            Assert.AreNotEqual(-1, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQDessinerRectangle50x100()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.DessinerRectangle(posXMid, posYMid, 50, 100);
            i.Afficher(displayTime);
            Assert.AreNotEqual(-1, testPolygone);
            i.Afficher(displayTime); // Pourquoi l'afficher deux fois ?
        }

        [TestMethod]
        public void SEQDessinerEtoileR5()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.DessinerEtoile(posXMid, posYMid, 40, 80, 5);
            i.Afficher(displayTime);
            Assert.AreNotEqual(-1, testPolygone);
            i.Afficher(displayTime); // Pourquoi l'afficher deux fois ?
        }

        [TestMethod]
        public void SEQDessinerEllipseR50x80()
        {
            i = new ModeSequentiel();
            int testEllipse = -1;
            testEllipse = i.DessinerEllipse(posXMid, posYMid, 50, 80);
            Assert.AreNotEqual(-1, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQDessinerTriangle20()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.DessinerTriangle(posXMid, posYMid, 20);
            Assert.AreNotEqual(-1, testPolygone);
            i.Afficher(displayTime);

        }

        /************************************************************************************************************
         * ************************************** Hors Canvas *******************************************************
         * *********************************************************************************************************/

        [TestMethod]
        public void SEQDessinerCarreeHorsCanvas()
        {
            i = new ModeSequentiel();
            int testEllipse = -1;
            testEllipse = i.DessinerRectangle(posXMid, posYMid, 10000, 10000);
            Assert.AreEqual(-1, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQDessinerCercleHorsCanvas()
        {
            i = new ModeSequentiel();
            int testEllipse = -1;
            testEllipse = i.DessinerCercle(posXMid, posYMid, 200000);
            Assert.AreEqual(-1, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQDessinerRectangleHorsCanvas()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.DessinerRectangle(posXMid, posYMid, 500000, 10000000);
            i.Afficher(displayTime);
            Assert.AreEqual(-1, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQDessinerEtoileHorsCanvas()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.DessinerEtoile(posXMid, posYMid, 40000, 80000, 5);
            i.Afficher(displayTime);
            Assert.AreEqual(-1, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void SEQDessinerEllipseHorsCanvas()
        {
            i = new ModeSequentiel();
            int testEllipse = -1;
            testEllipse = i.DessinerEllipse(posXMid, posYMid, 50000, 80000);
            Assert.AreEqual(-1, testEllipse);
            i.Afficher(displayTime);
        }

        // Pas développée
        [TestMethod]
        public void SEQDessinerTriangleHorsCanvas()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.DessinerTriangle(posXMid, posYMid, 200000);
            Assert.AreEqual(-1, testPolygone);
            i.Afficher(displayTime);

        }

        [TestMethod]
        public void SEQDessinerFormeLibreHorsCanvas()
        {
            i = new ModeSequentiel();
            int testFormeLibre = -1;
            i.Stylo.DescendrePointeur();
            i.Stylo.Avancer(20000);
            i.Stylo.LeverPointeur();

            throw new Exception("Dessin libre pas encore implémenté");
        }

        /************************************************************************************************************
         * ************************************** Tourner ***********************************************************
         * *********************************************************************************************************/

        [TestMethod]
        public void SEQTournerPolygone()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.DessinerTriangle(posXMid, posYMid, 20);
            i.Tourner(testPolygone, -300000);
            i.Afficher(displayTime);
        }

        
        [TestMethod]
        public void SEQDupliquerPolygone()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.DessinerTriangle(posXMid, posYMid, 20);
            Assert.AreNotEqual(-1, testPolygone);
            int polygoneDuplique = i.Dupliquer(testPolygone, posXMid + 30, posYMid + 30);
            Assert.AreNotEqual(0, polygoneDuplique);
            Assert.AreNotEqual(testPolygone, polygoneDuplique);
            i.Afficher(displayTime);
        }


        [TestMethod]
        public void SEQNettoyerCanvas()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.DessinerTriangle(posXMid, posYMid, 20);
            Assert.AreNotEqual(-1, testPolygone);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            i.Attendre(displayTime);
        }

        [TestMethod]
        public void SEQReinitialiserCanvas()
        {
            throw new Exception("Pas encore développé");
        }
    }
}
 