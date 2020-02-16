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

        public Auto(int id, string marka, string tipus, int gyartasi_ev, int vetelar, string rendszam, int kilometeroraallas, string alvazszam, string gepkocsi_tipusa, string uzemanyag, string sebessegvalto_tipusa, string tulajdonos_nev)
        {
            this.id = id;
            this.marka = marka;
            this.tipus = tipus;
            this.gyartasi_ev = gyartasi_ev;
            this.vetelar = vetelar;
            this.rendszam = rendszam;
            this.kilometeroraallas = kilometeroraallas;
            this.alvazszam = alvazszam;
            this.gepkocsi_tipusa = gepkocsi_tipusa;
            this.uzemanyag = uzemanyag;
            this.sebessegvalto_tipusa = sebessegvalto_tipusa;
            this.tulajdonos_nev = tulajdonos_nev;
        }

        public void setId(int id)
        {
            this.id = id;
        }
        public void setMarka (string marka)
        {
            this.marka = marka;
        }
        public void setTipus(string tipus)
        {
            this.tipus = tipus;
        }
        public void setGyartasiev(int gyartasi_ev)
        {
            this.gyartasi_ev = gyartasi_ev;
        }
        public void setVetelar(int vetelar)
        {
            this.vetelar = vetelar;
        }
        public void setRendszam (string rendszam)
        {
            this.rendszam = rendszam;
        }
        public void setKilometeroraallas(int kilometeroraallas)
        {
            this.kilometeroraallas = kilometeroraallas;
        }
        public void setAlvazszam(string alvazszam)
        {
            this.alvazszam = alvazszam;
        }
        public void setGepkocsiTipusa(string gepkocsi_tipusa)
        {
            this.gepkocsi_tipusa = gepkocsi_tipusa;
        }
        public void setUzemanyag(string uzemanyag)
        {
            this.uzemanyag = uzemanyag;
        }
        public void setSebessegvaltoTipusa (string sebessegvalto_tipusa)
        {
            this.sebessegvalto_tipusa = sebessegvalto_tipusa;
        }
        public int getId()
        {
            return id;
        }
    }
}
