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
            return"";
        }

        public string getUpdate(int cegid)
        {
            return"";
        }

        public static string getSQLCommandDeleteAllRecord()
        {
            return "DELETE FROM cegek";
        }

        public static string getSQLCommandGetAllRecord()
        {
            return "SELECT * FROM cegek INNER JOIN tulajdonosok ON cegek.cegid = tulajdonosok.cegid";
        }
    }
}
