using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using gtsiparis.Models;
using Microsoft.AspNet.Identity;
using PagedList;
using PagedList.Mvc;


namespace gtsiparis.Controllers
{
    public class GenelController : Controller
    {
        // GET: Genel
        private Model1 db = new Model1();

        public ActionResult Index()
        {
            MenuViewModels viewModel = new MenuViewModels
            {
                // Here you do a database call to populate your menu items
                // This GetAllMenuItems method returns a list of MenuItem objects
                MenuItems = db.Menu.ToList(),
            };
            return PartialView("_UstMenu", viewModel);
        }

        public ActionResult UrunListesi(int? id, int page)
        {
            var pager = new Pager(1, page);
            IEnumerable<Urun> UrunListesi;

            if (id ==0 || id==null)
            {
                UrunListesi = db.Urun.ToList();
            }
            else
            {
                UrunListesi = (from b in db.Urun where b.Kategori_Id == id  select b).ToList();
                
            }
            pager = new Pager(UrunListesi.Count(), page);
            Session["Lastpager"] = page;
            
            SiparisMenuView viewModel = new SiparisMenuView
            {
                KategoriItems = db.Kategori.ToList(),
                UrunItems = UrunListesi.OrderBy(x=>x.Id).ToPagedList(page,5),
                Pager =pager
            };
            return View(viewModel);
        }

        public ActionResult UrunGoster(int id)
        {
            Urun Urun1 = db.Urun.Find(id);
            ViewBag.Stok = (from b in db.Stok where b.UrunId == id select b).LastOrDefault();
            if (Urun1 == null)
            {
                return HttpNotFound();
            }
            return PartialView(Urun1);
        }

        
        public ActionResult UrunGosterDetay(int id, decimal SipMik)
        {
            Urun Urun = db.Urun.Find(id);
            
            if (!SipMik.Equals(null))
            {
                ViewBag.SipMik = SipMik;
            }
            else { ViewBag.SipMik = 0; }
            if (Urun == null)
            {
                return HttpNotFound();
            }
            return View(Urun);
        }

        [HttpPost]
        public ActionResult SiparisiSepeteEkle(int UrunId, decimal SipMik)
        {
            var userId = User.Identity.GetUserId();
            Urun urun = db.Urun.Find(UrunId);
             
                Siparis sparis = new Siparis
                {
                    Kullanici_Id = userId,
                    Miktar = SipMik,
                    Urun_Id = UrunId,
                    Tutar = urun.Fiyat * SipMik,
                    BirimFiyat = urun.Fiyat,
                    Tarih = DateTime.Now
                };
                db.Siparis.Add(sparis);
                db.SaveChanges();
            ViewData["msg"] = "Siparişiniz başarıyla eklenmiştir. ";
            
            return Json(Url.Action("UrunListesi", "Genel", new { id = urun.Kategori_Id, page = Session["Lastpager"] }));
            
        }

        [HttpPost]
        public ActionResult SepetGuncelle(int? id)
        {
            Siparis siparis= db.Siparis.Find(id);
            return PartialView("_SiparisGuncelle",siparis);
        }


        [HttpPost]
        public ActionResult SepetSil(int? id)
        {
            Siparis siparis = db.Siparis.Find(id);
            return PartialView("_SiparisSilMesaj", siparis);
        }

        [HttpPost]
        public ActionResult SepetGuncelleCalc(int? id, decimal SipMik)
        {
            Siparis siparis = db.Siparis.Find(id);
            siparis.Miktar = SipMik;
            siparis.Tutar = SipMik*siparis.BirimFiyat;
            db.Entry(siparis).State = EntityState.Modified;
            db.SaveChanges();
            return Json(Url.Action("SiparisleriGetir", "Genel"));
        }

        [HttpPost]
        public ActionResult SepetSilCalc(int? id)
        {
            Siparis siparis = db.Siparis.Find(id);
            db.Siparis.Remove(siparis);
            db.SaveChanges();
            return Json(Url.Action("SiparisleriGetir", "Genel"));
        }

        public ActionResult Sepet()
        {
            var userId = User.Identity.GetUserId();
            ViewBag.Miktar = (from b in db.Siparis where (b.Kullanici_Id == userId && b.Onay!=true ) select b).Count();
            return PartialView("_SiparisSepet");
        }

        public ActionResult SiparisleriGetir()
        {
            var userId = User.Identity.GetUserId();
            IEnumerable<Siparis> SiparisListesi;
            SiparisListesi = (from b in db.Siparis where (b.Kullanici_Id == userId && b.Onay!=true) select b).ToList();
           
            return View(SiparisListesi);
        }

        public ActionResult TumSiparisler()
        {
            var month = DateTime.Now.Month;
            IEnumerable<Siparis> SiparisListesi;
            SiparisListesi = (from b in db.Siparis where (b.Tarih.Month ==month ) select b).ToList();
            return View(SiparisListesi);
        }


        [ActionName("Onayla")]
        public ActionResult SiparisleriOnayla()
        {
            var userId = User.Identity.GetUserId();
            IEnumerable<Siparis> SiparisListesi;
            SiparisListesi = (from b in db.Siparis where (b.Kullanici_Id == userId && b.Onay!=true ) select b).ToList();
            foreach (Siparis siparis in SiparisListesi)
            {
                siparis.Onay = true;
                db.Entry(siparis).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index","Home");
        }


    }
}