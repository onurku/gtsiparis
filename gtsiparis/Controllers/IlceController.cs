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
    public class IlceController : Controller
    {
        private Model1 db = new Model1();

        // GET: Ilce
        public ActionResult Index()
        {
            var ilce = db.Ilce.Include(i => i.IL);
            return View(ilce.ToList());
        }

        // GET: Ilce/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilce ilce = db.Ilce.Find(id);
            if (ilce == null)
            {
                return HttpNotFound();
            }
            return View(ilce);
        }

        // GET: Ilce/Create
        public ActionResult Create()
        {
            ViewBag.IL_Id = new SelectList(db.IL, "Id", "ILAdi");
            return View();
        }

        // POST: Ilce/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IlceAdi,IL_Id")] Ilce ilce)
        {
            if (ModelState.IsValid)
            {
                db.Ilce.Add(ilce);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IL_Id = new SelectList(db.IL, "Id", "ILAdi", ilce.IL_Id);
            return View(ilce);
        }

        // GET: Ilce/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilce ilce = db.Ilce.Find(id);
            if (ilce == null)
            {
                return HttpNotFound();
            }
            ViewBag.IL_Id = new SelectList(db.IL, "Id", "ILAdi", ilce.IL_Id);
            return View(ilce);
        }

        // POST: Ilce/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IlceAdi,IL_Id")] Ilce ilce)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ilce).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IL_Id = new SelectList(db.IL, "Id", "ILAdi", ilce.IL_Id);
            return View(ilce);
        }

        // GET: Ilce/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilce ilce = db.Ilce.Find(id);
            if (ilce == null)
            {
                return HttpNotFound();
            }
            return View(ilce);
        }

        // POST: Ilce/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ilce ilce = db.Ilce.Find(id);
            db.Ilce.Remove(ilce);
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
