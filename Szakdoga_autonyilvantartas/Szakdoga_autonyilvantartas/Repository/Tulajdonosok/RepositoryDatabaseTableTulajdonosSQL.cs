using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdoga_autonyilvantartas.model;
using Szakdoga_autonyilvantartas.Repository;

namespace Szakdoga_autonyilvantartas.repository.Tulajdonosok
{
    partial class RepositoryDatabaseTableTulajdonos
    {
        public List<Tulajdonos> getTulajdonosokFromDatabase()
        {
            List<Tulajdonos> tulajdonosok = new List<Tulajdonos>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = Tulajdonos.getSQLCommandGetAllRecord();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int tulid = Convert.ToInt32(dr["tulid"]);
                    string tulajdonos_nev = dr["tulajdonos_nev"].ToString();
                    string tulajdonos_szemelyiigszam = dr["tulajdonos_szemelyiigszam"].ToString();
                    int jogositvany_azon = Convert.ToInt32(dr["jogositvany_azon"]);
                    string email_cim = dr["email_cim"].ToString();
                    int telefonszam = Convert.ToInt32(dr["telefonszam"]);
                    string cegnev = dr["cegnev"].ToString();

                    Tulajdonos c = new Tulajdonos(tulid, tulajdonos_nev, tulajdonos_szemelyiigszam, jogositvany_azon, email_cim, telefonszam, cegnev);
                    tulajdonosok.Add(c);
                }
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("A tulajdonos adatok beolvasása az adatbázisból sikertelen!");
            }
            return tulajdonosok;
        }

        public void deleteTulajdonosFromDatabase(int tulid)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "DELETE FROM tulajdonosok WHERE=" + tulid;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(tulid + "azonosító jelű tulajdonos törlése nem sikerült!");
                throw new RepositoryException("Sikertelen törlés az adatbázisból!");
            }
        }

        public void updateTulajdonosInDatabase(int tulid, Tulajdonos modified)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = modified.getUpdate(tulid);
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(tulid + "azonosító jelű tulajdonos módosítása nem sikerült!");
                throw new RepositoryException("Sikertelen módosítás az adatbázisban!");
            }
        }

        public void insertTulajdonosToDatabase(Tulajdonos ujTulajdonos)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = ujTulajdonos.getInsert();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(ujTulajdonos + "tulajdonos hozzáadása az adatbázishoz nem sikerült!");
                throw new RepositoryException("Sikertelen beszúrás az adatbázisba!");
            }
        }

    }
}
