using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sinif;
namespace ProjeCV.Controllers
{
    public class YeteneklerController : Controller
    {
        // GET: Yetenekler
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger4 = db.TBL_SKILLS.ToList();
            return View(cs);
        }

        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniYetenek(TBL_SKILLS tbl_skills)
        {
            db.TBL_SKILLS.Add(tbl_skills);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var temp = db.TBL_SKILLS.Find(id);
            db.TBL_SKILLS.Remove(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YetenekGetir(int id)
        {
            var temp = db.TBL_SKILLS.Find(id);
            return View("YetenekGetir",temp);
        }

        public ActionResult Guncelle(TBL_SKILLS p)
        {
            var temp = db.TBL_SKILLS.Find(p.ID);
            temp.SKILL = p.SKILL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}