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
            new PrivateType(typeof(IMode)).SetStaticFieldOrProperty("instance", null);
            new PrivateType(typeof(Canvas)).SetStaticField("instance", null);
        }


        [TestMethod]
        public void COMListerContributeur()
        {
            i = new ModeSequentiel();
            i.ListerContributeurs();
        }

        #region Nettoyer_Reinitialiser_Canvas

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
            i.Afficher(displayTime); // Les formes doivent s'afficher à nouveau 
        }

        [TestMethod]
        public void COMReinitialiserCanvas()
        {
            i = new ModeSequentiel();
            int testPolygone = -1;
            testPolygone = i.CreerTriangle(posXMid, posYMid, 20);
            i.CreerCarre(posXMid-40, posYMid, 20);
            Assert.IsTrue(testPolygone > 0);
            i.Afficher(displayTime);
            i.ReinitialiserCanvas();

            // Use a private object to access to protected method : IdentifierForme
            PrivateObject iPrivate = new PrivateObject(i);
            var retVal = iPrivate.Invoke("IdentifierForme", testPolygone);
            Assert.IsNull(retVal); 

            i.CreerTexte(posXMid, posYMid, 20, "Reset done");
            i.Afficher(displayTime); // Aucune forme ne doit s'afficher mis à part le texte
        }
        #endregion

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
