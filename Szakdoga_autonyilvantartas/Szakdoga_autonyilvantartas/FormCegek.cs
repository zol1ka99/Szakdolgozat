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
using Szakdoga_autonyilvantartas.repository.Company;

namespace Szakdoga_autonyilvantartas
{
    public partial class Form1 : Form
    {
        //Cégeket fogja tartalmazni ez az adattábla
        private DataTable cegDT = new DataTable();

        bool ujAdatfelvitelCeg = false;

        private void buttonCegAdatokBetoltese_Click(object sender, EventArgs e)
        {
            frissitAdatokkalDatGridViewtCeg();
            beallitCegekDataGridViewt();
            beallitGombokatIndulaskorCeg();

            dataGridViewCeg.SelectionChanged += DataGridViewCegek_SelectionChanged;
        }


        private void buttonTorolCeg_Click(object sender, EventArgs e)
        {
            torolHibauzenetet();
            if ((dataGridViewCeg.Rows == null) || (dataGridViewCeg.Rows.Count == 0))
            {
                return;
            }
            int sor = dataGridViewCeg.SelectedRows[0].Index;
            if (MessageBox.Show("Biztonsan törölni szeretné a sort?","Törlés",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) ==DialogResult.Yes)
            {
                int cegid = -1;
                if (!int.TryParse(dataGridViewCeg.SelectedRows[0].Cells[0].Value.ToString(),out cegid))
                {
                    return;
                }

                try
                {
                    cegek.deleteCegFromList(cegid);
                }
                catch (RepositoryExceptionCantDelete recd)
                {
                    kiirHibauzenetet(recd.Message);
                    Debug.WriteLine("A tulajdonos törlése nem sikerült!");
                }

                RepositoryDatabaseTableCeg rdtc = new RepositoryDatabaseTableCeg();

                try
                {
                    rdtc.deleteCegFromDatabase(cegid);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                }

                if (dataGridViewCeg.SelectedRows.Count <= 0)
                {
                    buttonUjCeg.Visible = true;
                }

                frissitAdatokkalDatGridViewtCeg();
                beallitCegekDataGridViewt();
                
            }
        }

