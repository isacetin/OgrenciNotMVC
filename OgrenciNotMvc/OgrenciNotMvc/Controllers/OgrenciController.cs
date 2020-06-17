using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntitiyFramework;

namespace OgrenciNotMvc.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci

        DbMvcOkulEntities db = new DbMvcOkulEntities();
        [Authorize]
        public ActionResult Index()
        {
            var ogrenciler = db.TBLOGRENCILER.Where(x => x.DURUM == true).ToList();
            return View(ogrenciler);
        }

        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER p3)
        {
            
            db.TBLOGRENCILER.Add(p3);
            p3.DURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            //db.TBLOGRENCILER.Remove(ogrenci);
            ogrenci.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciDetay(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            return View("OgrenciDetay", ogrenci);
        }

        public ActionResult Guncelle(TBLOGRENCILER p)
        {
            var ogr = db.TBLOGRENCILER.Find(p.OGRENCIID);
            ogr.OGRENCIAD = p.OGRENCIAD;
            ogr.OGRENCISOYAD = p.OGRENCISOYAD;
            ogr.OGRENCIFOTOGRAF = p.OGRENCIFOTOGRAF;
            ogr.OGRENCICINSIYET = p.OGRENCICINSIYET;
            db.SaveChanges();
            return RedirectToAction("Index","Ogrenci");

        }

    }
}