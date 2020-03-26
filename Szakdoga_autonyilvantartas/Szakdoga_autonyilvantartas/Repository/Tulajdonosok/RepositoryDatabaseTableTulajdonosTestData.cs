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
        public void fullTulajdonosokWithTestDataFromSQLCommand()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                string query =
                    "";


                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Tesztadaotok feltöltése sikertelen");
            }
        }
    }
}
