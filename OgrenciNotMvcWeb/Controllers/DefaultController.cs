﻿using OgrenciNotMvcWeb.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;


namespace OgrenciNotMvcWeb.Controllers
{
    public class DefaultController : Controller 
    {
        DbMvcOkulEntities db=new DbMvcOkulEntities(); 
        // GET: Default
        public ActionResult Index()
        {
            var dersler=db.TBLDERSLER.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDers(TBLDERSLER p) 
        {
            db.TBLDERSLER.Add(p);
            db.SaveChanges();
            return View();  
        }
        public ActionResult Sil(int id)
        {
            var ders=db.TBLDERSLER.Find(id);
            db.TBLDERSLER.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir(int id)
        {
            var ders = db.TBLDERSLER.Find(id);
            return View("DersGetir",ders);
        }
        public ActionResult Guncelle(TBLDERSLER p)
        {
            var drs = db.TBLDERSLER.Find(p.DERSID);
            drs.DERSAD = p.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
    }
}