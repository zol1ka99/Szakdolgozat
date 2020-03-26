using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdoga_autonyilvantartas.Model;
using Szakdoga_autonyilvantartas.Repository;

namespace Szakdoga_autonyilvantartas.repository.Company
{
    partial class RepositoryDatabaseTableCeg
    {
        public List<Ceg> getCegekFromDatabase()
        {
            List<Ceg> cegek = new List<Ceg>();
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
                    int cegid = Convert.ToInt32(dr["cegid"]);
                    string cegnev = dr["cegnev"].ToString();
                    int adoszam = Convert.ToInt32(dr["adoszam"]);
                    string varos = dr["varos"].ToString();
                    string utca = dr["utca"].ToString();
                    int szam = Convert.ToInt32(dr["szam"]);
                    string ceg_email_cim = dr["ceg_email_cim"].ToString();

                    Ceg c = new Ceg(cegid, cegnev, adoszam, varos, utca, szam, ceg_email_cim);
                    cegek.Add(c);
                }



            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Cég adatok beolvasása az adatbázisból sikertelen!");
            }
            return cegek;
        }

        public void deleteCegFromDatabase(int cegid)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "DELETE FROM cegek WHERE id=" + cegid;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(cegid + "azonosító jelű cég törlése nem sikerült!");
                throw new RepositoryException("Sikertelen törlés az adatbázisból!");
            }
        }

        public void updateCegInDatabase(int cegid,Ceg modified)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = modified.getUpdate(cegid);
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(cegid + "azonosító jelű cég módosítása nem sikerült!");
                throw new RepositoryException("Sikertelen módosítás az adatbázisban!");
            }
        }

        public void insertCegToDatabase(Ceg ujCeg)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = ujCeg.getInsert();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(ujCeg + "cég hozzáadása az adatbázishoz nem sikerült!");
                throw new RepositoryException("Sikertelen beszúrás az adatbázisba!");
            }
        }
    }
}
