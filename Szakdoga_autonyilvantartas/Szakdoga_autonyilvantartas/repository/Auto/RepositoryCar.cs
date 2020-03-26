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
    partial class Tarolo
    { 
        List<Car> cars;

        public List<Car> getAutok()
        {
            return cars;
        }

        public List<string> getCarsName()
        {
            List<string> carNames = new List<string>();
            foreach (Car p in cars)
            {
                carNames.Add(p.getMarka());
            }
            return carNames;
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
            carsDT.Columns.Add("gyartasi_ev", typeof(string));
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
                carsDT.Rows.Add(c.getId(), c.getMarka(), c.getTipus(), c.getGyartasiev(), c.getVetelar(), c.getRendszam(), c.getKilometeroraallas(), c.getAlvazszam(), c.getGepkocsiTipusa(), c.getUzemanyag(), c.getSebessegvaltoTipusa(), c.getTulajdonosNev());
            }
            return carsDT;
        }

        public void deleteCarFromList(int id)
        {
            Car p = cars.Find(x => x.getId() == id);
            if (p != null)
            {
                cars.Remove(p);
            }else
            {
                throw new RepositoryExceptionCantDelete("Az autó törlése sikertelen");
            }
        }

        public void updateCarInList(int id,Car modified)
        {
            Car p = cars.Find(x => x.getId() == id);
            if (p != null)
            {
                p.updateCar(modified);
            }else
            {
                throw new RepositoryExceptionCantModified("Az autó módosítása sikertelen");
            }
        }

        public void addCarToList(Car newCar)
        {
            try
            {
                cars.Add(newCar);
            }
            catch (Exception e)
            {

                throw new RepositoryExceptionCantAdd("A pizza hozzáadása nem sikerült");
            }
        }

        public Car getCar(int id)
        {
            return cars.Find(x => x.getId() == id);
        }

        public int getNextCarId()
        {
            if (cars.Count == 0)
            {
                return 1;
            }else
            {
                return cars.Max(x => x.getId()) + 1;
            }
        }

        public void setTestData()
        {
            cars.Add(new Car(1, "Audi", "RS5", "2018-02-15", 15000000, "RDS-458", 15000, "AZR879874545R587T", "SzGK", "Benzin", "Automata", "Feles Elek"));
            cars.Add(new Car(2, "Opel", "Vivaro", "2008-05-18", 1500000, "DRT-234", 140000, "AZR8787654987547T", "TGK", "Dízel", "Manuális", "Zuhany Rózsa"));
            cars.Add(new Car(1, "Neoplan", "Starliner 5218", "2015-02-15", 50000000, "FDJ-987", 15000, "RTZ984845R587597T", "Busz", "Dízel-Hibrid", "Automata", "Kalapos József"));
        }

    }
}
