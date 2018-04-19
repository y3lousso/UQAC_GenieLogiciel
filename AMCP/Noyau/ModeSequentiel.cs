using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMCP.Formes;

namespace AMCP.Noyau
{
    public class ModeSequentiel : IMode
    {
        private  Stylo Stylo { get; set; }

        /// <summary>
        /// Permet de créer une instance du mode séquentiel.
        /// </summary>
        public ModeSequentiel()
        {
            this.Stylo = new Stylo();
        }

        /// <summary>
        /// Permets de lister toutes les fonctions disponibles dans ce mode.
        /// </summary>
        public override void ListerFonctions()
        {
            IMode.instance.Logger(">>>>>>>>>> Mode Sequentiel <<<<<<<<<<<", ConsoleColor.Gray);
            IMode.instance.Logger("ModeOSequentiel", ConsoleColor.Gray);
            IMode.instance.Logger("   int <- CreerCarre()", ConsoleColor.Gray);
            IMode.instance.Logger("   int <- CreerRectangle()", ConsoleColor.Gray);
            IMode.instance.Logger("   int <- CreerTriangle()", ConsoleColor.Gray);
            IMode.instance.Logger("   int <- CreerLosange()", ConsoleColor.Gray);
            IMode.instance.Logger("   int <- CreerEtoile()", ConsoleColor.Gray);
            IMode.instance.Logger("   int <- CreerCercle()", ConsoleColor.Gray);
            IMode.instance.Logger("   int <- CreerEllipse()", ConsoleColor.Gray);
            IMode.instance.Logger("   int <- CreerTexte()", ConsoleColor.Gray);
            IMode.instance.Logger("   int <- CreerImage()", ConsoleColor.Gray);
            IMode.instance.Logger("   int <- DupliquerForme()", ConsoleColor.Gray);
            IMode.instance.Logger("   void <- ColorierForme()", ConsoleColor.Gray);
            IMode.instance.Logger("   void <- TournerForme()", ConsoleColor.Gray);
            IMode.instance.Logger("   void <- DeplacerForme()", ConsoleColor.Gray);
            IMode.instance.Logger("   void <- DimensionnerForme()", ConsoleColor.Gray);
            IMode.instance.Logger("   void <- SupprimerForme()", ConsoleColor.Gray);
            IMode.instance.Logger("   int <- LeverStylo()", ConsoleColor.Gray);
            IMode.instance.Logger("   void <- DescendreStylo()", ConsoleColor.Gray);
            IMode.instance.Logger("   void <- AvancerStylo()", ConsoleColor.Gray);
            IMode.instance.Logger("   void <- TournerStylo()", ConsoleColor.Gray);
            IMode.instance.Logger("   void <- DeplacerStylo()", ConsoleColor.Gray);
            IMode.instance.Logger("   void <- ColorierStylo()", ConsoleColor.Gray);
        }

        #region Createurs

        /// <summary>
        /// Permet de créer un carré.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="taille"></param>
        /// <returns></returns>
        public virtual int CreerCarre(int positionX, int positionY, int taille)
        {
            Polygone f = new Polygone(new Point(positionX, positionY));
            f.SetRectangle(taille, taille);
            this.Canvas.Formes.Add(f);
            IMode.instance.Logger(f.Type + " " + f.ID + " : Création effectuée.", ConsoleColor.Green);
            return f.ID;
        }

        /// <summary>
        /// Permet de créer un rectangle.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="largeur"></param>
        /// <param name="hauteur"></param>
        /// <returns></returns>
        public virtual int CreerRectangle(int positionX, int positionY, int largeur, int hauteur)
        {
            Polygone f = new Polygone(new Point(positionX, positionY));
            f.SetRectangle(largeur, hauteur);
            this.Canvas.Formes.Add(f);
            IMode.instance.Logger(f.Type + " " + f.ID + " : Création effectuée.", ConsoleColor.Green);
            return f.ID;
        }
      
