using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdoga_autonyilvantartas.Model;
using Szakdoga_autonyilvantartas.Repository;

namespace Szakdoga_autonyilvantartas
{
    class RepositoryTableFelhasznalok
    {
        private readonly string connectionStringCreate;
        private readonly string connectionString;

        public RepositoryTableFelhasznalok()
        {
            Connection cs = new Connection();
            connectionStringCreate = cs.getCreateString();
            connectionString = cs.getConnectionString();
        }
        public void createTableFelhasznalok()
        {
            string queryUSE = "USE autonyilvantartas;";
            string queryCreateTable =
                "CREATE TABLE IF NOT EXISTS `felhasznalok` ( " +
                "`id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT , " +
                "`felhasznalonev` VARCHAR(30) NOT NULL , " +
                "`jelszo` VARCHAR(30) NOT NULL, " +
                "`emailcimfelhasznalo` VARCHAR(30) NOT NULL)";

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();
                MySqlCommand cmdCreateTable = new MySqlCommand(queryCreateTable, connection);
                cmdCreateTable.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Tábla létrehozása nem járt sikerrel!");
            }
        }

        public void fillFelhasznalokWithTestDataFromSQLCommand()
        {



            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                string query =
                    "INSERT IGNORE INTO `felhasznalok` (`id`, `felhasznalonev`, `jelszo`, `emailcimfelhasznalo`) VALUES " +
                                        "(1, 'admin', 'admin', 'proba1@gmail.com')," +
                                        "(2, 'Teszt1', '1234', 'proba2@gmail.com')," +
                                        "(3, 'Teszt2', '1234', 'proba3@gmail.com')," +
                                        "(4, 'Teszt3', '1234', 'proba4@gmail.com')";
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
