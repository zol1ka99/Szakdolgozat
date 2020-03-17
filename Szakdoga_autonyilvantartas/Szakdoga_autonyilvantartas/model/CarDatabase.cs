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
                "INSERT INTO `cars`(``)";
        }

        public static string getSQLCommandDeleteAllRecord()
        {
            return "DELETE FROM cars";
        }

        public static string getSQLCommandGetAllRecord()
        {
            return "SELECT * FROM cars";
        }
    }
}
