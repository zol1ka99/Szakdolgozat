using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdoga_autonyilvantartas.Model;
using Szakdoga_autonyilvantartas.Repository;
using Szakdoga_autonyilvantartas.model;

namespace Szakdoga_autonyilvantartas.repository.Tulajdonosok
{
    partial class RepositoryDatabaseTableTulajdonos
    {
        private readonly string connectionStringCreate;
        private readonly string connectionString;

        public RepositoryDatabaseTableTulajdonos()
        {
            Connection cs = new Connection();
            connectionStringCreate = cs.getCreateString();
            connectionString = cs.getConnectionString();
        }

        public void createTableTulajdonos()
        {
            string queryUSE = "USE autonyilvantartas";
            string queryCreateTable =
                "CREATE TABLE `autonyilvantartas`.`tulajdonosok` (" +
                " `tulid` INT NOT NULL PRIMARY KEY AUTO_INCREMENT , " +
                "`tulajdonos_nev` VARCHAR(50) NOT NULL , " +
                "`tulajdonos_szemilyiigszam` VARCHAR(8) NOT NULL , " +
                "`jogositvany_azon` INT NOT NULL , " +
                "`email_cim` VARCHAR(40) NOT NULL , " +
                "`telefonszam` INT NOT NULL)";

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
                throw new RepositoryException("A tábla létrehozása nem járt sikerrel!");
            }
        }

        public void deleteTableTulajdonos()
        {
            string query =
                "USE autonyilvantartas;" +
                "DROP TABLE tulajdonosok;";

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
                throw new RepositoryExceptionCantDelete("A tábla törlése sikertelen");
            }
        }

        public void deleteDataFromTable()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = Tulajdonos.getSQLCommandDeleteAllRecord();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Tesztadatok törlése sikertelen!");
            }
        }

    }
}
