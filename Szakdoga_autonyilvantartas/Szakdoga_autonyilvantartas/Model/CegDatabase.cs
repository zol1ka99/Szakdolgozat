using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdoga_autonyilvantartas.Model
{
    partial class Ceg
    {
        public string getInsert()
        {
            return "INSERT INTO `cegek` (`cegid`, `cegnev`, `adoszam`, `varos`, `utca`, `szam`, `ceg_email_cim`) " +
                " VALUES ('"+getCegId()+"', '"+getCegnev()+"', '"+getAdoszam()+"', '"+getVaros()+"', '"+getUtca()+"', '"+getSzam()+"', '"+getCegEmailCim()+"');";
        }

        public string getUpdate(int cegid)
        {
            return "UPDATE `cegek` SET `cegnev` = '"+getCegnev()+"', `adoszam` = '"+getAdoszam()+"', `varos` = '"+getVaros()+"', `utca` = '"+getUtca()+"', `szam` = '"+getSzam()+"' WHERE `cegek`.`cegid` = " + cegid;
        }

        public static string getSQLCommandDeleteAllRecord()
        {
            return "DELETE FROM cegek";
        }

        public static string getSQLCommandGetAllRecord()
        {
            return "SELECT * FROM cegek"; 
        }
    }
}
