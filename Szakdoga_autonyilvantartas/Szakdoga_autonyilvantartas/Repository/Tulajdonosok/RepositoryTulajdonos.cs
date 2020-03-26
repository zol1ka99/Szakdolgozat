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
        List<Tulajdonos> tulajdonosok;

        public List<Tulajdonos> getTulajdonosok()
        {
            return tulajdonosok;
        }

        public List<string> getTulajdonosName()
        {
            List<string> tulajdonosName = new List<string>();
            foreach (Tulajdonos p in tulajdonosok)
            {
                tulajdonosName.Add(p.getTulajdonosnev());
            }
            return tulajdonosName;
        }

        public void setTulajdonosok(List<Tulajdonos> tulajdonosok)
        {
            this.tulajdonosok = tulajdonosok;
        }

        public DataTable getTulajdonosDataTableFromList()
        {
            DataTable tulajdonosDT = new DataTable();
            tulajdonosDT.Columns.Add("tulid", typeof(int));
            tulajdonosDT.Columns.Add("tulajdonos_nev", typeof(string));
            tulajdonosDT.Columns.Add("tulajdonos_szemelyiigszam", typeof(string));
            tulajdonosDT.Columns.Add("jogositvany_azon", typeof(int));
            tulajdonosDT.Columns.Add("email_cim", typeof(string));
            tulajdonosDT.Columns.Add("telefonszam", typeof(int));
            tulajdonosDT.Columns.Add("cegnev", typeof(string));
            foreach (Tulajdonos c in tulajdonosok)
            {
                tulajdonosDT.Rows.Add(c.getTulId(), c.getTulajdonosnev(), c.getTulajdonosszemelyiigszam(), c.getJogositvanyazon(), c.getEmailcim(), c.getTelefonszam(), c.getCegnev());
            }
            return tulajdonosDT;
        }

        public void deleteTulajdonosFromList(int tulid)
        {
            Tulajdonos p = tulajdonosok.Find(x => x.getTulId() == tulid);
            if (p != null)
            {
                tulajdonosok.Remove(p);
            }else
            {
                throw new RepositoryExceptionCantDelete("Az tulajdonos törlése sikertelen!");
            }
        }

        public void updateTulajdonosInList(int tulid, Tulajdonos modified)
        {
            Tulajdonos p = tulajdonosok.Find(x => x.getTulId() == tulid);
            if (p != null)
            {
                p.updateTulajdonos(modified);
            }else
            {
                throw new RepositoryExceptionCantModified("A tulajdonos módosítása sikertelen!");
            }
        }

        public void addTulajdonosToList(Tulajdonos newTulajdonos)
        {
            try
            {
                tulajdonosok.Add(newTulajdonos);
            }
            catch (Exception e)
            {
                throw new RepositoryExceptionCantAdd("A tulajdonos hozzáadása sikertelen!");
            }
        }

        public Tulajdonos getTulajdonos(int tulid)
        {
            return tulajdonosok.Find(x => x.getTulId() == tulid);
        }

        public int getNextTulajdonosId()
        {
            if (tulajdonosok.Count == 0)
            {
                return 1;
            }else
            {
                return tulajdonosok.Max(x => x.getTulId()) + 1;
            }
        }



    }
}
