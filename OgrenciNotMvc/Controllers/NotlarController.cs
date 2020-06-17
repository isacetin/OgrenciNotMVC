using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models;
using OgrenciNotMvc.Models.EntitiyFramework;
namespace OgrenciNotMvc.Controllers
{
    public class NotlarController : Controller
    {
        // GET: Notlar
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        [Authorize]
        public ActionResult Index()
        {
            var SinavNotlar = db.TBLNOTLAR.ToList();
            return View(SinavNotlar);
        }
        [HttpGet]
        public ActionResult YeniSinav()
        {
            List<SelectListItem> degerler = (from i in db.TBLDERS.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.DERSAD,
                                                 Value = i.DERSID.ToString()
                                             }
                                           ).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(Class1 model,TBLNOTLAR tbn, int vize = 0, int final = 0)
        {
                var ders = db.TBLDERS.Where(m => m.DERSID == tbn.DERSID).FirstOrDefault();
                tbn.TBLDERS = ders;
                db.TBLNOTLAR.Add(tbn);

            if (model.islem == "HESAPLA")
            {
                double ortalama = (vize * 0.40) + (final * 0.60);
                bool durum = ortalama > 50;
                ViewBag.ort = ortalama;
                if (durum == true)
                {
                    ViewBag.drm = "Başarılı";
                }
                else
                {
                    ViewBag.drm = "Başarısız";
                }

            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NotDetay(int id)
        {
            var notlar = db.TBLNOTLAR.Find(id);
            return View("NotDetay",notlar);

        }
        [HttpPost]
        public ActionResult NotDetay(Class1 model,TBLNOTLAR p, int vize=0, int final=0)
        {
            if(model.islem == "HESAPLA")
            {
                double ortalama = (vize * 0.40) + (final * 0.60);
                bool durum = ortalama > 50;
                ViewBag.ort = ortalama;
                if(durum == true)
                {
                    ViewBag.drm = "Başarılı";
                }
                else
                {
                    ViewBag.drm = "Başarısız";
                }
                
            }
            if(model.islem == "NOTGUNCELLE")
            {
                var snv = db.TBLNOTLAR.Find(p.NOTID);
                snv.Vize = p.Vize;
                snv.Final = p.Final;
                snv.ORTALAMA = p.ORTALAMA;
                if(snv.ORTALAMA >= 50)
                {
                    snv.DURUM = true;
                }
                else
                {
                    snv.DURUM = false;
                }
                db.SaveChanges();
                return RedirectToAction("Index","Notlar");
            }
            return View();
        }
    }
}