        /// <summary>
        /// Permet de créer un triangle.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="taille"></param>
        /// <returns></returns>
        public virtual int CreerTriangle(int positionX, int positionY, int taille)
        {
            Polygone f = new Polygone(new Point(positionX, positionY));
            f.SetTriangle(taille);
            this.Canvas.Formes.Add(f);
            IMode.instance.Logger(f.Type + " " + f.ID + " : Création effectuée.", ConsoleColor.Green);
            return f.ID;
        }

        /// <summary>
        /// Permet de créer un losange.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="largeur"></param>
        /// <param name="hauteur"></param>
        /// <returns></returns>
        public virtual int CreerLosange(int positionX, int positionY, int largeur, int hauteur)
        {
            Polygone f = new Polygone(new Point(positionX, positionY));
            f.SetLosange(largeur, hauteur);
            this.Canvas.Formes.Add(f);
            IMode.instance.Logger(f.Type + " " + f.ID + " : Création effectuée.", ConsoleColor.Green);
            return f.ID;
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
        public virtual int CreerEtoile(int positionX, int positionY, int rayonInterieur, int rayonExterieur, int nbSommet)
        {
            Polygone f = new Polygone(new Point(positionX, positionY));
            f.SetEtoile(rayonInterieur/2, rayonExterieur/2, nbSommet);
            this.Canvas.Formes.Add(f);
            IMode.instance.Logger(f.Type + " " + f.ID + " : Création effectuée.", ConsoleColor.Green);
            return f.ID;
        }
        
        /// <summary>
        /// Permet de créer un cercle.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="rayon"></param>
        /// <returns></returns>
        public virtual int CreerCercle(int positionX, int positionY, int rayon)
        {
            Ellipse f = new Ellipse(new Point(positionX, positionY), rayon, rayon);
            this.Canvas.Formes.Add(f);
            IMode.instance.Logger(f.Type + " " + f.ID + " : Création effectuée.", ConsoleColor.Green);
            return f.ID;
        }

        /// <summary>
        /// Permet de créer une ellipse.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="rayon1"></param>
        /// <param name="rayon2"></param>
        /// <returns></returns>
        public virtual int CreerEllipse(int positionX, int positionY, int rayon1, int rayon2)
        {
            Ellipse f = new Ellipse(new Point(positionX, positionY), rayon1, rayon2);
            this.Canvas.Formes.Add(f);
            IMode.instance.Logger(f.Type + " " + f.ID + " : Création effectuée.", ConsoleColor.Green);
            return f.ID;
        }

        /// <summary>
        /// Permet de créer un texte.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="taillePolice"></param>
        /// <param name="contenu"></param>
        /// <returns></returns>
        public virtual int CreerTexte(int positionX, int positionY, int taillePolice, string contenu)
        {
            Texte f = new Texte(new Point(positionX, positionY), taillePolice, contenu);
            this.Canvas.Formes.Add(f);
            IMode.instance.Logger(f.Type + " " + f.ID + " : Création effectuée.", ConsoleColor.Green);
            return f.ID;
        }

        /// <summary>
        /// Permet de créer une image.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="imageName"></param>
        /// <returns></returns>
        public virtual int CreerImage(int positionX, int positionY, string imageName)
        {
            Forme f = new Formes.Image(new Point(positionX, positionY), imageName);
            this.Canvas.Formes.Add(f);
            IMode.instance.Logger(f.Type + " " + f.ID + " : Création effectuée.", ConsoleColor.Green);
            return f.ID;
        }
        #endregion

        #region Forme Methodes
        /// <summary>
        /// Permet créer une forme, image, texte à partir de l'id d'un objet existant.
        /// </summary>
        /// <param name="idForme"></param>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <returns></returns>
        public virtual int DupliquerForme(int idForme, int positionX, int positionY)
        {
            Forme f = IdentifierForme(idForme);
            if( f != null)
            {
                return f.Dupliquer(positionX, positionY).ID;
            }
            else
            {
                return -1;
            }          
        }

        /// <summary>
        /// Permet de colorier une forme.
        /// </summary>
        /// <param name="idForme"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        public virtual void ColorierForme(int idForme, int r, int g, int b)
        {
            Forme f = IdentifierForme(idForme);
            if (f != null)
            {
                f.Colorier(r, g, b);
            }
        }

        /// <summary>
        /// Permet de tourner une forme.
        /// </summary>
        /// <param name="idForme"></param>
        /// <param name="angle">En degrées</param>
        public virtual void TournerForme(int idForme, int angle)
        {
            Forme f = IdentifierForme(idForme);
            if (f != null)
            {
                f.Tourner(angle);
            }
        }

        /// <summary>
        /// Permet de déplacer une forme.
        /// </summary>
        /// <param name="idForme"></param>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        public virtual void DeplacerForme(int idForme, int positionX, int positionY)
        {
            Forme f = IdentifierForme(idForme);
            if (f != null)
            {
                f.Deplacer(positionX, positionY);
            }
        }

        /// <summary>
        /// Permet de changer la taille d'une forme.
        /// </summary>
        /// <param name="idForme"></param>
        /// <param name="taille">Facteur d'agrandissement (entre 0 et l'infini)</param>
        public virtual void DimensionnerForme(int idForme, float taille)
        {
            Forme f = IdentifierForme(idForme);
            if (f != null)
            {
                f.Dimensionner(taille);
            }
        }

        /// <summary>
        /// Permet de supprimer une forme.
        /// </summary>
        /// <param name="idForme"></param>
        public virtual void SupprimerForme(int idForme)
        {
            Forme f = IdentifierForme(idForme);
            if (f != null)
            {
                f.Supprimer();
            }
        }
        #endregion

        #region Stylo

        /// <summary>
        /// Permet d'arreter l'écriture avec le stylo et de créer la forme en même temps.
        /// </summary>
        /// <returns></returns>
        public virtual int LeverStylo()
        {
            try{
                return this.Stylo.LeverStylo().ID;
            }
            catch
            {
                return -1;
            }            
        }

        /// <summary>
        /// Permet de commencer l'écriture avec le stylo.
        /// </summary>
        public virtual void DescendreStylo()
        {
            this.Stylo.DescendreStylo();
        }

        /// <summary>
        /// Permet de faire avancer le stylo pendant la phase d'écriture.
        /// </summary>
        /// <param name="pas"></param>
        public virtual void AvancerStylo(int pas)
        {
            this.Stylo.Avancer(pas);
        }

        /// <summary>
        /// Permet de tourner le stylo pendant la phase d'écriture.
        /// </summary>
        /// <param name="angle"></param>
        public virtual void TournerStylo(int angle)
        {
            this.Stylo.Tourner(angle);
        }

        /// <summary>
        /// Permet de déplacer le stylo en dehors de la phase d'écriture.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        public virtual void DeplacerStylo(int positionX, int positionY)
        {
            this.Stylo.Deplacer(positionX, positionY);
        }

        /// <summary>
        /// Permet de changer la couleur du stylo.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        public virtual void ColorierStylo(int r, int g, int b)
        {
            this.Stylo.Couleur = Color.FromArgb(r, g, b);
        }

        #endregion

        /// <summary>
        /// Retourne une forme a partir de son id. Retourne null si la forme correspondante n'a pas été trouvée.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal protected virtual Forme IdentifierForme(int id)
        {
            foreach (Forme f in this.Canvas.Formes) {
                if (f.ID == id)
                {
                    return f;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            IMode.instance.Logger("L'id donné: " + id + " ne correspond a aucune Forme dans le Canvas!", ConsoleColor.Red);
            Console.ResetColor();
            return null;
        }

    }
}
