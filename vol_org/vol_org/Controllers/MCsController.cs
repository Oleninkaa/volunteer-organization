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
    public class MCsController : Controller
    {
        private volunteer_orgEntities db = new volunteer_orgEntities();

        // GET: MCs
        public ActionResult Index()
        {
            return View(db.MC.ToList());
        }

        // GET: MCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MC mC = db.MC.Find(id);
            if (mC == null)
            {
                return HttpNotFound();
            }
            return View(mC);
        }

        // GET: MCs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MCs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,unit,price")] MC mC)
        {
            if (ModelState.IsValid)
            {
                db.MC.Add(mC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mC);
        }

        // GET: MCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MC mC = db.MC.Find(id);
            if (mC == null)
            {
                return HttpNotFound();
            }
            return View(mC);
        }

        // POST: MCs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,unit,price")] MC mC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mC);
        }

        // GET: MCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MC mC = db.MC.Find(id);
            if (mC == null)
            {
                return HttpNotFound();
            }
            return View(mC);
        }

        // POST: MCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MC mC = db.MC.Find(id);
            db.MC.Remove(mC);
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
