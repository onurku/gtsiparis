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
    public class ILController : Controller
    {
        private Model1 db = new Model1();

        // GET: IL
        public ActionResult Index()
        {
            return View(db.IL.ToList());
        }

        // GET: IL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IL iL = db.IL.Find(id);
            if (iL == null)
            {
                return HttpNotFound();
            }
            return View(iL);
        }

        // GET: IL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IL/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ILAdi")] IL iL)
        {
            if (ModelState.IsValid)
            {
                db.IL.Add(iL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iL);
        }

        // GET: IL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IL iL = db.IL.Find(id);
            if (iL == null)
            {
                return HttpNotFound();
            }
            return View(iL);
        }

        // POST: IL/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ILAdi")] IL iL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iL);
        }

        // GET: IL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IL iL = db.IL.Find(id);
            if (iL == null)
            {
                return HttpNotFound();
            }
            return View(iL);
        }

        // POST: IL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IL iL = db.IL.Find(id);
            db.IL.Remove(iL);
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
