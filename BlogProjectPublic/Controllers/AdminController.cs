using BusinnesLayer.Concrete;
using BusinnesLayer.ValidationRules;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogProjectPublic.Controllers
{
    public class AdminController : Controller
    {
        AdminValidator validationRules = new AdminValidator();
        AdminManager adm = new AdminManager(new EfAdminDal());
        Context c = new Context();
        public ActionResult Giris()
        {
            string p = (string)Session["Username"];
            string user = c.Admins.Where(x => x.Username == p).Select(z => z.Username).FirstOrDefault();
            ViewBag.username = user;
            return View();
        }
        [HttpGet]
        public ActionResult AdminProfile(int id = 0)
        {
            string p = (string)Session["Username"];
            id = c.Admins.Where(x => x.Username == p).Select(z => z.Id).FirstOrDefault();
            var adminid = adm.GetByID(id);
            return View(adminid);
        }
        [HttpPost]
        public ActionResult AdminProfile(Admin a)
        {
            ValidationResult result = validationRules.Validate(a);

            if (result.IsValid)
            {
                string p = (string)Session["Username"];
                string role = c.Admins.Where(x => x.Username == p).Select(z=>z.Role).FirstOrDefault();
                a.Role = role;
                adm.AdminUpdate(a);
                FormsAuthentication.SignOut();
                Session.Abandon();
                return RedirectToAction("Index", "Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();            
        }
        [Authorize(Roles = "A")]
        public ActionResult AdminList()
        {
            var admin = adm.GetList();
            return View(admin);
        }
        [Authorize(Roles = "A")]
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [Authorize(Roles = "A")]
        [HttpPost]
        public ActionResult AddAdmin(Admin a)
        {
            ValidationResult result = validationRules.Validate(a);

            if (result.IsValid)
            {
                adm.AdminAdd(a);
                return RedirectToAction("AdminList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();            
        }
        [Authorize(Roles = "A")]
        [HttpGet]
        public ActionResult AdminUpdate(int id)
        {
            var idad = adm.GetByID(id);
            return View(idad);
        }
        [Authorize(Roles = "A")]
        [HttpPost]
        public ActionResult AdminUpdate(Admin a)
        {
            ValidationResult result = validationRules.Validate(a);
            if (result.IsValid)
            {
                adm.AdminUpdate(a);
                return RedirectToAction("AdminList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();            
        }
        [Authorize(Roles = "A")]
        public ActionResult AdminDelete(int id)
        {
            var idd = adm.GetByID(id);
            adm.AdminDelete(idd);
            return RedirectToAction("AdminList");
        }
    }
}