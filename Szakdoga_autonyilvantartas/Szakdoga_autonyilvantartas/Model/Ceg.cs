using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdoga_autonyilvantartas.Model
{
    partial class Ceg
    {
        private int cegid;
        private string cegnev;
        private int adoszam;
        private string varos;
        private string utca;
        private int szam;
        private string ceg_email_cim;

        public Ceg(int cegid, string cegnev, int adoszam, string varos, string utca, int szam, string ceg_email_cim)
        {
            this.cegid = cegid;
            this.cegnev = cegnev;
            this.adoszam = adoszam;
            this.varos = varos;
            this.utca = utca;
            this.szam = szam;
            this.ceg_email_cim = ceg_email_cim;
        }

        public void updateCeg(Ceg modified)
        {
            this.cegnev = modified.getCegnev();
            this.adoszam = modified.getAdoszam();
            this.varos = modified.getVaros();
            this.utca = modified.getUtca();
            this.szam = modified.getSzam();
            this.ceg_email_cim = modified.getCegEmailCim();
        }

        public void setCegId(int cegid)
        {
            this.cegid = cegid;
        }
        public int getCegId()
        {
            return cegid;
        }

        public void setCegnev(string cegnev)
        {
            this.cegnev = cegnev;
        }
        public string getCegnev()
        {
            return cegnev;
        }

        public void setAdoszam(int adoszam)
        {
            this.adoszam = adoszam;
        }
        public int getAdoszam()
        {
            return adoszam;
        }

        public void setVaros(string varos)
        {
            this.varos = varos;
        }
        public string getVaros()
        {
            return varos;
        }

        public void setUtca(string utca)
        {
            this.utca = utca;
        }
        public string getUtca()
        {
            return utca;
        }

        public void setSzam(int szam)
        {
            this.szam = szam;
        }
        public int getSzam()
        {
            return szam;
        }

        public void setCegEmailCim(string ceg_email_cim)
        {
            this.ceg_email_cim = ceg_email_cim;
        }
        public string getCegEmailCim()
        {
            return ceg_email_cim;
        }

    }
}
