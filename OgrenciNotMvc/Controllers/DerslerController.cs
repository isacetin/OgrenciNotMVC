using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntitiyFramework;


namespace OgrenciNotMvc.Controllers
{
    public class DerslerController : Controller
    {
        // GET: Default
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        [Authorize]
        public ActionResult Index()
        {
            var dersler = db.TBLDERS.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult YeniDers()
        {
            List<SelectListItem> degerler = (from i in db.TBLOGRETMENLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.OGRETMENAD,
                                                 Value = i.OGRETMENID.ToString()
                                             }
                                           ).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniDers(TBLDERS p)
        {
            var ogrtmn = db.TBLOGRETMENLER.Where(m => m.OGRETMENID == p.TBLOGRETMENLER.OGRETMENID).FirstOrDefault();
            p.TBLOGRETMENLER = ogrtmn;
            db.TBLDERS.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ders = db.TBLDERS.Find(id);
            db.TBLDERS.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersDetay(int id)
        {
            var dersdetay = db.TBLDERS.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLOGRETMENLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.OGRETMENAD,
                                                 Value = i.OGRETMENID.ToString()
                                             }
                                           ).ToList();
            ViewBag.dgr = degerler;
            return View("DersDetay",dersdetay);
        }
        public ActionResult Guncelle(TBLDERS p)
        {
            var drs = db.TBLDERS.Find(p.DERSID);
            drs.DERSAD = p.DERSAD;
            var ogrtmn = db.TBLOGRETMENLER.Where(m => m.OGRETMENID == p.TBLOGRETMENLER.OGRETMENID).FirstOrDefault();
            drs.OGRTID = ogrtmn.OGRETMENID;
            db.SaveChanges();
            return RedirectToAction("Index","Dersler");
        }
    }
}