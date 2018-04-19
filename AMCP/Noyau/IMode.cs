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
        internal static IMode instance;
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
                Logger("Impossible de créer plusieurs instances de type Mode !", ConsoleColor.Red);
            }
        }

        public abstract void ListerFonctions();

        /// <summary>
        /// Permet de lister les noms de tous les contributeurs de cette application.
        /// </summary>
        public void ListerContributeurs()
        {
            Console.Clear();
            Logger("////////////////// AMCP //////////////////", ConsoleColor.White);
            Logger("-------- Analyse fonctionnelle -----------", ConsoleColor.Red);
            Logger("BERTHET Maxime" ,ConsoleColor.Gray);
            Logger("DELEMOTTE David" ,ConsoleColor.Gray);
            Logger("FALLON Blandine" ,ConsoleColor.Gray);
            Logger("JOLY Corentin" ,ConsoleColor.Gray);
            Logger("MARTIN Gaetan" ,ConsoleColor.Gray);
            Logger("MAROUN Marc-Yves" ,ConsoleColor.Gray);
            Logger("MORICE Renald" ,ConsoleColor.Gray);
            Logger("-------------- Conception ----------------" ,ConsoleColor.Yellow);
            Logger("ESSIMMOU Assil" ,ConsoleColor.Gray);
            Logger("GALL Antoine" ,ConsoleColor.Gray);
            Logger("LARGE Erwann" ,ConsoleColor.Gray);
            Logger("LASCHKAR Benjamin" ,ConsoleColor.Gray);
            Logger("LEBLEU Anthony" ,ConsoleColor.Gray);
            Logger("RIEUF Ianis" ,ConsoleColor.Gray);
            Logger("SAKHI Faical" ,ConsoleColor.Gray);
            Logger("------------- Développement --------------" ,ConsoleColor.Blue);
            Logger("LOUSSOUARN Yannick" ,ConsoleColor.Gray);
            Logger("MANZANILLA Francis Andre" ,ConsoleColor.Gray);
            Logger("NGOY-WESSESSI Brice Cesar" ,ConsoleColor.Gray);
            Logger("RAZAFINDRAHAINGO Iry Fanevan'ny Aina" ,ConsoleColor.Gray);
            Logger("RIVAULT Nicolas" ,ConsoleColor.Gray);
            Logger("RYCKAERT Guillaume" ,ConsoleColor.Gray);
            Logger("SANOU Yves Patrick Albert" ,ConsoleColor.Gray);
            Logger("---------- Assurance Qualitée ------------" ,ConsoleColor.Green);
            Logger("BATTISTON Aurelie" ,ConsoleColor.Gray);
            Logger("COMBETTE Elise" ,ConsoleColor.Gray);
            Logger("LE BAIL Loick" ,ConsoleColor.Gray);
            Logger("LUCE-LUCAS Mathilde" ,ConsoleColor.Gray);
            Logger("MESNY Alexandre" ,ConsoleColor.Gray);
            Logger("VANMARCKE Romain" ,ConsoleColor.Gray);            
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
            Logger("", ConsoleColor.Gray);
            Logger("Appuyez sur une touche pour continuer...", ConsoleColor.Gray);
            Console.ReadLine();
        }

        public void Logger(string texte, ConsoleColor couleur)
        {
            Console.ForegroundColor = couleur;
            Console.WriteLine(texte);
            Console.ResetColor();
        }

    }
}
