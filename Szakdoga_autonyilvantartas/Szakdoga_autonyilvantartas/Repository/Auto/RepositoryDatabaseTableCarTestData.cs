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
					"INSERT IGNORE INTO `cars` (`id`, `marka`, `tipus`, `gyartasi_ev`, `vetelar`, `rendszam`, `kilometeroraallas`, `alvazszam`, `gepkocsi_tipusa`, `uzemanyag`, `sebessegvalto_tipusa`, `tulajdonos_nev`) VALUES " +
										"(1, 'Audi', 'A5', '2018-01-02', 2005000, 'RSF-123', 15000, 'AZR8123654987547T', 'SzGK', 'Benzin', 'Automata', 'Kiss Ferenc')," +
										"(2, 'BMW', '520D', '2018-04-14', 2007000, 'RZT-874', 150000, 'AZR8123665487547T', 'SzGK', 'Benzin', 'Automata', 'Tóth Ferenc')," +
										"(3, 'Opel', 'Astra', '2018-12-16', 2400000, 'OTU-756', 155400, 'AZR8122764987547T', 'SzGK', 'Benzin', 'Automata', 'Zuhany Ferenc')," +
										"(4, 'Skoda', 'Fabia', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Automata', 'Kovács Ferenc')";
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
