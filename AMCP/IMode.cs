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
        protected Canvas Canvas { get; set; } // TODO : Les variables protected sont en Camel
        protected bool HistoriqueActions { get; set; }  // TODO : Les variables protected sont en Camel
        public Stylo Stylo { get; set; } 

        public IMode()
        {
            if(instance == null)
            {
                instance = this;
                this.Canvas = new Canvas(1280, 720);
                this.Stylo = new Stylo();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Impossible de créer plusieurs instances de IMode!");
                Console.ResetColor();
            }
        }

        public void ListerFonction()
        {

        }

        public void ListerContributeur()
        {

        }

        public void ChargerImage(string chemin, int positionX, int positionY)
        {

        }

        /// <summary>
        /// Permet d'afficher toutes les formes précédements créer.
        /// </summary>
        public virtual void Afficher()
        {
            foreach (Forme f in this.Canvas.Formes)
            {
                f.Afficher();
            }
        }

        /// <summary>
        /// Permet d'afficher toutes les formes précédements créer avec une pause entre chaque.
        /// </summary>
        /// <param name="pasDeTemps"></param>
        public virtual void Afficher(int temps)
        {
            foreach(Forme f in this.Canvas.Formes)
            {             
                System.Windows.Forms.Application.DoEvents();
                f.Afficher();
                Thread.Sleep((int)(temps * 1000));
            }        
        }

        /// <summary>
        /// Permet d'attendre X secondes.
        /// </summary>
        /// <param name="temps"></param>
        public virtual void Attendre(float temps)
        {
            Thread.Sleep((int)(temps * 1000));
        }

        /// <summary>
        /// Permet d'enlever tous les dessins de l'écran.
        /// </summary>
        public virtual void NettoyerEcran()
        {
            this.Canvas.Graphic.Clear(Color.White);
        }

        /// <summary>
        /// Permet de mettre en pause l'execution du programme, appuyez sur une touche pour relancer.
        /// </summary>
        public virtual void Pause()
        {
            Console.WriteLine("Press any key to continue ...");
            Console.ReadLine();
            Console.WriteLine("Starting");
        }

    }
}
