using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdoga_autonyilvantartas.Model
{
    partial class Tulajdonos
    {
        public string getInsert()
        {
            return "INSERT INTO `tulajdonosok` (`tulid`, `tulajdonos_nev`, `tulajdonos_szemelyiigszam`, `jogositvany_azon`, `email_cim`, `telefonszam`, `cegid`) " +
                " VALUES('" + getTulId() + "', '" + getTulajdonosnev() + "', '" + getTulajdonosszemelyiigszam() + "', '" + getJogositvanyazon() + "', '" + getEmailcim() + "', '" + getTelefonszam() + "', (SELECT cegid FROM cegek WHERE cegek.cegnev ='" + getCegnev()+"'));";
        }

        public string getUpdate(int tulid)
        {
            return "UPDATE `tulajdonosok` SET `tulajdonos_nev` = '" + getTulajdonosnev() + "', `tulajdonos_szemelyiigszam` = '" + getTulajdonosszemelyiigszam() + "', `jogositvany_azon` = '" + getJogositvanyazon() + "', `email_cim` = '" + getEmailcim() + "', `telefonszam` = '" + getTelefonszam() + "', cegid=(SELECT cegid FROM cegek WHERE cegek.cegnev ='" + getCegnev() + "') WHERE `tulajdonosok`.`tulid` = '" + getTulId()+"';";
        }

        public static string getSQLCommandDeleteAllRecord()
        {
            return "DELETE FROM tulajdonosok";
        }
        public static string getSQLCommandGetAllRecord()
        {
            return "SELECT `tulid`,`tulajdonos_nev`,`tulajdonos_szemelyiigszam`,`jogositvany_azon`,`email_cim`,`telefonszam`, cegek.cegnev FROM tulajdonosok INNER JOIN cegek ON tulajdonosok.cegid = cegek.cegid";
        }
    }
}
