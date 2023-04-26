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
    public class Doh_numController : Controller
    {
        private volunteer_orgEntities db = new volunteer_orgEntities();

        // GET: Doh_num
        public ActionResult Index()
        {
            var doh_num = db.Doh_num.Include(d => d.MC).Include(d => d.Dohidna_n).Include(d => d.MC1);
            return View(doh_num.ToList());
        }

        // GET: Doh_num/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doh_num doh_num = db.Doh_num.Find(id);
            if (doh_num == null)
            {
                return HttpNotFound();
            }
            return View(doh_num);
        }

        // GET: Doh_num/Create
        public ActionResult Create()
        {
            ViewBag.mc_ID = new SelectList(db.MC, "ID", "name");
            ViewBag.dohidna_ID = new SelectList(db.Dohidna_n, "ID", "ID");
            ViewBag.mc_ID = new SelectList(db.MC, "ID", "name");
            return View();
        }

        // POST: Doh_num/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,dohidna_ID,number,quantity,mc_ID")] Doh_num doh_num)
        {
            if (ModelState.IsValid)
            {
                db.Doh_num.Add(doh_num);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mc_ID = new SelectList(db.MC, "ID", "name", doh_num.mc_ID);
            ViewBag.dohidna_ID = new SelectList(db.Dohidna_n, "ID", "ID", doh_num.dohidna_ID);
            ViewBag.mc_ID = new SelectList(db.MC, "ID", "name", doh_num.mc_ID);
            return View(doh_num);
        }

        // GET: Doh_num/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doh_num doh_num = db.Doh_num.Find(id);
            if (doh_num == null)
            {
                return HttpNotFound();
            }
            ViewBag.mc_ID = new SelectList(db.MC, "ID", "name", doh_num.mc_ID);
            ViewBag.dohidna_ID = new SelectList(db.Dohidna_n, "ID", "ID", doh_num.dohidna_ID);
            ViewBag.mc_ID = new SelectList(db.MC, "ID", "name", doh_num.mc_ID);
            return View(doh_num);
        }

        // POST: Doh_num/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,dohidna_ID,number,quantity,mc_ID")] Doh_num doh_num)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doh_num).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mc_ID = new SelectList(db.MC, "ID", "name", doh_num.mc_ID);
            ViewBag.dohidna_ID = new SelectList(db.Dohidna_n, "ID", "ID", doh_num.dohidna_ID);
            ViewBag.mc_ID = new SelectList(db.MC, "ID", "name", doh_num.mc_ID);
            return View(doh_num);
        }

        // GET: Doh_num/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doh_num doh_num = db.Doh_num.Find(id);
            if (doh_num == null)
            {
                return HttpNotFound();
            }
            return View(doh_num);
        }

        // POST: Doh_num/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doh_num doh_num = db.Doh_num.Find(id);
            db.Doh_num.Remove(doh_num);
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
