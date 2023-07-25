using OgrenciNotMvcWeb.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMvcWeb.Controllers
{
    public class OgrenciController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Ogrenci
        public ActionResult Index()
        {
            var ogrenciler = db.TBLOGRENCILER.ToList();

            return View(ogrenciler);
        }


        [HttpGet]
        public ActionResult YeniOgrenci()// listeleme
        {
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString(),
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }


        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER p3) // db ye gönderme- ekleme
        {
            var klp = db.TBLKULUPLER.Where(m => m.KULUPID == p3.TBLKULUPLER.KULUPID).FirstOrDefault();
            p3.TBLKULUPLER = klp;
            db.TBLOGRENCILER.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci2 = db.TBLOGRENCILER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString(),
                                             }).ToList();

            ViewBag.dgr = degerler;

            return View("OgrenciGetir", ogrenci2);
        }

        public ActionResult Guncelle(TBLOGRENCILER p)
        {

            var ogr = db.TBLOGRENCILER.Find(p.OGRENCIID);
            ogr.OGRAD=p.OGRAD;
            ogr.OGRSOYAD=p.OGRSOYAD;    
            ogr.OGRFOTO=p.OGRFOTO;
            ogr.OGRFOTO=p.OGRFOTO;
            ogr.OGRCINSIYET=p.OGRCINSIYET;
            ogr.OGRKULUP=p.OGRKULUP;
            db.SaveChanges();
               return RedirectToAction("Index","Ogrenci"); 
        }
    }
}

//List<SelectListItem> items = new List<SelectListItem>();

//items.Add(new SelectListItem { Text = "Matematik", Value = "0" });

//items.Add(new SelectListItem { Text = "Fen Bilgisi", Value = "1" });

//items.Add(new SelectListItem { Text = "İnklap", Value = "2", });

//items.Add(new SelectListItem { Text = "Coğtafya", Value = "3" });

//ViewBag.DersAd = items;