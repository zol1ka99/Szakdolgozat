using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using Szakdoga_autonyilvantartas.Model;
using Szakdoga_autonyilvantartas.Repository;

namespace Szakdoga_autonyilvantartas.repository.Auto
{
	partial class RepositoryDatabaseTableCar
	{
		public void fillCarsWithTestDataFromSQLCommand()
		{



			MySqlConnection connection = new MySqlConnection(connectionString);

			try
			{
				connection.Open();

				string query =
					"INSERT IGNORE INTO `cars` (`id`, `marka`, `tipus`, `gyartasi_ev`, `vetelar`, `rendszam`, `kilometeroraallas`, `alvazszam`, `gepkocsi_tipusa`, `uzemanyag`, `sebessegvalto_tipusa`, `tulid`) VALUES " +
										"(1, 'Audi', 'A5', '2018-01-02', 2005000, 'RSF-123', 15000, 'AZR8123654987547T', 'SzGK', 'Benzin', 'Automata', '1')," +
										"(2, 'BMW', '520D', '2018-04-14', 2007000, 'RZT-874', 150000, 'AZR8123665487547T', 'SzGK', 'Benzin', 'Automata', '1')," +
										"(3, 'Opel', 'Astra', '2018-12-16', 2400000, 'OTU-756', 155400, 'AZR8122764987547T', 'SzGK', 'Dízel', 'Manuális', '2')," +
										"(4, 'BMW', 'M5', '2020-02-15', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Automata', '2')," +
										"(5, 'Skoda', 'Fabia', '2005-05-25', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Automata', '3')," +
										"(6, 'BMW', 'X5', '2014-01-18', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Manuális', '3')," +
										"(7, 'Skoda', 'Octavia', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Hibrid', 'Automata', '4')," +
										"(8, 'Skoda', 'Citygo', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Manuális', '4')," +
										"(9, 'BMW', '330I', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Hibrid', 'Automata', '5')," +
										"(10, 'BMW', 'X1', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Automata', '5')," +
										"(11, 'Skoda', 'Karoq', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Manuális', '6')," +
										"(12, 'BMW', 'X7', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Hibrid', 'Automata', '6')," +
										"(13, 'Skoda', 'Fabia', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Automata', '7')," +
										"(14, 'Audi', 'A1', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Manuális', '7')," +
										"(15, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '8')," +
										"(16, 'Volkswagen', 'Golf', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Automata', '8')";
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
