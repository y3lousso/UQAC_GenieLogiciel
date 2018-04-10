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
            Polygone f = new Polygone(new Point(positionX, positionY));
            f.SetRectangle(taille, taille);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f.ID;
        }

        public virtual int CreerRectangle(int positionX, int positionY, int largeur, int hauteur)
        {
            Polygone f = new Polygone(new Point(positionX, positionY));
            f.SetRectangle(largeur, hauteur);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f.ID;
        }
      
        public virtual int CreerTriangle(int positionX, int positionY, int taille)
        {
            Polygone f = new Polygone(new Point(positionX, positionY));
            f.SetTriangle(taille);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f.ID;
        }

        public virtual int CreerLosange(int positionX, int positionY, int largeur, int hauteur)
        {
            Polygone f = new Polygone(new Point(positionX, positionY));
            f.SetLosange(largeur, hauteur);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f.ID;
        }

        public virtual int CreerEtoile(int positionX, int positionY, int rayonInterieur, int rayonExterieur, int nbSommet)
        {
            Polygone f = new Polygone(new Point(positionX, positionY));
            f.SetEtoile(rayonInterieur/2, rayonExterieur/2, nbSommet);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f.ID;
        }
        
        //TODO : La forme ne s'affiche pas lorsquelle est centrée sur le canvas avec un rayon de 20000
        public virtual int CreerCercle(int positionX, int positionY, int rayon)
        {
            Ellipse f = new Ellipse(new Point(positionX, positionY), rayon, rayon); // TODO : renommer ellipse "p"
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f.ID;
        }
        
        //TODO : La forme ne s'affiche pas lorsquelle est centrée sur le canvas avec un rayon1 de 50000 et rayon2 de 80000
        public virtual int CreerEllipse(int positionX, int positionY, int rayon1, int rayon2)
        {
            Ellipse f = new Ellipse(new Point(positionX, positionY), rayon1, rayon2); // TODO : renommer ellipse "p"
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f.ID;
        }

        public virtual int CreerTexte(int positionX, int positionY, int taillePolice, string contenu)
        {
            Texte f = new Texte(new Point(positionX, positionY), taillePolice, contenu);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f.ID;
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
            IdentifierForme(idForme).Tourner(angle);
        }

        public virtual void Deplacer(int idForme, int positionX, int positionY)
        {
            IdentifierForme(idForme).Deplacer(positionX,positionY);
        }

        public virtual void Dimensionner(int idForme, float taille)
        {
            IdentifierForme(idForme).Dimensionner(taille);
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
