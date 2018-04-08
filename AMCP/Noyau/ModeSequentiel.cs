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
        public virtual int CreerCarre(int positionX, int positionY, int taille)
        {
            Polygone p = new Polygone();
            p.SetRectangle(new Point(positionX, positionY), taille, taille);
            Canvas.Formes.Add(p);
            Console.WriteLine("Le carré " + p.ID +  " a été crée.");
            return p.ID;
        }

        public virtual int CreerRectangle(int positionX, int positionY, int largeur, int hauteur)
        {
            Polygone p = new Polygone();
            p.SetRectangle(new Point(positionX, positionY), largeur, hauteur);
            Canvas.Formes.Add(p);
            Console.WriteLine("Le rectangle " + p.ID + " a été crée.");
            return p.ID;
        }

        public virtual int CreerCercle(int positionX, int positionY, int rayon)
        {
            Ellipse p = new Ellipse(new Point(positionX, positionY), rayon, rayon); // TODO : renommer ellipse "p"
            Canvas.Formes.Add(p);
            Console.WriteLine("Le cercle " + p.ID + " a été crée.");
            return p.ID;
        }

        public virtual int CreerTriangle(int positionX, int positionY, int taille)
        {
            Polygone p = new Polygone();
            p.SetTriangle(new Point(positionX, positionY), taille);
            Console.WriteLine("Le triangle " + p.ID + " a été crée.");
            Canvas.Formes.Add(p);
            return p.ID;
        }

        public virtual int CreerLosange(int positionX, int positionY, int largeur, int hauteur)
        {
            Polygone p = new Polygone();
            p.SetLosange(new Point(positionX, positionY), largeur, hauteur);
            Console.WriteLine("Le losange " + p.ID + " a été crée.");
            Canvas.Formes.Add(p);
            return p.ID;           
        }

        public virtual int CreerEtoile(int positionX, int positionY, int rayonInterieur, int rayonExterieur, int nbSommet)
        {
            Polygone p = new Polygone();
            p.SetEtoile(new Point(positionX, positionY), rayonInterieur/2, rayonExterieur/2, nbSommet);
            Canvas.Formes.Add(p);
            Console.WriteLine("L'étoile " + p.ID + " a été créee.");
            return p.ID;
        }

        public virtual int CreerEllipse(int positionX, int positionY, int rayon1, int rayon2)
        {
            Ellipse p = new Ellipse(new Point(positionX, positionY), rayon1, rayon2); // TODO : renommer ellipse "p"
            Canvas.Formes.Add(p);
            Console.WriteLine("L'ellipse " + p.ID + " a été créee.");
            return p.ID;
        }

        public virtual int CreerTexte(int positionX, int positionY, int taillePolice, string contenu)
        {
            Texte t = new Texte(new Point(positionX, positionY), taillePolice, contenu);
            Canvas.Formes.Add(t);
            Console.WriteLine("Le texte " + t.ID + " a été crée.");
            return t.ID;

        }

        public virtual int Dupliquer(int idForme, int positionX, int positionY)
        {
            Forme origin = IdentifierForme(idForme);
            if (origin != null)
            {
                Forme copy = origin.Dupliquer(positionX, positionY);
                return copy.ID;
            }else
            {
                return -1;
            }
        }

        public virtual void Colorier(int idForme, int r, int g, int b)
        {
            Forme f = IdentifierForme(idForme);
            if (f != null)
            {
                f.Colorier(r, g, b);
            }

        }
        
        public virtual void Tourner(int idForme, int angle)
        {
            if(IdentifierForme(idForme) is Polygone)
            {
                ((Polygone)IdentifierForme(idForme)).Tourner(angle);
            }
            else if (IdentifierForme(idForme) is Ellipse)
            {
                ((Ellipse)IdentifierForme(idForme)).Tourner(angle);
            }
        }

        public virtual void Deplacer(int idForme, int positionX, int positionY)
        {
            if (IdentifierForme(idForme) is Polygone)
            {
                ((Polygone)IdentifierForme(idForme)).Deplacer(positionX,positionY);
            }
            else if (IdentifierForme(idForme) is Ellipse)
            {
                ((Ellipse)IdentifierForme(idForme)).Deplacer(positionX,positionY);
            }

        }

        public virtual void Dimensionner(int idForme, float taille)
        {
            if (IdentifierForme(idForme) is Polygone)
            {
                ((Polygone)IdentifierForme(idForme)).Dimensionner(taille);
            }
            else if (IdentifierForme(idForme) is Ellipse)
            {
                ((Ellipse)IdentifierForme(idForme)).Dimensionner(taille);
            }

        }

        ///<summary>
        /// Retourne une forme a partir de son id. Retourne null si la forme correspondante n'a pas été trouvée.
        ///</summary>
        protected virtual Forme IdentifierForme(int id)
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
