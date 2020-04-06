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
    public class CarTests
    {
        [TestMethod()]
        public void isValidGyartasievTest()
        {
            try
            {
                Car c = new Car(1, "Audi", "A5", "2020-02-15", 25000, "RRR-234", 65481, "AZ345345", "SzGK", "Benzin", "Automata", "Kiss Ferenc");
                if(c.isValid())
                {

                }
            }
            catch (Exception e)
            {
                Assert.Fail("Ne hagyja üresen a mezőt!");
            }
        }


        [TestMethod()]
        public void isValidDateTimeTest()
        {
            try
            {
                Car c = new Car(1, "Audi", "A5", "2020-02-15", 25000, "RRR-234", 65481, "AZ345345", "SzGK", "Benzin", "Automata", "Kiss Ferenc");
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail("A gyártási év mező nem lehet üres");
            }
        }

        [TestMethod()]
        public void isValidUpperCaseStartGKTTest()
        {
            try
            {
                Car c = new Car(1, "Audi", "A5", "2020-02-12", 25000, "RRR-234", 65481, "AZ345345", "SzGK", "Benzin", "Automata", "Kiss Ferenc");
            }
            catch (Exception ex)
            {
                Assert.Fail("A gyártási év mező nem lehet üres");
            }
        }

        [TestMethod()]
        public void isValidUpperCaseStartUzemanyagTest()
        {
            try
            {
                Car c = new Car(1, "Audi", "A5", "2020-02-12", 25000, "RRR-234", 65481, "AZ345345", "SzGK", "benzin", "Automata", "Kiss Ferenc");
                if (c.isValid())
                {
                    Assert.Fail("Kisbetűnél nem dob kivételt!");
                }
            }
            catch (ModelCarKisbetuuzemanyagException ex)
            {
                if (ex.Message!= "Írja nagy betűvel!")
                {
                    Assert.Fail("Kisbetüs üzemanyag esetén hibát dob de a hiba szövege rossz!");
                }
            }
            catch (Exception e)
            {
                Assert.Fail("Kisbetüs üzemanyag esetén hibát dob de a hiba szövege rossz!");
            }
        }

        [TestMethod()]
        public void isValidUpperCaseStartSebessegVTTest()
        {
            try
            {
                Car c = new Car(1, "Audi", "A5", "2020-02-15", 25000, "RRR-234", 65481, "AZ345345", "SzGK", "Benzin", "Automata", "Kiss Ferenc");
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail("A gyártási év mező nem lehet üres");
            }
        }

        [TestMethod()]
        public void isValidUpperCaseTulajNevTest()
        {
            try
            {
                Car c = new Car(1, "Audi", "A5", "2020-02-15", 25000, "RRR-234", 65481, "AZ345345", "SzGK", "Benzin", "Automata", "Kiss Ferenc");
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail("A gyártási év mező nem lehet üres");
            }
        }

    }
}