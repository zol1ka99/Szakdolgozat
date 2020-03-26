using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdoga_autonyilvantartas.Model;
using Szakdoga_autonyilvantartas.Repository;

namespace Szakdoga_autonyilvantartas.repository.Company
{
    partial class RepositoryDatabaseTableCeg
    {
        private readonly string connectionStringCreate;
        private readonly string connectionString;

        public RepositoryDatabaseTableCeg()
        {
            Connection cs = new Connection();
            connectionStringCreate = cs.getCreateString();
            connectionString = cs.getConnectionString();
        }

        public void createTableCeg()
        {
            string queryUSE = "USE autonyilvantartas";
            string queryCreateTable =
                "CREATE TABLE `autonyilvantartas`.`cegek` ( " +
                "`cegid` INT NOT NULL PRIMARY KEY AUTO_INCREMENT , " +
                "`cegnev` INT(50) NOT NULL , " +
                "`adoszam` INT(13) NOT NULL , " +
                "`varos` VARCHAR(20) NOT NULL , " +
                "`utca` VARCHAR(20) NOT NULL , " +
                "`szam` VARCHAR(7) NOT NULL , " +
                "`ceg_email_cim` VARCHAR(40) NOT NULL";

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Close();
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
                throw new RepositoryException("Tábla létrehozása sikertelen!");
            }
        }

        public void deleteTableCeg()
        {
            string query =
                "USE autonyilvantartas;" +
                "DROP TABLE cegek";

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryExceptionCantDelete("Tábla törlése nem járt sikerrel!");
            }
        }

        public void deleteDataFromTable()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = Ceg.getSQLCommandDeleteAllRecord();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Tesztadatok törlése nem járt sikerrel!");
            }
        }

    }
}
