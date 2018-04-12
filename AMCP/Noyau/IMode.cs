using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using AMCP.InterfaceUtilisateur;
using AMCP.Formes;

namespace AMCP.Noyau
{
    public abstract class IMode
    {
        private static IMode instance;
        protected Canvas Canvas { get; set; } 
        protected bool HistoriqueActions { get; set; } 
        public Stylo Stylo { get; set; } 

        public IMode()
        {
            if(instance == null)
            {
                instance = this;
                this.Canvas = new Canvas(1200, 700);
                this.Stylo = new Stylo();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Impossible de créer plusieurs instances de type Mode !");
                Console.ResetColor();
            }
        }

        public void ListerFonction()
        {

        }

        public void ListerContributeur()
        {
            Console.Clear();
            Console.WriteLine("////////////////// AMCP //////////////////");
            Console.WriteLine("-------- Analyse fonctionnelle -----------");
            Console.WriteLine("-------------- Conception ----------------");
            Console.WriteLine("------------- Développement --------------");
            Console.WriteLine("---------- Assurance Qualitée ------------");
        }

        public void ChangerDimension(int x, int y)
        {
            Canvas.instance.Size = new Size(x, y);
            Canvas.instance.Graphic = Canvas.instance.CreateGraphics();
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
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadLine();
        }

    }
}
