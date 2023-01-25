using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            //return View(db.TblUrunler.Where(m => m.URUNAD.Contains(ara) || ara == null).ToList().ToPagedList(sayfa, 6));
			var degerler = db.TblUrunler.ToList();
			//var degerler = db.TblUrunler.ToList().ToPagedList(sayfa, 6);
			return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.TblKategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString(),
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(TblUrunler p1)
        {
            var ktg = db.TblKategoriler.Where(m => m.KATEGORIID == p1.TblKategoriler.KATEGORIID).FirstOrDefault();
            p1.TblKategoriler = ktg;
            db.TblUrunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var urun = db.TblUrunler.Find(id);
            db.TblUrunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.TblUrunler.Find(id);
            List<SelectListItem> degerler = (from i in db.TblKategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString(),
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir", urun);
        }
        public ActionResult Guncelle(TblUrunler p)
        {
            var urun = db.TblUrunler.Find(p.URUNID);
            urun.URUNAD = p.URUNAD;
            urun.MARKA = p.MARKA;
            urun.STOK = p.STOK;
            urun.FIYAT = p.FIYAT;
			//surun.URUNKATEGORI = p.URUNKATEGORI;
			var ktg = db.TblKategoriler.Where(m => m.KATEGORIID == p.TblKategoriler.KATEGORIID).FirstOrDefault();
			urun.URUNKATEGORI = ktg.KATEGORIID;
			db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}