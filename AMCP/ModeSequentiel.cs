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

        public int DessinerRectangle(int positionX, int positionY, int largeur, int hauteur)
        {
            Polygone p = new Polygone();
            if (!EstDehors(positionX, positionY, largeur, hauteur))
            {
                p.SetRectangle(new Point(positionX, positionY), largeur, hauteur);
                Canvas.Formes.Add(p);
                return Canvas.Formes.IndexOf(p);
            }
            else return -1;
        }

        public int DessinerCercle(int positionX, int positionY, int rayon)
        {
            if (!EstDehors(positionX, positionY, rayon, rayon))
            {
                Ellipse p = new Ellipse(new Point(positionX, positionY), rayon, rayon); // TODO : une ellipse "p" ? à renommer 
                Canvas.Formes.Add(p);
                return Canvas.Formes.IndexOf(p);
            }
            else return -1;
        }

        public int DessinerTriangle(int positionX, int positionY, int taille)
        {
            Polygone p = new Polygone();
            p.SetTriangle(new Point(positionX, positionY), taille);
            Canvas.Formes.Add(p);
            return Canvas.Formes.IndexOf(p);
        }

        public int DessinerLosange(int positionX, int positionY, int largeur, int hauteur)
        {
            Polygone p = new Polygone();
            if (!EstDehors(positionX, positionY, largeur, hauteur))
            {
                p.SetLosange(new Point(positionX, positionY), largeur, hauteur);
                Canvas.Formes.Add(p);
                return Canvas.Formes.IndexOf(p);
            }
            else
            {
                Console.WriteLine("Le losange est hors du canvas.");
                return -1;
            }
        }

        public int DessinerEtoile(int positionX, int positionY, int rayonInterieur, int rayonExterieur, int nbSommet)
        {
            Polygone p = new Polygone();
            if (!EstDehors(positionX, positionY, rayonExterieur, rayonExterieur / 2))
            {
                p.SetEtoile(new Point(positionX, positionY), rayonInterieur, rayonExterieur, nbSommet);
                Canvas.Formes.Add(p);
                return Canvas.Formes.IndexOf(p);
            }
            else return -1;
        }

        public int DessinerEllipse(int positionX, int positionY, int rayon1, int rayon2)
        {
            Ellipse p = new Ellipse(new Point(positionX, positionY), rayon1, rayon2);
            if (!EstDehors(positionX, positionY, rayon1, rayon2 / 2))
            {
                Canvas.Formes.Add(p);
                return Canvas.Formes.IndexOf(p);
            }
            else return -1;
        }

        public int Dupliquer(int idForme, int positionX, int positionY)
        {
            return 0;
        }

        public void Colorier(int idForme, int r, int g, int b)
        {

        }
        
        public void Tourner(int idForme, int angle)
        {
            if(Canvas.Formes[idForme] is Polygone)
            {
                ((Polygone)Canvas.Formes[idForme]).Tourner(angle);
            }
            else if (Canvas.Formes[idForme] is Ellipse)
            {

            }
        }

        public void Deplacer(int idForme, int positionX, int positionY)
        {

        }

        public void Dimensionner(int idForme, float taille)
        {

        }

        public Boolean EstDehors(float positionX, float positionY, float coteX, float coteY)
        {
            Console.WriteLine(Canvas.Graphic.VisibleClipBounds);

            if (positionX - coteX / 2 < 0 || positionX + coteX / 2 > Canvas.Graphic.VisibleClipBounds.Width || positionY - coteY / 2 < 0 || positionY + coteY / 2 > Canvas.Graphic.VisibleClipBounds.Height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
