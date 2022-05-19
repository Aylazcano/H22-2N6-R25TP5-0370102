using System.IO;

namespace BaladeurMultiFormats
{
    public class ChansonMP3 : Chanson
    {
        #region PROPRIETE
        /// <summary>
        /// Obtient le format du fichier (AAC) 
        /// </summary>
        public override string Format { get { return "MP3"; } }
        #endregion

        #region CONSTRUCTEURS
        /// <summary>
        /// Initialise une instance avec les données passées en paramètres en appelant le constructeur de la classe de base
        /// </summary>
        /// <param name="pNomFichier">Fichier audio (textes)</param>
        public ChansonMP3(string pNomFichier) : base(pNomFichier)
        {
        }

        /// <summary>
        /// Initialise une instance avec les données passées en paramètres en appelant le constructeur de la classe de base
        /// </summary>
        /// <param name="pRepertoire">Repertoire du fichier</param> 
        /// <param name="pArtiste">Nom de l'artiste</param> 
        /// <param name="pTitre">Titre de la chanson</param> 
        /// <param name="pAnnée">Annee de la chanson</param> 
        public ChansonMP3(string pRepertoire, string pArtiste, string pTitre, int pAnnée) : base(pRepertoire, pArtiste, pTitre, pAnnée)
        {
        }
        #endregion

        #region METHODES
        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine($@"{m_artiste} | {m_annee} | {m_titre}");
        }

        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            pobjFichier.WriteLine(OutilsFormats.EncoderAAC(pParoles));
        }

        /// <summary>
        /// Lit la premiere ligne du fichier de la chanson et initialise les champs de la chanson (artiste, année de création et titre)
        /// </summary>
        public override void LireEntete()
        {
            StreamReader objFichier = new StreamReader(m_nomFichier);
            string[] ligne = objFichier.ReadLine().Split('|');
            m_artiste = ligne[0].Trim();
            m_annee = int.Parse(ligne[1]);
            m_titre = ligne[2].Trim();
            objFichier.Close();
        }

        public override string LireParoles(StreamReader pobjFichier)
        {
            return OutilsFormats.DecoderMP3(pobjFichier.ReadToEnd());
        }
        #endregion
    }
}
