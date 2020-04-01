using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szakdoga_autonyilvantartas.Repository;
using Szakdoga_autonyilvantartas.Model;
using MySql.Data.MySqlClient;

namespace Szakdoga_autonyilvantartas
{
    public partial class Form1Login : Form
    {
        //Tarolo felhasznalok = new Tarolo();

        public Form1Login()
        {
            InitializeComponent();
            beallitKezdoLogin();
            adatbazisesfelhasznaloktablaletrehozasa();
        }

        private void adatbazisesfelhasznaloktablaletrehozasa()
        {
            RepositoryDatabase rd = new RepositoryDatabase();
            rd.createDatabase();
            RepositoryTableFelhasznalok rtf = new RepositoryTableFelhasznalok();
            rtf.createTableFelhasznalok();
            rtf.fillFelhasznalokWithTestDataFromSQLCommand();

        }
        private void beallitKezdoLogin()
        {
            this.Size = new Size(700, 400);
            this.Text = "Login To Car Docket (Beta)";
        }

        int i;

        private void buttonBelepes_Click(object sender, EventArgs e)
        {
            Connection cs = new Connection();
            i = 0;
            string felhasznalonev = textBoxFelhasznalonev.Text;
            string jelszo = textBoxJelszo.Text;
            MySqlConnection connection = new MySqlConnection(cs.getConnectionString());
            connection.Open();
            string query = "SELECT * FROM felhasznalok WHERE felhasznalonev ='"+felhasznalonev+"' AND jelszo='"+jelszo+"';";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                labelHibauzenet.Text = "Rossz felhasználónév vagy jelszó!";
                textBoxFelhasznalonev.Text = "";
                textBoxJelszo.Text = "";
            }
            else
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
        }

        private void buttonKilepes_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztosan bezárja a programot?","Bezárás",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                Application.Exit();
            }
        }
    }
}
