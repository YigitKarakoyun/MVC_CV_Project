using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sinif;
namespace ProjeCV.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger3 = db.TBL_EDUCATION.ToList();
            return View(cs);
        }

        [HttpPost]
        public ActionResult YeniEgitim(TBL_EDUCATION tbl_education)
        {
            db.TBL_EDUCATION.Add(tbl_education);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniEgitim()
        {
            return View();
        }

        public ActionResult Sil(int id)
        {
            var temp = db.TBL_EDUCATION.Find(id);
            db.TBL_EDUCATION.Remove(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}