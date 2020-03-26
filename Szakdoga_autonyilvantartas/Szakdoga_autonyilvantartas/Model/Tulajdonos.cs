using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdoga_autonyilvantartas.Model
{
    partial class Tulajdonos
    {
        private int tulid;
        private string tulajdonos_nev;
        private string tulajdonos_szemelyiigszam;
        private int jogositvany_azon;
        private string email_cim;
        private int telefonszam;
        private string cegnev; //ennek az sql része lesz probléma mert uganúgy kell mint az autónál a tulid-vel, inner joinnal

        public Tulajdonos(int tulid, string tulajdonos_nev, string tulajdonos_szemelyiigszam, int jogositvany_azon, string email_cim, int telefonszam, string cegnev)
        {
            this.tulid = tulid;
            this.tulajdonos_nev = tulajdonos_nev;
            this.tulajdonos_szemelyiigszam = tulajdonos_szemelyiigszam;
            this.jogositvany_azon = jogositvany_azon;
            this.email_cim = email_cim;
            this.telefonszam = telefonszam;
            this.cegnev = cegnev;
        }

        public void updateTulajdonos(Tulajdonos modified)
        {
            //this.tulid = modified.getId();
            this.tulajdonos_nev = modified.getTulajdonosnev();
            this.tulajdonos_szemelyiigszam = modified.getTulajdonosszemelyiigszam();
            this.jogositvany_azon = modified.getJogositvanyazon();
            this.email_cim = modified.getEmailcim();
            this.telefonszam = modified.getTelefonszam();
            this.cegnev = modified.getCegnev();
        }


        public void setTulId(int tulid)
        {
            this.tulid = tulid;
        }
        public int getTulId()
        {
            return tulid;
        }

        public void setTulajdonosnev(string tulajdonos_nev)
        {
            this.tulajdonos_nev = tulajdonos_nev;
        }
        public string getTulajdonosnev()
        {
            return tulajdonos_nev;
        }

        public void setTulajdonosszemelyiigszam(string tulajdonos_szemelyiigszam)
        {
            this.tulajdonos_szemelyiigszam = tulajdonos_szemelyiigszam;
        }
        public string getTulajdonosszemelyiigszam()
        {
            return tulajdonos_szemelyiigszam;
        }

        public void setJogositvanyazon(int jogositvany_azon)
        {
            this.jogositvany_azon = jogositvany_azon;
        }
        public int getJogositvanyazon()
        {
            return jogositvany_azon;
        }

        public void setEmailcim(string email_cim)
        {
            this.email_cim = email_cim;
        }
        public string getEmailcim()
        {
            return email_cim;
        }

        public void setTelefonszam(int telefonszam)
        {
            this.telefonszam = telefonszam;
        }
        public int getTelefonszam()
        {
            return telefonszam;
        }

        public void setCegnev(string cegnev)
        {
            this.cegnev = cegnev;
        }
        public string getCegnev()
        {
            return cegnev;
        }
    }
}
