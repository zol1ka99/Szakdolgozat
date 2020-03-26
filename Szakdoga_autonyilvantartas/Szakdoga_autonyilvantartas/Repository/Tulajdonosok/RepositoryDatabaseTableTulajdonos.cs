using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdoga_autonyilvantartas.Model;

namespace Szakdoga_autonyilvantartas.repository.Tulajdonosok
{
    class RepositoryDatabaseTableTulajdonos
    {
        private readonly string connectionStringCreate;
        private readonly string connectionString;

        public RepositoryDatabaseTableTulajdonos()
        {
            Connection cs = new Connection();
            connectionStringCreate = cs.getCreateString();
            connectionString = cs.getConnectionString();
        }

        public void createTableTulajdonos()
        {
            string queryUSE = "USE autonyilvantartas";

        }
    }
}
