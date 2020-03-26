using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdoga_autonyilvantartas.model
{
    partial class Tulajdonos
    {
        public string getInsert()
        {

        }

        public string getUpdate(int tulid)
        {

        }

        public static string getSQLCommandDeleteAllRecord()
        {
            return "DELETE FROM tulajdonosok";
        }
        public static string getSQLCommandGetAllRecord()
        {
            return "SELECT * FROM tulajdonosok INNER JOIN cegek ON tulajdonosok.cegid = cegek.cegid";
        }
    }
}
