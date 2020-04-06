using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Szakdoga_autonyilvantartas.Model
{
    public partial class Ceg
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

        /*Validáció bár az adatbáziba nem megy fel rossza adat mert le van kezelve error providerekkel és label ir irja ha hiba van*/


        public bool isValidUpperCaseStartCegnev(string cegnev)
        {
            if (!char.IsUpper(cegnev.ElementAt(0)))
            {
                return false;
            }
            return true;
        }

        public bool isValidCaseStartVaros(string varos)
        {
            if (!char.IsUpper(varos.ElementAt(0)))
            {
                return false;
            }
            return true;
        }

        public bool isValidCaseStartUtca(string utca)
        {
            if (!char.IsUpper(utca.ElementAt(0)))
            {
                return false;
            }
            return true;
        }

        public static bool ValidEmail(string email_cim)
        {
            var regex = new Regex(@"([a-z0-9][-a-z0-9_\+\.]*[a-z0-9])@([a-z0-9][-a-z0-9\.]*[a-z0-9]\.(arpa|root|aero|biz|cat|com|coop|edu|gov|info|int|jobs|mil|mobi|museum|name|net|org|pro|tel|travel|ac|ad|ae|af|ag|ai|al|am|an|ao|aq|ar|as|at|au|aw|ax|az|ba|bb|bd|be|bf|bg|bh|bi|bj|bm|bn|bo|br|bs|bt|bv|bw|by|bz|ca|cc|cd|cf|cg|ch|ci|ck|cl|cm|cn|co|cr|cu|cv|cx|cy|cz|de|dj|dk|dm|do|dz|ec|ee|eg|er|es|et|eu|fi|fj|fk|fm|fo|fr|ga|gb|gd|ge|gf|gg|gh|gi|gl|gm|gn|gp|gq|gr|gs|gt|gu|gw|gy|hk|hm|hn|hr|ht|hu|id|ie|il|im|in|io|iq|ir|is|it|je|jm|jo|jp|ke|kg|kh|ki|km|kn|kr|kw|ky|kz|la|lb|lc|li|lk|lr|ls|lt|lu|lv|ly|ma|mc|md|mg|mh|mk|ml|mm|mn|mo|mp|mq|mr|ms|mt|mu|mv|mw|mx|my|mz|na|nc|ne|nf|ng|ni|nl|no|np|nr|nu|nz|om|pa|pe|pf|pg|ph|pk|pl|pm|pn|pr|ps|pt|pw|py|qa|re|ro|ru|rw|sa|sb|sc|sd|se|sg|sh|si|sj|sk|sl|sm|sn|so|sr|st|su|sv|sy|sz|tc|td|tf|tg|th|tj|tk|tl|tm|tn|to|tp|tr|tt|tv|tw|tz|ua|ug|uk|um|us|uy|uz|va|vc|ve|vg|vi|vn|vu|wf|ws|ye|yt|yu|za|zm|zw)|([0-9]{1,3}\.{3}[0-9]{1,3}))");
            return regex.IsMatch(email_cim);
        }
    }
}

