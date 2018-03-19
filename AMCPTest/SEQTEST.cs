using System;
using AMCP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AMCPTest
{
    [TestClass]
    public class SEQTEST
    {
        InterfaceSequencielle i;

        [TestInitialize()]
        public void Initialize()
        {
            new PrivateType(typeof(IMode)).SetStaticField("instance", null);
            new PrivateType(typeof(Canvas)).SetStaticField("instance", null);
        }


        [TestMethod]
        public void SEQDessinerCercle()
        {
            i = new InterfaceSequencielle();
            int testEllipse = -1;
            testEllipse = i.DessinerCercle(20, 20, -1);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(-1, testEllipse);
        }

        [TestMethod]
        public void SEQDessinerRectangle()
        {
            i = new InterfaceSequencielle();
            int testPolygone = -1;
            testPolygone = i.DessinerRectangle(20, 20, 50, 70);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(-1, testPolygone);
        }

        [TestMethod]
        public void SEQDessinerEtoile()
        {
            i = new InterfaceSequencielle();
            int testPolygone = -1;
            testPolygone = i.DessinerEtoile(20, 120, 40, 80, 5);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(-1, testPolygone);
        }

        [TestMethod]
        public void SEQDessinerEllipse()
        {
            i = new InterfaceSequencielle();
            int testEllipse = -1;
            testEllipse = i.DessinerEllipse(20, 270, 20, 50);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(-1, testEllipse);
        }

        [TestMethod]
        public void SEQDessinerTriangle()
        {
            i = new InterfaceSequencielle();
            int testPolygone = -1;
            testPolygone = i.DessinerTriangle(100, 100, 200);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(-1, testPolygone);
            
        }

        [TestMethod]
        public void SEQTournerPolygone()
        {
            i = new InterfaceSequencielle();
            int testPolygone = -1;
            testPolygone = i.DessinerTriangle(20, 20, 20);
            i.Tourner(testPolygone, -300000);
        }

    }
}
