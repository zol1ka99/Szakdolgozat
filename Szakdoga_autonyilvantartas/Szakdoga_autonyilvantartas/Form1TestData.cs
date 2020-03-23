using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Szakdoga_autonyilvantartas.Model;
using Szakdoga_autonyilvantartas.Repository;
using Szakdoga_autonyilvantartas.repository.Auto;

namespace Szakdoga_autonyilvantartas
{
    public partial class Form1 : Form
    {
        RepositoryDatabase rd = new RepositoryDatabase();
        RepositoryDatabaseTableCar rdCar = new RepositoryDatabaseTableCar();

        private void torolHibauzenetet()
        {
            toolStripLabelHibauzenet.ForeColor = Color.Black;
            toolStripLabelHibauzenet.Text = "";
        }

        private void kiirHibauzenetet(string hibauzenet)
        {
            toolStripLabelHibauzenet.ForeColor = Color.Red;  //toolstrip label oldalaljára odarakni
            toolStripLabelHibauzenet.Text = hibauzenet;
        }
        private void adatbázisLétrehozásaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                torolHibauzenetet();
                rd.createDatabase();
            }
            catch (Exception ex)
            {
                kiirHibauzenetet("Adatbázis létrehozása ismeretlen okokból nem sikerült!");
            }
        }

        private void törölAdatbázistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                torolHibauzenetet();
                rd.deleteDatabase();
            }
            catch (Exception ex)
            {
                kiirHibauzenetet("Adatbázis törlése ismeretlen okokból nem sikerült!");
            }
        }

        private void feltöltésTesztadatokkalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                torolHibauzenetet();

                //táblák létrehozása
                rdCar.createTableCar();

                //tesztadatok feltöltése adatbázisba
                rdCar.fillCarsWithTestDataFromSQLCommand();

                //adatbázisból listák feltöltése
                cars.setAutok(rdCar.getCarsFromDatabaseTable());
            }
            catch (Exception ex)
            {
                kiirHibauzenetet("Tesztadatok feltöltése sikertelen!");
            }
        }

        private void törölTesztadatokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                torolHibauzenetet();
                rdCar.deleteTableCar();
            }
            catch (Exception ex)
            {
                kiirHibauzenetet("Táblák törlése sikertelen!");
            }
        }

    }
}
