using System.IO;

namespace BaladeurMultiFormats
{
    public class ChansonAAC : Chanson
    {
        #region PROPRIETE
        /// <summary>
        /// Obtient le format du fichier (AAC) 
        /// </summary>
        public override string Format { get { return "ACC"; } }
        #endregion

        #region CONSTRUCTEURS
        /// <summary>
        /// Initialise une instance avec les données passées en paramètres en appelant le constructeur de la classe de base
        /// </summary>
        /// <param name="pNomFichier">Fichier audio (textes)</param>
        public ChansonAAC(string pNomFichier) : base(pNomFichier)
        {
        }

        /// <summary>
        /// Initialise une instance avec les données passées en paramètres en appelant le constructeur de la classe de base
        /// </summary>
        /// <param name="pRepertoire">Repertoire du fichier</param> 
        /// <param name="pArtiste">Nom de l'artiste</param> 
        /// <param name="pTitre">Titre de la chanson</param> 
        /// <param name="pAnnée">Annee de la chanson</param> 
        public ChansonAAC(string pRepertoire, string pArtiste, string pTitre, int pAnnée) : base(pRepertoire, pArtiste, pTitre, pAnnée)
        {
        }
        #endregion

        #region METHODES
        /// <summary>
        /// Écrit une ligne dans le fichier passé en paramètre
        /// </summary>
        /// <param name="pobjFichier">Fichier audio (textes)</param>
        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine($"TITRE = {m_titre} : ARTISTE = {m_artiste} : ANNÉE = {m_annee}");
        }

        /// <summary>
        /// Encode les paroles reçues en paramètre au format AAC, ensuite écrit ses paroles encodées dans le fichier passé en paramètre
        /// </summary>
        /// <param name="pobjFichier">Fichier audio (texte)</param>
        /// <param name="pParoles">Paroles à écrire</param>
        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            pobjFichier.WriteLine(OutilsFormats.EncoderAAC(pParoles));
        }

        /// <summary>
        /// Lit la premiere ligne du fichier de la chanson et initialise les champs de la chanson (titre, artiste et année de création de la chanson)
        /// </summary>
        public override void LireEntete()
        {
            StreamReader objFichier = new StreamReader(m_nomFichier);
            string[] ligne = objFichier.ReadLine().Split(':');
            m_titre = ligne[0].Split('=')[1].Trim();
            m_artiste = ligne[1].Split('=')[1].Trim();
            m_annee = int.Parse(ligne[2].Split('=')[1]);
            objFichier.Close();
        }

        /// <summary>
        /// Récupère les paroles de la chanson à partir du fichier passé en paramètre, les décode selon le format AAC et les retourne
        /// </summary>
        /// <param name="pobjFichier">Fichier audio (textes)</param>
        /// <returns>Paroles décrypté</returns>
        public override string LireParoles(StreamReader pobjFichier)
        {
            return OutilsFormats.DecoderAAC(pobjFichier.ReadToEnd());
        }
        #endregion
    }
}