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
    public class SiparisController : Controller
    {
        private Model1 db = new Model1();

        // GET: Siparis
        public ActionResult Index()
        {
            var siparis = db.Siparis.Include(s => s.Kullanici).Include(s => s.Urun);
            return View(siparis.ToList());
        }

        // GET: Siparis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Siparis.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            return View(siparis);
        }

        // GET: Siparis/Create
        public ActionResult Create()
        {
            ViewBag.Kullanici_Id = new SelectList(db.Users, "Id", "AdSoyad");
            ViewBag.Urun_Id = new SelectList(db.Users, "Id", "AdSoyad");
            ViewBag.OnayliKullanici_ID = new SelectList(db.Users, "Id", "AdSoyad");

            return View();
        }

        // POST: Siparis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Miktar,Tarih,Onay,Iade,Kullanici_Id,Urun_Id")] Siparis siparis)
        {
            if (ModelState.IsValid)
            {
                db.Siparis.Add(siparis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
      
            ViewBag.Kullanici_Id = new SelectList(db.Users, "Id", "AdSoyad", siparis.Kullanici_Id);
            ViewBag.Urun_Id = new SelectList(db.Urun, "Id", "Adi", siparis.Urun_Id);
            return View(siparis);
        }

        // GET: Siparis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Siparis.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            ViewBag.Kullanici_Id = new SelectList(db.Users, "Id", "AdSoyad", siparis.Kullanici_Id);
            ViewBag.Urun_Id = new SelectList(db.Urun, "Id", "Adi", siparis.Urun_Id);
            return View(siparis);
        }

        // POST: Siparis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Miktar,Tarih,Iade,Kullanici_Id,Urun_Id")] Siparis siparis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siparis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Kullanici_Id = new SelectList(db.Users, "Id", "AdSoyad", siparis.Kullanici_Id);
            ViewBag.Urun_Id = new SelectList(db.Urun, "Id", "Adi", siparis.Urun_Id);
            return View(siparis);
        }

        // GET: Siparis/Edit/5
        public ActionResult EditAdmin(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Siparis.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            ViewBag.Kullanici_Id = new SelectList(db.Users, "Id", "AdSoyad", siparis.Kullanici_Id);
            ViewBag.Urun_Id = new SelectList(db.Urun, "Id", "Adi", siparis.Urun_Id);
            return View(siparis);
        }

        // POST: Siparis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAdmin([Bind(Include = "Id,Miktar,Tarih,Iade,Kullanici_Id,Urun_Id")] Siparis siparis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siparis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Genel","TumSiparisler");
            }
            ViewBag.Kullanici_Id = new SelectList(db.Users, "Id", "AdSoyad", siparis.Kullanici_Id);
            ViewBag.Urun_Id = new SelectList(db.Urun, "Id", "Adi", siparis.Urun_Id);
            return View(siparis);
        }

        // GET: Siparis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Siparis.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            return View(siparis);
        }

        // POST: Siparis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Siparis siparis = db.Siparis.Find(id);
            db.Siparis.Remove(siparis);
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
