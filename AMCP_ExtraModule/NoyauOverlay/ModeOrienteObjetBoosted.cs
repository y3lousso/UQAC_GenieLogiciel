using System;
using System.Drawing;
using AMCP.Formes;
using AMCP_ExtraModule.Formes;

namespace AMCP_ExtraModule.NoyauOverlay
{
    public class ModeOrienteObjetBoosted : AMCP.Noyau.ModeOrienteObjet
    {
        #region Createurs

        /// <summary>
        /// Permet de créer une carré.
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="taille"></param>
        /// <returns></returns>
        public virtual Forme CreerVoiture(int positionX, int positionY)
        {
            Voiture f = new Voiture(new Point(positionX, positionY));
            Canvas.Formes.Add(f);
            Logger(f.Type + " " + f.ID + " : Création effectuée.", ConsoleColor.Green);
            return f;
        }

        #endregion
    }   
}