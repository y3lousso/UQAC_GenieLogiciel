using System;
using System.Diagnostics;
using System.Threading;
using AMCP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

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
         * ************************************** Dessiner Formes ***************************************************
         * *********************************************************************************************************/

        [TestMethod]
        public void POODessinerCarree100x100()
        {
            i = new ModeOrienteObjet();
            Polygone testPolygone = null;
            testPolygone = i.DessinerRectangle(posXMid, posYMid, 100, 100);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerCercleR20()
        {
            i = new ModeOrienteObjet();
            Ellipse testEllipse = null;
            testEllipse = i.DessinerCercle(posXMid, posYMid, 20);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(null, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerRectangle50x100()
        {
            i = new ModeOrienteObjet();
            Polygone testPolygone = null;
            testPolygone = i.DessinerRectangle(posXMid, posYMid, 50, 100);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerEtoileS5()
        {
            i = new ModeOrienteObjet();
            Polygone testPolygone = null;
            testPolygone = i.DessinerEtoile(posXMid, posYMid, 40, 80, 5);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerEllipseR50x80()
        {
            i = new ModeOrienteObjet();
            Ellipse testEllipse = null;
            testEllipse = i.DessinerEllipse(posXMid, posYMid, 50, 80);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(null, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerTriangle20()
        {
            i = new ModeOrienteObjet();
            Polygone testPolygone = null;
            testPolygone = i.DessinerTriangle(posXMid, posYMid, 20);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(null, testPolygone);
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
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerCercleHorsCanvas()
        {
            i = new ModeOrienteObjet();
            Ellipse testEllipse = null;
            testEllipse = i.DessinerCercle(posXMid, posYMid, 20000);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(null, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerRectangleHorsCanvas()
        {
            i = new ModeOrienteObjet();
            Polygone testPolygone = null;
            testPolygone = i.DessinerRectangle(posXMid, posYMid, 50000, 100000);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerEtoileHorsCanvas()
        {
            i = new ModeOrienteObjet();
            Polygone testPolygone = null;
            testPolygone = i.DessinerEtoile(posXMid, posYMid, 40000, 80000, 5);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerEllipseHorsCanvas()
        {
            i = new ModeOrienteObjet();
            Ellipse testEllipse = null;
            testEllipse = i.DessinerEllipse(posXMid, posYMid, 50000, 80000);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(null, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerTriangleHorsCanvas()
        {
            i = new ModeOrienteObjet();
            Polygone testPolygone = null;
            testPolygone = i.DessinerTriangle(posXMid, posYMid, 20000);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(null, testPolygone);
            i.Afficher(displayTime);
        }


    }
}
