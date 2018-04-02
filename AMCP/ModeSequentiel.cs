using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCP
{
    public class ModeSequentiel : IMode
    {
        public virtual int DessinerCarre(int positionX, int positionY, int taille)
        {
            Polygone p = new Polygone();
            if (!p.EstDehors(positionX, positionY, taille, taille))
            {
                p.SetRectangle(new Point(positionX, positionY), taille, taille);
                Canvas.Formes.Add(p);
                Console.WriteLine("Le carré " + p.GetId() +  " a été dessiné.");
                return p.GetId();
            }
            else
            {
                Console.WriteLine("Le carré est hors du canvas.");
                return -1;
            }
        }

        public virtual int DessinerRectangle(int positionX, int positionY, int largeur, int hauteur)
        {
            Polygone p = new Polygone();
            if (!p.EstDehors(positionX, positionY, largeur, hauteur))
            {
                p.SetRectangle(new Point(positionX, positionY), largeur, hauteur);
                Canvas.Formes.Add(p);
                Console.WriteLine("Le rectangle " + p.GetId() + " a été dessiné.");
                return p.GetId();
            }
            else
            {
                Console.WriteLine("Le rectangle est hors du canvas.");
                return -1;
            }
        }

        public virtual int DessinerCercle(int positionX, int positionY, int rayon)
        {
            Ellipse p = new Ellipse(new Point(positionX, positionY), rayon, rayon);
            if (!p.EstDehors(positionX, positionY, rayon, rayon))
            {
                Canvas.Formes.Add(p);
                Console.WriteLine("Le cercle " + p.GetId() + " a été dessinée.");
                return p.GetId();
            }
            else
            {
                Console.WriteLine("Le cercle " + p.GetId() + " est hors du canvas.");
                return -1;
            }
        }

        public virtual int DessinerTriangle(int positionX, int positionY, int taille)
        {
            Polygone p = new Polygone();
            if (!p.EstDehors(positionX, positionY, taille*2, taille*2))
            {
                p.SetTriangle(new Point(positionX, positionY), taille);
                Console.WriteLine("Le triangle " + p.GetId() + " a été dessiné.");
                Canvas.Formes.Add(p);
                return p.GetId();
            }
            else
            {
                Console.WriteLine("Le triangle est hors du canvas.");
                return -1;
            }
        }

        public virtual int DessinerLosange(int positionX, int positionY, int largeur, int hauteur)
        {
            Polygone p = new Polygone();
            if (!p.EstDehors(positionX, positionY, largeur, hauteur))
            {
                p.SetLosange(new Point(positionX, positionY), largeur, hauteur);
                Console.WriteLine("Le losange " + p.GetId() + " a été dessiné.");
                Canvas.Formes.Add(p);
                return p.GetId();
            }
            else
            {
                Console.WriteLine("Le losange est hors du canvas.");
                return -1;
            }
        }

        public virtual int DessinerEtoile(int positionX, int positionY, int rayonInterieur, int rayonExterieur, int nbSommet)
        {
            Polygone p = new Polygone();
            if (!p.EstDehors(positionX, positionY, rayonExterieur/2, rayonExterieur))
            {
                p.SetEtoile(new Point(positionX, positionY), rayonInterieur/2, rayonExterieur/2, nbSommet);
                Canvas.Formes.Add(p);
                Console.WriteLine("L'étoile " + p.GetId() + " a été dessinée.");
                return p.GetId();
            }
            else
            {
                Console.WriteLine("L'étoile est hors du canvas.");
                return -1;
            }
        }

        public virtual int DessinerEllipse(int positionX, int positionY, int rayon1, int rayon2)
        {
            Ellipse p = new Ellipse(new Point(positionX, positionY), rayon1, rayon2);
            if (!p.EstDehors(positionX, positionY, rayon1, rayon2 / 2))
            {
                Canvas.Formes.Add(p);
                Console.WriteLine("L'ellipse " + p.GetId() + " a été dessinée.");
                return p.GetId();
            }
            else
            {
                Console.WriteLine("L'ellipse est hors du canvas.");
                return -1;
            }
        }

        public virtual int Dupliquer(int idForme, int positionX, int positionY)
        {
            Forme origin = IdentifierForme(idForme);
            if (origin != null)
            {
                Forme copy = origin.Dupliquer(positionX, positionY);
                return copy.GetId();
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
            if(Canvas.Formes[idForme] is Polygone)
            {
                ((Polygone)Canvas.Formes[idForme]).Tourner(angle);
            }
            else if (Canvas.Formes[idForme] is Ellipse)
            {

            }
        }

        public virtual void Deplacer(int idForme, int positionX, int positionY)
        {
            Console.WriteLine(Canvas.Formes[idForme].GetType());
            Canvas.Formes[idForme].Position = new Point(positionX, positionY);
        }

        public virtual void Dimensionner(int idForme, float taille)
        {

        }

        public virtual Boolean EstDehors(float positionX, float positionY, float coteX, float coteY)
        {
            if (positionX - coteX / 2 < 0 
                || positionX + coteX / 2 > Canvas.Graphic.VisibleClipBounds.Width 
                || positionY - coteY / 2 < 0 
                || positionY + coteY / 2 > Canvas.Graphic.VisibleClipBounds.Height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        ///<summary>
        /// Retourne une forme a partir de son id. Retourne null si la forme correspondante n'a pas été trouvée.
        ///</summary>
        protected virtual Forme IdentifierForme(int id)
        {
            foreach (Forme f in Canvas.Formes) {
                if (f.GetId() == id)
                {
                    return f;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("L'id donné: " + id + " ne correspond a aucune Forme dans le Canvas!");
            Console.ResetColor();
            throw new Exception("L'id donné: " + id + " ne correspond a aucune Forme dans le Canvas!");
        }

    }
}
