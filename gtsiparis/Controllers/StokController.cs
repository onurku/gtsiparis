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
    public class StokController : Controller
    {
        private Model1 db = new Model1();

        // GET: Stok
        public ActionResult Index()
        {
            var stok = db.Stok.Include(s => s.Urun);
            return View(stok.ToList());
        }

        // GET: Stok/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stok stok = db.Stok.Find(id);
            if (stok == null)
            {
                return HttpNotFound();
            }
            return View(stok);
        }

        // GET: Stok/Create
        public ActionResult Create()
        {
            ViewBag.UrunId = new SelectList(db.Urun, "Id", "Adi");
            return View();
        }

        // POST: Stok/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UrunId,SonStok,Miktar,GirdiCikti,Tarih")] Stok stok)
        {
            if (ModelState.IsValid)
            {
                db.Stok.Add(stok);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UrunId = new SelectList(db.Urun, "Id", "Adi", stok.UrunId);
            return View(stok);
        }

        // GET: Stok/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stok stok = db.Stok.Find(id);
            if (stok == null)
            {
                return HttpNotFound();
            }
            ViewBag.UrunId = new SelectList(db.Urun, "Id", "Adi", stok.UrunId);
            return View(stok);
        }

        // POST: Stok/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UrunId,SonStok,Miktar,GirdiCikti,Tarih")] Stok stok)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stok).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UrunId = new SelectList(db.Urun, "Id", "Adi", stok.UrunId);
            return View(stok);
        }

        // GET: Stok/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stok stok = db.Stok.Find(id);
            if (stok == null)
            {
                return HttpNotFound();
            }
            return View(stok);
        }

        // POST: Stok/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stok stok = db.Stok.Find(id);
            db.Stok.Remove(stok);
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
