using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntitiyFramework;
using System.Web.Security;
using System.Web.SessionState;

namespace OgrenciNotMvc.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Giris(TBLADMIN t)
        {
            var bilgiler = db.TBLADMIN.FirstOrDefault(x => x.kullanici == t.kullanici && x.sifre == t.sifre);
            if(bilgiler!= null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanici, false);
                Session.Add("username", bilgiler.kullanici);
                return RedirectToAction("Index","Ogrenci");
            }
            else
            {
                ViewBag.LoginError = "Hatalı Kullanıcı Adı veya Şifre...";

                return View();
            }
            
        }
        [HttpGet]
        public ActionResult KisiEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KisiEkle(TBLADMIN p1)
        {
            db.TBLADMIN.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Giris", "GirisYap");
        }
        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Giris", "GirisYap");
        }
        
    }
}