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
    public class Dohidna_nController : Controller
    {
        private volunteer_orgEntities db = new volunteer_orgEntities();

        // GET: Dohidna_n
        public ActionResult Index()
        {
            var dohidna_n = db.Dohidna_n.Include(d => d.Member).Include(d => d.Vydatkovy_ko);
            return View(dohidna_n.ToList());
        }

        // GET: Dohidna_n/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dohidna_n dohidna_n = db.Dohidna_n.Find(id);
            if (dohidna_n == null)
            {
                return HttpNotFound();
            }
            return View(dohidna_n);
        }

        // GET: Dohidna_n/Create
        public ActionResult Create()
        {
            ViewBag.member_ID = new SelectList(db.Member, "ID", "full_name");
            ViewBag.ID = new SelectList(db.Vydatkovy_ko, "ID", "number");
            return View();
        }

        // POST: Dohidna_n/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,date,member_ID")] Dohidna_n dohidna_n)
        {
            if (ModelState.IsValid)
            {
                db.Dohidna_n.Add(dohidna_n);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.member_ID = new SelectList(db.Member, "ID", "full_name", dohidna_n.member_ID);
            ViewBag.ID = new SelectList(db.Vydatkovy_ko, "ID", "number", dohidna_n.ID);
            return View(dohidna_n);
        }

        // GET: Dohidna_n/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dohidna_n dohidna_n = db.Dohidna_n.Find(id);
            if (dohidna_n == null)
            {
                return HttpNotFound();
            }
            ViewBag.member_ID = new SelectList(db.Member, "ID", "full_name", dohidna_n.member_ID);
            ViewBag.ID = new SelectList(db.Vydatkovy_ko, "ID", "number", dohidna_n.ID);
            return View(dohidna_n);
        }

        // POST: Dohidna_n/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,date,member_ID")] Dohidna_n dohidna_n)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dohidna_n).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.member_ID = new SelectList(db.Member, "ID", "full_name", dohidna_n.member_ID);
            ViewBag.ID = new SelectList(db.Vydatkovy_ko, "ID", "number", dohidna_n.ID);
            return View(dohidna_n);
        }

        // GET: Dohidna_n/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dohidna_n dohidna_n = db.Dohidna_n.Find(id);
            if (dohidna_n == null)
            {
                return HttpNotFound();
            }
            return View(dohidna_n);
        }

        // POST: Dohidna_n/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dohidna_n dohidna_n = db.Dohidna_n.Find(id);
            db.Dohidna_n.Remove(dohidna_n);
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
