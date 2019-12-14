using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemov3.Models;

namespace WebDemov3.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            SettingSQLModel.GetDBConnection().Open();
            string sql = "Select * from `m_username` where user_name ='" + username + "' ";
            sql += "and password ='" + password + "'";
            MySql.Data.MySqlClient.MySqlCommand cmd =
                new MySql.Data.MySqlClient.MySqlCommand(sql, SettingSQLModel.GetDBConnection());
            if (cmd.ExecuteScalar() != null)
            {
                return Content("Dang nhap thanh cong");
            }
            else
                return Content("Fail!!!");
        }
    }
}