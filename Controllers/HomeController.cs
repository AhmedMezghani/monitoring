using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Monitoring.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Sites()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Create()
        {
            ViewBag.Message = "Create new page";

            return View();
        }
        public ActionResult LogIn()
        {
            ViewBag.Message = "Create new page";

            return View();
        }
        public void SendEmail(string FullName,string AddressEmail,String Tel,string Message)
        {
                System.Net.Mail.MailMessage Email = new System.Net.Mail.MailMessage();

                Email.Body = "name : " + FullName + "\nAddress Email : " + AddressEmail + "\nTel : " + Tel + "\nMessage : " + Message;
                Email.Subject = "Contact";
                Email.IsBodyHtml = true;
                Email.To.Clear();
                Email.From = new System.Net.Mail.MailAddress("MonitoringSite.mezghani@gmail.com");
                Email.To.Add(new System.Net.Mail.MailAddress("mezghaniahmed55@gmail.com"));
                System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient();
                mailClient.Host = "smtp.gmail.com";
                mailClient.Port = 587;
                mailClient.EnableSsl = true;
                System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential() { UserName = "MonitoringSite.mezghani@gmail.com", Password = "monitoring12345678" };
                mailClient.UseDefaultCredentials = true;
                mailClient.Credentials = basicAuthenticationInfo;
                mailClient.Send(Email);
        } 

    }
}