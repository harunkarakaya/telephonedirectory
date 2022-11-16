using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.BusinessLayer;
using TelefonRehberi.BusinessLayer.Results;
using TelefonRehberi.Entities;
using TelefonRehberi.Entities.ViewModel;
using TelefonRehberi.WebApp.Fİlters;

namespace TelefonRehberi.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private CalisanManager cm = new CalisanManager();
        private AdminManager admin_mngr = new AdminManager();
        private DepartmanManager dm = new DepartmanManager();


        public ActionResult PublicUI()
        {
            List<Calisan> CalisanList = cm.List();

            return View(CalisanList);
        }

        public ActionResult PublicUIDetails(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Calisan calisanDetay = cm.Find(x => x.ID == id.Value);
            //calisanDetay.Departman = cm.GetDepartmanById(calisanDetay.DepartmanId);
            calisanDetay.Departman = dm.Find(x => x.ID == calisanDetay.DepartmanId);


            return View(calisanDetay);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                BusinessLayerResult<Admin> res = admin_mngr.AdminGiris(model);

                if(res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("",x.Message));
                    return View(model);
                }

                Session["login"] = res.Result;
                return RedirectToAction("Index","Calisan");
            }

            return View(model);

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("PublicUI");
        }

        [Auth]
        public ActionResult AdminBilgileriGoster()
        {
            Admin admin = Session["login"] as Admin;

            return View(admin);
        }

        [Auth]
        public ActionResult AdminBilgileriDuzenle()
        {
            Admin admin = Session["login"] as Admin;

            return View(admin);
        }

        [Auth,HttpPost]
        public ActionResult AdminBilgileriDuzenle(Admin model)
        {
            if(ModelState.IsValid)
            {

                BusinessLayerResult<Admin> res = admin_mngr.AdminUpdate(model);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(model);
                }

                Session["login"] = res.Result;

                return RedirectToAction("AdminBilgileriGoster");
            }

            return View(model);
        }

    }
}