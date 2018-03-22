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
        InterfaceOrienteeObjet i;
        Int32 displayTime = 2000;

        [TestInitialize()]
        public void Initialize()
        {
            new PrivateType(typeof(IMode)).SetStaticField("instance", null);
            new PrivateType(typeof(Canvas)).SetStaticField("instance", null);
        }

        [TestMethod]
        public void POODessinerCercle()
        {
            i = new InterfaceOrienteeObjet();
            int posX = 20;
            int posY = 20;
            Ellipse testEllipse = null;
            testEllipse = i.DessinerCercle(0 + posX, posY, 20);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(null, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerRectangle()
        {
            i = new InterfaceOrienteeObjet();
            int posX = 20;
            int posY = 20;
            Polygone testPolygone = null;
            testPolygone = i.DessinerRectangle(posX, posY, 50, 70);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerEtoile()
        {
            i = new InterfaceOrienteeObjet();
            int posX = 20;
            int posY = 20;
            Polygone testPolygone = null;
            testPolygone = i.DessinerEtoile(posX, posY + 100, 40, 80, 5);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(null, testPolygone);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerEllipse()
        {
            i = new InterfaceOrienteeObjet();
            int posX = 20;
            int posY = 20;
            Ellipse testEllipse = null;
            testEllipse = i.DessinerEllipse(posX, posY + 250, 20, 50);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(null, testEllipse);
            i.Afficher(displayTime);
        }

        [TestMethod]
        public void POODessinerTriangle()
        {
            i = new InterfaceOrienteeObjet();
            int posX = 20;
            int posY = 20;
            Polygone testPolygone = null;
            testPolygone = i.DessinerTriangle(posX, posY, 20);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(null, testPolygone);
            i.Afficher(displayTime);
        }
    }
}
