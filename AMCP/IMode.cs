using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AMCP
{
    public abstract class IMode
    {
        private static IMode instance;
        protected Canvas Canvas { get; set; } 
        protected bool HistoriqueActions { get; set; }  
        private Pointeur Pointeur { get; set; } 

        public IMode()
        {
            if(instance == null)
            {
                instance = this;
                Canvas = new Canvas(500, 500);
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

        //TODO faute - Charger
        public void ChagerImage(string chemin, Vector2 position)
        {

        }

        public void ChangerDimension(int tailleX, int tailleY)
        {
            Canvas.Size = new Size(tailleX, tailleY);
            //Canvas.Update();
        }

    }
}
