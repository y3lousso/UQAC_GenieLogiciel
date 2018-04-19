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
        public Stylo Stylo { get; set; }

        /// <summary>
        /// Permet de créer une instance du mode orientée objet.
        /// </summary>
        public ModeOrienteObjet()
        {
            this.Stylo = new Stylo();
        }

        /// <summary>
        /// Permets de lister toutes les fonctions disponibles dans ce mode.
        /// </summary>
        public override void ListerFonctions()
        {
            IMode.instance.Logger(">>>>>>>>>> Mode Orienté Objet <<<<<<<<<<<", ConsoleColor.Gray);
            IMode.instance.Logger("ModeOrienteObjet", ConsoleColor.Gray);
            IMode.instance.Logger("   Forme <- CreerCarre()", ConsoleColor.Gray);
            IMode.instance.Logger("   Forme <- CreerRectangle()", ConsoleColor.Gray);
            IMode.instance.Logger("   Forme <- CreerTriangle()", ConsoleColor.Gray);
            IMode.instance.Logger("   Forme <- CreerLosange()", ConsoleColor.Gray);
            IMode.instance.Logger("   Forme <- CreerEtoile()", ConsoleColor.Gray);
            IMode.instance.Logger("   Forme <- CreerCercle()", ConsoleColor.Gray);
            IMode.instance.Logger("   Forme <- CreerEllipse()", ConsoleColor.Gray);
            IMode.instance.Logger("   Forme <- CreerTexte()", ConsoleColor.Gray);
            IMode.instance.Logger("   Forme <- CreerImage()", ConsoleColor.Gray);
            IMode.instance.Logger("Forme", ConsoleColor.Gray);
            IMode.instance.Logger("   Forme <- Dupliquer()", ConsoleColor.Gray);
            IMode.instance.Logger("   void <- Colorier()", ConsoleColor.Gray);
            IMode.instance.Logger("   void <- Deplacer()", ConsoleColor.Gray);
            IMode.instance.Logger("   void <- Dimensionner()", ConsoleColor.Gray);
            IMode.instance.Logger("   void <- Tourner()", ConsoleColor.Gray);
            IMode.instance.Logger("   void <- Supprimer()", ConsoleColor.Gray);
            IMode.instance.Logger("Stylo", ConsoleColor.Gray);
            IMode.instance.Logger("   Forme <- LeverStylo()", ConsoleColor.Gray);
            IMode.instance.Logger("   void <- DescendreStylo()", ConsoleColor.Gray);
            IMode.instance.Logger("   void <- Avancer()", ConsoleColor.Gray);
            IMode.instance.Logger("   void <- Tourner()", ConsoleColor.Gray);
            IMode.instance.Logger("   void <- Deplacer()", ConsoleColor.Gray);
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
            this.Canvas.Formes.Add(f);
            IMode.instance.Logger(f.Type + " " + f.ID + " : Création effectuée.", ConsoleColor.Green);
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
            this.Canvas.Formes.Add(f);
            IMode.instance.Logger(f.Type + " " + f.ID + " : Création effectuée.", ConsoleColor.Green);
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
            this.Canvas.Formes.Add(f);
            IMode.instance.Logger(f.Type + " " + f.ID + " : Création effectuée.", ConsoleColor.Green);
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
            this.Canvas.Formes.Add(f);
            IMode.instance.Logger(f.Type + " " + f.ID + " : Création effectuée.", ConsoleColor.Green);
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
            this.Canvas.Formes.Add(f);
            IMode.instance.Logger(f.Type + " " + f.ID + " : Création effectuée.", ConsoleColor.Green);
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
            this.Canvas.Formes.Add(f);
            IMode.instance.Logger(f.Type + " " + f.ID + " : Création effectuée.", ConsoleColor.Green);
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
            this.Canvas.Formes.Add(f);
            IMode.instance.Logger(f.Type + " " + f.ID + " : Création effectuée.", ConsoleColor.Green);
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
            this.Canvas.Formes.Add(f);
            IMode.instance.Logger(f.Type + " " + f.ID + " : Création effectuée.", ConsoleColor.Green);
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
            this.Canvas.Formes.Add(f);
            IMode.instance.Logger(f.Type + " " + f.ID + " : Création effectuée.", ConsoleColor.Green);
            return f;
        }
        #endregion
    }
}
