using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace WebDemov3.Models
{
    public static class SettingSQLModel
    {
        static string connectString = "server=localhost;uid=ifmsolut_admin;pwd=1012@pass;database=ifmsolut_maindb;port=3306";

        public static MySqlConnection GetDBConnection()
        {
            return new MySqlConnection(connectString);
        }
    }
}