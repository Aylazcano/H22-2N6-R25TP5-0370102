using System;
using System.IO;

namespace BaladeurMultiFormats
{
    public class ChansonWMA : Chanson
    {
        #region CHAMP ET PROPRIETE
        private int m_codage;

        /// <summary>
        /// Obtient le format du fichier (AAC) 
        /// </summary>
        public override string Format { get { return "WMA"; } }
        #endregion

        #region CONSTRUCTEURS
        /// <summary>
        /// Initialise une instance avec les données passées en paramètres en appelant le constructeur de la classe de base
        /// </summary>
        /// <param name="pNomFichier">Fichier audio (textes)</param>
        public ChansonWMA(string pNomFichier) : base(pNomFichier)
        {
        }

        /// <summary>
        /// Initialise une instance avec les données passées en paramètres en appelant le constructeur de la classe de base
        /// </summary>
        /// <param name="pRepertoire">Repertoire du fichier</param> 
        /// <param name="pArtiste">Nom de l'artiste</param> 
        /// <param name="pTitre">Titre de la chanson</param> 
        /// <param name="pAnnée">Annee de la chanson</param> 
        public ChansonWMA(string pRepertoire, string pArtiste, string pTitre, int pAnnée) : base(pRepertoire, pArtiste, pTitre, pAnnée)
        {
        }
        #endregion

        #region METHODES
        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            Random random = new Random();
            m_codage = random.Next(3, 16);
            pobjFichier.WriteLine($@"{m_codage} / {m_annee} / {m_titre} / {m_artiste}");
        }

        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            pobjFichier.WriteLine(OutilsFormats.EncoderWMA(pParoles, m_codage));
        }

        /// <summary>
        /// Lit la premiere ligne du fichier de la chanson et initialise les champs de la chanson (artiste, année de création et titre)
        /// </summary>
        public override void LireEntete()
        {
            StreamReader objFichier = new StreamReader(m_nomFichier);
            string[] ligne = objFichier.ReadLine().Split('/');
            m_codage = int.Parse(ligne[0]);
            m_annee = int.Parse(ligne[1]);
            m_titre = ligne[2].Trim();
            m_artiste = ligne[3].Trim();
            objFichier.Close();
        }

        public override string LireParoles(StreamReader pobjFichier)
        {
            return OutilsFormats.DecoderWMA(pobjFichier.ReadToEnd(), m_codage);
        }
        #endregion

    }
}
