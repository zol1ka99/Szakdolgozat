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
        //Autókat fogja tartalmazni ez az adattábla
        private DataTable carsDT = new DataTable();

        //Ez még itt nem tudom mit csinál
        bool ujAdatfelvitel = false;

        /// <summary>
        /// Az adatok betöltésére szolgáló gomb funkcioit gyüjtöttem ide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdatokBetoltese_Click(object sender, EventArgs e)
        {
            frissitAdatokkalDataGridViewt();
            beallitCarsDataGridViewt();
            beallitGombokatIndulaskor();

            dataGridViewAutok.SelectionChanged += DataGridViewCars_SelectionChanged;
        }

        private void buttonTorol_Click(object sender, EventArgs e)
        {
            torolHibauzenetet(); //Ezt a test data formban kell majd megcsinálni
            if ((dataGridViewAutok.Rows == null) || (dataGridViewAutok.Rows.Count == 0))
            {
                return;
            }
            int sor = dataGridViewAutok.SelectedRows[0].Index;
            if (MessageBox.Show("Biztosan törölni szeretné a sort?","Törlés",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int id = -1;
                if (!int.TryParse(dataGridViewAutok.SelectedRows[0].Cells[0].Value.ToString(),out id))
                {
                    return;
                }


                try
                {
                    cars.deleteCarFromList(id);//ezt is meg kell majd írni még
                }
                catch (RepositoryExceptionCantDelete recd)
                {
                    kiirHibauzenetet(recd.Message); //ezt is meg kell írni majd
                    Debug.WriteLine("Az autó törlés nem sikerült, nincs a listában!");
                }

                RepositoryDatabaseTableCar rdtc = new RepositoryDatabaseTableCar(); //ezt is meg kell majd írni
                
                try
                {
                    rdtc.deleteCarFromDatabase(id); //ezt is meg kell majd írni
                }
                catch (RepositoryException ex)
                {
                    kiirHibauzenetet(ex.Message); //ezt is meg kell majd írni
                }

                if (dataGridViewAutok.SelectedRows.Count <= 0)
                {
                    buttonUjAuto.Visible = true;
                }

                frissitAdatokkalDataGridViewt();
                beallitCarsDataGridViewt();
                

            }

        }

        private void buttonUjMentes_Click(object sender, EventArgs e)
        {
            torolHibauzenetet();
            errorProviderAutoAzonosito.Clear();
            errorProviderAutoMarka.Clear();
            errorProviderAutoTipus.Clear();
            errorProviderAutoGyartasiEv.Clear();
            errorProviderAutoVetelar.Clear();
            errorProviderAutoRendszam.Clear();
            errorProviderAutoKilometeroraallas.Clear();
            errorProviderAutoAlvazszam.Clear();
            errorProviderAutoGepkocsiTipusa.Clear();
            errorProviderAutoUzemanyag.Clear();
            errorProviderAutoSebessegvaltoTipusa.Clear();
            errorProviderAutoTulajdonosNev.Clear();

            try
            {
                Car ujCar = new Car(
                    Convert.ToInt32(textBoxAzonosito.Text),
                    comboBoxMarka.Text,
                    textBoxTipus.Text,
                    textBoxGyartasiEv.Text,
                    Convert.ToInt32(textBoxVetelar.Text),
                    textBoxRendszam.Text,
                    Convert.ToInt32(textBoxKilometeroraAllas.Text),
                    textBoxAlvazszam.Text,
                    textBoxGepkocsiTipusa.Text,
                    textBoxUzemanyag.Text,
                    textBoxSebessegvaltoTipusa.Text,
                    textBoxTulajdonosNeve.Text
                    );
                int azonosito = Convert.ToInt32(textBoxAzonosito.Text);
                //1.Hozzáadni a listához
                try
                {
                    cars.addCarToList(ujCar);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                    return;
                }
                //2. hozzáadni az adatbázishoz
                RepositoryDatabaseTableCar rdtc = new RepositoryDatabaseTableCar();
                try
                {
                    rdtc.insertCarToDatabase(ujCar);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                }
                //3. Frissíteni a DataGridVieww-t
                beallitGombokatUjCarMegsemEsMentes();
                frissitAdatokkalDataGridViewt();
                if (dataGridViewAutok.SelectedRows.Count == 1)
                {
                    beallitCarsDataGridViewt();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void buttonMegsem_Click(object sender, EventArgs e)
        {
            beallitGombokatUjCarMegsemEsMentes();
        }

       
        private void buttonModositAuto_Click(object sender, EventArgs e)
        {
            torolHibauzenetet();
            errorProviderAutoAzonosito.Clear();
            errorProviderAutoMarka.Clear();
            errorProviderAutoTipus.Clear();
            errorProviderAutoGyartasiEv.Clear();
            errorProviderAutoVetelar.Clear();
            errorProviderAutoRendszam.Clear();
            errorProviderAutoKilometeroraallas.Clear();
            errorProviderAutoAlvazszam.Clear();
            errorProviderAutoGepkocsiTipusa.Clear();
            errorProviderAutoUzemanyag.Clear();
            errorProviderAutoSebessegvaltoTipusa.Clear();
            errorProviderAutoTulajdonosNev.Clear();



            try
            {
                Car modosult = new Car(
                    Convert.ToInt32(textBoxAzonosito.Text),
                    comboBoxMarka.Text,
                    textBoxTipus.Text,
                    textBoxGyartasiEv.Text,
                    Convert.ToInt32(textBoxVetelar.Text),
                    textBoxRendszam.Text,
                    Convert.ToInt32(textBoxKilometeroraAllas.Text),
                    textBoxAlvazszam.Text,
                    textBoxGepkocsiTipusa.Text,
                    textBoxUzemanyag.Text,
                    textBoxSebessegvaltoTipusa.Text,
                    textBoxTulajdonosNeve.Text
                    );
                int azonosito = Convert.ToInt32(textBoxAzonosito.Text);
                //1. módosítani a listába
                try
                {
                    cars.updateCarInList(azonosito, modosult);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                    return;
                }
                //2. Módosítani az adatbázisba
                RepositoryDatabaseTableCar rdtc = new RepositoryDatabaseTableCar();
                try
                {
                    rdtc.updateCarInDatabase(azonosito, modosult);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                }
                //3. Módosítani a DataGridViewban
                frissitAdatokkalDataGridViewt();
            }
            catch (Exception ex)
            {
                kiirHibauzenetet(ex.Message);
                Debug.WriteLine("A módosítás nem sikerült mert nincs autó a listában!");
            }
        }

        private void buttonUjAuto_Click(object sender, EventArgs e)
        {
            ujAdatfelvitel = true;
            buttonUjMentes.Visible = true;
            beallitGombokatTextboxokatUjAutonal();
            int ujAutoAzonosito = cars.getNextCarId();
            textBoxAzonosito.Text = ujAutoAzonosito.ToString();
        }


        private void DataGridViewCars_SelectionChanged(object sender, EventArgs e)
        {
            if (ujAdatfelvitel)
            {
                beallitGombokatKattintaskor();
            }
            if (dataGridViewAutok.SelectedRows.Count == 1)
            {
                panelAutok.Visible = true;
                panelModositTorolGomb.Visible = true;
                buttonUjAuto.Visible = true;

                textBoxAzonosito.Text = dataGridViewAutok.SelectedRows[0].Cells[0].Value.ToString();
                comboBoxMarka.Text = dataGridViewAutok.SelectedRows[0].Cells[1].Value.ToString();
                textBoxTipus.Text = dataGridViewAutok.SelectedRows[0].Cells[2].Value.ToString();
                textBoxGyartasiEv.Text = dataGridViewAutok.SelectedRows[0].Cells[3].Value.ToString();
                textBoxVetelar.Text = dataGridViewAutok.SelectedRows[0].Cells[4].Value.ToString();
                textBoxRendszam.Text = dataGridViewAutok.SelectedRows[0].Cells[5].Value.ToString();
                textBoxKilometeroraAllas.Text = dataGridViewAutok.SelectedRows[0].Cells[6].Value.ToString();
                textBoxAlvazszam.Text = dataGridViewAutok.SelectedRows[0].Cells[7].Value.ToString();
                textBoxGepkocsiTipusa.Text = dataGridViewAutok.SelectedRows[0].Cells[8].Value.ToString();
                textBoxUzemanyag.Text = dataGridViewAutok.SelectedRows[0].Cells[9].Value.ToString();
                textBoxSebessegvaltoTipusa.Text = dataGridViewAutok.SelectedRows[0].Cells[10].Value.ToString();
                textBoxTulajdonosNeve.Text = dataGridViewAutok.SelectedRows[0].Cells[11].Value.ToString();
            }
            else
            {
                panelAutok.Visible = false;
                panelModositTorolGomb.Visible = false;
                buttonUjAuto.Visible = false;
            }
        }

        private void beallitGombokatTextboxokatUjAutonal()
        {
            panelAutok.Visible = true;
            panelModositTorolGomb.Visible = false;

            textBoxAzonosito.Text = "";
            comboBoxMarka.Text = "";
            textBoxTipus.Text = "";
            textBoxGyartasiEv.Text= "";
            textBoxVetelar.Text = "";
            textBoxRendszam.Text = "";
            textBoxKilometeroraAllas.Text = "";
            textBoxAlvazszam.Text = "";
            textBoxGepkocsiTipusa.Text = "";
            textBoxUzemanyag.Text = "";
            textBoxSebessegvaltoTipusa.Text = "";
            textBoxTulajdonosNeve.Text = "";

        }

        private void beallitGombokatKattintaskor()
        {
            ujAdatfelvitel = false;
            buttonUjMentes.Visible = false;
            panelModositTorolGomb.Visible = true;
            //ide még jönnek majd az error providerek ha bevitelnél nem helyesek az adatok
        }

        private void beallitGombokatIndulaskor()
        {
            panelAutok.Visible = false;
            panelModositTorolGomb.Visible = false;
            buttonMegsem.Visible = false;
            buttonUjMentes.Visible = false;
            if (dataGridViewAutok.SelectedRows.Count != 0)
            {
                buttonUjAuto.Visible = false;
            }
            else
            {
                buttonUjAuto.Visible = true;
            }
        }

        private void beallitGombokatUjCarMegsemEsMentes()
        {
            if ((dataGridViewAutok.Rows != null) &&
                (dataGridViewAutok.Rows.Count > 0))
            {
                dataGridViewAutok.Rows[0].Selected = true;
                buttonUjMentes.Visible = true;
                buttonMegsem.Visible = true;
                panelModositTorolGomb.Visible = true;
                ujAdatfelvitel = false;

                textBoxAzonosito.Text = "";
                comboBoxMarka.Text = "";
                textBoxTipus.Text = "";
                textBoxGyartasiEv.Text = "";
                textBoxVetelar.Text = "";
                textBoxRendszam.Text = "";
                textBoxKilometeroraAllas.Text = "";
                textBoxAlvazszam.Text = "";
                textBoxGepkocsiTipusa.Text = "";
                textBoxUzemanyag.Text = "";
                textBoxSebessegvaltoTipusa.Text = "";
                textBoxTulajdonosNeve.Text = "";
            }
        }


        /// <summary>
        /// Data grid view (táblázat) beállításáért felelősd kód
        /// </summary>
        private void beallitCarsDataGridViewt()
        {
            carsDT.Columns[0].ColumnName = "Azonosító";
            carsDT.Columns[0].Caption = "Autó azonosítója";
            carsDT.Columns[1].ColumnName = "Márka";
            carsDT.Columns[1].Caption = "Autó márkája";
            carsDT.Columns[2].ColumnName = "Típus";
            carsDT.Columns[2].Caption = "Autó típusa";
            carsDT.Columns[3].ColumnName = "Gyártási év";
            carsDT.Columns[3].Caption = "Autó gyártási éve";
            carsDT.Columns[4].ColumnName = "Vételár";
            carsDT.Columns[4].Caption = "Autó vételára";
            carsDT.Columns[5].ColumnName = "Rendszám";
            carsDT.Columns[5].Caption = "Autó rendszáma";
            carsDT.Columns[6].ColumnName = "Kilóméteróraállás";
            carsDT.Columns[6].Caption = "Autó kilóméteróraállása";
            carsDT.Columns[7].ColumnName = "Alvázszám";
            carsDT.Columns[7].Caption = "Autó alvázszáma";
            carsDT.Columns[8].ColumnName = "Gépkocsi típusa";
            carsDT.Columns[8].Caption = "Gépkocsi típusa";
            carsDT.Columns[9].ColumnName = "Üzemanyag";
            carsDT.Columns[9].Caption = "Üzemanyag";
            carsDT.Columns[10].ColumnName = "Sebességváltó";
            carsDT.Columns[10].Caption = "Sebességváltó típusa";
            carsDT.Columns[11].ColumnName = "Tulajdonos név";
            carsDT.Columns[11].Caption = "Autó tulajdonosa";

            dataGridViewAutok.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAutok.ReadOnly = true;
            dataGridViewAutok.AllowUserToDeleteRows = false;
            dataGridViewAutok.AllowUserToAddRows = false;
            dataGridViewAutok.MultiSelect = true;
            dataGridViewAutok.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewAutok.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        /// <summary>
        /// Frissíti a datagridviewban szereplő adatokat hogy mintig aktualizálva legyenek
        /// </summary>
        private void frissitAdatokkalDataGridViewt()
        {
            //Feltölti az adattáblát a repository auto listából
            carsDT = cars.getCarDataTableFromList();
            dataGridViewAutok.DataSource = null;
            dataGridViewAutok.DataSource = carsDT;
        }
    }
}
