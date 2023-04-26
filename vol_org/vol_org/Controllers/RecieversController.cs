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
    public class RecieversController : Controller
    {
        private volunteer_orgEntities db = new volunteer_orgEntities();

        // GET: Recievers
        public ActionResult Index()
        {
            return View(db.Reciever.ToList());
        }

        // GET: Recievers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reciever reciever = db.Reciever.Find(id);
            if (reciever == null)
            {
                return HttpNotFound();
            }
            return View(reciever);
        }

        // GET: Recievers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recievers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,military_unit,department,full_name")] Reciever reciever)
        {
            if (ModelState.IsValid)
            {
                db.Reciever.Add(reciever);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reciever);
        }

        // GET: Recievers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reciever reciever = db.Reciever.Find(id);
            if (reciever == null)
            {
                return HttpNotFound();
            }
            return View(reciever);
        }

        // POST: Recievers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,military_unit,department,full_name")] Reciever reciever)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reciever).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reciever);
        }

        // GET: Recievers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reciever reciever = db.Reciever.Find(id);
            if (reciever == null)
            {
                return HttpNotFound();
            }
            return View(reciever);
        }

        // POST: Recievers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reciever reciever = db.Reciever.Find(id);
            db.Reciever.Remove(reciever);
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
