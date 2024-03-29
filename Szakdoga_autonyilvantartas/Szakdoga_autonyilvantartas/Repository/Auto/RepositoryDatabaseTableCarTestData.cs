﻿using MySql.Data.MySqlClient;
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
										"(16, 'Volkswagen', 'Golf', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Automata', '8')," +
										"(17, 'BMW', '520D', '2018-04-14', 2007000, 'RZT-874', 150000, 'AZR8123665487547T', 'SzGK', 'Benzin', 'Automata', '9')," +
										"(18, 'Opel', 'Astra', '2018-12-16', 2400000, 'OTU-756', 155400, 'AZR8122764987547T', 'SzGK', 'Dízel', 'Manuális', '9')," +
										"(19, 'BMW', 'M5', '2020-02-15', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Automata', '10')," +
										"(20, 'Skoda', 'Fabia', '2005-05-25', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Automata', '10')," +
										"(21, 'BMW', 'X5', '2014-01-18', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Manuális', '11')," +
										"(22, 'Skoda', 'Octavia', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Hibrid', 'Automata', '11')," +
										"(23, 'Skoda', 'Citygo', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Manuális', '12')," +
										"(24, 'BMW', '330I', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Hibrid', 'Automata', '12')," +
										"(25, 'BMW', 'X1', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Automata', '13')," +
										"(26, 'Skoda', 'Karoq', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Manuális', '13')," +
										"(27, 'BMW', 'X7', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Hibrid', 'Automata', '14')," +
										"(28, 'Skoda', 'Fabia', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Automata', '14')," +
										"(29, 'Audi', 'A1', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Manuális', '15')," +
										"(30, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(31, 'BMW', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(32, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(33, 'Skoda', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(34, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(35, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(36, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(37, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(38, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(39, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(40, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(41, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(42, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(43, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(44, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(45, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(46, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(47, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(48, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(49, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(50, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(51, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(52, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(53, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(54, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(55, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(56, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(57, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(58, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(59, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(60, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', '15')," +
										"(61, 'Volkswagen', 'Golf', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Automata', '16')";
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
