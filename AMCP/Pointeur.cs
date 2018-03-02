using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCP
{
    internal class Pointeur
    {

        int Id { get; set; } 
        //TODO deux int dans le CON
        Vector2 Position { get; set; } 
        int TaillePointeur { get; set; } 
        string Couleur { get; set; } 

        protected void Dessiner()
        {

        }

        protected void LeverPointeur()
        {

        }

        protected void DescendrePointeur()
        {

        }

        //TODO n'est pas le même nom que dans le CON, manque le paramètre
        protected void Avant()
        {

        }

        protected void Tourner(int angle)
        {

        }
        //TODO pas dans le CON à ne développer que si nécessaire pour le reste
        public void ObtenirHistoriqueActions()
        {

        }


    }
}
