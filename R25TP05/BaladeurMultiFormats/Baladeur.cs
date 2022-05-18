using System;
using System.Collections.Generic;
using System.IO;
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
            pListView.Items.Clear();
            pListView.BeginUpdate();

            foreach (Chanson chanson in m_colChansons)
            {
                ListViewItem listViewItem = new ListViewItem(chanson.Artiste);
                listViewItem.SubItems.Add(chanson.Titre);
                listViewItem.SubItems.Add(chanson.Annee.ToString());
                listViewItem.SubItems.Add(chanson.Format);
                listViewItem.Tag = chanson;
                pListView.Items.Add(listViewItem);
            }

            pListView.EndUpdate();
        }

        public Chanson ChansonAt(int pIndex)
        {
            return m_colChansons[pIndex];
        }

        public void ConstruireLaListeDesChansons()
        {
            m_colChansons.Clear();

            if (!Directory.Exists(NOM_RÉPERTOIRE)) 
                MessageBox.Show("Impossible de trouver le dossier!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string[] listeFichierChansons = Directory.GetFiles(NOM_RÉPERTOIRE);
                int nombreErreurs = 0;
                Chanson chanson = null;
                
                foreach (string fichier in listeFichierChansons)
                {
                    try
                    {
                        switch (fichier.Substring(fichier.Length - 3).ToUpper()) //Extention
                        {
                            case "MP3":
                                chanson = new ChansonMP3(fichier);
                                break;
                            case "WMA":
                                chanson = new ChansonWMA(fichier);
                                break;
                            case "AAC":
                                chanson = new ChansonAAC(fichier);
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        nombreErreurs++;
                        chanson = null;
                    }
                    if (chanson != null)
                        m_colChansons.Add(chanson);
                }
                if (nombreErreurs > 0)
                    MessageBox.Show(nombreErreurs + " chansons n'ont pu être chargeés correctement", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ConvertirVersAAC(int pIndex)
        {
            Chanson chanson = m_colChansons[pIndex];
            ChansonAAC chansonAAC = new ChansonAAC(NOM_RÉPERTOIRE, chanson.Artiste, chanson.Titre, chanson.Annee);
            chansonAAC.Ecrire(chanson.Paroles);
            File.Delete(chanson.NomFichier);
            m_colChansons[pIndex] = chansonAAC;
        }

        public void ConvertirVersMP3(int pIndex)
        {
            Chanson chanson = m_colChansons[pIndex];
            ChansonMP3 chansonMP3 = new ChansonMP3(NOM_RÉPERTOIRE, chanson.Artiste, chanson.Titre, chanson.Annee);
            chansonMP3.Ecrire(chanson.Paroles);
            File.Delete(chanson.NomFichier);
            m_colChansons[pIndex] = chansonMP3;
        }

        public void ConvertirVersWMA(int pIndex)
        {
            Chanson chanson = m_colChansons[pIndex];
            ChansonWMA chansonWMA = new ChansonWMA(NOM_RÉPERTOIRE, chanson.Artiste, chanson.Titre, chanson.Annee);
            chansonWMA.Ecrire(chanson.Paroles);
            File.Delete(chanson.NomFichier);
            m_colChansons[pIndex] = chansonWMA;
        }
        #endregion
    }
}
