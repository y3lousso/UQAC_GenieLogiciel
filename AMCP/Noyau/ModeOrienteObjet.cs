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
        /// Permet de dessiner un carré en prennant comme origine l'arrete supérieure gauche du carré.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="taille"></param>
        public virtual Forme CreerCarre(int positionX, int positionY, int taille)
        {
            Polygone p = new Polygone();
            p.SetRectangle(new Point(positionX, positionY), taille, taille);
            p.SetRectangle(new Point(positionX, positionY), taille, taille);
            Canvas.Formes.Add(p);
            Console.WriteLine("Le carré a été crée.");
            return p;
        }

        public virtual Forme CreerRectangle(int positionX, int positionY, int largeur, int hauteur )
        {
            Polygone p = new Polygone();
            p.SetRectangle(new Point(positionX, positionY), largeur, hauteur);
            Canvas.Formes.Add(p);
            Console.WriteLine("Le rectangle a été crée.");
            return p;
        }

        public virtual Forme CreerCercle(int positionX, int positionY, int rayon)
        {
            Ellipse p = new Ellipse(new Point(positionX, positionY), rayon, rayon); // TODO : renommer ellipse "p"
            Canvas.Formes.Add(p);
            return p;
        }

        public virtual Forme CreerTriangle(int positionX, int positionY, int taille)
        {
            Polygone p = new Polygone();
            p.SetTriangle(new Point(positionX, positionY), taille);
            Canvas.Formes.Add(p);
            Console.WriteLine("Le triangle a été crée.");
            return p;
        }

        public virtual Forme CreerLosange(int positionX, int positionY, int largeur, int hauteur)
        {
            Polygone p = new Polygone();
            p.SetLosange(new Point(positionX, positionY), largeur, hauteur);
            Canvas.Formes.Add(p);
            Console.WriteLine("Le losange a été crée.");
            return p;
        }

        public virtual Forme CreerEtoile(int positionX, int positionY,int rayonInterieur, int rayonExterieur, int nbSommet)
        {
            Polygone p = new Polygone();
            p.SetEtoile(new Point(positionX, positionY), rayonInterieur / 2, rayonExterieur / 2, nbSommet);
            Canvas.Formes.Add(p);
            Console.WriteLine("l'étoile a été crée.");
            return p;
        }

        public virtual Forme CreerEllipse(int positionX, int positionY, int rayon1, int rayon2)
        {
            Ellipse p = new Ellipse(new Point(positionX, positionY), rayon1, rayon2); // TODO : renommer ellipse "p"
            Canvas.Formes.Add(p);
            return p;
        }

        public virtual Forme CreerTexte(int positionX, int positionY, int taillePolice, string contenu)
        {
            Texte t = new Texte(new Point(positionX, positionY), taillePolice, contenu);
            Canvas.Formes.Add(t);
            Console.WriteLine("Le texte '" + t.Contenu +"' a été crée.");
            return t;          
        }
    }
}
