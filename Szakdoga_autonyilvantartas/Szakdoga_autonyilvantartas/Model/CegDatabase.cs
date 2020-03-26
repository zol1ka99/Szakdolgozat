using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdoga_autonyilvantartas.model
{
    partial class Ceg
    {
        public string getInsert()
        {

        }

        public string getUpdate(int cegid)
        {

        }

        public static string getSQLCommandDeleteALlRecord()
        {
            return "DELETE FROM cegek";
        }

        public static string getSQLCommandGetAllRecord()
        {
            return "SELECT * FROM cegek INNER JOIN tulajdonosok ON cegek.cegid = tulajdonosok.cegid";
        }
    }
}
