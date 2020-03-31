using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdoga_autonyilvantartas.Model
{
    partial class Car
    {
        public string getInsert()
        {
            return
                "INSERT INTO `cars` (`id`, `marka`, `tipus`, `gyartasi_ev`, `vetelar`, `rendszam`, `kilometeroraallas`, `alvazszam`, `gepkocsi_tipusa`, `uzemanyag`, `sebessegvalto_tipusa`, `tulid`)" +
                "VALUES ('"+getId()+"', '"+getMarka()+"', '"+getTipus()+"', '"+getGyartasiev()+"', '"+getVetelar()+"', '"+getRendszam()+"', '"+getKilometeroraallas()+"', '"+getAlvazszam()+"', '"+getGepkocsiTipusa()+"', '"+getUzemanyag()+"', '"+getSebessegvaltoTipusa()+"', (SELECT tulid FROM tulajdonosok WHERE tulajdonosok.tulajdonos_nev = '"+getTulajdonosNev()+"'))";
        }

        public string getUpdate(int id)
        {
            return "UPDATE `cars` SET `marka` = '"+getMarka()+"', `tipus` = '"+getTipus()+"', `gyartasi_ev` = '"+getGyartasiev()+"', `vetelar` = '"+getVetelar()+"', `rendszam` = '"+getRendszam()+"', `kilometeroraallas` = '"+getKilometeroraallas()+"', `alvazszam` = '"+getAlvazszam()+"', `gepkocsi_tipusa` = '"+getGepkocsiTipusa()+"', `uzemanyag` = '"+getUzemanyag()+"', `sebessegvalto_tipusa` = '"+getSebessegvaltoTipusa()+"', tulid=(SELECT tulid FROM tulajdonosok WHERE tulajdonosok.tulajdonos_nev ='"+getTulajdonosNev()+"') WHERE `cars`.`id` = " + id;
        }

        public static string getSQLCommandDeleteAllRecord()
        {
            return "DELETE FROM cars";
        }

        public static string getSQLCommandGetAllRecord()
        {
            return "SELECT * FROM cars INNER JOIN tulajdonosok ON cars.tulid = tulajdonosok.tulid";
        }
    }
}
