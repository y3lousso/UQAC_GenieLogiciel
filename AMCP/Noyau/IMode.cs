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
        
        protected IMode()
        {
            if(instance == null)
            {
                instance = this;
                this.Canvas = new Canvas(1200, 700);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Impossible de créer plusieurs instances de type Mode !");
                Console.ResetColor();
            }
        }

        public abstract void ListerFonctions();

        /// <summary>
        /// Permet de lister les noms de tous les contributeurs de cette application.
        /// </summary>
        public void ListerContributeurs()
        {
            Console.Clear();
            Console.WriteLine("////////////////// AMCP //////////////////");
            Console.WriteLine("-------- Analyse fonctionnelle -----------");
            Console.WriteLine("BERTHET Maxime");
            Console.WriteLine("DELEMOTTE David");
            Console.WriteLine("FALLON Blandine");
            Console.WriteLine("JOLY Corentin");
            Console.WriteLine("MARTIN Gaetan");
            Console.WriteLine("MAROUN Marc-Yves");
            Console.WriteLine("MORICE Renald");
            Console.WriteLine("-------------- Conception ----------------");
            Console.WriteLine("ESSIMMOU Assil");
            Console.WriteLine("GALL Antoine");
            Console.WriteLine("LARGE Erwann");
            Console.WriteLine("LASCHKAR Benjamin");
            Console.WriteLine("LEBLEU Anthony");
            Console.WriteLine("RIEUF Ianis");
            Console.WriteLine("SAKHI Faical");
            Console.WriteLine("------------- Développement --------------");
            Console.WriteLine("LOUSSOUARN Yannick");
            Console.WriteLine("MANZANILLA Francis Andre");
            Console.WriteLine("NGOY-WESSESSI Brice Cesar");
            Console.WriteLine("RAZAFINDRAHAINGO Iry Fanevan'ny Aina");
            Console.WriteLine("RIVAULT Nicolas");
            Console.WriteLine("RYCKAERT Guillaume");
            Console.WriteLine("SANOU Yves Patrick Albert");
            Console.WriteLine("---------- Assurance Qualitée ------------");
            Console.WriteLine("BATTISTON Aurelie");
            Console.WriteLine("COMBETTE Elise");
            Console.WriteLine("LE BAIL Loick");
            Console.WriteLine("LUCE-LUCAS Mathilde");
            Console.WriteLine("MESNY Alexandre");
            Console.WriteLine("VANMARCKE Romain");            
        }

        /// <summary>
        /// Permet de changer la dimension de la zone de dessin. (Canvas)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void ChangerDimension(int x, int y)
        {
            Canvas.instance.Size = new Size(x, y);
            Canvas.instance.Graphic = Canvas.instance.CreateGraphics();
        }

        /// <summary>
        /// Permet d'afficher toutes les formes précédements créées.
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
            this.Canvas.NettoyerCanvas();
        }

        /// <summary>
        /// Permet d'enlever toutes les formes précédement créées en mémoire.
        /// </summary>
        public virtual void ReinitialiserCanvas()
        {
            this.Canvas.Formes.Clear();
            NettoyerEcran();
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
