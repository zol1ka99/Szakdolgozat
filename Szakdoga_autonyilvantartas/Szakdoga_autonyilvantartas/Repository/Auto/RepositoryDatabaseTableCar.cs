using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdoga_autonyilvantartas.Model;
using Szakdoga_autonyilvantartas.Repository;

namespace Szakdoga_autonyilvantartas.repository.Auto
{
    partial class RepositoryDatabaseTableCar
    {
        private readonly string connectionStringCreate;
        private readonly string connectionString;

        public RepositoryDatabaseTableCar()
        {
            Connection cs = new Connection();
            connectionStringCreate = cs.getCreateString();
            connectionString = cs.getConnectionString();
        }
        public void createTableCar()
        {
            string queryUSE = "USER autonyilvantartas";
            string queryCreateTable =
                "CREATE TABLE `cars` ( " +
                "`id` INT NOT NULL AUTO_INCREMENT , " +
                "`marka` VARCHAR(20) NOT NULL , " +
                "`tipus` VARCHAR(30) NOT NULL , " +
                "`gyartasi_ev` VARCHAR(15) NOT NULL , " +
                "`vetelar` INT(15) NULL , " +
                "`rendszam` VARCHAR(10) NOT NULL , " +
                "`kilometeroraallas` INT(10) NULL , " +
                "`alvazszam` VARCHAR(20) NOT NULL , " +
                "`gepkocsi_tipusa` VARCHAR(5) NOT NULL , " +
                "`uzemanyag` VARCHAR(15) NOT NULL , " +
                "`sebessegvalto_tipusa` VARCHAR(10) NOT NULL , " +
                "`tulajdonos_nev` VARCHAR(50) NOT NULL , " +
                "PRIMARY KEY (`id`)) ENGINE = InnoDB;";

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

        public void deleteTableCar()
        {
            string query =
                "USE autonyilvantartas; " +
                "DROP TABLE cars;";

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
                throw new RepositoryException("Tábla törlése nem járt sikerrel!");
            }
        }

        public void deleteDataFromTable()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = Car.getSQLCommandDeleteAllRecord();
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
