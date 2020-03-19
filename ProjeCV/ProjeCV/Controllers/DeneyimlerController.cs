using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sinif;
namespace ProjeCV.Controllers
{
    public class DeneyimlerController : Controller
    {
        // GET: Deneyimler
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger2 = db.TBL_EXPERIENCE.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult YeniDeneyim(TBL_EXPERIENCE tbl_experience)
        {
            db.TBL_EXPERIENCE.Add(tbl_experience);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniDeneyim()
        {
            return View();
        }

        public ActionResult DeneyimSil(int id)
        {
            var temp = db.TBL_EXPERIENCE.Find(id);
            db.TBL_EXPERIENCE.Remove(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}