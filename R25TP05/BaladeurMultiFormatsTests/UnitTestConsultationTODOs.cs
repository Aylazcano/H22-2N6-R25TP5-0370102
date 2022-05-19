using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaladeurMultiFormats.Tests
{
    [TestClass()]
    public class UnitTestConsultationTODOs
    {
        // TODO Test 0 : Compléter les méthodes de test pour vérifier le bon fonctionnement
        // des deux classes Consultation et Historique
        // Vous avez terminé une méthode de test, vous la lancez et le test passe (Bingo ! Tout est en vert !) 
        // Mais pour vérifier si votre méthode de test est correcte, vous devez changer le comportement 
        // de la méthode à tester et lancez le test de nouveau qui doit échouer théoriquement !
        // Exemple 01 : Si on s'attend que la méthode à tester lève une exception de type ArgumentNullException
        // 1. Modifiez dans le code de la méthode à tester pour qu'elle lève une exception de type IndexOutOfRangeException 
        // 2. Lancez le test de nouveau, dans ce cas il doit échouer
        // 3. Remttre le code initial de la méthode à tester
        // Exemple 02 : Si on s'attend que la méthode à tester retourne un nombre égal à 5
        // 1. Modifiez dans le code de la méthode à tester pour qu'elle retourne 3 
        // 2. Lancez le test de nouveau, dans ce cas il doit échouer
        // 3. Remttre le code initial de la méthode à tester



        // TODO Test A : ConsultationTestPourUneConsulationParam2NullTest
        // Compléter la méthode pour tester le constructeur au cas où la chanson passée en 
        // deuxième paramètre est à null
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConsultationTestPourUneConsulationParam2NullTest()
        {

            // Arrange/Act : Instancier un objet Consultation avec la date actuelle et une chanson à null
            // À compléter...
            Consultation objConsultation = new Consultation(DateTime.Now, null);
            
            // Assert : Vérifier si le constructeur lève une exception ArgumentNullException
            // À compléter...
        }

        // TODO Test B : ConsultationTestParamètreDateTest
        // Compléter la méthode pour tester si la propriété Date de la classe Consultation
       [TestMethod]
        public void ConsultationTestParamètreDateTest()
        {
            // Arrange : Instancier un objet ChansonsAAC 
            // Instancier un objet DateTime pour la date actuelle
            // Instancier un objet consultation en utilisant les deux objets que vous venez de créer
            // À compléter...
            ChansonAAC objChansonAAC = new ChansonAAC(@"Chansons\Happy.aac");
            DateTime objDateTimeAttendue = DateTime.Now;
            Consultation objConsultation = new Consultation(objDateTimeAttendue, objChansonAAC);

            // Act : Récupérer la date de consultation de la chanson en utilisant la propriété Date 
            // À compléter...
            DateTime dateConsultRetounee = objConsultation.Date;

            // Assert : Vérifier si la propriété Date retourne la bonne date
            // À compléter...
            Assert.AreEqual(objDateTimeAttendue, dateConsultRetounee);
        }

        // TODO Test C : ConsultationTestParamètreDélaiTest
        // Compléter la méthode pour tester la propriété Délai
        [TestMethod]
        public void ConsultationTestParamètreDélaiTest()
        {
            // Arrange : Instancier un objet ChansonsAAC 
            // Instancier un objet DateTime pour le 1er janvier 2021
            // Instancier un objet consultation en utilisant les deux objets que vous venez de créer
            // À compléter...
            ChansonAAC objChansonAAC = new ChansonAAC(@"Chansons\Happy.aac");
            DateTime objDatetime = new DateTime(2021, 01, 01);
            Consultation objConsultation = new Consultation(objDatetime, objChansonAAC);

            // Act : Récupérer le délai de la en utilisant la propriété Délai
            // À compléter...
            int delaiRetourne = objConsultation.Délai;

            // Assert : Vérifier si la propriété Délai calcule et retourne le bon délai 
            // À compléter...
            int delaiAttendu = (int)((DateTime.Now - objDatetime).TotalSeconds); // Calcul le délai en la date actuelle et la date de consultation de la chanson en secondes
            Assert.AreEqual(delaiAttendu, delaiRetourne);
        }

        // TODO Test D : ConsultationTestParamètreChansonTest
        // Compléter la méthode pour tester la propriété LaChanson
        [TestMethod]
        public void ConsultationTestParamètreChansonTest()
        {
            // Arrange : Instancier un objet ChansonsAAC 
            // Instancier un objet consultation avec la date actuelle et l'objet ChansonAAC
            // À compléter...
            ChansonAAC objChansonAACAttendue = new ChansonAAC(@"Chansons\Happy.aac");
            DateTime objDateTime = DateTime.Now;
            Consultation objConsultation = new Consultation(objDateTime, objChansonAACAttendue);

            // Act : Récupérer la chanson avec la propriété LaChanson
            // À compléter...
            ChansonAAC chansonAACRecuperee = (ChansonAAC)objConsultation.LaChanson;

            // Assert : Vérifier si la propriété LaChanson retourne la bonne chanson
            // À compléter...
            Assert.AreEqual(objChansonAACAttendue, chansonAACRecuperee);
        }
    }
}