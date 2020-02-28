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
    {
        //RepositoryDatabase rd = new RepositoryDatabase();

        Repository cars = new Repository();

        public Form1()
        {
            
            InitializeComponent();
            beallitKezdoOldalt();
        }

        private void beallitKezdoOldalt()
        {
            this.Size = new Size(1014, 640);
            this.Text = "Car Docker (Beta)";
        }

        

        //Autók tab page
        private void carsToolStripMenu_Item_Click(Object sender, EventArgs e)
        {
            tabControlCarDocket.SelectTab("tabPageAutok");
        }

        //Tulajdonosok tab page
        private void ownersToolStripMenu_Item_Click(Object sender, EventArgs e)
        {
            tabControlCarDocket.SelectTab("tabPageTulajdonosok");
        }

        













        /*
        private void megjelenitAutot(Car h)
        {
            comboBox1.Text = h.getautotipus().ToString();
            textBoxUzemanyag.Text = h.getautomodell().ToString();
            textBoxSebessegvaltoTipusa.Text = h.getevjarat().ToString();
            textBoxTulajdonosNeve.Text = h.getforgalombahelyez_ev().ToString();
        }

        private void buttonautofelvetel_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(comboBox1, "");
            errorProvider1.SetError(textBoxUzemanyag, "");
            errorProvider2.SetError(textBoxSebessegvaltoTipusa, "");
            errorProvider3.SetError(textBoxTulajdonosNeve, "");
            bool vanHiba = false;


            string autotipus = "";
           
                autotipus = comboBox1.Text;
            if(autotipus==string.Empty)
                errorProvider1.SetError(comboBox1, "Hibás adat!");
            


            string automodell = "";
           
                automodell =textBoxUzemanyag.Text;
            if(automodell==string.Empty)
                errorProvider2.SetError(textBoxUzemanyag, "Hibás adat!");
            


            int evjarat = 0;
            try
            {
                evjarat = Convert.ToInt32(textBoxSebessegvaltoTipusa.Text);
            }
            catch (Exception ex)
            {
                errorProvider3.SetError(textBoxSebessegvaltoTipusa, "Hibás adat!");
                vanHiba = true;
            }

            int forgalombahelyez_ev = 0;
            try
            {
                forgalombahelyez_ev = Convert.ToInt32(textBoxTulajdonosNeve.Text);
            }
            catch (Exception ex)
            {
                errorProvider4.SetError(textBoxTulajdonosNeve, "Hibás adat!");
                vanHiba = true;
            }



            if (!vanHiba)
            {
                Car h = new Car(autotipus, automodell, evjarat, forgalombahelyez_ev);
                autok.hozzaadAutot(h);
                megjelenitAutokatListboxban();
            }
        }


        private void buttonautotorlese_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index < 0)
                return;
            try
            {
                //kiválasztott elem
                Car h = autok.getAdottElem(index);
                //id-jét megkeressük, töröljük
                int id = h.getId();
                autok.torolIdAlapjan(id);
                //majd frissítjük a ListBox-ot
                megjelenitAutokatListboxban();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonBeolvas_Click(object sender, EventArgs e)
        {
            //beolvas a fájlból
            autok.beolvas();
            //adatokat megjelenít a Listboxban
            megjelenitAutokatListboxban();
        }
        private void megjelenitAutokatListboxban()
        {
            //listbox delete majd adatok bele töltése
            listBox1.DataSource = null;
            listBox1.DataSource = autok.getAutok();
        }

        private void buttonautomodosit_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(comboBox1, "");
            errorProvider2.SetError(textBoxUzemanyag, "");
            errorProvider3.SetError(textBoxSebessegvaltoTipusa, "");
            errorProvider4.SetError(textBoxTulajdonosNeve, "");
            bool vanHiba = false;

            string autotipus = null;
            try
            {
                autotipus = Convert.ToString(comboBox1.Text);
            }
            catch
            {
                errorProvider1.SetError(comboBox1, "Hibás adat!");
                vanHiba = true;
            }

            string automodell = null;
            try
            {
                automodell = Convert.ToString(textBoxUzemanyag.Text);
            }
            catch (Exception ex)
            {
                errorProvider2.SetError(textBoxUzemanyag, "Hibás adat!");
                vanHiba = true;
            }

            int evjarat = 0;
            try
            {
                evjarat = Convert.ToInt32(textBoxSebessegvaltoTipusa.Text);
            }
            catch (Exception ex)
            {
                errorProvider3.SetError(textBoxSebessegvaltoTipusa, "Hibás adat!");
                vanHiba = true;
            }

            int forgalombahelyez_ev = 0;
            try
            {
                forgalombahelyez_ev = Convert.ToInt32(textBoxTulajdonosNeve.Text);

            }
            catch (Exception ex)
            {
                errorProvider4.SetError(textBoxTulajdonosNeve, "Hibás adat!");
                vanHiba = true;
            }
            if (!vanHiba)
            {
                //Kell a kijelölt elem, mert őt módosítjuk
                int index = listBox1.SelectedIndex;
                if (index < 0) //üres a ListBox
                    return;
                Car modositando = autok.getAdottElem(index);
                //Lekérjük a módosítandó elem ID-jét 
                int id = modositando.getId();
                //Létrehozzuk az autót
                Car h = new Car(autotipus, automodell, evjarat, forgalombahelyez_ev);
                //A repositoryban az adott id-vel rendelekező háromszoget módosítjuk az új h háromszögre
                autok.modositAutot(id, h);
                //Frissítjük a ListBox-ot az új adatokkal
                megjelenitAutokatListboxban();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const string sPath = "autok1.txt";

            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
            foreach (var item in listBox1.Items)
            {
                SaveFile.WriteLine(item);
            }

            SaveFile.Close();

            MessageBox.Show("Adatok mentve!");
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index < 0) //üres a ListBox
                return;
            try
            {
                //kiválasztott autó lekérése és megjelenítése
                Car h = autok.getAdottElem(index);
                megjelenitAutot(h);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxGepkocsiTipusa.Text = autok.getAutokSzama().ToString();
        }

    */
    }
}
