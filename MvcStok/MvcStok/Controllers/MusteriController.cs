using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index( string ara, int sayfa =1)
        {
			return View("Index", db.TblMusteriler.Where(m =>m.MUSTERIAD.Contains(ara) || ara == null).ToList().ToPagedList(sayfa, 6));
			//var degerler = db.TblMusteriler.ToList();
			//return View(degerler);

		}
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TblMusteriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TblMusteriler.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var musteri = db.TblMusteriler.Find(id);
            db.TblMusteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TblMusteriler.Find(id);
            return View("MusteriGetir",mus);
        }
		public ActionResult Guncelle(TblMusteriler p1)
        {
            var musteri = db.TblMusteriler.Find(p1.MUSTERIID);
            musteri.MUSTERIAD=p1.MUSTERIAD;
            musteri.MUSTERISOYAD=p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
            

	}
}