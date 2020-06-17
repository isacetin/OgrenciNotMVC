using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.IO;
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
            string fileName = Path.GetFileNameWithoutExtension(p3.ImageFile.FileName);
            string extension = Path.GetExtension(p3.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            p3.OGRENCIFOTOGRAF = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            p3.ImageFile.SaveAs(fileName);
            db.TBLOGRENCILER.Add(p3);
            p3.DURUM = true;
            ModelState.Clear();
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
            ogr.OGRENCICINSIYET = p.OGRENCICINSIYET;
            db.SaveChanges();
            return RedirectToAction("Index","Ogrenci");

        }

    }
}