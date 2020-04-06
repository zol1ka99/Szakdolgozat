using Microsoft.VisualStudio.TestTools.UnitTesting;
using Szakdoga_autonyilvantartas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdoga_autonyilvantartas.Model.Tests
{
    [TestClass()]
    public class CegTests
    {
        [TestMethod()]
        public void isValidUpperCaseStartCegnevTest()
        {
            try
            {
                Ceg c = new Ceg(1, "Teszt1", 1234, "Szeged", "Radnóti", 12, "valami@gmail.com");
                Assert.IsTrue(true);
            }
            catch(Exception ex)
            {
                Assert.Fail();
            }
        }
        
        [TestMethod()]
        public void isValidCaseStartVaros()
        {
            try
            {
                Ceg c = new Ceg(1, "Teszt1", 1234, "Szeged", "Radnóti", 12, "valami@gmail.com");
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void isValidCaseStartUtca()
        {
            try
            {
                Ceg c = new Ceg(1, "Teszt1", 1234, "Szeged", "Radnóti", 12, "valami@gmail.com");
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public static void ValidEmail()
        {
            try
            {
                Ceg c = new Ceg(1, "Teszt1", 1234, "Szeged", "Radnóti", 12, "valami@gmail.com");
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
    }
}