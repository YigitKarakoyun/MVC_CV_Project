using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sinif;
namespace ProjeCV.Controllers
{
    public class KonferanslarController : Controller
    {
        // GET: Konferanslar
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger6 = db.TBL_AWARDS.ToList();
            return View(cs);
        }

        [HttpGet]
        public ActionResult YeniKonferans()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKonferans(TBL_AWARDS tbl_awards)
        {
            db.TBL_AWARDS.Add(tbl_awards);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var temp = db.TBL_AWARDS.Find(id);
            db.TBL_AWARDS.Remove(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KonferansGetir(int id)
        {
            var temp = db.TBL_AWARDS.Find(id);
            return View("KonferansGetir",temp);
        }
        public ActionResult Guncelle(TBL_AWARDS p)
        {
            var temp = db.TBL_AWARDS.Find(p.ID);
            temp.AWARD = p.AWARD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}