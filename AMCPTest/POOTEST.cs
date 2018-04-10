using System;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using AMCP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AMCP.Noyau;
using AMCP.InterfaceUtilisateur;

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
         * ********************************************* Stylo ***************************************************
         * *********************************************************************************************************/

        [TestMethod]
        public void POOBaisserLeverStylo()
        {
            i = new ModeOrienteObjet();
            i.Stylo.DescendreStylo();
            AMCP.Formes.Forme testFormeLibre = i.Stylo.LeverStylo();
            Assert.AreNotEqual(null, testFormeLibre);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POOAvancerStyloDe50()
        {
            i = new ModeOrienteObjet();
            i.Stylo.DescendreStylo();
            i.Stylo.Avancer(50);
            AMCP.Formes.Forme testFormeLibre = i.Stylo.LeverStylo();
            Assert.AreNotEqual(null, testFormeLibre);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POOAvancerStyloDe50SansBaisser()
        {
            i = new ModeOrienteObjet();
            i.Stylo.Avancer(50);
        }

        [TestMethod]
        public void POOTournerStyloDe90()
        {
            i = new ModeOrienteObjet();
            i.Stylo.DescendreStylo();
            i.Stylo.Avancer(50);
            i.Stylo.Tourner(90);
            i.Stylo.Avancer(50);
            AMCP.Formes.Forme testFormeLibre = i.Stylo.LeverStylo();
            Assert.AreNotEqual(null, testFormeLibre);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POOTournerStyloDe450()
        {
            i = new ModeOrienteObjet();
            i.Stylo.DescendreStylo();
            i.Stylo.Avancer(50);
            i.Stylo.Tourner(450);
            i.Stylo.Avancer(50);
            AMCP.Formes.Forme testFormeLibre = i.Stylo.LeverStylo();
            Assert.AreNotEqual(null, testFormeLibre);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POOChangerCouleurStylo()
        {
            i = new ModeOrienteObjet();
            i.Stylo = new Stylo(new Point(posXMid, posYMid), 10, 0, Color.Red);
            i.Stylo.DescendreStylo();
            i.Stylo.Avancer(50);
            AMCP.Formes.Forme testFormeLibre = i.Stylo.LeverStylo();
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
            AMCP.Formes.Forme testPolygone = null;
            testPolygone = i.CreerRectangle(posXMid, posYMid, 100, 100);
            Assert.AreNotEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerCercleR20()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testEllipse = null;
            testEllipse = i.CreerCercle(posXMid, posYMid, 20);
            Assert.AreNotEqual(null, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerRectangle50x100()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testPolygone = null;
            testPolygone = i.CreerRectangle(posXMid, posYMid, 50, 100);
            Assert.AreNotEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerEtoileS5()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testPolygone = null;
            testPolygone = i.CreerEtoile(posXMid, posYMid, 40, 80, 5);
            Assert.AreNotEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerEllipseR50x80()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testEllipse = null;
            testEllipse = i.CreerEllipse(posXMid, posYMid, 50, 80);
            Assert.AreNotEqual(null, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerTriangle20()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testPolygone = null;
            testPolygone = i.CreerTriangle(posXMid, posYMid, 20);
            Assert.AreNotEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerTriangleLibre()
        {
            i = new ModeOrienteObjet();
            i.Stylo.DescendreStylo();
            i.Stylo.Avancer(50);
            i.Stylo.Tourner(30);
            i.Stylo.Avancer(50);
            i.Stylo.Tourner(30);
            i.Stylo.Avancer(50);
            AMCP.Formes.Forme testTriangleLibre = i.Stylo.LeverStylo();
            Assert.AreNotEqual(null, testTriangleLibre);
            i.Afficher(displayTime);
        }

        /************************************************************************************************************
         * ************************************** Hors Canvas *******************************************************
         * *********************************************************************************************************/

        [TestMethod]
        public void POODessinerCarreeHorsCanvas()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testPolygone = null;
            testPolygone = i.CreerRectangle(posXMid, posYMid, 10000, 10000);
            Assert.AreEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerCercleHorsCanvas()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testEllipse = null;
            testEllipse = i.CreerCercle(posXMid, posYMid, 20000);
            Assert.AreEqual(null, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerRectangleHorsCanvas()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testPolygone = null;
            testPolygone = i.CreerRectangle(posXMid, posYMid, 50000, 100000);
            Assert.AreEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerEtoileHorsCanvas()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testPolygone = null;
            testPolygone = i.CreerEtoile(posXMid, posYMid, 40000, 80000, 5);
            Assert.AreEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerEllipseHorsCanvas()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testEllipse = null;
            testEllipse = i.CreerEllipse(posXMid, posYMid, 50000, 80000);
            Assert.AreEqual(null, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerTriangleHorsCanvas()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testPolygone = null;
            testPolygone = i.CreerTriangle(posXMid, posYMid, 20000);
            Assert.AreEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerFormeLibreHorsCanvas()
        {
            i = new ModeOrienteObjet();
            i.Stylo.DescendreStylo();
            i.Stylo.Avancer(20000);
            AMCP.Formes.Forme testFormeLibre = i.Stylo.LeverStylo();
            Assert.AreEqual(null, testFormeLibre);
            i.Afficher(displayTime);
        }

        /************************************************************************************************************
         * ************************************** Dupliquer ***********************************************************
         * *********************************************************************************************************/


        [TestMethod]
        public void POODupliquerPolygone()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testPolygone = i.CreerTriangle(posXMid, posYMid, 20);
            Assert.AreNotEqual(-1, testPolygone.ID);
            AMCP.Formes.Forme polygoneDuplique = testPolygone.Dupliquer(posXMid + 30, posYMid + 30);
            Assert.AreNotEqual(-1, polygoneDuplique.ID);
            Assert.AreNotSame(testPolygone, polygoneDuplique);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODupliquerEllipse()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testCercle = i.CreerCercle(posXMid, posYMid, 20);
            Assert.AreNotEqual(-1, testCercle.ID);
            AMCP.Formes.Forme cercleDuplique = testCercle.Dupliquer(posXMid + 30, posYMid + 30);
            Assert.AreNotEqual(-1, cercleDuplique.ID);
            Assert.AreNotSame(testCercle, cercleDuplique);
            i.Afficher(displayTime);
        }

        /************************************************************************************************************
         * ************************************** Nettoyer/Reinitialiser Canvas ***********************************************************
         * *********************************************************************************************************/

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
        public void POORotationPolygoneRectangle()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testPolygone = null;
            testPolygone = i.CreerRectangle(posXMid, posYMid, 100, 100);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testPolygone.Tourner(40);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POORotationPolygoneTriangle()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testPolygone = null;
            testPolygone = i.CreerTriangle(posXMid, posYMid, 30);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testPolygone.Tourner(40);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POORotationPolygoneEtoile()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testPolygone = null;
            testPolygone = i.CreerEtoile(posXMid, posYMid, 30, 50, 5);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testPolygone.Tourner(40);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POORotationPolygoneLosange()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testPolygone = null;
            testPolygone = i.CreerLosange(posXMid, posYMid, 30,50);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testPolygone.Tourner(40);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POORotationEllipse()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testEllipse = null;
            testEllipse = i.CreerEllipse(posXMid, posYMid, 50, 80);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testEllipse.Tourner(40);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POOTranslationPolygoneRectangle()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testPolygone = null;
            testPolygone = i.CreerRectangle(posXMid, posYMid, 100, 100);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testPolygone.Deplacer(200,200);
            i.Afficher(displayTime);

        }
        [TestMethod]
        public void POOTranslationPolygoneTriangle()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testPolygone = null;
            testPolygone = i.CreerTriangle(posXMid, posYMid, 30);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testPolygone.Deplacer(200, 200);
            i.Afficher(displayTime);

        }
        [TestMethod]
        public void POOTranslationPolygoneEtoile()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testPolygone = null;
            testPolygone = i.CreerEtoile(posXMid, posYMid, 30, 50, 5);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testPolygone.Deplacer(200, 200);
            i.Afficher(displayTime);

        }
        [TestMethod]
        public void POOTranslationPolygoneLosange()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testPolygone = null;
            testPolygone = i.CreerLosange(posXMid, posYMid, 30, 50);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testPolygone.Deplacer(200, 200);
            i.Afficher(displayTime);

        }

        [TestMethod]
        public void POOTranslationEllipse()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testEllipse = null;
            testEllipse = i.CreerEllipse(posXMid, posYMid, 50, 80);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testEllipse.Deplacer(200, 200);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POOHomothetiePolygoneRectangle()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testPolygone = null;
            testPolygone = i.CreerRectangle(posXMid, posYMid, 100, 100);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testPolygone.Dimensionner(2);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POOHomothetiePolygoneTriangle()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testPolygone = null;
            testPolygone = i.CreerTriangle(posXMid, posYMid, 30);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testPolygone.Dimensionner(2);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POOHomothetiePolygoneEtoile()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testPolygone = null;
            testPolygone = i.CreerEtoile(posXMid, posYMid, 30, 50, 5);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testPolygone.Dimensionner(2);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POOHomothetiePolygoneLosange()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testPolygone = null;
            testPolygone = i.CreerLosange(posXMid, posYMid, 30, 50);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testPolygone.Dimensionner(2);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POOHomothetieEllipse()
        {
            i = new ModeOrienteObjet();
            AMCP.Formes.Forme testEllipse = null;
            testEllipse = i.CreerEllipse(posXMid, posYMid, 50, 80);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testEllipse.Dimensionner(2);
            i.Afficher(displayTime);
        }
    }
}
