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
    }
}
