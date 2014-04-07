using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_EksamensOpgave2014;

namespace Testing
{
    [TestClass]
    public class RegistreringsNummerGyldighedsTest
    {
        [TestMethod]
        public void RegistreringsNummer_IsValid()
        {
            Privatbil test_bil = new Privatbil(Brændstof.Diesel, 1989);
            test_bil.Registreringsnummer = "gw12345";
            test_bil.Registreringsnummer = "yN67890";
            test_bil.Registreringsnummer = "Qp83746";
            test_bil.Registreringsnummer = "AY07634";
            test_bil.Registreringsnummer = "wø00000";
            test_bil.Registreringsnummer = "åa88734";
            test_bil.Registreringsnummer = "HÆ72934";
            test_bil.Registreringsnummer = "ØA98475";
            test_bil.Registreringsnummer = "ll11111";
        }
        
        public bool RegistreringsNummer_IsInvalid(string nummer)
        {
            Privatbil test_bil = new Privatbil(Brændstof.Diesel, 1989);
            try
            {
                test_bil.Registreringsnummer = nummer;
            }
            catch (RegistreringnummerException)
            {
                return true;                
            }
            return false;
        }
        [TestMethod]
        public void RegistreringsNummer_IsInvalid1()
        {
            Assert.IsTrue( RegistreringsNummer_IsInvalid("5679845"));
        }

        [TestMethod]
        public void RegistreringsNummer_IsInvalid2()
        {
            Assert.IsTrue(RegistreringsNummer_IsInvalid("aaaaaaa"));
        }
        [TestMethod]
        public void RegistreringsNummer_IsInvalid3()
        {
            Assert.IsTrue(RegistreringsNummer_IsInvalid("a123543"));
        }
        [TestMethod]
        public void RegistreringsNummer_IsInvalid4()
        {
            Assert.IsTrue(RegistreringsNummer_IsInvalid("kjh98765"));
        }
        [TestMethod]
        public void RegistreringsNummer_IsInvalid5()
        {
            Assert.IsTrue(RegistreringsNummer_IsInvalid("as987676"));
        }
        [TestMethod]
        public void RegistreringsNummer_IsInvalid6()
        {
            Assert.IsTrue(RegistreringsNummer_IsInvalid("a92384"));
        }
        [TestMethod]
        public void RegistreringsNummer_IsInvalid7()
        {
            Assert.IsTrue(RegistreringsNummer_IsInvalid("as0984"));
        }
        [TestMethod]
        public void RegistreringsNummer_IsInvalid8()
        {
            Assert.IsTrue(RegistreringsNummer_IsInvalid("as0984"));
        }
        [TestMethod]
        public void RegistreringsNummer_IsInvalid9()
        {
            Assert.IsTrue(RegistreringsNummer_IsInvalid("a!98753"));
        }
        [TestMethod]
        public void RegistreringsNummer_IsInvalid10()
        {
            Assert.IsTrue(RegistreringsNummer_IsInvalid("aä86242"));
        }
        [TestMethod]
        public void RegistreringsNummer_IsInvalid11()
        {
            Assert.IsTrue(RegistreringsNummer_IsInvalid(""));
        }
    }
}
