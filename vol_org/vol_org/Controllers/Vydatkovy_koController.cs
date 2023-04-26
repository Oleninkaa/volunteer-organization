using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using vol_org.Models;

namespace vol_org.Controllers
{
    public class Vydatkovy_koController : Controller
    {
        private volunteer_orgEntities db = new volunteer_orgEntities();

        // GET: Vydatkovy_ko
        public ActionResult Index()
        {
            var vydatkovy_ko = db.Vydatkovy_ko.Include(v => v.Balance).Include(v => v.Dohidna_n);
            return View(vydatkovy_ko.ToList());
        }

        // GET: Vydatkovy_ko/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vydatkovy_ko vydatkovy_ko = db.Vydatkovy_ko.Find(id);
            if (vydatkovy_ko == null)
            {
                return HttpNotFound();
            }
            return View(vydatkovy_ko);
        }

        // GET: Vydatkovy_ko/Create
        public ActionResult Create()
        {
            ViewBag.balance_ID = new SelectList(db.Balance, "ID", "ID");
            ViewBag.ID = new SelectList(db.Dohidna_n, "ID", "ID");
            return View();
        }

        // POST: Vydatkovy_ko/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,number,date,sum,reason,balance_ID")] Vydatkovy_ko vydatkovy_ko)
        {
            if (ModelState.IsValid)
            {
                db.Vydatkovy_ko.Add(vydatkovy_ko);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.balance_ID = new SelectList(db.Balance, "ID", "ID", vydatkovy_ko.balance_ID);
            ViewBag.ID = new SelectList(db.Dohidna_n, "ID", "ID", vydatkovy_ko.ID);
            return View(vydatkovy_ko);
        }

        // GET: Vydatkovy_ko/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vydatkovy_ko vydatkovy_ko = db.Vydatkovy_ko.Find(id);
            if (vydatkovy_ko == null)
            {
                return HttpNotFound();
            }
            ViewBag.balance_ID = new SelectList(db.Balance, "ID", "ID", vydatkovy_ko.balance_ID);
            ViewBag.ID = new SelectList(db.Dohidna_n, "ID", "ID", vydatkovy_ko.ID);
            return View(vydatkovy_ko);
        }

        // POST: Vydatkovy_ko/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,number,date,sum,reason,balance_ID")] Vydatkovy_ko vydatkovy_ko)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vydatkovy_ko).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.balance_ID = new SelectList(db.Balance, "ID", "ID", vydatkovy_ko.balance_ID);
            ViewBag.ID = new SelectList(db.Dohidna_n, "ID", "ID", vydatkovy_ko.ID);
            return View(vydatkovy_ko);
        }

        // GET: Vydatkovy_ko/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vydatkovy_ko vydatkovy_ko = db.Vydatkovy_ko.Find(id);
            if (vydatkovy_ko == null)
            {
                return HttpNotFound();
            }
            return View(vydatkovy_ko);
        }

        // POST: Vydatkovy_ko/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vydatkovy_ko vydatkovy_ko = db.Vydatkovy_ko.Find(id);
            db.Vydatkovy_ko.Remove(vydatkovy_ko);
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
