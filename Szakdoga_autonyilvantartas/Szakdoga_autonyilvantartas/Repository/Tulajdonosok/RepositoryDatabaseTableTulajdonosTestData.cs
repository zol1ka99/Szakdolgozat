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
                    "(1, 'Kiss Ferenc1', '1234', 12351, 'feribacsi@valami1.com', 202663557, 1)," +
                    "(2, 'Kiss Ferenc2', '1234', 12351, 'feribacsi@valami2.com', 202623457, 1)," +
                    "(3, 'Kiss Ferenc3', '1234', 12351, 'feribacsi@valami3.com', 202606547, 2)," +
                    "(4, 'Kiss Ferenc4', '1234', 12351, 'feribacsi@valami4.com', 207756655, 2)," +
                    "(5, 'Kiss Ferenc5', '1234', 12351, 'feribacsi@valami5.com', 207756655, 3)," +
                    "(6, 'Kiss Ferenc6', '1234', 12351, 'feribacsi@valami6.com', 207756655, 3)," +
                    "(7, 'Kiss Ferenc7', '1234', 12351, 'feribacsi@valami7.com', 207756655, 4)," +
                    "(8, 'Kiss Ferenc8', '1234', 12351, 'feribacsi@valami8.com', 207756655, 4)";


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
