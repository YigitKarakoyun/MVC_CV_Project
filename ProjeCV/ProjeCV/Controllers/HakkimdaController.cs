using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sinif;
namespace ProjeCV.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TBL_ABOUT.ToList();
            return View(cs);
        }

        public ActionResult VeriGetir(int id)
        {
            var temp = db.TBL_ABOUT.Find(id);
            return View("VeriGetir", temp);
        }

        public ActionResult Guncelle(TBL_ABOUT p)
        {
            TBL_ABOUT degerler = db.TBL_ABOUT.Find(p.ID);
            degerler.NAME = p.NAME;
            degerler.SURNAME = p.SURNAME;
            degerler.PHONE = p.PHONE;
            degerler.MAIL = p.MAIL;
            degerler.ADDRESS = p.ADDRESS;
            degerler.ABOUT = p.ABOUT;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}