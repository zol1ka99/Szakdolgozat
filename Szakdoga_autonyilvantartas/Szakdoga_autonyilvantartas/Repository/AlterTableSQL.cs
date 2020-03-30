using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdoga_autonyilvantartas.Model;
using Szakdoga_autonyilvantartas.Repository;

namespace Szakdoga_autonyilvantartas.repository
{
    partial class AlterTableSQL
    {
        private readonly string connectionStringCreate;
        private readonly string connectionString;

        public AlterTableSQL()
        {
            Connection cs = new Connection();
            connectionStringCreate = cs.getCreateString();
            connectionString = cs.getConnectionString();
        }

        public void createAlterTable()
        {
            string queryUSE = "USE autonyilvantartas;";
            string queryAlterTable =
                "ALTER TABLE `cars` ADD CONSTRAINT `cars_ibfk_1` FOREIGN KEY(`tulid`) REFERENCES `tulajdonosok` (`tulid`);" +
                "ALTER TABLE `tulajdonosok` ADD CONSTRAINT `tulajdonosok_ibfk_1` FOREIGN KEY(`cegid`) REFERENCES `cegek` (`cegid`);";

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();
                MySqlCommand cmdCreateTable = new MySqlCommand(queryAlterTable, connection);
                cmdCreateTable.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Alter Table sikertelen");
            }
        }
    }
}
