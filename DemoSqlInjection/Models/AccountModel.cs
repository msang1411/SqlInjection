using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoSqlInjection.Models
{
    public class AccountModel
    {
        public int AccountID { set; get; }
        public string Account { set; get; }
        public string Password { set; get; }
    }
}