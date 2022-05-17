using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaladeurMultiFormats
{
    public class Baladeur : IBaladeur
    {
        #region CHAMPS ET PROPRIETE
        private const string NOM_RÉPERTOIRE = "Chansons";

        private List<Chanson> m_colChansons;
        /// <summary>
        /// Obtient le nombre de chansons.
        /// </summary>
        public int NbChansons { get { return m_colChansons.Count; } }
        #endregion

        #region CONSTRUCTEUR
        /// <summary>
        /// Initialise une instance de la classe Baladeur. Elle instancie la collection des chansons
        /// </summary>
        public Baladeur()
        {
            m_colChansons = new List<Chanson>();
        }
        #endregion

        #region METHODES
        public void AfficherLesChansons(ListView pListView)
        {
            throw new NotImplementedException();
        }

        public Chanson ChansonAt(int pIndex)
        {
            throw new NotImplementedException();
        }

        public void ConstruireLaListeDesChansons()
        {
            throw new NotImplementedException();
        }

        public void ConvertirVersAAC(int pIndex)
        {
            throw new NotImplementedException();
        }

        public void ConvertirVersMP3(int pIndex)
        {
            throw new NotImplementedException();
        }

        public void ConvertirVersWMA(int pIndex)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
