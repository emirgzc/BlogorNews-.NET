using BusinessLayer.Concrete;
using BusinnesLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProjectPublic.Controllers
{
    public class ServiceController : Controller
    {
        ServicesValidator validationRules = new ServicesValidator();
        ServicesManager sm = new ServicesManager(new EfServiceDal());
        [AllowAnonymous]
        public ActionResult Index()
        {
            var service = sm.GetListByTrue();
            return View(service);
        }
        [Authorize(Roles="A,B")]
        public ActionResult AServiceList()
        {
            var list = sm.GetList();
            return View(list);
        }
        [Authorize(Roles = "A,B")]
        [HttpGet]
        public ActionResult AServiceAdd()
        {
            return View();
        }
        [Authorize(Roles = "A,B")]
        [HttpPost]
        public ActionResult AServiceAdd(Service s)
        {
            ValidationResult result = validationRules.Validate(s);

            if (result.IsValid)
            {
                s.Status = true;
                sm.ServiceAdd(s);
                return RedirectToAction("AServiceList");
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
        [Authorize(Roles = "A,B")]
        public ActionResult AServiceDoTrue(int id)
        {
            var idser = sm.GetByID(id);
            idser.Status = true;
            sm.ServiceUpdate(idser);
            return RedirectToAction("AServiceList");
        }
        [Authorize(Roles = "A,B")]
        public ActionResult AServiceDoFalse(int id)
        {
            var idser = sm.GetByID(id);
            idser.Status = false;
            sm.ServiceUpdate(idser);
            return RedirectToAction("AServiceList");
        }
        [Authorize(Roles = "A,B")]
        [HttpGet]
        public ActionResult AServiceUpdate(int id)
        {
            var idserv = sm.GetByID(id);
            return View(idserv);
        }
        [Authorize(Roles = "A,B")]
        [HttpPost]
        public ActionResult AServiceUpdate(Service s)
        {
            ValidationResult result = validationRules.Validate(s);

            if (result.IsValid)
            {
                s.Status = false;
                sm.ServiceUpdate(s);
                return RedirectToAction("AServiceList");
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
        [Authorize(Roles = "A,B")]
        public ActionResult AServiceDelete(int id)
        {
            var idserv = sm.GetByID(id);
            sm.ServiceDelete(idserv);
            return RedirectToAction("AServiceList");
        }
    }
}