using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCP
{
    public abstract class ModeInterface
    {
        protected bool Mode { get; set; }
        protected Canvas canvas { get; set; }
        protected bool HistoriqueActions { get; set; }
        //public void List<Forme> formes { get;set; }

        public void ListerFonction()
        {

        }

        public void ListerContributeur()
        {

        }

        public void Dupliquer(int idForme, Vector2 position)
        {

        }

        public void Dessiner()
        {

        }

        public void IdentifierForme(int id)
        {

        }

        public void ChargerImage(string chemin, Vector2 position)
        {

        }

        public void ChargerDimension(Vector2 position)
        {

        }

    }
}
