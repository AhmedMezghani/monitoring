using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Windows;
using Monitoring2.Models;
using System.Threading.Tasks;
namespace Monitoring2.Controllers
{
    public class SitesController : Controller
    {
        private SiteDbEntities2 db = new SiteDbEntities2();

        // GET: Sites
        public ActionResult Index()
        {
            //MessageBox.Show("ton message");
            return View(db.MonitoringSite.ToList());
        }

        // GET: Sites/Details/5
        public ActionResult Details(int? id)
        {
            int id2 = (int)id;
            Console.Write(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonitoringSite monitoringSite = db.MonitoringSite.Find(id);
            if (monitoringSite == null)
            {
                return HttpNotFound();
            }
            
            return View(monitoringSite);
        }

        // GET: Sites/Create
        public ActionResult Create()
        {
            return View(new MonitoringSite());
        }

        // POST: Sites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MonitoringSiteId,Url,Interval,VerifyWord,Active,LastRun,SendEmail,Username,Password,UserNameTextInputName,PasswordTextInputName,LoginSubmitButtonName,ReportSubmitButtonName,NbFail,IntervalSec")] MonitoringSite monitoringSite)
        {
            if (ModelState.IsValid)
            {
                db.MonitoringSite.Add(monitoringSite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monitoringSite);
        }

        // GET: Sites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonitoringSite monitoringSite = db.MonitoringSite.Find(id);
            if (monitoringSite == null)
            {
                return HttpNotFound();
            }
            return View(monitoringSite);
        }

        // POST: Sites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MonitoringSiteId,Url,Interval,VerifyWord,Active,LastRun,SendEmail,Username,Password,UserNameTextInputName,PasswordTextInputName,LoginSubmitButtonName,ReportSubmitButtonName,NbFail,IntervalSec")] MonitoringSite monitoringSite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monitoringSite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monitoringSite);
        }

        // GET: Sites/Delete/5
        public ActionResult Delete(int? id)
        {
            MonitoringSite monitoringSite = db.MonitoringSite.Find(id);
            db.MonitoringSite.Remove(monitoringSite);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Sites/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            MonitoringSite monitoringSite = db.MonitoringSite.Find(id);
            db.MonitoringSite.Remove(monitoringSite);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
