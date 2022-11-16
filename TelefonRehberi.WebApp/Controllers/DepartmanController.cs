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
    public class DepartmanController : Controller
    {
        CalisanManager cm = new CalisanManager();
        DepartmanManager dm = new DepartmanManager();

        public ActionResult Index()
        {
            List<Departman> departmanlar = dm.List();

            return View(departmanlar);
        }
        

        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departman departman)
        {
            if (ModelState.IsValid)
            {

                dm.Insert(departman);
                dm.Save();

                return RedirectToAction("Index");
            }

            return View(departman);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Departman dept = dm.Find(x => x.ID == id.Value);

            if (dept == null)
            {
                return HttpNotFound();
            }
            return View(dept);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Departman departman)
        {
            if (ModelState.IsValid)
            {
                Departman db_dept = dm.Find(x => x.ID == departman.ID);
                db_dept.DepartmanAdi = departman.DepartmanAdi;

                return RedirectToAction("Index");
            }
            return View(departman);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Departman db_dept = dm.Find(x => x.ID == id.Value);


            if (db_dept == null)
            {
                return HttpNotFound();
            }
            return View(db_dept);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List<Calisan> calisanlar = cm.List();
            bool sil = true;

            foreach (Calisan clsn in calisanlar)
            {
                if (clsn.DepartmanId == id)
                {
                    sil = false;
                }
            }

            if(sil)
            {
                Departman dept = dm.Find(x => x.ID == id);
                dm.Delete(dept);
            }
            else
            {
                ViewBag.Hata = "Çalışanların olduğu departmanı silemezsiniz!!!";
                return View("Hata");
            }

            return RedirectToAction("Index");
        }

    }
}
