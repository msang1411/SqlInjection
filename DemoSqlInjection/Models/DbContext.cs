using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DemoSqlInjection.Models
{
    public class DbContext
    {
        DbConnection db = new DbConnection();
        public AccountModel GetAccount(string account,string password)
        {
            string sql = "select * from Account where Account = '"+account+"' and Password = '"+password+"'";

            SqlConnection con = db.GetConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            //Open connection
            con.Open();
            cmd.Fill(dt);
            //close connection
            cmd.Dispose();
            con.Close();

            AccountModel strMM;
            if (dt.Rows.Count == 0)
            {
                strMM = new AccountModel();
                return strMM;
            }
            

                strMM = new AccountModel();
                strMM.AccountID = Convert.ToInt32(dt.Rows[0]["AccountID"].ToString());
                strMM.Account = dt.Rows[0]["Account"].ToString();
                strMM.Password = dt.Rows[0]["Password"].ToString();

                return strMM;

            
        }
    }
}