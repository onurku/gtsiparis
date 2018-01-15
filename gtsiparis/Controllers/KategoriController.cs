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
    public class KategoriController : Controller
    {
        private Model1 db = new Model1();
        
        // GET: Kategori
        public ActionResult Index()
        {
            var kategori = db.Kategori.Include(k => k.Grup).Include(k => k.Kullanici).Include(k => k.Lokasyon);
            return View(kategori.ToList());
        }

        // GET: Kategori/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = db.Kategori.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        // GET: Kategori/Create
        public ActionResult Create()
        {
            ViewBag.Grup_Id = new SelectList(db.Grup, "Id", "GrupAdi");
            ViewBag.CreatedBy_Id = new SelectList(db.Users, "Id", "AdSoyad");
            ViewBag.Lokasyon_Id = new SelectList(db.Lokasyon, "Id", "LokasyonAdi");
            return View();
        }

        // POST: Kategori/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KategoriAdi,Aktif,CreatedTime,CreatedBy_Id,Grup_Id,Lokasyon_Id")] Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                db.Kategori.Add(kategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Grup_Id = new SelectList(db.Grup, "Id", "GrupAdi", kategori.Grup_Id);
            ViewBag.CreatedBy_Id = new SelectList(db.Users, "Id", "AdSoyad", kategori.CreatedBy_Id);
            ViewBag.Lokasyon_Id = new SelectList(db.Lokasyon, "Id", "LokasyonAdi", kategori.Lokasyon_Id);
            return View(kategori);
        }

        // GET: Kategori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = db.Kategori.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            ViewBag.Grup_Id = new SelectList(db.Grup, "Id", "GrupAdi", kategori.Grup_Id);
            ViewBag.CreatedBy_Id = new SelectList(db.Users, "Id", "AdSoyad", kategori.CreatedBy_Id);
            ViewBag.Lokasyon_Id = new SelectList(db.Lokasyon, "Id", "LokasyonAdi", kategori.Lokasyon_Id);
            return View(kategori);
        }

        // POST: Kategori/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KategoriAdi,Aktif,CreatedTime,CreatedBy_Id,Grup_Id,Lokasyon_Id")] Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Grup_Id = new SelectList(db.Grup, "Id", "GrupAdi", kategori.Grup_Id);
            ViewBag.CreatedBy_Id = new SelectList(db.Users, "Id", "AdSoyad", kategori.CreatedBy_Id);
            ViewBag.Lokasyon_Id = new SelectList(db.Lokasyon, "Id", "LokasyonAdi", kategori.Lokasyon_Id);
            return View(kategori);
        }

        // GET: Kategori/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = db.Kategori.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        // POST: Kategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategori kategori = db.Kategori.Find(id);
            db.Kategori.Remove(kategori);
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
