using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.BusinessLayer;
using TelefonRehberi.Entities;
using TelefonRehberi.WebApp.Fİlters;

namespace TelefonRehberi.WebApp.Controllers
{
    [Auth]
    public class CalisanController : Controller
    {
        CalisanManager cm = new CalisanManager();
        DepartmanManager dm = new DepartmanManager();

        public ActionResult Index()
        {
            List<Calisan> calisanlar = cm.List();

            foreach(Calisan clsn in calisanlar)
            {
                clsn.Departman = dm.Find(x => x.ID == clsn.DepartmanId);
            }

            return View(calisanlar);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Calisan calisan = cm.Find(x=> x.ID == id.Value);
            calisan.Departman = dm.Find(x => x.ID == calisan.DepartmanId);

            if (calisan == null)
            {
                return HttpNotFound();
            }
            return View(calisan);
        }

        

        public ActionResult Create()
        {

            List<Calisan> calisan = cm.List();
            List<Departman> departmanlar = dm.List();

            ViewBag.Calisanlar = new SelectList(calisan, "ID", "Ad");
            ViewBag.Departmanlar = new SelectList(departmanlar, "ID", "DepartmanAdi");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Calisan calisan)
        {
            List<Calisan> db_calisan = cm.List();
            List<Departman> db_departmanlar = dm.List();

            ModelState.Remove("YoneticiMi");
            ModelState.Remove("DepartmanId");

            if (ModelState.IsValid)
            {
                cm.Insert(calisan);
                cm.Save();

                return RedirectToAction("Index");
            }
            ViewBag.Calisanlar = new SelectList(db_calisan, "ID", "Ad", calisan.ID);
            ViewBag.Departmanlar = new SelectList(db_departmanlar, "ID", "DepartmanAdi",calisan.Departman.ID);

            return View(calisan);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Calisan calisan = cm.Find(x => x.ID == id.Value);

            if (calisan == null)
            {
                return HttpNotFound();
            }

            return View(calisan);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Calisan calisan)
        {
            ModelState.Remove("YoneticiMi");
            ModelState.Remove("DepartmanId");

            if (ModelState.IsValid)
            {
                Calisan db_calisan = cm.Find(x => x.ID == calisan.ID);
                db_calisan.Ad = calisan.Ad;
                db_calisan.Soyad = calisan.Soyad;
                db_calisan.TelefonNumarası = calisan.TelefonNumarası;

                //db_calisan.Departman.DepartmanAdi = calisan.Departman.DepartmanAdi;
                //db_calisan.Yonetici = calisan.Yonetici;

                return RedirectToAction("Index");
            }

            return View(calisan);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Calisan db_calisan = cm.Find(x => x.ID == id.Value);

            if (db_calisan == null)
            {
                return HttpNotFound();
            }

            return View(db_calisan);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List<Calisan> clsn_list = cm.List();

            Calisan silinecek_calisan = cm.Find(x => x.ID == id);

            bool sil = true;

            foreach (Calisan clsn in clsn_list)
            {
                if(clsn.Yonetici == silinecek_calisan.Ad +" "+silinecek_calisan.Soyad )
                {
                    sil = false;
                }
            }

            if(sil)
            {
                cm.Delete(silinecek_calisan);

            }
            else
            {
                ViewBag.Hata = "Bu kişi herhangi bir çalışanın yöneticisidir.\n " +
                    "Bu sebepten dolayı bu kişiyi silemezsiniz.";

                return View("Hata");
            }

            return RedirectToAction("Index");
        }

    }
}