        private void buttonUjMentesCeg_Click(object sender, EventArgs e)
        {
            torolHibauzenetet();
            errorProviderCegAzonosito.Clear();
            CegFormerrorProviderCegnev.Clear();
            CegFormerrorProviderEmailCim.Clear();
            errorProviderAdoszam.Clear();
            errorProviderVaros.Clear();
            errorProviderUtca.Clear();
            errorProviderSzam.Clear();

            try
            {
                Ceg ujCeg = new Ceg(
                    Convert.ToInt32(textBoxCegAzonosito.Text),
                    textBoxCegNev.Text,
                    Convert.ToInt32(textBoxAdoszam.Text),
                    comboBoxVaros.Text,
                    textBoxCegUtca.Text,
                    Convert.ToInt32(textBoxCegSzam.Text),
                    textBoxCegEmailCim.Text
                    );
                int cegAzonosito = Convert.ToInt32(textBoxCegAzonosito.Text);

                try
                {
                    cegek.addCegToList(ujCeg);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                    return;
                }

                RepositoryDatabaseTableCeg rdtc = new RepositoryDatabaseTableCeg();
                try
                {
                    rdtc.insertCegToDatabase(ujCeg);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                }

                beallitGombokatUjCegMegsemEsMentes();
                frissitAdatokkalDatGridViewtCeg();
                if (dataGridViewCeg.SelectedRows.Count == 1)
                {
                    beallitCegekDataGridViewt();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void buttonUjCeg_Click(object sender, EventArgs e)
        {
            ujAdatfelvitelCeg = true;
            beallitGombokatTextboxokatUjCegnel();
            int ujCegAzonosito = cegek.getNextCegId();
            textBoxCegAzonosito.Text = ujCegAzonosito.ToString();
        }

        private void buttonMegsemCeg_Click(object sender, EventArgs e)
        {
            beallitGombokatUjCegMegsemEsMentes();
        }

        private void buttonModositCeg_Click(object sender, EventArgs e)
        {
            torolHibauzenetet();
            errorProviderCegAzonosito.Clear();
            CegFormerrorProviderCegnev.Clear();
            CegFormerrorProviderEmailCim.Clear();
            errorProviderAdoszam.Clear();
            errorProviderVaros.Clear();
            errorProviderUtca.Clear();
            errorProviderSzam.Clear();

            try
            {
                Ceg modosultCeg = new Ceg(
                    Convert.ToInt32(textBoxCegAzonosito.Text),
                    textBoxCegNev.Text,
                    Convert.ToInt32(textBoxAdoszam.Text),
                    comboBoxVaros.Text,
                    textBoxCegUtca.Text,
                    Convert.ToInt32(textBoxCegSzam.Text),
                    textBoxCegEmailCim.Text
                    );

                int cegazonosito = Convert.ToInt32(textBoxCegAzonosito.Text);
                try
                {
                    cegek.updateCegInList(cegazonosito, modosultCeg);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                    return;
                }

                RepositoryDatabaseTableCeg rdtc = new RepositoryDatabaseTableCeg();
                try
                {
                    rdtc.updateCegInDatabase(cegazonosito, modosultCeg);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                }
                frissitAdatokkalDatGridViewtCeg();
            }
            catch (Exception ex)
            {
                kiirHibauzenetet(ex.Message);
                Debug.WriteLine("A módosítás nem sikerült mert nincs tulajdonos a listában!");
            }
        }



        private void beallitGombokatUjCegMegsemEsMentes()
        {
            if ((dataGridViewCeg.Rows != null) && (dataGridViewCeg.Rows.Count > 0))
            {
                dataGridViewCeg.Rows[0].Selected = true;
                buttonUjMentesCeg.Visible = false;
                buttonMegsemCeg.Visible = false;
                panelModositTorolGombokCeg.Visible = true;
                ujAdatfelvitelCeg = false;

                textBoxCegAzonosito.Text = "";
                textBoxCegNev.Text = "";
                textBoxAdoszam.Text = "";
                comboBoxVaros.Text = "";
                textBoxCegUtca.Text = "";
                textBoxCegSzam.Text = "";
                textBoxCegEmailCim.Text = "";
            }
        }


        private void DataGridViewCegek_SelectionChanged(object sender, EventArgs e)
        {
            if (ujAdatfelvitelCeg)
            {
                beallitGombokatKattintaskorCeg();
            }
            if (dataGridViewCeg.SelectedRows.Count == 1)
            {
                panelCegAdatok.Visible = true;
                panelModositTorolGombokCeg.Visible = true;
                buttonUjCeg.Visible = true;

                textBoxCegAzonosito.Text = dataGridViewCeg.SelectedRows[0].Cells[0].Value.ToString();
                textBoxCegNev.Text = dataGridViewCeg.SelectedRows[0].Cells[1].Value.ToString();
                textBoxAdoszam.Text = dataGridViewCeg.SelectedRows[0].Cells[2].Value.ToString();
                comboBoxVaros.Text = dataGridViewCeg.SelectedRows[0].Cells[3].Value.ToString();
                textBoxCegUtca.Text = dataGridViewCeg.SelectedRows[0].Cells[4].Value.ToString();
                textBoxCegSzam.Text = dataGridViewCeg.SelectedRows[0].Cells[5].Value.ToString();
                textBoxCegEmailCim.Text = dataGridViewCeg.SelectedRows[0].Cells[6].Value.ToString();
            }
        }


        public void beallitGombokatTextboxokatUjCegnel()
        {
            panelCegAdatok.Visible = true;
            panelModositTorolGombokCeg.Visible = false;

            textBoxCegAzonosito.Text = "";
            textBoxCegNev.Text = "";
            textBoxAdoszam.Text = "";
            comboBoxVaros.Text = "";
            textBoxCegUtca.Text = "";
            textBoxCegSzam.Text = "";
            textBoxCegEmailCim.Text = "";

        }

        private void beallitGombokatKattintaskorCeg()
        {
            ujAdatfelvitelCeg = false;
            buttonUjMentesCeg.Visible = false;
            panelModositTorolGombokCeg.Visible = true;
        }

        public void beallitGombokatIndulaskorCeg()
        {
            panelCegAdatok.Visible = false;
            panelModositTorolGombokCeg.Visible = false;
            buttonMegsemCeg.Visible = false;
            buttonUjMentesCeg.Visible = false;
            if (dataGridViewCeg.SelectedRows.Count != 0)
            {
                buttonUjCeg.Visible = false;
            }
            else
            {
                buttonUjCeg.Visible = true;
            }
        }

        private void beallitCegekDataGridViewt()
        {
            cegDT.Columns[0].ColumnName = "Azonosító";
            cegDT.Columns[0].Caption = "Cég azonosítója";
            cegDT.Columns[1].ColumnName = "Cégnév";
            cegDT.Columns[1].Caption = "Cég neve";
            cegDT.Columns[2].ColumnName = "Adószám";
            cegDT.Columns[2].Caption = "Cég adószáma";
            cegDT.Columns[3].ColumnName = "Város";
            cegDT.Columns[3].Caption = "Cég városa";
            cegDT.Columns[4].ColumnName = "Utca";
            cegDT.Columns[4].Caption = "Cég utcája";
            cegDT.Columns[5].ColumnName = "Szám";
            cegDT.Columns[5].Caption = "Cég szám";
            cegDT.Columns[6].ColumnName = "Email cím";
            cegDT.Columns[6].Caption = "Cég email címe";

            dataGridViewCeg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCeg.ReadOnly = true;
            dataGridViewCeg.AllowUserToDeleteRows = false;
            dataGridViewCeg.AllowUserToAddRows = false;
            dataGridViewCeg.MultiSelect = true;
            dataGridViewCeg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCeg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        
        private void frissitAdatokkalDatGridViewtCeg()
        {
            cegDT = cegek.getCegDataTableFromList();
            dataGridViewCeg.DataSource = null;
            dataGridViewCeg.DataSource = cegDT;
        }

    }
}
