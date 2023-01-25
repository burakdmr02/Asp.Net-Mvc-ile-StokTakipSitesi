using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();  
        public ActionResult Index(string ara, int sayfa=1)
        {
			return View("Index", db.TblKategoriler.Where(m => m.KATEGORIAD.Contains(ara) || ara == null).ToList().ToPagedList(sayfa, 6));
			//var degerler = db.TblKategoriler.ToList();
			//var degerler = db.TblKategoriler.ToList().ToPagedList(sayfa, 4);
			// return View(degerler);
		}
        [HttpGet]
		public ActionResult YeniKategori()
		{
			return View();
		}
		[HttpPost]
        public ActionResult YeniKategori(TblKategoriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            {

            }
            db.TblKategoriler.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var kategori = db.TblKategoriler.Find(id);
            db.TblKategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TblKategoriler.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Guncelle(TblKategoriler p1)
        {
            var ktg = db.TblKategoriler.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}