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
            Polygone f = new Polygone(new Point(positionX, positionY));
            f.SetRectangle(taille, taille);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f;
        }

        public virtual Forme CreerRectangle(int positionX, int positionY, int largeur, int hauteur )
        {
            Polygone f = new Polygone(new Point(positionX, positionY));
            f.SetRectangle(largeur, hauteur);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f;
        }

        public virtual Forme CreerTriangle(int positionX, int positionY, int taille)
        {
            Polygone f = new Polygone(new Point(positionX, positionY));
            f.SetTriangle(taille);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f;
        }

        public virtual Forme CreerLosange(int positionX, int positionY, int largeur, int hauteur)
        {
            Polygone f = new Polygone(new Point(positionX, positionY));
            f.SetLosange(largeur, hauteur);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f;
        }

        public virtual Forme CreerEtoile(int positionX, int positionY,int rayonInterieur, int rayonExterieur, int nbSommet)
        {
            Polygone f = new Polygone(new Point(positionX, positionY));
            f.SetEtoile(rayonInterieur / 2, rayonExterieur / 2, nbSommet);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f;
        }
        
        //TODO : La forme ne s'affiche pas lorsquelle est centrée sur le canvas avec un rayon de 20000
        public virtual Forme CreerCercle(int positionX, int positionY, int rayon)
        {
            Forme f = new Ellipse(new Point(positionX, positionY), rayon, rayon);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f;
        }
        
        //TODO : La forme ne s'affiche pas lorsquelle est centrée sur le canvas avec un rayon1 de 50000 et rayon2 de 80000
        public virtual Forme CreerEllipse(int positionX, int positionY, int rayon1, int rayon2)
        {
            Forme f = new Ellipse(new Point(positionX, positionY), rayon1, rayon2); // TODO : renommer ellipse "p"
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f;
        }

        public virtual Forme CreerTexte(int positionX, int positionY, int taillePolice, string contenu)
        {
            Forme f = new Texte(new Point(positionX, positionY), taillePolice, contenu);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f;
        }

        public virtual Forme CreerImage(int positionX, int positionY, string imageName)
        {
            Forme f = new Formes.Image(new Point(positionX, positionY), imageName);
            Canvas.Formes.Add(f);
            Console.WriteLine(f.Type + " " + f.ID + " : Création effectuée.");
            return f;
        }
    }
}
