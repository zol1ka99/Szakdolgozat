using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdoga_autonyilvantartas.Model;
using Szakdoga_autonyilvantartas.Repository;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Szakdoga_autonyilvantartas.Repository
{
    class RepositoryDatabase
    {
        private readonly string connectionStringCreate;
        private readonly string connectionString;

        /// <summary>
        /// Konstruktorok
        /// </summary>
        public RepositoryDatabase()
        {
            Connection cs = new Connection();
            connectionStringCreate = cs.getCreateString();
            connectionString = cs.getConnectionString();
        }

        /// <summary>
        /// Adatbázis létrehozása
        /// </summary>
        public void createDatabase()
        {
            string query =
                "CREATE DATABASE IF NOT EXISTS autonyilvantartas " +
                "DEFAULT CHARACTER SET utf8 " +
                "COLLATE utf8_hungarian_ci ";

            MySqlConnection connection = new MySqlConnection(connectionStringCreate);
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
                throw new RepositoryException("Az adatbázis létrehozása nem sikerült vagy már létezik!");
            }
        }

        public void deleteDatabase()
        {
            string query =
                "DROP DATABASE autonyilvantartas;";

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
                throw new RepositoryException("Adatbázis törlése nem sikerült!");
            }
        }

    }
}
