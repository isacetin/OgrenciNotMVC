using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntitiyFramework;

namespace OgrenciNotMvc.Controllers
{
    public class AnasayfaController : Controller
    {
        // GET: Anasayfa
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            
            return View();
            
        }
        public ActionResult Ogrtmenler()
        {
            var ogretmenler = db.TBLOGRETMENLER.Where(x => x.DURUM == true).ToList();
            return View(ogretmenler);
        }
        public ActionResult Dersler()
        {
            var dersler = db.TBLDERS.ToList();
            return View(dersler);
        }


    }
}