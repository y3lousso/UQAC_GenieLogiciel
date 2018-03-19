using System;
using AMCP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace AMCPTest
{
    [TestClass]
    public class POOTEST
    {
        InterfaceOrienteeObjet i;

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
            testEllipse = i.DessinerCercle(0 + posX, posY, -1);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(null, testEllipse);
            
        }

        [TestMethod]
        public void POODessinerRectangle50x70()
        {
            i = new InterfaceOrienteeObjet();
            int posX = 20;
            int posY = 20;
            i.DessinerRectangle(posX, posY, 50, 70);
        }

        /*[TestMethod]
        public void POOTestAll()
        {
            i = new InterfaceOrienteeObjet();
            POODessinerRectangle50x70();
            POODessinerCercle();
        }

        private void POODessinerRectangle50x70()
        {
            int posX = 20;
            int posY = 20;

            i.DessinerRectangle(posX, posY, 50, 70);
        }

        public void POODessinerCercle()
        {
            int posX = 20;
            int posY = 20;
            Ellipse testEllipse = null;
            testEllipse = i.DessinerCercle(0 + posX, posY, -1);
            Assert.AreNotEqual(null, testEllipse);
        }*/


    }
}
