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
        public List<Car> getCarsFromDatabase()
        {
            List<Car> cars = new List<Car>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = Car.getSQLCommandGetAllRecord();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["id"]);
                    string marka = dr["marka"].ToString();
                    string tipus = dr["tipus"].ToString();
                    string gyartasi_ev = dr["gyartasi_ev"].ToString();
                    int vetelar = Convert.ToInt32(dr["vetelar"]);
                    string rendszam = dr["rendszam"].ToString();
                    int kilometeroraallas = Convert.ToInt32(dr["kilometeroraallas"]);
                    string alvazszam = dr["alvazszam"].ToString();
                    string gepkocsi_tipusa = dr["gepkocsi_tipusa"].ToString();
                    string uzemanyag = dr["uzemanyag"].ToString();
                    string sebessegvalto_tipusa = dr["sebessegvalto_tipusa"].ToString();
                    string tulajdonos_nev = dr["tulajdonos_nev"].ToString();

                    Car c = new Car(id, marka, tipus, gyartasi_ev, vetelar, rendszam, kilometeroraallas, alvazszam, gepkocsi_tipusa, uzemanyag, sebessegvalto_tipusa, tulajdonos_nev);
                    cars.Add(c);
                }


            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Autó adatok beolvasása az adatbázisból nem sikerült!");
            }

            return cars;
        }

        public void deleteCarFromDatabase(int id)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "DELETE FROM cars WHERE id=" + id;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(id + "azonosító jelű autó törlése nem sikerült!");
                throw new RepositoryException("Sikertelen törlés az adatbázisból!");
            }
        }

        public void updateCarInDatabase(int id,Car modified)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = modified.getUpdate(id);
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(id + "azonosító jelű autó módosítása nem sikerült!");
                throw new RepositoryException("Sikertelen módosítás az adatbázisban!");
            }
        }

        public void insertCarToDatabase(Car ujCar)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = ujCar.getInsert();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(ujCar + "autó hozzáadása az adatbázishoz nem sikerült!");
                throw new RepositoryException("Sikertelen beszúrás az adatbázisból!");
            }
        }
    }
}
