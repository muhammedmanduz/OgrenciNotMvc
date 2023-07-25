using OgrenciNotMvcWeb.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMvcWeb.Controllers
{
    public class KuluplerController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Kulupler

        public ActionResult Index()
        {
            var kulupler = db.TBLKULUPLER.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();

        }

        [HttpPost]
        public ActionResult YeniKulup(TBLKULUPLER p2)
        {
            db.TBLKULUPLER.Add(p2);
            db.SaveChanges();
            return View();

        }
        public ActionResult Sil(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);
            db.TBLKULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KulupGetir(int id)
        {
            var kulup2 = db.TBLKULUPLER.Find(id);

            return View("KulupGetir", kulup2);
        }

        public ActionResult Guncelle(TBLKULUPLER p)
        {
            var klp = db.TBLKULUPLER.Find(p.KULUPID);
            klp.KULUPAD = p.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index","Kulupler"); 
        }
    }
}