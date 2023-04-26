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
    public class MC_remainController : Controller
    {
        private volunteer_orgEntities db = new volunteer_orgEntities();

        // GET: MC_remain
        public ActionResult Index()
        {
            var mC_remain = db.MC_remain.Include(m => m.MC);
            return View(mC_remain.ToList());
        }

        // GET: MC_remain/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MC_remain mC_remain = db.MC_remain.Find(id);
            if (mC_remain == null)
            {
                return HttpNotFound();
            }
            return View(mC_remain);
        }

        // GET: MC_remain/Create
        public ActionResult Create()
        {
            ViewBag.mc_ID = new SelectList(db.MC, "ID", "name");
            return View();
        }

        // POST: MC_remain/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,mc_ID,amount")] MC_remain mC_remain)
        {
            if (ModelState.IsValid)
            {
                db.MC_remain.Add(mC_remain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mc_ID = new SelectList(db.MC, "ID", "name", mC_remain.mc_ID);
            return View(mC_remain);
        }

        // GET: MC_remain/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MC_remain mC_remain = db.MC_remain.Find(id);
            if (mC_remain == null)
            {
                return HttpNotFound();
            }
            ViewBag.mc_ID = new SelectList(db.MC, "ID", "name", mC_remain.mc_ID);
            return View(mC_remain);
        }

        // POST: MC_remain/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,mc_ID,amount")] MC_remain mC_remain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mC_remain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mc_ID = new SelectList(db.MC, "ID", "name", mC_remain.mc_ID);
            return View(mC_remain);
        }

        // GET: MC_remain/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MC_remain mC_remain = db.MC_remain.Find(id);
            if (mC_remain == null)
            {
                return HttpNotFound();
            }
            return View(mC_remain);
        }

        // POST: MC_remain/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MC_remain mC_remain = db.MC_remain.Find(id);
            db.MC_remain.Remove(mC_remain);
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
