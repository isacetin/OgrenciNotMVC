using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntitiyFramework;


namespace OgrenciNotMvc.Controllers
{
    public class OgretmenlerController : Controller
    {
        // GET: Ogretmenler

            DbMvcOkulEntities db = new DbMvcOkulEntities();
        [Authorize]
        public ActionResult Index()
        {
            var ogretmenler = db.TBLOGRETMENLER.Where(x => x.DURUM == true).ToList();
            return View(ogretmenler);
        }

        [HttpGet]
        public ActionResult YeniOgretmen()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniOgretmen(TBLOGRETMENLER p2)
        {
            db.TBLOGRETMENLER.Add(p2);
            p2.DURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ogretmen = db.TBLOGRETMENLER.Find(id);
            //db.TBLOGRETMENLER.Remove(ogretmen);
            ogretmen.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgretmenDetay(int id)
        {
            var ogretmendetay = db.TBLOGRETMENLER.Find(id);

            return View("OgretmenDetay",ogretmendetay);
        }

        public ActionResult Guncelle(TBLOGRETMENLER p)
        {
            var ogretmen = db.TBLOGRETMENLER.Find(p.OGRETMENID);
            ogretmen.OGRETMENAD = p.OGRETMENAD;
            ogretmen.OGRETMENSOYAD = p.OGRETMENSOYAD;
            ogretmen.OGRETMENBRANS = p.OGRETMENBRANS;
            db.SaveChanges();
            return RedirectToAction("Index","Ogretmenler");
        }
    }
}