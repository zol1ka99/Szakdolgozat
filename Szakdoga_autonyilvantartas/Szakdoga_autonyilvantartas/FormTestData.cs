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

namespace Szakdoga_autonyilvantartas
{
    public partial class Form1 : Form
    

        RepositoryDatabase rd = new RepositoryDatabase();
        RepositoryDatabaseTableCar rdCar = new RepositoryDatabaseTableCar(); //RepositoryDatabaseTableCar, létre kell majd hozni
        //RepositoryDatabaseTableOwner rdOwner = new RepositoryDatabaseTableOwner(); //tulajdonosokhoz kell majd

        private void torolHibauzenetet()
        {
            toolStripLabelHibauzenet.ForeColor = Color.Black;
            toolStripLabelHibauzenet.Text = "";
        }

        private void kiirHibauzenetet(string hibauzenet)
        {
            toolStripLabelHibauzenet.ForeColor = Color.Red;
            ToolStripLabelHibauzenet.Text = hibauzenet;
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
                kiirHibauzenetet("Adatbázis létrehozási hiba!");
            }
        }

        private void törölAdatbázistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                torolHibauzenetet();
                rd.deleteDatabase();
            }
            catch
            {
                kiirHibauzenetet("Adatbázis törlése hiba!");
            }
        }

        private void feltöltésTesztadatokkalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                torolHibauzenetet();

                //táblák létrehozása
                rdCar.createTableCar(); //RepositoryDataBaseTableCar, létre kell hozni majd

                //tesztadatok feltöltése adatbázisba
                rdCar.fillCarsWithTestDataFromSQLCommand(); //RepositoryDatabaseTableCarTestData, létre kell majd hozni

                //adatbázisból listák feltöltése
                cars.setAutok(rdCar.getCarsFromDatabaseTable()); //RepositoryDatabaseTableCarSQL, létre kell majd hozni
            }
            catch (Exception ex)
            {
                kiirHibauzenetet("Teszadatok feltöltése sikertelen!");
            }
        }

        private void törölTesztadatokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                torolHibauzenetet();
                rdCar.deleteTableCar(); //RepositoryDatabaseTableCar, létre kell majd hozni
            }
            catch (Exception ex)
            {
                kiirHibauzenetet("Táblák törlése sikertelen!");
            }
        }

    }
}
