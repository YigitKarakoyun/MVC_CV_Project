using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sinif;
namespace ProjeCV.Controllers
{
    public class HobilerController : Controller
    {
        // GET: Hobiler
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger5 = db.TBL_INTERESTS.ToList();
   
            return View(cs);
        }
        [HttpGet]
        public ActionResult YeniHobi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniHobi(TBL_INTERESTS tbl_interests)
        {
            db.TBL_INTERESTS.Add(tbl_interests);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        
    }
}