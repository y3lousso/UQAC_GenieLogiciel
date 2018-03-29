﻿using System;
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
            Canvas.Formes.Add(p);
            return p;
        }

        public virtual  Polygone DessinerRectangle(int positionX, int positionY, int largeur, int hauteur )
        {
            Polygone p = new Polygone();
            p.SetRectangle(new Point(positionX, positionY), largeur, hauteur);
            Canvas.Formes.Add(p);
            return p;
        }

        public virtual Ellipse DessinerCercle(int positionX, int positionY, int rayon)
        {
            Ellipse p = new Ellipse(new Point(positionX, positionY), rayon, rayon); // TODO : une ellipse "p" ?
            Canvas.Formes.Add(p);           
            return p;
        }

        public virtual Polygone DessinerTriangle(int positionX, int positionY, int taille)
        {
            Polygone p = new Polygone();
            p.SetTriangle(new Point(positionX, positionY), taille);
            Canvas.Formes.Add(p);
            return p;
        }

        public virtual Polygone DessinerLosange(int positionX, int positionY, int largeur, int hauteur)
        {
            Polygone p = new Polygone();
            p.SetLosange(new Point(positionX, positionY), largeur, hauteur);
            Canvas.Formes.Add(p);
            return p;
        }

        public virtual Polygone DessinerEtoile(int positionX, int positionY,int rayonInterieur, int rayonExterieur, int nbSommet)
        {
            Polygone p = new Polygone();
            p.SetEtoile(new Point(positionX, positionY), rayonInterieur, rayonExterieur, nbSommet);
            Canvas.Formes.Add(p);
            return p;
        }

        public virtual Ellipse DessinerEllipse(int positionX, int positionY, int rayon1, int rayon2)
        {
            Ellipse p = new Ellipse(new Point(positionX, positionY), rayon1, rayon2);
            Canvas.Formes.Add(p);
            return p;
        }

    }
}
