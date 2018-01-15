using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using gtsiparis;

namespace gtsiparis.Controllers
{
    public class GrupController : Controller
    {
        private Model1 db = new Model1();

        // GET: Grup
        public ActionResult Index()
        {
            var grup = db.Grup.Include(g => g.Lokasyon);
            return View(grup.ToList());
        }

        // GET: Grup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grup grup = db.Grup.Find(id);
            if (grup == null)
            {
                return HttpNotFound();
            }
            return View(grup);
        }

        // GET: Grup/Create
        public ActionResult Create()
        {
            ViewBag.Lokasyon_Id = new SelectList(db.Lokasyon, "Id", "LokasyonAdi");
            return View();
        }

        // POST: Grup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GrupAdi,Lokasyon_Id")] Grup grup)
        {
            if (ModelState.IsValid)
            {
                db.Grup.Add(grup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Lokasyon_Id = new SelectList(db.Lokasyon, "Id", "LokasyonAdi", grup.Lokasyon_Id);
            return View(grup);
        }

        // GET: Grup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grup grup = db.Grup.Find(id);
            if (grup == null)
            {
                return HttpNotFound();
            }
            ViewBag.Lokasyon_Id = new SelectList(db.Lokasyon, "Id", "LokasyonAdi", grup.Lokasyon_Id);
            return View(grup);
        }

        // POST: Grup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GrupAdi,Lokasyon_Id")] Grup grup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Lokasyon_Id = new SelectList(db.Lokasyon, "Id", "LokasyonAdi", grup.Lokasyon_Id);
            return View(grup);
        }

        // GET: Grup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grup grup = db.Grup.Find(id);
            if (grup == null)
            {
                return HttpNotFound();
            }
            return View(grup);
        }

        // POST: Grup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grup grup = db.Grup.Find(id);
            db.Grup.Remove(grup);
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
