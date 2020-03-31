using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdoga_autonyilvantartas.Model;

namespace Szakdoga_autonyilvantartas.Repository
{
    partial class Tarolo
    {
        public Tarolo()
        {
            cars = new List<Car>();
            tulajdonosok = new List<Tulajdonos>();
            cegek = new List<Ceg>();
            //felhasznalok = new List<Felhasznalo>();

        }
    }
}
