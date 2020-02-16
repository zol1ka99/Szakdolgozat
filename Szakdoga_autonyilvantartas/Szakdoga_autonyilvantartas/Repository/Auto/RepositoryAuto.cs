using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdoga_autonyilvantartas.Repository;

namespace Szakdoga_autonyilvantartas.Repository.Auto
{
    partial class RepositoryAuto
    {
        List<Auto> autok;

        public List<Auto> getAutok()
        {
            return autok;
        }
    }
}
