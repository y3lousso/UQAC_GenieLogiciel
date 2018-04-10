using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCP
{
    public class ModeOrienteObjet : IMode
    {
        /// <summary>
        /// Permet de dessiner un carré en prennant comme origine l'arrete supérieure gauche du carré.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="taille"></param>
        public virtual Polygone DessinerCarre(int positionX, int positionY, int taille)
        {
            Polygone p = new Polygone();
            p.SetRectangle(new Point(positionX, positionY), taille, taille);
            if (!p.EstDehors(positionX, positionY, taille, taille))
            {
                p.SetRectangle(new Point(positionX, positionY), taille, taille);
                Canvas.Formes.Add(p);
                Console.WriteLine("Le carré a été dessiné.");
                return p;
            }
            else
            {
                Console.WriteLine("Le carré est hors du canvas.");
                return null;
            }
        }

        public virtual  Polygone DessinerRectangle(int positionX, int positionY, int largeur, int hauteur )
        {
            Polygone p = new Polygone();
            if (!p.EstDehors(positionX, positionY, largeur, hauteur))
            {
                p.SetRectangle(new Point(positionX, positionY), largeur, hauteur);
                Canvas.Formes.Add(p);
                Console.WriteLine("Le rectangle a été dessiné.");
                return p;
            }
            else
            {
                Console.WriteLine("Le rectangle est hors du canvas.");
                return null;
            }
        }

        public virtual Ellipse DessinerCercle(int positionX, int positionY, int rayon)
        {
            Ellipse p = new Ellipse(new Point(positionX, positionY), rayon, rayon); // TODO : renommer ellipse "p"
            if (!p.EstDehors(positionX, positionY, rayon, rayon))
            {
                Canvas.Formes.Add(p);
                return p;
            }
            else
            {
                Console.WriteLine("Le cercle est hors du canvas.");
                return null;
            }
        }

        public virtual Polygone DessinerTriangle(int positionX, int positionY, int taille)
        {
            Polygone p = new Polygone();
            if (!p.EstDehors(positionX, positionY, taille * 2, taille * 2))
            {
                p.SetTriangle(new Point(positionX, positionY), taille);
                Canvas.Formes.Add(p);
                Console.WriteLine("Le triangle a été dessiné.");
                return p;
            }
            else
            {
                Console.WriteLine("Le triangle est hors du canvas.");
                return null;
            }
        }

        public virtual Polygone DessinerLosange(int positionX, int positionY, int largeur, int hauteur)
        {
            Polygone p = new Polygone();
            if (!p.EstDehors(positionX, positionY, largeur, hauteur))
            {
                p.SetLosange(new Point(positionX, positionY), largeur, hauteur);
                Canvas.Formes.Add(p);
                Console.WriteLine("Le losange a été dessiné.");
                return p;
            }
            else
            {
                Console.WriteLine("Le losange est hors du canvas.");
                return null;
            }
        }

        public virtual Polygone DessinerEtoile(int positionX, int positionY,int rayonInterieur, int rayonExterieur, int nbSommet)
        {
            Polygone p = new Polygone();
            if (!p.EstDehors(positionX, positionY, rayonExterieur / 2, rayonExterieur))
            {
                p.SetEtoile(new Point(positionX, positionY), rayonInterieur / 2, rayonExterieur / 2, nbSommet);
                Canvas.Formes.Add(p);
                Console.WriteLine("l'étoile a été dessinée.");
                return p;
            }
            else
            {
                Console.WriteLine("L'étoile est hors du canvas.");
                return null;
            }
        }

        public virtual Ellipse DessinerEllipse(int positionX, int positionY, int rayon1, int rayon2)
        {
            Ellipse p = new Ellipse(new Point(positionX, positionY), rayon1, rayon2); // TODO : renommer ellipse "p"
            if (!p.EstDehors(positionX, positionY, rayon1, rayon2 / 2))
            {
                Canvas.Formes.Add(p);
                return p;
            }
            else
            {
                Console.WriteLine("L'ellipse est hors du canvas.");
                return null;
            }
        }

    }
}
