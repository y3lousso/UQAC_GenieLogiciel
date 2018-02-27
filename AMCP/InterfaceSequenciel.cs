using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCP
{
    public class InterfaceSequenciel : IMode
    {
        public int DessinerCarre(int positionX, int positionY, int taille)
        {
            Rectangle r = new Rectangle(new Vector2(positionX, positionY), taille, taille);
            Canvas.Formes.Add(r);
            Canvas.Graphic.DrawRectangle(new Pen(Color.Black), positionX, positionY, taille, taille);
            Console.WriteLine("Un carré a été dessiné.");
            return Canvas.Formes.IndexOf(r);
        }

        public int DessinerRectangle(int positionX, int positionY, int largeur, int hauteur)
        {
            Vector2 position = new Vector2(positionX, positionY);
            Rectangle r = new Rectangle(position, largeur, hauteur);
            Canvas.Formes.Add(r);
            Canvas.Graphic.DrawRectangle(new Pen(Color.Black), position.X, position.Y, largeur, hauteur);
            Console.WriteLine("Un rectangle a été dessiné.");
            return Canvas.Formes.IndexOf(r);
        }

        public int DessinerCercle(int positionX, int positionY, int rayon)
        {
            Cercle c = new Cercle(new Vector2(positionX, positionY), rayon);
            Canvas.Formes.Add(c);
            Canvas.Graphic.DrawEllipse(new Pen(Color.Black), positionX, positionY, rayon, rayon);
            Console.WriteLine("Un cercle a été dessiné.");
            return Canvas.Formes.IndexOf(c);
        }

        public int DessinerTriangle(int positionX, int positionY, int taille)
        {
            return 0;
        }

        public int DessinerLosange(int positionX, int positionY, int largeur, int hauteur)
        {
            return 0;
        }

        public int DessinerEtoile(int positionX, int positionY, int taille, int nbSommet)
        {
            return 0;
        }

        public int DessinerEllipse(int positionX, int positionY, int rayon1, int rayon2)
        {
            Ellipse e = new Ellipse(new Vector2(positionX, positionY), rayon1, rayon2);
            Canvas.Formes.Add(e);
            Canvas.Graphic.DrawEllipse(new Pen(Color.Black), positionX, positionY, rayon1, rayon2);
            Console.WriteLine("Une éllipse a été dessiné.");
            return Canvas.Formes.IndexOf(e);
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

        }

        public void Deplacer(int idForme, int positionX, int positionY)
        {

        }

        public void Dimensionner(int idForme, float taille)
        {

        }
    }
}
