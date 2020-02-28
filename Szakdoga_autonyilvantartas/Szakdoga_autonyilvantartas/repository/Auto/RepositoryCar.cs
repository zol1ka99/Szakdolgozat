using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdoga_autonyilvantartas.Repository;
using Szakdoga_autonyilvantartas.Model;
using System.Data;

namespace Szakdoga_autonyilvantartas.Repository
{
    partial class RepositoryCar
    { 
        List<Car> cars;

        public List<Car> getAutok()
        {
            return cars;
        }

        public void setAutok(List<Car> cars)
        {
            this.cars = cars;
        }

        public DataTable getCarDataTableFromList()
        {
            DataTable carsDT = new DataTable();
            carsDT.Columns.Add("id", typeof(int));
            carsDT.Columns.Add("marka", typeof(string));
            carsDT.Columns.Add("tipus", typeof(string));
            carsDT.Columns.Add("gyartasi_ev", typeof(int));
            carsDT.Columns.Add("vetelar", typeof(int));
            carsDT.Columns.Add("rendszam", typeof(string));
            carsDT.Columns.Add("kilometeroraallas", typeof(int));
            carsDT.Columns.Add("alvazszam", typeof(string));
            carsDT.Columns.Add("gepkocsi_tipusa", typeof(string));
            carsDT.Columns.Add("uzemanyag", typeof(string));
            carsDT.Columns.Add("sebessegvalto_tipusa", typeof(string));
            carsDT.Columns.Add("tulajdonos_nev", typeof(string));
            foreach (Car c in cars)
            {
                carsDT.Rows.Add(c.getId(), c.getMarka(), c.getTipus(), c.getGyartasiev(), c.getVetelar(), c.getRendszam(), c.getKilometeroraallas(), c.getAlvazszam(), c.getGepkocsiTipusa(), c.getUzemanyag(), c.getSebessegvaltoTipusa(), c.getTulajdonosNeve());
            }
            return carsDT;
        }
    }
}
