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
    public class Vydatkova_nController : Controller
    {
        private volunteer_orgEntities db = new volunteer_orgEntities();

        // GET: Vydatkova_n
        public ActionResult Index()
        {
            var vydatkova_n = db.Vydatkova_n.Include(v => v.MC).Include(v => v.Reciever);
            return View(vydatkova_n.ToList());
        }

        // GET: Vydatkova_n/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vydatkova_n vydatkova_n = db.Vydatkova_n.Find(id);
            if (vydatkova_n == null)
            {
                return HttpNotFound();
            }
            return View(vydatkova_n);
        }

        // GET: Vydatkova_n/Create
        public ActionResult Create()
        {
            ViewBag.mc_ID = new SelectList(db.MC, "ID", "name");
            ViewBag.reciever_ID = new SelectList(db.Reciever, "ID", "military_unit");
            return View();
        }

        // POST: Vydatkova_n/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,number,date,quantity,reciever_ID,mc_ID")] Vydatkova_n vydatkova_n)
        {
            if (ModelState.IsValid)
            {
                db.Vydatkova_n.Add(vydatkova_n);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mc_ID = new SelectList(db.MC, "ID", "name", vydatkova_n.mc_ID);
            ViewBag.reciever_ID = new SelectList(db.Reciever, "ID", "military_unit", vydatkova_n.reciever_ID);
            return View(vydatkova_n);
        }

        // GET: Vydatkova_n/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vydatkova_n vydatkova_n = db.Vydatkova_n.Find(id);
            if (vydatkova_n == null)
            {
                return HttpNotFound();
            }
            ViewBag.mc_ID = new SelectList(db.MC, "ID", "name", vydatkova_n.mc_ID);
            ViewBag.reciever_ID = new SelectList(db.Reciever, "ID", "military_unit", vydatkova_n.reciever_ID);
            return View(vydatkova_n);
        }

        // POST: Vydatkova_n/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,number,date,quantity,reciever_ID,mc_ID")] Vydatkova_n vydatkova_n)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vydatkova_n).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mc_ID = new SelectList(db.MC, "ID", "name", vydatkova_n.mc_ID);
            ViewBag.reciever_ID = new SelectList(db.Reciever, "ID", "military_unit", vydatkova_n.reciever_ID);
            return View(vydatkova_n);
        }

        // GET: Vydatkova_n/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vydatkova_n vydatkova_n = db.Vydatkova_n.Find(id);
            if (vydatkova_n == null)
            {
                return HttpNotFound();
            }
            return View(vydatkova_n);
        }

        // POST: Vydatkova_n/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vydatkova_n vydatkova_n = db.Vydatkova_n.Find(id);
            db.Vydatkova_n.Remove(vydatkova_n);
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
