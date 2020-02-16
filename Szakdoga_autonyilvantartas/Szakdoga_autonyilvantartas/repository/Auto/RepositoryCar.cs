using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdoga_autonyilvantartas.Repository;
using Szakdoga_autonyilvantartas.Model;

namespace Szakdoga_autonyilvantartas.Repository.Auto
{
    partial class RepositoryCar
    { 
        List<Car> autok;

        public List<Car> getAutok()
        {
            return autok;
        }

        public void setAutok(List<Car> cars)
        {
            this.autok = autok;
        }
    }
}
