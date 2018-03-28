using System;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using AMCP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AMCPTest
{
    [TestClass]
    public class POOTEST
    {
        ModeOrienteObjet i;
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
        public void POOBaisserLeverPointeur()
        {
            i = new ModeOrienteObjet();
            i.Stylo.DescendrePointeur();
            i.Stylo.LeverPointeur();
            AMCP.Formes.FormeLibre testFormeLibre = i.Stylo.Dessiner();
            Assert.AreNotEqual(null, testFormeLibre);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POOAvancerPointeurDe50()
        {
            i = new ModeOrienteObjet();
            i.Stylo = new Stylo(new Point(posXMid, posYMid), 30, 0, Color.Black);
            i.Stylo.DescendrePointeur();
            i.Stylo.Avancer(50);
            i.Stylo.LeverPointeur();
            AMCP.Formes.FormeLibre testFormeLibre = i.Stylo.Dessiner();
            Assert.AreNotEqual(null, testFormeLibre);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POOAvancerPointeurDe50SansBaisser()
        {
            i = new ModeOrienteObjet();
            i.Stylo.Avancer(50);
        }

        [TestMethod]
        public void POOTournerPointeurDe90()
        {
            i = new ModeOrienteObjet();
            i.Stylo = new Stylo(new Point(posXMid, posYMid), 30, 0, Color.Black);
            i.Stylo.DescendrePointeur();
            i.Stylo.Avancer(50);
            i.Stylo.Tourner(90);
            i.Stylo.Avancer(50);
            i.Stylo.LeverPointeur();
            AMCP.Formes.FormeLibre testFormeLibre = i.Stylo.Dessiner();
            Assert.AreNotEqual(null, testFormeLibre);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POOTournerPointeurDe450()
        {
            i = new ModeOrienteObjet();
            i.Stylo = new Stylo(new Point(posXMid, posYMid), 30, 0, Color.Black);
            i.Stylo.DescendrePointeur();
            i.Stylo.Avancer(50);
            i.Stylo.Tourner(450);
            i.Stylo.Avancer(50);
            i.Stylo.LeverPointeur();
            AMCP.Formes.FormeLibre testFormeLibre = i.Stylo.Dessiner();
            Assert.AreNotEqual(null, testFormeLibre);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POOChangerCouleurPointeur()
        {
            i = new ModeOrienteObjet();
            i.Stylo = new Stylo(new Point(posXMid, posYMid), 30, 0, Color.Red);
            i.Stylo.DescendrePointeur();
            i.Stylo.Avancer(50);
            i.Stylo.LeverPointeur();
            AMCP.Formes.FormeLibre testFormeLibre = i.Stylo.Dessiner();
            Assert.AreNotEqual(null, testFormeLibre);
            i.Afficher(displayTime);
        }

        /************************************************************************************************************
         * ************************************** Dessiner Formes ***************************************************
         * *********************************************************************************************************/

        [TestMethod]
        public void POODessinerCarree100x100()
        {
            i = new ModeOrienteObjet();
            Polygone testPolygone = null;
            testPolygone = i.DessinerRectangle(posXMid, posYMid, 100, 100);
            Assert.AreNotEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerCercleR20()
        {
            i = new ModeOrienteObjet();
            Ellipse testEllipse = null;
            testEllipse = i.DessinerCercle(posXMid, posYMid, 20);
            Assert.AreNotEqual(null, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerRectangle50x100()
        {
            i = new ModeOrienteObjet();
            Polygone testPolygone = null;
            testPolygone = i.DessinerRectangle(posXMid, posYMid, 50, 100);
            Assert.AreNotEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerEtoileS5()
        {
            i = new ModeOrienteObjet();
            Polygone testPolygone = null;
            testPolygone = i.DessinerEtoile(posXMid, posYMid, 40, 80, 5);
            Assert.AreNotEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerEllipseR50x80()
        {
            i = new ModeOrienteObjet();
            Ellipse testEllipse = null;
            testEllipse = i.DessinerEllipse(posXMid, posYMid, 50, 80);
            Assert.AreNotEqual(null, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerTriangle20()
        {
            i = new ModeOrienteObjet();
            Polygone testPolygone = null;
            testPolygone = i.DessinerTriangle(posXMid, posYMid, 20);
            Assert.AreNotEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        /************************************************************************************************************
         * ************************************** Hors Canvas *******************************************************
         * *********************************************************************************************************/

        [TestMethod]
        public void POODessinerCarreeHorsCanvas()
        {
            i = new ModeOrienteObjet();
            Polygone testPolygone = null;
            testPolygone = i.DessinerRectangle(posXMid, posYMid, 10000, 10000);
            Assert.AreEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerCercleHorsCanvas()
        {
            i = new ModeOrienteObjet();
            Ellipse testEllipse = null;
            testEllipse = i.DessinerCercle(posXMid, posYMid, 20000);
            Assert.AreEqual(null, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerRectangleHorsCanvas()
        {
            i = new ModeOrienteObjet();
            Polygone testPolygone = null;
            testPolygone = i.DessinerRectangle(posXMid, posYMid, 50000, 100000);
            Assert.AreEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerEtoileHorsCanvas()
        {
            i = new ModeOrienteObjet();
            Polygone testPolygone = null;
            testPolygone = i.DessinerEtoile(posXMid, posYMid, 40000, 80000, 5);
            Assert.AreEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerEllipseHorsCanvas()
        {
            i = new ModeOrienteObjet();
            Ellipse testEllipse = null;
            testEllipse = i.DessinerEllipse(posXMid, posYMid, 50000, 80000);
            Assert.AreEqual(null, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerTriangleHorsCanvas()
        {
            i = new ModeOrienteObjet();
            Polygone testPolygone = null;
            testPolygone = i.DessinerTriangle(posXMid, posYMid, 20000);
            Assert.AreEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerFormeLibreHorsCanvas()
        {
            i = new ModeOrienteObjet();
            i.Stylo.DescendrePointeur();
            i.Stylo.Avancer(20000);
            i.Stylo.LeverPointeur();
            AMCP.Formes.FormeLibre testFormeLibre = i.Stylo.Dessiner();
            Assert.AreEqual(null, testFormeLibre);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODupliquerPolygone()
        {
            i = new ModeOrienteObjet();
            throw new Exception("Pas encore développé");
        }

        [TestMethod]
        public void POONettoyerCanvas()
        {
            throw new Exception("Pas encore développé");
        }

        [TestMethod]
        public void POOReinitialiserCanvas()
        {
            throw new Exception("Pas encore développé");
        }


        /************************************************************************************************************
 * ************************************** Rotation/translation/homothétie d'une forme *******************************************************
 * *********************************************************************************************************/

        [TestMethod]
        public void POORotationPolygone()
        {
            i = new ModeOrienteObjet();
            Polygone testPolygone = null;
            testPolygone = i.DessinerRectangle(posXMid, posYMid, 100, 100);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testPolygone.Tourner(40);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POORotationPolygone2()
        {
            i = new ModeOrienteObjet();
            Polygone testPolygone = null;
            testPolygone = i.DessinerTriangle(posXMid, posYMid, 30);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testPolygone.Tourner(40);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POORotationEllipse()
        {
            i = new ModeOrienteObjet();
            Ellipse testEllipse = null;
            testEllipse = i.DessinerEllipse(posXMid, posYMid, 50, 80);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testEllipse.Tourner(40);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POOTranslationPolygone()
        {
            i = new ModeOrienteObjet();
            Polygone testPolygone = null;
            testPolygone = i.DessinerRectangle(posXMid, posYMid, 100, 100);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testPolygone.Deplacer(200,200);
            i.Afficher(displayTime);

        }

        [TestMethod]
        public void POOTranslationEllipse()
        {
            i = new ModeOrienteObjet();
            Ellipse testEllipse = null;
            testEllipse = i.DessinerEllipse(posXMid, posYMid, 50, 80);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testEllipse.Deplacer(200, 200);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POOHomothetiePolygone()
        {
            i = new ModeOrienteObjet();
            Polygone testPolygone = null;
            testPolygone = i.DessinerRectangle(posXMid, posYMid, 100, 100);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testPolygone.Dimensionner(2);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POOHomothetieEllipse()
        {
            i = new ModeOrienteObjet();
            Ellipse testEllipse = null;
            testEllipse = i.DessinerEllipse(posXMid, posYMid, 50, 80);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testEllipse.Dimensionner(2);
            i.Afficher(displayTime);
        }
    }
}
