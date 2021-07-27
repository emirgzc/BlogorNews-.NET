using BusinnesLayer.Concrete;
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
    public class AboutController : Controller
    {
        AboutValidator validationRules = new AboutValidator();
        AboutManager abm = new AboutManager(new EfAboutDal());
        [AllowAnonymous]
        public ActionResult Index()
        {
            var about = abm.GetList();
            return View(about);
        }
        [Authorize(Roles="A,B")]
        public ActionResult AIndex()
        {
            var about = abm.GetList();
            return View(about);
        }
        [Authorize(Roles = "A,B")]
        [HttpGet]
        public ActionResult AAboutUpdate(int id)
        {
            var about = abm.GetByID(id);
            return View(about);
        }
        [Authorize(Roles = "A,B")]
        [HttpPost]
        public ActionResult AAboutUpdate(About a)
        {
            ValidationResult result = validationRules.Validate(a);

            if (result.IsValid)
            {
                abm.AboutUpdate(a);
                return RedirectToAction("AIndex");
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
    }
}