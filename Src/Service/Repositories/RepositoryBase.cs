using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Service;

namespace Service.Repositories
{
    class RepositoryBase
    {
        public static IDbConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        }

    }
}
