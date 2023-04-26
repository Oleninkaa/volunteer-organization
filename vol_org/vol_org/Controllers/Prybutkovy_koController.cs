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
    public class Prybutkovy_koController : Controller
    {
        private volunteer_orgEntities db = new volunteer_orgEntities();

        // GET: Prybutkovy_ko
        public ActionResult Index()
        {
            var prybutkovy_ko = db.Prybutkovy_ko.Include(p => p.Balance).Include(p => p.Member);
            return View(prybutkovy_ko.ToList());
        }

        // GET: Prybutkovy_ko/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prybutkovy_ko prybutkovy_ko = db.Prybutkovy_ko.Find(id);
            if (prybutkovy_ko == null)
            {
                return HttpNotFound();
            }
            return View(prybutkovy_ko);
        }

        // GET: Prybutkovy_ko/Create
        public ActionResult Create()
        {
            ViewBag.balance_ID = new SelectList(db.Balance, "ID", "ID");
            ViewBag.member_ID = new SelectList(db.Member, "ID", "full_name");
            return View();
        }

        // POST: Prybutkovy_ko/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,balance_ID,number,date,sum,member_ID")] Prybutkovy_ko prybutkovy_ko)
        {
            if (ModelState.IsValid)
            {
                db.Prybutkovy_ko.Add(prybutkovy_ko);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.balance_ID = new SelectList(db.Balance, "ID", "ID", prybutkovy_ko.balance_ID);
            ViewBag.member_ID = new SelectList(db.Member, "ID", "full_name", prybutkovy_ko.member_ID);
            return View(prybutkovy_ko);
        }

        // GET: Prybutkovy_ko/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prybutkovy_ko prybutkovy_ko = db.Prybutkovy_ko.Find(id);
            if (prybutkovy_ko == null)
            {
                return HttpNotFound();
            }
            ViewBag.balance_ID = new SelectList(db.Balance, "ID", "ID", prybutkovy_ko.balance_ID);
            ViewBag.member_ID = new SelectList(db.Member, "ID", "full_name", prybutkovy_ko.member_ID);
            return View(prybutkovy_ko);
        }

        // POST: Prybutkovy_ko/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,balance_ID,number,date,sum,member_ID")] Prybutkovy_ko prybutkovy_ko)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prybutkovy_ko).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.balance_ID = new SelectList(db.Balance, "ID", "ID", prybutkovy_ko.balance_ID);
            ViewBag.member_ID = new SelectList(db.Member, "ID", "full_name", prybutkovy_ko.member_ID);
            return View(prybutkovy_ko);
        }

        // GET: Prybutkovy_ko/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prybutkovy_ko prybutkovy_ko = db.Prybutkovy_ko.Find(id);
            if (prybutkovy_ko == null)
            {
                return HttpNotFound();
            }
            return View(prybutkovy_ko);
        }

        // POST: Prybutkovy_ko/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prybutkovy_ko prybutkovy_ko = db.Prybutkovy_ko.Find(id);
            db.Prybutkovy_ko.Remove(prybutkovy_ko);
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
