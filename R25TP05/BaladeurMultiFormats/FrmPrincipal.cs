using System;
using System.Windows.Forms;
using System.IO;


namespace BaladeurMultiFormats
{
    // Étapes de  réalisation :
    // Étape #1 : Définir les classes Chanson et ChasonAAC

    public partial class FrmPrincipal : Form
    {
        public const string APP_INFO = "0370102";

        #region Propriété : MonHistorique : MonBaladeur
        public Historique MonHistorique { get; }
        public Baladeur MonBaladeur { get; }
        public Chanson ChansonSelectionnee 
        { 
            get 
            { 
                if(lsvChansons.SelectedIndices.Count <= 0) 
                    return null;
                return MonBaladeur.ChansonAt(lsvChansons.SelectedIndices[0]);
            } 
        }
        #endregion

        //---------------------------------------------------------------------------------
        #region FrmPrincipal
        public FrmPrincipal()
        {
            InitializeComponent();
            Text += APP_INFO;
            MonHistorique = new Historique();
            // À COMPLÉTER...
            MonBaladeur = new Baladeur();
            MonBaladeur.ConstruireLaListeDesChansons();
            MonBaladeur.AfficherLesChansons(lsvChansons);
            lblNbChansons.Text = lsvChansons.Items.Count.ToString();
            MettreAJourSelonContexte();
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Méthode : MettreAJourSelonContexte
        private void MettreAJourSelonContexte()
        {
            // À COMPLÉTER...
            if(ChansonSelectionnee == null)
            {
                MnuFormatConvertirVersWMA.Enabled = false;
                MnuFormatConvertirVersMP3.Enabled = false;
                MnuFormatConvertirVersAAC.Enabled = false;
                txtParoles.Text = string.Empty;
            }
            else
            {
                switch (ChansonSelectionnee.Format)
                {
                    case "MP3":
                        MnuFormatConvertirVersWMA.Enabled = true;
                        MnuFormatConvertirVersMP3.Enabled = false;
                        MnuFormatConvertirVersAAC.Enabled = true;
                        break;
                    case "WMA":
                        MnuFormatConvertirVersWMA.Enabled = false;
                        MnuFormatConvertirVersMP3.Enabled = true;
                        MnuFormatConvertirVersAAC.Enabled = true;
                        break;
                    case "AAC":
                        MnuFormatConvertirVersWMA.Enabled = true;
                        MnuFormatConvertirVersMP3.Enabled = true;
                        MnuFormatConvertirVersAAC.Enabled = false;
                        break;
                }
            }
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Événement : LsvChansons_SelectedIndexChanged
        private void LsvChansons_SelectedIndexChanged(object sender, EventArgs e)
        {
            // À COMPLÉTER...
            if (lsvChansons.SelectedIndices.Count > 0)
            {
                txtParoles.Text = ChansonSelectionnee.Paroles;
                MonHistorique.Add(new Consultation(DateTime.Now, ChansonSelectionnee));
            }
            MettreAJourSelonContexte();
        }
        #endregion

        //---------------------------------------------------------------------------------
        #region Méthodes : Convertir vers les formats AAC, MP3 ou WMA
        private void MnuFormatConvertirVersAAC_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            // À COMPLÉTER...
            MonHistorique.Clear();
            MonBaladeur.ConvertirVersAAC(lsvChansons.SelectedIndices[0]);
            MettreAJourSelonContexte();
        }
        private void MnuFormatConvertirVersMP3_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            // À COMPLÉTER...
            MonHistorique.Clear();
            MonBaladeur.ConvertirVersMP3(lsvChansons.SelectedIndices[0]);
            MettreAJourSelonContexte();
        }
        private void MnuFormatConvertirVersWMA_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            // À COMPLÉTER...
            MonHistorique.Clear();
            MonBaladeur.ConvertirVersWMA(lsvChansons.SelectedIndices[0]);
            MettreAJourSelonContexte();
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Historique
        private void MnuSpécialHistorique_Click(object sender, EventArgs e)
        {
            FrmHistorique objFormulaire = new FrmHistorique(MonHistorique);
            objFormulaire.ShowDialog();
        }
        #endregion
         //---------------------------------------------------------------------------------
        #region Méthodes : MnuFichierQuitter_Click
        //---------------------------------------------------------------------------------
        private void MnuFichierQuitter_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
