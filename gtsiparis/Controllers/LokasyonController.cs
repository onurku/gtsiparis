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
    public class LokasyonController : Controller
    {
        private Model1 db = new Model1();

        // GET: Lokasyon
        public ActionResult Index()
        {
            var lokasyon = db.Lokasyon.Include(l => l.IL).Include(l => l.Rol);
            return View(lokasyon.ToList());
        }

        // GET: Lokasyon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokasyon lokasyon = db.Lokasyon.Find(id);
            if (lokasyon == null)
            {
                return HttpNotFound();
            }
            return View(lokasyon);
        }

        // GET: Lokasyon/Create
        public ActionResult Create()
        {
            ViewBag.IL_Id = new SelectList(db.IL, "Id", "ILAdi");
            ViewBag.Rol_Id = new SelectList(db.Rol, "Id", "RolAdi");
            return View();
        }

        // POST: Lokasyon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LokasyonAdi,Rol_Id,IL_Id")] Lokasyon lokasyon)
        {
            if (ModelState.IsValid)
            {
                db.Lokasyon.Add(lokasyon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IL_Id = new SelectList(db.IL, "Id", "ILAdi", lokasyon.IL_Id);
            ViewBag.Rol_Id = new SelectList(db.Rol, "Id", "RolAdi", lokasyon.Rol_Id);
            return View(lokasyon);
        }

        // GET: Lokasyon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokasyon lokasyon = db.Lokasyon.Find(id);
            if (lokasyon == null)
            {
                return HttpNotFound();
            }
            ViewBag.IL_Id = new SelectList(db.IL, "Id", "ILAdi", lokasyon.IL_Id);
            ViewBag.Rol_Id = new SelectList(db.Rol, "Id", "RolAdi", lokasyon.Rol_Id);
            return View(lokasyon);
        }

        // POST: Lokasyon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LokasyonAdi,Rol_Id,IL_Id")] Lokasyon lokasyon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lokasyon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IL_Id = new SelectList(db.IL, "Id", "ILAdi", lokasyon.IL_Id);
            ViewBag.Rol_Id = new SelectList(db.Rol, "Id", "RolAdi", lokasyon.Rol_Id);
            return View(lokasyon);
        }

        // GET: Lokasyon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokasyon lokasyon = db.Lokasyon.Find(id);
            if (lokasyon == null)
            {
                return HttpNotFound();
            }
            return View(lokasyon);
        }

        // POST: Lokasyon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lokasyon lokasyon = db.Lokasyon.Find(id);
            db.Lokasyon.Remove(lokasyon);
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
