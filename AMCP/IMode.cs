using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace AMCP
{
    public abstract class IMode
    {
        private static IMode instance;
        protected Canvas Canvas { get; set; } //Les variables protected sont en Camel
        protected bool HistoriqueActions { get; set; }  //Les variables protected sont en Camel
        public Pointeur Pointeur { get; set; } 

        public IMode()
        {
            if(instance == null)
            {
                instance = this;
                Canvas = new Canvas(1280, 720);
                Pointeur = new Pointeur();
            }
            else
            {
                throw new Exception("Can't create multiple instance of IMode");
            }
        }

        public void ListerFonction()
        {

        }

        public void ListerContributeur()
        {

        }

        public void IdentifierForme(int id)
        {

        }

        public void ChargerImage(string chemin, int positionX, int positionY)
        {

        }

        public void ChangerDimension(int tailleX, int tailleY)
        {
            Canvas.Size = new Size(tailleX, tailleY);
            //Canvas.Update();
        }

        /// <summary>
        /// Permet d'afficher toutes les formes précédements créer. Le paramètre d'entrée permet d'ajouter une pause entre l'affichage de chaque forme. (en millisecondes)
        /// </summary>
        /// <param name="pasDeTemps"></param>
        public virtual void Afficher(int pasDeTemps = 0)
        {
            foreach(Forme f in Canvas.Formes)
            {             
                System.Windows.Forms.Application.DoEvents();
                f.Afficher();
                Thread.Sleep(pasDeTemps);
            }        
        }

        public virtual void AfficherTout(int pasDeTemps = 0)
        {
            foreach(Forme f in Canvas.Formes)
            {             
                System.Windows.Forms.Application.DoEvents();
                f.Afficher();               
            }
            Thread.Sleep(pasDeTemps);
        }

        public virtual void NettoyerEcran()
        {
            Canvas.instance.Graphic.Clear(Color.White);
        }

        public virtual void Pause()
        {
            Console.WriteLine("Press any key to continue ...");
            Console.ReadLine();
            Console.WriteLine("Starting");
        }

    }
}
