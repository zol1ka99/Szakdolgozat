using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdoga_autonyilvantartas.Repository;

namespace Szakdoga_autonyilvantartas.repository.Tulajdonosok
{
    partial class RepositoryDatabaseTableTulajdonos
    {
        public void fillTulajdonosokWithTestDataFromSQLCommand()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                string query =
                    "INSERT IGNORE INTO `tulajdonosok` (`tulid`, `tulajdonos_nev`, `tulajdonos_szemelyiigszam`, `jogositvany_azon`, `email_cim`, `telefonszam`, `cegid`) VALUES " +
                    "(1, 'Kiss Ferenc', '1234', 12351, 'feribacsi@valami.com', 202663557, 1)," +
                    "(2, 'Kiss Ferencegy', '1234', 12351, 'feribacsi@valami1.com', 202623457, 2)," +
                    "(3, 'Kiss Ferencketto', '1234', 12351, 'feribacsi@valami2.com', 202606547, 3)," +
                    "(4, 'Kiss Ferencharom', '1234', 12351, 'feribacsi@valami3.com', 207756655, 4);";


                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Tesztadatok feltöltése sikertelen");
            }
        }
    }
}
