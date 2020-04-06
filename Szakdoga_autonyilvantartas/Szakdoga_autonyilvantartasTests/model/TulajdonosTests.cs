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
    public class TulajdonosTests
    {
        [TestMethod()]
        public void isValidUpperCaseTulajNevTest()
        {
            try
            {
                Tulajdonos t = new Tulajdonos(1, "Kiss Ferenc", "SA134636", 12353, "valamiteszt1@gmail.com", 4565657, "Teszt1");
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void ValidEmail()
        {
            try
            {
                Tulajdonos t = new Tulajdonos(1, "Kiss Ferenc", "SA134636", 12353, "valamiteszt1@gmail.com", 4565657, "Teszt1");
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
    }
}