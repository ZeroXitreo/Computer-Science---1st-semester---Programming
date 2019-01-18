using Logic.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    static class DB
    {
        private static readonly string connectionString = string.Format("Server={0}; Database={1}; User Id={2}; Password={3};", Settings.Default.dbserver, Settings.Default.dbname, Settings.Default.dbuser, Settings.Default.dbpassword);
        internal static readonly SqlConnection Connection = new SqlConnection(connectionString);
    }
}
