using System;
using AMCP.InterfaceUtilisateur;
using AMCP.Noyau;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AMCPTest
{
    [TestClass]
    public class COMTEST
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


        [TestMethod]
        public void COMListerContributeur()
        {
            throw new Exception("Pas encore développé");
        }


        [TestMethod]
        public void COMNettoyerCanvas()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerTriangle(posXMid, posYMid, 20);
            Assert.IsTrue(testPolygone > 0);
            i.Afficher(displayTime);
            i.NettoyerEcran();
            i.Attendre(displayTime);
        }

        [TestMethod]
        public void COMChangerDimensionCanvas()
        {
            i = new ModeSequentiel();
            i.Attendre(displayTime);
            i.ChangerDimension(100, 200);
            i.Attendre(displayTime);
        }
    }


}
