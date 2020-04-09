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
using Szakdoga_autonyilvantartas.repository.Tulajdonosok;

namespace Szakdoga_autonyilvantartas
{
    public partial class Form1 : Form
    {
        //Tulajdonosokat fogja tartalmazni ez az adattábla
        private DataTable tulajdonosDT = new DataTable();

        bool ujAdatfelvitelTulajdonos = false;

        private void buttonTulajdonosAdatokBetoltese_Click(object sender, EventArgs e)
        {
            frissitAdatokkalDataGridViewtTulajdonos();
            beallitTulajdonosokDataGridViewt();
            beallitGombokatIndulaskorTulajdonos();

            dataGridViewTulajdonosok.SelectionChanged += DataGridViewTulajdonosok_SelectionChanged;
        }


        private void buttonTorolTulajdonos_Click(object sender, EventArgs e)
        {
            torolHibauzenetet();
            if ((dataGridViewTulajdonosok.Rows == null) || (dataGridViewTulajdonosok.Rows.Count == 0)) 
            {
                return;
            }
            int sor = dataGridViewTulajdonosok.SelectedRows[0].Index;
            if (MessageBox.Show("Biztosan törölni szeretné a sort?","Törlés",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) ==DialogResult.Yes)
            {
                int tulid = -1;
                if (!int.TryParse(dataGridViewTulajdonosok.SelectedRows[0].Cells[0].Value.ToString(),out tulid))
                {
                    return;
                }

                try
                {
                    tulajdonosok.deleteTulajdonosFromList(tulid);
                }
                catch (RepositoryExceptionCantDelete recd)
                {
                    kiirHibauzenetet(recd.Message);
                    Debug.WriteLine("A tulajdonos törlése nem sikerült, nincs a listában!");
                }

                RepositoryDatabaseTableTulajdonos rdtc = new RepositoryDatabaseTableTulajdonos();

                try
                {
                    rdtc.deleteTulajdonosFromDatabase(tulid);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                }

                if (dataGridViewTulajdonosok.SelectedRows.Count <= 0)
                {
                    buttonUjTulajdonos.Visible = true;
                }

                frissitAdatokkalDataGridViewtTulajdonos();
                beallitTulajdonosokDataGridViewt();
                
            }
        }

