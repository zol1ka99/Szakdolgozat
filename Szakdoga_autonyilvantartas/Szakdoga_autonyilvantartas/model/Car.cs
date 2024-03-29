﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Szakdoga_autonyilvantartas.Repository;

namespace Szakdoga_autonyilvantartas.Model
{
    public partial class Car
    {
        private int id;
        private string marka; //comboboxba be kell tölteni az adatokat
        private string tipus; //ide a felhasználó írhat
        private string gyartasi_ev; //ezt ha lehet akkor datetimepicker-el kellene megcsinálni de majd még kiderül
        private int vetelar; //3as tagolás beállítása
        private string rendszam; //későbbi fejlesztésben ki lehet választani egyes országok rendszám formátumát grafikus update
        private int kilometeroraallas; //+km tagot odarakni majd
        private string alvazszam; 
        private string gepkocsi_tipusa;  //szgk, tgk, busz stbstb
        private string uzemanyag; //benzin, gazolaj, cng, hibrid(benzin vagy dizel hibrid ezt majd jelölni kellene), 
        private string sebessegvalto_tipusa; //automata, manuális (később esetleg részletesebb ha szükséges)
        private string tulajdonos_nev;

        public Car(int id, string marka, string tipus, string gyartasi_ev, int vetelar, string rendszam, int kilometeroraallas, string alvazszam, string gepkocsi_tipusa, string uzemanyag, string sebessegvalto_tipusa, string tulajdonos_nev)
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

        public bool isValid()
        {
            if (!isValidGyartasiev(gyartasi_ev))
            {
                throw new ModelCarDateTimeException("Ne hagyja üresen a mezőt!");
            }

            if (!isValidDateTime(gyartasi_ev))
            {
                throw new ModelCarDateTimeFormatException("Ne hagyja üresen a mezőt!");
            }
            if(!isValidUpperCaseStartUzemanyag(uzemanyag))
            {
                throw new ModelCarKisbetuuzemanyagException("Írja nagy betűvel!");
            }


            return true;
        }


        public void updateCar(Car modified)
        {
            this.marka = modified.getMarka();
            this.tipus = modified.getTipus();
            this.gyartasi_ev = modified.getGyartasiev();
            this.vetelar = modified.getVetelar();
            this.rendszam = modified.getRendszam();
            this.kilometeroraallas = modified.getKilometeroraallas();
            this.alvazszam = modified.getAlvazszam();
            this.gepkocsi_tipusa = modified.getGepkocsiTipusa();
            this.uzemanyag = modified.getUzemanyag();
            this.sebessegvalto_tipusa = modified.getSebessegvaltoTipusa();
            this.tulajdonos_nev = modified.getTulajdonosNev();
        }

        public void setId(int id)
        {
            this.id = id;
        }
        public int getId()
        {
            return id;
        }


        public void setMarka (string marka)
        {
            this.marka = marka;
        }
        public string getMarka()
        {
            return marka;
        }


        public void setTipus(string tipus)
        {
            this.tipus = tipus;
        }
        public string getTipus()
        {
            return tipus;
        }


        public void setGyartasiev(string gyartasi_ev)
        {
            this.gyartasi_ev = gyartasi_ev;
        }
        public string getGyartasiev()
        {
            return gyartasi_ev;
        }


        public void setVetelar(int vetelar)
        {
            this.vetelar = vetelar;
        }
        public int getVetelar()
        {
            return vetelar;
        }


        public void setRendszam (string rendszam)
        {
            this.rendszam = rendszam;
        }
        public string getRendszam()
        {
            return rendszam;
        }


        public void setKilometeroraallas(int kilometeroraallas)
        {
            this.kilometeroraallas = kilometeroraallas;
        }
        public int getKilometeroraallas()
        {
            return kilometeroraallas;
        }


        public void setAlvazszam(string alvazszam)
        {
            this.alvazszam = alvazszam;
        }
        public string getAlvazszam()
        {
            return alvazszam;
        }


        public void setGepkocsiTipusa(string gepkocsi_tipusa)
        {
            this.gepkocsi_tipusa = gepkocsi_tipusa;
        }
        public string getGepkocsiTipusa()
        {
            return gepkocsi_tipusa;
        }


        public void setUzemanyag(string uzemanyag)
        {
            this.uzemanyag = uzemanyag;
        }
        public string getUzemanyag()
        {
            return uzemanyag;
        }


        public void setSebessegvaltoTipusa (string sebessegvalto_tipusa)
        {
            this.sebessegvalto_tipusa = sebessegvalto_tipusa;
        }
        public string getSebessegvaltoTipusa()
        {
            return sebessegvalto_tipusa;
        }

        public void setTulajdonosNev(string tulajdonos_nev)
        {
            this.tulajdonos_nev = tulajdonos_nev;
        }
        public string getTulajdonosNev()
        {
            return tulajdonos_nev;
        }



        /*Validáció bár az adatbáziba nem megy fel rossza adat mert le van kezelve error providerekkel és label ir irja ha hiba van*/
        public bool isValidGyartasiev(string gyartasi_ev)
        {
            if (gyartasi_ev == string.Empty)
            {
                return false;
            }
            return true;
        }

        public bool isValidDateTime(string gyartasi_ev)
        {
            var regex = new Regex(@"^\d{4}[/.-]((0\d)|(1[012]))[/.-](([012]\d)|3[01])$");
            return regex.IsMatch(gyartasi_ev);
        }

        public bool isValidUpperCaseStartGKT(string gepkocsi_tipusa)
        {
            if (!char.IsUpper(gepkocsi_tipusa.ElementAt(0)))
            {
                return false;
            }
            return true;
        }

        public bool isValidUpperCaseStartUzemanyag(string uzemanyag)
        {
            if (!char.IsUpper(uzemanyag.ElementAt(0)))
            {
                return false;
            }
            return true;
        }

        public bool isValidUpperCaseStartSebessegVT(string sebessegvalto_tipusa)
        {
            if (!char.IsUpper(sebessegvalto_tipusa.ElementAt(0)))
            {
                return false;
            }
            return true;
        }

        public bool isValidUpperCaseTulajNev(string tulajdonos_nev)
        {
            if (!char.IsUpper(tulajdonos_nev.ElementAt(0)))
            {
                return false;
            }
            return true;
        }
    }
}
