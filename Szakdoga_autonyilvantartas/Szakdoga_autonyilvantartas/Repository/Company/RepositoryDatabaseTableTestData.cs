using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdoga_autonyilvantartas.Repository;

namespace Szakdoga_autonyilvantartas.repository.Company
{
    partial class RepositoryDatabaseTableCeg
    {
        public void fillCegekWithTestDataFromSQLCommand()
        {
			MySqlConnection connection = new MySqlConnection(connectionString);

			try
			{
				connection.Open();

				string query =
					"INSERT IGNORE INTO `cegek` (`cegid`, `cegnev`, `adoszam`, `varos`, `utca`, `szam`, `ceg_email_cim`) VALUES " +
										"(1, 'Test kft', 123456, 'Szeged', 'Valami utca', 12, 'test1@gmail.com')," +
										"(2, 'Test2 kft', 765344, 'Deszk', 'Valami1 utca', 14, 'test2@gmail.com')," +
										"(3, 'Test3 kft', 873456, 'Budapest', 'Valami2 utca', 16, 'test3@gmail.com')," +
										"(4, 'Test4 kft', 878496, 'Deszk', 'Valami3 utca', 20, 'test4@gmail.com')," +
										"(5, 'Test5 kft', 878496, 'Szeged', 'Valami3 utca', 20, 'test5@gmail.com')," +
										"(6, 'Test6 kft', 878496, 'Pécs', 'Valami3 utca', 20, 'test6@gmail.com')," +
										"(7, 'Test7 kft', 878496, 'Szeged', 'Valami3 utca', 20, 'test7@gmail.com')," +
										"(8, 'Test8 kft', 878496, 'Budapest', 'Valami3 utca', 20, 'test8@gmail.com')";


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
