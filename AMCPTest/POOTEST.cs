using System;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using AMCP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AMCP.Noyau;
using AMCP.Formes;
using AMCP.InterfaceUtilisateur;
using System.IO;

namespace AMCPTest
{
    [TestClass]
    public class POOTEST
    {
        ModeOrienteObjet i;
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
        public void POOBaisserLeverStylo()
        {
            i = new ModeOrienteObjet();
            i.Stylo.DescendreStylo();
            Forme testFormeLibre = i.Stylo.LeverStylo();
            Assert.AreNotEqual(null, testFormeLibre);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POOAvancerStyloDe50()
        {
            i = new ModeOrienteObjet();
            i.Stylo.DescendreStylo();
            i.Stylo.Avancer(50);
            Forme testFormeLibre = i.Stylo.LeverStylo();
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
            Forme testFormeLibre = i.Stylo.LeverStylo();
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
            Forme testFormeLibre = i.Stylo.LeverStylo();
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
            Forme testFormeLibre = i.Stylo.LeverStylo();
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
            Forme testPolygone = null;
            testPolygone = i.CreerRectangle(posXMid, posYMid, 100, 100);
            Assert.AreNotEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerCercleR20()
        {
            i = new ModeOrienteObjet();
            Forme testEllipse = null;
            testEllipse = i.CreerCercle(posXMid, posYMid, 20);
            Assert.AreNotEqual(null, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerRectangle50x100()
        {
            i = new ModeOrienteObjet();
            Forme testPolygone = null;
            testPolygone = i.CreerRectangle(posXMid, posYMid, 50, 100);
            Assert.AreNotEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerEtoileS5()
        {
            i = new ModeOrienteObjet();
            Forme testPolygone = null;
            testPolygone = i.CreerEtoile(posXMid, posYMid, 40, 80, 5);
            Assert.AreNotEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerEllipseR50x80()
        {
            i = new ModeOrienteObjet();
            Forme testEllipse = null;
            testEllipse = i.CreerEllipse(posXMid, posYMid, 50, 80);
            Assert.AreNotEqual(null, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerTriangle20()
        {
            i = new ModeOrienteObjet();
            Forme testPolygone = null;
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
            i.Stylo.Tourner(120);
            i.Stylo.Avancer(50);
            i.Stylo.Tourner(120);
            i.Stylo.Avancer(50);
            Forme testTriangleLibre = i.Stylo.LeverStylo();
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
            Forme testPolygone = null;
            testPolygone = i.CreerRectangle(posXMid+1000, posYMid+1000, 10000, 10000);
            i.Afficher(displayTime);
            Assert.AreEqual(null, testPolygone);
        }

        [TestMethod]
        public void POODessinerCercleHorsCanvas()
        {
            i = new ModeOrienteObjet();
            Forme testEllipse = null;
            testEllipse = i.CreerCercle(posXMid + 1000, posYMid + 1000, 20000);
            i.Afficher(displayTime);
            Assert.AreEqual(null, testEllipse);
        }

        [TestMethod]
        public void POODessinerRectangleHorsCanvas()
        {
            i = new ModeOrienteObjet();
            Forme testPolygone = null;
            testPolygone = i.CreerRectangle(posXMid + 1000, posYMid + 1000, 50000, 100000);
            i.Afficher(displayTime);
            Assert.AreEqual(null, testPolygone);
        }

        [TestMethod]
        public void POODessinerEtoileHorsCanvas()
        {
            i = new ModeOrienteObjet();
            Forme testPolygone = null;
            testPolygone = i.CreerEtoile(posXMid + 1000, posYMid + 1000, 40000, 80000, 5);
            i.Afficher(displayTime);
            Assert.AreEqual(null, testPolygone);
        }

        [TestMethod]
        public void POODessinerEllipseHorsCanvas()
        {
            i = new ModeOrienteObjet();
            Forme testEllipse = null;
            testEllipse = i.CreerEllipse(posXMid + 1000, posYMid + 1000, 50000, 80000);
            i.Afficher(displayTime);
            Assert.AreEqual(null, testEllipse);
        }

        [TestMethod]
        public void POODessinerTriangleHorsCanvas()
        {
            i = new ModeOrienteObjet();
            Forme testPolygone = null;
            testPolygone = i.CreerTriangle(posXMid + 1000, posYMid + 1000, 20000);
            i.Afficher(displayTime);
            Assert.AreEqual(null, testPolygone);
        }

        [TestMethod]
        public void POODessinerFormeLibreHorsCanvas()
        {
            i = new ModeOrienteObjet();
            i.Stylo.Deplacer(-2000, 300);
            i.Stylo.DescendreStylo();
            i.Stylo.Avancer(2000);
            Forme testFormeLibre = i.Stylo.LeverStylo();
            i.Afficher(displayTime); // Ne doit rien afficher
        }

        [TestMethod]
        public void POODessinerFormeLibreDepasseHorsCanvas()
        {
            i = new ModeOrienteObjet();
            i.Stylo.DescendreStylo();
            i.Stylo.Avancer(2000);
            Forme testFormeLibre = i.Stylo.LeverStylo();
            i.Afficher(displayTime); // Doit afficher
        }

        /************************************************************************************************************
         * ************************************** Dupliquer ***********************************************************
         * *********************************************************************************************************/


        [TestMethod]
        public void POODupliquerPolygone()
        {
            i = new ModeOrienteObjet();
            Forme testPolygone = i.CreerTriangle(posXMid, posYMid, 20);
            Assert.IsTrue(testPolygone.ID > 0);
            Forme polygoneDuplique = testPolygone.Dupliquer(posXMid + 30, posYMid + 30);
            Assert.IsTrue(polygoneDuplique.ID > 0);
            Assert.AreNotSame(testPolygone, polygoneDuplique);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODupliquerEllipse()
        {
            i = new ModeOrienteObjet();
            Forme testCercle = i.CreerCercle(posXMid, posYMid, 20);
            Assert.IsTrue(testCercle.ID > 0);
            Forme cercleDuplique = testCercle.Dupliquer(posXMid + 30, posYMid + 30);
            Assert.IsTrue(cercleDuplique.ID > 0);
            Assert.AreNotSame(testCercle, cercleDuplique);
            i.Afficher(displayTime);
        }


        /************************************************************************************************************
         * ************************************** Reinitialiser Canvas ***********************************************************
         * *********************************************************************************************************/

        [TestMethod]
        public void POOReinitialiserCanvas()
        {
            throw new Exception("Pas encore développé");
        }


        /************************************************************************************************************
         * ************************************** Ecrire Texte/Importer Image ***********************************************************
         * *********************************************************************************************************/


        [TestMethod]
        public void POOEcrireTexte()
        {
            i = new ModeOrienteObjet();
            Forme texte = i.CreerTexte(posXMid, posYMid, 60, "THIS IS A TEST");
            Assert.IsTrue(texte.ID > 0);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POOImporterImage()
        {
            i = new ModeOrienteObjet();
            string fileName = "pikachu.png";
            string rootPath = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
            string path = Path.Combine(rootPath, @"assets\", fileName);
            Forme img = i.CreerImage(100, 100, path);
            img.Dimensionner(.5f);
            Assert.IsTrue(img.ID > 0);
            i.Afficher(displayTime);
        }

        /************************************************************************************************************
 * ************************************** Rotation/translation/homothétie d'une forme *******************************************************
 * *********************************************************************************************************/

        [TestMethod]
        public void POORotationPolygoneRectangle()
        {
            i = new ModeOrienteObjet();
            Forme testPolygone = null;
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
            Forme testPolygone = null;
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
            Forme testPolygone = null;
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
            Forme testPolygone = null;
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
            Forme testEllipse = null;
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
            Forme testPolygone = null;
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
            Forme testPolygone = null;
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
            Forme testPolygone = null;
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
            Forme testPolygone = null;
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
            Forme testEllipse = null;
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
            Forme testPolygone = null;
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
            Forme testPolygone = null;
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
            Forme testPolygone = null;
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
            Forme testPolygone = null;
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
            Forme testEllipse = null;
            testEllipse = i.CreerEllipse(posXMid, posYMid, 50, 80);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            testEllipse.Dimensionner(2);
            i.Afficher(displayTime);
        }
    }
}
