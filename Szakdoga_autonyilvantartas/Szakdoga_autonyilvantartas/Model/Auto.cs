using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdoga_autonyilvantartas.Model
{
    partial class Auto
    {
        private int id;
        private string marka; //comboboxba be kell tölteni az adatokat
        private string tipus; //ide a felhasználó írhat
        private int gyartasi_ev; //ezt ha lehet akkor datetimepicker-el kellene megcsinálni de majd még kiderül
        private int vetelar; //3as tagolás beállítása
        private string rendszam; //későbbi fejlesztésben ki lehet választani egyes országok rendszám formátumát grafikus update
        private int kilometeroraallas; //+km tagot odarakni majd
        private string alvazszam; 
        private string gepkocsi_tipusa;  //szgk, tgk, busz stbstb
        private string uzemanyag; //benzin, gazolaj, cng, hibrid(benzin vagy dizel hibrid ezt majd jelölni kellene), 
        private string sebessegvalto_tipusa; //automata, manuális (később esetleg részletesebb ha szükséges)
        private string tulajdonos_nev;
    }
}
