using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdoga_autonyilvantartas.Model;

namespace Szakdoga_autonyilvantartas.Repository
{
    partial class Tarolo
    {
        List<Ceg> cegek;

        public List<Ceg> getCegek()
        {
            return cegek;
        }

        public List<string> getCegName()
        {
            List<string> cegName = new List<string>();
            foreach (Ceg p in cegek)
            {
                cegName.Add(p.getCegnev());
            }
            return cegName;
        }

        public void setCegek(List<Ceg> cegek)
        {
            this.cegek = cegek;
        }

        public DataTable getCegDataTableFromList()
        {
            DataTable cegDT = new DataTable();
            cegDT.Columns.Add("cegid", typeof(int));
            cegDT.Columns.Add("cegnev", typeof(string));
            cegDT.Columns.Add("adoszam", typeof(int));
            cegDT.Columns.Add("varos", typeof(string));
            cegDT.Columns.Add("utca", typeof(string));
            cegDT.Columns.Add("szam", typeof(int));
            cegDT.Columns.Add("ceg_email_cim", typeof(string));
            foreach (Ceg p in cegek)
            {
                cegDT.Rows.Add(p.getCegId(), p.getCegnev(), p.getAdoszam(), p.getVaros(), p.getUtca(), p.getSzam(), p.getCegEmailCim());
            }
            return cegDT;
        }

        public void deleteCegFromList(int cegid)
        {
            Ceg p = cegek.Find(x => x.getCegId() == cegid);
            if (p != null)
            {
                cegek.Remove(p);
            }else
            {
                throw new RepositoryExceptionCantDelete("A cég törlése sikertelen");
            }
        }

        public void updateCegInList(int cegid, Ceg modified)
        {
            Ceg p = cegek.Find(x => x.getCegId() == cegid);
            if (p != null)
            {
                p.updateCeg(modified);
            }else
            {
                throw new RepositoryExceptionCantModified("A cég módosítása sikertelen!");
            }
        }

        public void addCegToList(Ceg newCeg)
        {
            try
            {
                cegek.Add(newCeg);
            }
            catch (Exception e)
            {
                throw new RepositoryExceptionCantAdd("A cég hozzáadása sikertelen!");
            }
        }

        public Ceg getCeg(int cegid)
        {
            return cegek.Find(x => x.getCegId() == cegid);
        }

        public int getNextCegId()
        {
            if (cegek.Count == 0)
            {
                return 1;
            }else
            {
                return cegek.Max(x => x.getCegId()) + 1;
            }
        }

    }
}
