using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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


        /*Validáció bár az adatbáziba nem megy fel rossza adat mert le van kezelve error providerekkel és label ir irja ha hiba van*/
        public bool isValidUpperCaseTulajNev(string tulajdonos_nev)
        {
            if (!char.IsUpper(tulajdonos_nev.ElementAt(0)))
            {
                return false;
            }
            return true;
        }



        private static bool ValidEmail(string email_cim)
        {
            var regex = new Regex(@"([a-z0-9][-a-z0-9_\+\.]*[a-z0-9])@([a-z0-9][-a-z0-9\.]*[a-z0-9]\.(arpa|root|aero|biz|cat|com|coop|edu|gov|info|int|jobs|mil|mobi|museum|name|net|org|pro|tel|travel|ac|ad|ae|af|ag|ai|al|am|an|ao|aq|ar|as|at|au|aw|ax|az|ba|bb|bd|be|bf|bg|bh|bi|bj|bm|bn|bo|br|bs|bt|bv|bw|by|bz|ca|cc|cd|cf|cg|ch|ci|ck|cl|cm|cn|co|cr|cu|cv|cx|cy|cz|de|dj|dk|dm|do|dz|ec|ee|eg|er|es|et|eu|fi|fj|fk|fm|fo|fr|ga|gb|gd|ge|gf|gg|gh|gi|gl|gm|gn|gp|gq|gr|gs|gt|gu|gw|gy|hk|hm|hn|hr|ht|hu|id|ie|il|im|in|io|iq|ir|is|it|je|jm|jo|jp|ke|kg|kh|ki|km|kn|kr|kw|ky|kz|la|lb|lc|li|lk|lr|ls|lt|lu|lv|ly|ma|mc|md|mg|mh|mk|ml|mm|mn|mo|mp|mq|mr|ms|mt|mu|mv|mw|mx|my|mz|na|nc|ne|nf|ng|ni|nl|no|np|nr|nu|nz|om|pa|pe|pf|pg|ph|pk|pl|pm|pn|pr|ps|pt|pw|py|qa|re|ro|ru|rw|sa|sb|sc|sd|se|sg|sh|si|sj|sk|sl|sm|sn|so|sr|st|su|sv|sy|sz|tc|td|tf|tg|th|tj|tk|tl|tm|tn|to|tp|tr|tt|tv|tw|tz|ua|ug|uk|um|us|uy|uz|va|vc|ve|vg|vi|vn|vu|wf|ws|ye|yt|yu|za|zm|zw)|([0-9]{1,3}\.{3}[0-9]{1,3}))");
            return regex.IsMatch(email_cim);
        }
    }
}
