using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DemoSqlInjection.Models
{
    public class DbConnection
    {
        string strCon;
        public DbConnection()
        {
            strCon = ConfigurationManager.ConnectionStrings["SqlInjectionConnectionString"].ConnectionString;
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(strCon);
        }
    }

}