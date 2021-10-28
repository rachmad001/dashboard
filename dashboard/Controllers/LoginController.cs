using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace dashboard.Controllers
{
    public class LoginController : Controller
    {
        //mysql
        //private static string connStr = "server=localhost;user=root;database=learn;port=3306;password=@QazXsw21";
        //private MySqlConnection conn = new MySqlConnection(connStr);
        //private bool statusConn = false;

        //sql server
        private static string connStr = "Server=RACHMAD\\MSSQLSERVER01;Database=kpp;Trusted_Connection=True";
        private SqlConnection conn = new SqlConnection(connStr);
        private bool statusConn = false;
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Validasi()
        {
            if (!statusConn)
            {
                try
                {
                    conn.Open();
                    statusConn = true;
                }
                catch (Exception ex)
                {
                    statusConn = false;
                    return Content("{\"status\": \"fail\", \"msg\": \"eror connection\"}");
                }
            }
            if (statusConn)
            {
                String username = Request["username"];
                String password = Request["password"];
                string SQL = string.Format("Select * from account where username='{0}' AND password='{1}'", MySqlEscape(username), MySqlEscape(password));
                //mysql
                //MySqlCommand cmd = new MySqlCommand(SQL, conn);
                //MySqlDataReader rdr = cmd.ExecuteReader();

                SqlCommand cmd = new SqlCommand(SQL, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Session["username"] = username;
                    return Content("{\"status\": true, \"msg\": \"account found\"}");
                }
                else
                {
                    return Content("{\"status\": false, \"msg\": \"account not found\"}");
                }
            }
            return Content("tes");
        }

        private static string MySqlEscape(string str)
        {
            return Regex.Replace(str, @"[\x00'""\b\n\r\t\cZ\\%_]",
            delegate (Match match)
            {
                string v = match.Value;
                switch (v)
                {
                    case "\x00":            // ASCII NUL (0x00) character
                        return "\\0";
                    case "\b":              // BACKSPACE character
                        return "\\b";
                    case "\n":              // NEWLINE (linefeed) character
                        return "\\n";
                    case "\r":              // CARRIAGE RETURN character
                        return "\\r";
                    case "\t":              // TAB
                        return "\\t";
                    case "\u001A":          // Ctrl-Z
                        return "\\Z";
                    default:
                        return "\\" + v;
                }
            });
        } 
    }
}