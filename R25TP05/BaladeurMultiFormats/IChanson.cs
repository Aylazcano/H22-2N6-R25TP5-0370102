using System.IO;

namespace BaladeurMultiFormats
{
    internal interface IChanson
    {
        #region PROPRIETES
        /// <summary>
        /// Obtient l’année de création de la chanson 
        /// </summary>
        int Annee { get; }

        /// <summary>
        /// Obtient le nom de l’artiste ou du groupe ayant créé la chanson
        /// </summary>
        string Artiste { get; }

        /// <summary>
        /// Obtient le format audio de la chanson par exemple AAC, MP3 ou WMA
        /// </summary>
        string Format { get; }

        /// <summary>
        /// Obtient le nom de fichier de la chanson
        /// </summary>
        string NomFichier { get; }

        /// <summary>
        /// Propriété calculée pour obtenir les paroles de la chanson à partir d’un fichier texte
        /// </summary>
        string Paroles { get; }

        /// <summary>
        /// Obtient le titre de la chanson
        /// </summary>
        string Titre { get; }
        #endregion


        #region METHODES
        /// <summary>
        /// Écrit les paroles passées en paramètre dans le fichier de la chanson
        /// </summary>
        /// <param name="pParoles">Paroles de la chanson</param>
        void Ecrire(string pParoles);

        /// <summary>
        /// Écrit uniquement l'entête de la chanson
        /// </summary>
        /// <param name="pobjFichier">Fichier audio (textes)</param>
        void EcrireEntete(StreamWriter pobjFichier);

        /// <summary>
        /// Écrit uniquement les paroles de la chanson
        /// </summary>
        /// <param name="pobjFichier">Fichier audio (textes)</param>
        /// <param name="pParoles">Paroles a écrire</param>
        void EcrireParoles(StreamWriter pobjFichier, string pParoles);

        /// <summary>
        /// Lecture de l’en-tête du fichier soit uniquement la première ligne
        /// </summary>
        void LireEntete();

        /// <summary>
        /// Obtient les paroles à partir d'un fichier binaire déjà ouvert
        /// </summary>
        /// <param name="pobjFichier">Fichier audio (textes)</param>
        /// <returns></returns>
        string LireParoles(StreamReader pobjFichier);


        /// <summary>
        /// Lit une ligne à partir du fichier passé en paramètre
        /// </summary>
        /// <param name="pobjFichier">Fichier audio (textes)</param>
        void SauterEntete(StreamReader pobjFichier);
        #endregion
    }
}
