using AMCP.Formes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCP.Noyau
{
    public class ModeOrienteObjet : IMode
    {
        /// <summary>
        /// Permets de lister toutes les fonctions disponibles dans ce mode.
        /// </summary>
        public override void ListerFonctions()
        {
            Console.WriteLine(">>>>>>>>>> Mode Orienté Objet <<<<<<<<<<<");
            Console.WriteLine("ModeOrienteObjet");
            Console.WriteLine("   Forme <- CreerCarre()");
            Console.WriteLine("   Forme <- CreerRectangle()");
            Console.WriteLine("   Forme <- CreerTriangle()");
            Console.WriteLine("   Forme <- CreerLosange()");
            Console.WriteLine("   Forme <- CreerEtoile()");
            Console.WriteLine("   Forme <- CreerCercle()");
            Console.WriteLine("   Forme <- CreerEllipse()");
            Console.WriteLine("   Forme <- CreerTexte()");
            Console.WriteLine("   Forme <- CreerImage()");
            Console.WriteLine("Forme");
            Console.WriteLine("   Forme <- Dupliquer()");
            Console.WriteLine("   void <- Colorier()");
            Console.WriteLine("   void <- Deplacer()");
            Console.WriteLine("   void <- Dimensionner()");
            Console.WriteLine("   void <- Tourner()");
            Console.WriteLine("   void <- Supprimer()");
            Console.WriteLine("Stylo");
            Console.WriteLine("   Forme <- LeverStylo()");
            Console.WriteLine("   void <- DescendreStylo()");
            Console.WriteLine("   void <- Avancer()");
            Console.WriteLine("   void <- Tourner()");
            Console.WriteLine("   void <- Deplacer()");
        }

        #region Createurs

        /// <summary>
        /// Permet de créer une carré.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="taille"></param>
        /// <returns></returns>
        public virtual Forme CreerCarre(int positionX, int positionY, int taille)
        {
            Polygone f = new Polygone(new Point(positionX, positionY));
            f.SetRectangle(taille, taille);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f;
        }

        /// <summary>
        /// Permet de créer un rectangle.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="largeur"></param>
        /// <param name="hauteur"></param>
        /// <returns></returns>
        public virtual Forme CreerRectangle(int positionX, int positionY, int largeur, int hauteur )
        {
            Polygone f = new Polygone(new Point(positionX, positionY));
            f.SetRectangle(largeur, hauteur);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f;
        }

        /// <summary>
        /// Permet de créer un triangle.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="taille"></param>
        /// <returns></returns>
        public virtual Forme CreerTriangle(int positionX, int positionY, int taille)
        {
            Polygone f = new Polygone(new Point(positionX, positionY));
            f.SetTriangle(taille);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f;
        }

        /// <summary>
        /// Permet de créer un losange.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="largeur"></param>
        /// <param name="hauteur"></param>
        /// <returns></returns>
        public virtual Forme CreerLosange(int positionX, int positionY, int largeur, int hauteur)
        {
            Polygone f = new Polygone(new Point(positionX, positionY));
            f.SetLosange(largeur, hauteur);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f;
        }

        /// <summary>
        /// Permet de créer une étoile.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="rayonInterieur"></param>
        /// <param name="rayonExterieur"></param>
        /// <param name="nbSommet"></param>
        /// <returns></returns>
        public virtual Forme CreerEtoile(int positionX, int positionY,int rayonInterieur, int rayonExterieur, int nbSommet)
        {
            Polygone f = new Polygone(new Point(positionX, positionY));
            f.SetEtoile(rayonInterieur / 2, rayonExterieur / 2, nbSommet);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f;
        }
        
        /// <summary>
        /// Permet de créer un cercle.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="rayon"></param>
        /// <returns></returns>
        public virtual Forme CreerCercle(int positionX, int positionY, int rayon)
        {
            Forme f = new Ellipse(new Point(positionX, positionY), rayon, rayon);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f;
        }
        
        /// <summary>
        /// Permet de créer une ellipse.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="rayon1"></param>
        /// <param name="rayon2"></param>
        /// <returns></returns>
        public virtual Forme CreerEllipse(int positionX, int positionY, int rayon1, int rayon2)
        {
            Forme f = new Ellipse(new Point(positionX, positionY), rayon1, rayon2);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f;
        }

        /// <summary>
        /// Permet de créer un texte.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="taillePolice"></param>
        /// <param name="contenu"></param>
        /// <returns></returns>
        public virtual Forme CreerTexte(int positionX, int positionY, int taillePolice, string contenu)
        {
            Forme f = new Texte(new Point(positionX, positionY), taillePolice, contenu);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f;
        }

        /// <summary>
        /// Permet de créer une image.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="imageName"></param>
        /// <returns></returns>
        public virtual Forme CreerImage(int positionX, int positionY, string imageName)
        {
            Forme f = new Formes.Image(new Point(positionX, positionY), imageName);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f;
        }
        #endregion
    }
}
