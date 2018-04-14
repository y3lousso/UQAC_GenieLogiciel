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
        #region Createurs

        /// <summary>
        /// Permets de lister toutes les fonctions disponibles dans ce mode.
        /// </summary>
        public override void ListerFonctions()
        {
            Console.WriteLine(">>>>>>>>>> Mode Séquentiel <<<<<<<<<<<");
        }

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
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
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
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
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
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
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
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
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
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
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
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
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
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
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
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
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
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
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
            return this.Stylo.LeverStylo().ID;
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
            foreach (Forme f in Canvas.Formes) {
                if (f.ID == id)
                {
                    return f;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("L'id donné: " + id + " ne correspond a aucune Forme dans le Canvas!");
            Console.ResetColor();
            return null;
        }

    }
}
