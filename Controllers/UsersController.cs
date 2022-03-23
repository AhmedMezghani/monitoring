using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Monitoring2.Models;
using System.Data.SqlClient;

namespace Monitoring2.Controllers
{
    public class UsersController : Controller
    {
        private SiteDbEntities2 db = new SiteDbEntities2();

        // GET: MonitoringUsers2
        public ActionResult Index()
        {
            return View(db.MonitoringUser.ToList());
        }

        // GET: MonitoringUsers2/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonitoringUser monitoringUser = db.MonitoringUser.Find(id);
            if (monitoringUser == null)
            {
                return HttpNotFound();
            }
            return View(monitoringUser);
        }

        // GET: MonitoringUsers2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonitoringUsers2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserName,Password")] MonitoringUser monitoringUser)
        {
            if (ModelState.IsValid)
            {
                db.MonitoringUser.Add(monitoringUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monitoringUser);
        }

        
        public void Register(string username, string password)
        {
            MonitoringUser monitoringUser = new MonitoringUser();
            monitoringUser.UserName = username;
            monitoringUser.Password = password;
            string connectionString = "data source=(LocalDb)\\MSSQLLocalDB;initial catalog=SiteDb;Integrated Security=True;User=LAPTOP-POATUUVT\\ASUS;Password=HElloo123";
            SqlConnection connection = new SqlConnection(@connectionString);
            string query = "INSERT INTO MonitoringUser (Username,Password) VALUES(@username,@password)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                connection.Close();
            }
        }
        public int verifUsername(string username,string password)
        {
            DataTable dt = new DataTable();

            string ConnectString = "data source=(LocalDb)\\MSSQLLocalDB;initial catalog=SiteDb;Integrated Security=True;User=LAPTOP-POATUUVT\\ASUS;Password=HElloo123";
            string QueryString = "select * from MonitoringUser where UserName=@username";

            SqlConnection myConnection = new SqlConnection(ConnectString);
            SqlDataAdapter myCommand = new SqlDataAdapter(QueryString, myConnection);
            myCommand.SelectCommand.Parameters.AddWithValue("@username", username);
            myCommand.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                Register(username, password);
                return 1;
            }
            return 0;
        }

       
       
        // GET: Users/Create
        public ActionResult login()
        {
            return View();
        }
        public int LoginSite(string username, string password)
        {
            DataTable dt = new DataTable();

            string ConnectString = "data source=(LocalDb)\\MSSQLLocalDB;initial catalog=SiteDb;Integrated Security=True;User=LAPTOP-POATUUVT\\ASUS;Password=HElloo123";
            string QueryString = "select * from MonitoringUser where UserName=@username and Password=@password";

            SqlConnection myConnection = new SqlConnection(ConnectString);
            SqlDataAdapter myCommand = new SqlDataAdapter(QueryString, myConnection);
            myCommand.SelectCommand.Parameters.AddWithValue("@username", username);
            myCommand.SelectCommand.Parameters.AddWithValue("@password", password);
            myCommand.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                return 1;
            }
            
            return 0;
        }
        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(string username,string password)
        {
            if (ModelState.IsValid)
            {
                string indexUser = db.MonitoringUser.Find(username);   
                if ()
                db.MonitoringUser.Add(monitoringUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monitoringUser);
        }*/
        public void GetDb(String Username, String password)
        {
            /*foreach (var item in db.MonitoringUser)
            {
               username.Add(item.UserName);
            }
            Console.WriteLine("aaaaaa5");
                return username;
            */
        }
    }
}
