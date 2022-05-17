using System.IO;
using System.Windows.Forms;

namespace BaladeurMultiFormats
{
    public abstract class Chanson : IChanson
    {
        //Quelques résumés s'affiche déjà avec l'interface iChanson, réecrire les résumés est redondant. 
        #region CHAMPS ET PROPRIETES 
        protected int m_annee;
        public int Annee { get { return m_annee; } }

        protected string m_artiste;
        public string Artiste { get { return m_artiste; } }

        public abstract string Format { get; }

        protected string m_nomFichier;
        public string NomFichier { get { return m_nomFichier; } }

        public string Paroles
        {
            get
            {
                if (!File.Exists(m_nomFichier))
                {
                    MessageBox.Show("Impossible de trouver le fichier!", Application.ProductName, MessageBoxButtons.OK);
                    return "";
                }

                StreamReader objFichier = new StreamReader(m_nomFichier);
                SauterEntete(objFichier);
                string paroles = LireParoles(objFichier);
                objFichier.Close();
                return paroles;
            }
        }

        protected string m_titre;
        public string Titre { get { return m_titre; } }
        #endregion

        #region CONSTRUCTEURS 
        /// <summary> 
        /// Initialise une instance a 1 paramettre 
        /// </summary> 
        /// <param name="pNomFichier">Fichier audio (textes)</param> 
        public Chanson(string pNomFichier)
        {
            m_nomFichier = pNomFichier;
            LireEntete();
        }

        /// <summary> 
        /// Initialise une instance a 4 paramettres 
        /// </summary> 
        /// <param name="pRepertoire">Repertoire du fichier</param> 
        /// <param name="pArtiste">Nom de l'artiste</param> 
        /// <param name="pTitre">Titre de la chanson</param> 
        /// <param name="pAnnée">Annee de la chanson</param> 
        public Chanson(string pRepertoire, string pArtiste, string pTitre, int pAnnée)
        {
            m_nomFichier = $@"{pRepertoire}\{pTitre}.{Format.ToLower()}";
            m_artiste = pArtiste;
            m_titre = pTitre;
            m_annee = pAnnée;
        }

        #endregion

        #region METHODES 
        public void Ecrire(string pParoles)
        {
            StreamWriter objFichier = new StreamWriter(m_nomFichier);
            EcrireEntete(objFichier);
            EcrireParoles(objFichier, pParoles);
            objFichier.Close();
        }

        public abstract void EcrireEntete(StreamWriter pobjFichier);

        public abstract void EcrireParoles(StreamWriter pobjFichier, string pParoles);

        public abstract void LireEntete();

        public abstract string LireParoles(StreamReader pobjFichier);

        public void SauterEntete(StreamReader pobjFichier)
        {
            pobjFichier.ReadLine();
        }
        #endregion
    }
}