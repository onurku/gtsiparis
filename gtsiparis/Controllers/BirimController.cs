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
    public class BirimController : Controller
    {
        private Model1 db = new Model1();

        // GET: Birim
        public ActionResult Index()
        {
            return View(db.Birim.ToList());
        }

        // GET: Birim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Birim birim = db.Birim.Find(id);
            if (birim == null)
            {
                return HttpNotFound();
            }
            return View(birim);
        }

        // GET: Birim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Birim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BirimAdi")] Birim birim)
        {
            if (ModelState.IsValid)
            {
                db.Birim.Add(birim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(birim);
        }

        // GET: Birim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Birim birim = db.Birim.Find(id);
            if (birim == null)
            {
                return HttpNotFound();
            }
            return View(birim);
        }

        // POST: Birim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BirimAdi")] Birim birim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(birim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(birim);
        }

        // GET: Birim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Birim birim = db.Birim.Find(id);
            if (birim == null)
            {
                return HttpNotFound();
            }
            return View(birim);
        }

        // POST: Birim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Birim birim = db.Birim.Find(id);
            db.Birim.Remove(birim);
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
