using System.Windows.Forms;

namespace BaladeurMultiFormats
{
    public interface IBaladeur
	{
        #region PROPRIETE
        /// <summary>
        /// Obtient le nombre de chansons
        /// </summary>
        int NbChansons { get; }
        #endregion

        #region METHODES
        /// <summary>
        /// Affiche la liste des chansons dans la pListView passée en paramètre
        /// </summary>
        /// <param name="pListView">Liste des chansons</param>
        void AfficherLesChansons(ListView pListView);

		/// <summary>
		/// Obtient la chanson à l’index pIndex passé en paramètre
		/// </summary>
		/// <param name="pIndex">Index de la chanson selectionnee</param>
		/// <returns></returns>
		Chanson ChansonAt(int pIndex);

		/// <summary>
		/// Récupère la liste des fichiers dans le dossier Chansons, instancie selon le cas des objets des classes dérivées de la classe Chanson
		/// </summary>
		void ConstruireLaListeDesChansons();

		/// <summary>
		/// Instancie une ChansonAAC à partir de la chanson à l’index pIndex, enregistre les paroles et supprime le fichier du format précédent.
		/// </summary>
		/// <param name="pIndex">Index de la chanson selectionnee</param>
		void ConvertirVersAAC(int pIndex);

		/// <summary>
		/// Instancie une ChansonMP3 à partir de la chanson à l’index pIndex, enregistre les paroles et supprime le fichier du format précédent.
		/// </summary>
		/// <param name="pIndex">Index de la chanson selectionnee</param>
		void ConvertirVersMP3(int pIndex);

		/// <summary>
		/// Instancie une ChansonWMA à partir de la chanson à l’index pIndex, enregistre les paroles et supprime le fichier du format précédent
		/// </summary>
		/// <param name="pIndex">Index de la chanson selectionne</param>
		void ConvertirVersWMA(int pIndex);
        #endregion
    }
}