        private void buttonUjMentesTulajdonos_Click(object sender, EventArgs e)
        {
            torolHibauzenetet();
            errorProviderTulajdonosAzonosito.Clear();
            errorProviderTulajdonosName.Clear();
            errorProviderSzemelyiigszam.Clear();
            errorProviderJogositvanyAzon.Clear();
            errorProviderEmailcim.Clear();
            errorProviderTelefonszam.Clear();
            errorProviderTulajCegnev.Clear();

            try
            {
                Tulajdonos ujTulajdonos = new Tulajdonos(
                    Convert.ToInt32(textBoxTulAzonosito.Text),
                    textBoxTulajdonosName.Text,
                    textBoxTulajdonosSzemelyiigszam.Text,
                    Convert.ToInt32(textBoxJogositvanyAzon.Text),
                    textBoxEmailcim.Text,
                    Convert.ToInt32(textBoxTelefonszam.Text),
                    textBoxTulCegnev.Text
                    );
                int tulAzonosito = Convert.ToInt32(textBoxTulAzonosito.Text);

                try
                {
                    tulajdonosok.addTulajdonosToList(ujTulajdonos);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                    return;
                }


                RepositoryDatabaseTableTulajdonos rdtt = new RepositoryDatabaseTableTulajdonos();
                try
                {
                    rdtt.insertTulajdonosToDatabase(ujTulajdonos);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                }

                beallitGombokatUjTulajdonosMegsemEsMentes();
                frissitAdatokkalDataGridViewtTulajdonos();
                if (dataGridViewTulajdonosok.SelectedRows.Count == 1)
                {
                    beallitTulajdonosokDataGridViewt();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void buttonUjTulajdonos_Click(object sender, EventArgs e)
        {
            ujAdatfelvitelTulajdonos = true;
            buttonUjMentesTulajdonos.Visible = true;
            beallitGombokatTextboxokatUjTulajdonosnal();
            int ujTulajdonosAzonosito = tulajdonosok.getNextTulajdonosId();
            textBoxTulAzonosito.Text = ujTulajdonosAzonosito.ToString();
        }


        private void buttonMegsemTulajdonos_Click(object sender, EventArgs e)
        {
            beallitGombokatUjTulajdonosMegsemEsMentes();
        }

        private void buttonModositTulajdonos_Click(object sender, EventArgs e)
        {
            torolHibauzenetet();
            errorProviderTulajdonosAzonosito.Clear();
            errorProviderTulajdonosName.Clear();
            errorProviderSzemelyiigszam.Clear();
            errorProviderJogositvanyAzon.Clear();
            errorProviderEmailcim.Clear();
            errorProviderTelefonszam.Clear();
            errorProviderTulajCegnev.Clear();


            try
            {
                Tulajdonos modosultTulajdonos = new Tulajdonos(
                    Convert.ToInt32(textBoxTulAzonosito.Text),
                    textBoxTulajdonosName.Text,
                    textBoxTulajdonosSzemelyiigszam.Text,
                    Convert.ToInt32(textBoxJogositvanyAzon.Text),
                    textBoxEmailcim.Text,
                    Convert.ToInt32(textBoxTelefonszam.Text),
                    textBoxTulCegnev.Text
                    );
                int tulazonosito = Convert.ToInt32(textBoxTulAzonosito.Text);
                try
                {
                    tulajdonosok.updateTulajdonosInList(tulazonosito, modosultTulajdonos);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                    return;
                }

                RepositoryDatabaseTableTulajdonos rdtt = new RepositoryDatabaseTableTulajdonos();
                try
                {
                    rdtt.updateTulajdonosInDatabase(tulazonosito, modosultTulajdonos);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                }
                frissitAdatokkalDataGridViewtTulajdonos();
            }
            catch (Exception ex)
            {
                kiirHibauzenetet(ex.Message);
                Debug.WriteLine("A módosítás nem sikerült mert nincs tulajdonos a listában!");
            }


        }


        private void beallitGombokatUjTulajdonosMegsemEsMentes()
        {
            if ((dataGridViewTulajdonosok.Rows != null) && (dataGridViewTulajdonosok.Rows.Count > 0))
            {
                dataGridViewTulajdonosok.Rows[0].Selected = true;
                buttonUjMentesTulajdonos.Visible = true;
                buttonMegsemTulajdonos.Visible = false;
                panelModositTorolTulajdonos.Visible = true;
                ujAdatfelvitelTulajdonos = false;

                textBoxTulAzonosito.Text = "";
                textBoxTulajdonosName.Text = "";
                textBoxTulajdonosSzemelyiigszam.Text = "";
                textBoxJogositvanyAzon.Text = "";
                textBoxEmailcim.Text = "";
                textBoxTelefonszam.Text = "";
                textBoxTulCegnev.Text = "";
            }
        }

        private void DataGridViewTulajdonosok_SelectionChanged(object sender, EventArgs e)
        {
            if (ujAdatfelvitelTulajdonos)
            {
                beallitGombokatKattintaskorTulajdonos();
            }
            if (dataGridViewTulajdonosok.SelectedRows.Count == 1)
            {
                panelTulajdonosAdatok.Visible = true;
                panelModositTorolTulajdonos.Visible = true;
                buttonUjTulajdonos.Visible = true;

                textBoxTulAzonosito.Text = dataGridViewTulajdonosok.SelectedRows[0].Cells[0].Value.ToString();
                textBoxTulajdonosName.Text = dataGridViewTulajdonosok.SelectedRows[0].Cells[1].Value.ToString();
                textBoxTulajdonosSzemelyiigszam.Text = dataGridViewTulajdonosok.SelectedRows[0].Cells[2].Value.ToString();
                textBoxJogositvanyAzon.Text = dataGridViewTulajdonosok.SelectedRows[0].Cells[3].Value.ToString();
                textBoxEmailcim.Text = dataGridViewTulajdonosok.SelectedRows[0].Cells[4].Value.ToString();
                textBoxTelefonszam.Text = dataGridViewTulajdonosok.SelectedRows[0].Cells[5].Value.ToString();
                textBoxTulCegnev.Text = dataGridViewTulajdonosok.SelectedRows[0].Cells[6].Value.ToString();
            }
            else
            {
                panelAutok.Visible = false;
                panelModositTorolGomb.Visible = false;
                buttonUjTulajdonos.Visible = false;
            }
        }

        public void beallitGombokatTextboxokatUjTulajdonosnal()
        {
            panelTulajdonosAdatok.Visible = true;
            panelModositTorolTulajdonos.Visible = false;

            textBoxTulAzonosito.Text = "";
            textBoxTulajdonosName.Text = "";
            textBoxTulajdonosSzemelyiigszam.Text = "";
            textBoxJogositvanyAzon.Text = "";
            textBoxEmailcim.Text = "";
            textBoxTelefonszam.Text = "";
            textBoxTulCegnev.Text = "";
        }

        private void beallitGombokatKattintaskorTulajdonos()
        {
            ujAdatfelvitelTulajdonos = false;
            buttonUjMentesTulajdonos.Visible = false;
            panelModositTorolTulajdonos.Visible = true;
        }

        public void beallitGombokatIndulaskorTulajdonos()
        {
            panelTulajdonosAdatok.Visible = false;
            panelModositTorolTulajdonos.Visible = false;
            buttonMegsemTulajdonos.Visible = false;
            buttonUjMentesTulajdonos.Visible = false;
            if (dataGridViewTulajdonosok.SelectedRows.Count != 0)
            {
                buttonUjTulajdonos.Visible = false;
            }
            else
            {
                buttonUjTulajdonos.Visible = true;
            }
        }

        private void beallitTulajdonosokDataGridViewt()
        {
            tulajdonosDT.Columns[0].ColumnName = "Azonosító";
            tulajdonosDT.Columns[0].Caption = "Tulajdonos azonosítója";
            tulajdonosDT.Columns[1].ColumnName = "Név";
            tulajdonosDT.Columns[1].Caption = "Tulajdonos neve";
            tulajdonosDT.Columns[2].ColumnName = "Személyiigazolvány szám";
            tulajdonosDT.Columns[2].Caption = "Tulajdonos személyiigazolvány száma";
            tulajdonosDT.Columns[3].ColumnName = "Jogositvány azonosító";
            tulajdonosDT.Columns[3].Caption = "Tulajdonos jogositvány azonosítója";
            tulajdonosDT.Columns[4].ColumnName = "Email cím";
            tulajdonosDT.Columns[4].Caption = "Tulajdonos email címe";
            tulajdonosDT.Columns[5].ColumnName = "Telefonszám";
            tulajdonosDT.Columns[5].Caption = "Tulajdonos telefonszáma";
            tulajdonosDT.Columns[6].ColumnName = "Cégnév";
            tulajdonosDT.Columns[6].Caption = "Tulajdonos cégének neve";

            dataGridViewTulajdonosok.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTulajdonosok.ReadOnly = true;
            dataGridViewTulajdonosok.AllowUserToDeleteRows = false;
            dataGridViewTulajdonosok.AllowUserToAddRows = false;
            dataGridViewTulajdonosok.MultiSelect = true;
            dataGridViewTulajdonosok.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewTulajdonosok.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void frissitAdatokkalDataGridViewtTulajdonos()
        {
            tulajdonosDT = tulajdonosok.getTulajdonosDataTableFromList();
            dataGridViewTulajdonosok.DataSource = null;
            dataGridViewTulajdonosok.DataSource = tulajdonosDT;
        }
    }
}
