using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCP
{
    // TODO : Refactor to InterfaceSequentielle
    public class InterfaceSequencielle : IMode
    {

        public int DessinerRectangle(int positionX, int positionY, int largeur, int hauteur)
        {
            Polygone p = new Polygone();
            p.SetRectangle(new Point(positionX, positionY), largeur, hauteur);
            Canvas.Formes.Add(p);
            return Canvas.Formes.IndexOf(p);
        }

        public int DessinerCercle(int positionX, int positionY, int rayon)
        {
            Ellipse p = new Ellipse(new Point(positionX, positionY), rayon, rayon);
            Canvas.Formes.Add(p);
            return Canvas.Formes.IndexOf(p);
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
            p.SetLosange(new Point(positionX, positionY), largeur, hauteur);
            Canvas.Formes.Add(p);
            return Canvas.Formes.IndexOf(p);
        }

        public int DessinerEtoile(int positionX, int positionY, int rayonInterieur, int rayonExterieur, int nbSommet)
        {
            Polygone p = new Polygone();
            p.SetEtoile(new Point(positionX, positionY), rayonInterieur, rayonExterieur, nbSommet);
            Canvas.Formes.Add(p);
            return Canvas.Formes.IndexOf(p);
        }

        public int DessinerEllipse(int positionX, int positionY, int rayon1, int rayon2)
        {
            Ellipse p = new Ellipse(new Point(positionX, positionY), rayon1, rayon2);
            Canvas.Formes.Add(p);
            return Canvas.Formes.IndexOf(p);
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
    }
}
