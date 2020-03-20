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
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TBL_AWARDS
                           select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m=>m.AWARD.Contains(p));
            }

            return View(degerler.ToList());
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