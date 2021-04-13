using DemoSqlInjection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoSqlInjection.Controllers
{
    public class HomeController : Controller
    {
        DbContext dbC = new DbContext();
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string account,string password)
        {
            AccountModel acc = dbC.GetAccount(account, password);
            if(acc.Account != null)
            {
                Session["Account"] = acc;
                return RedirectToAction("Admin");
            }
            ViewBag.Mess = "Sai mat khau hay cai gi do roi bro";
            return View();
        }
        public ActionResult Admin()
        {
            //AccountModel acc = Session["Account"] as AccountModel;
            if (Session["Account"] != null)
            {
                return View();
            }
            return RedirectToAction("Login");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}