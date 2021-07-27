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
    public class SettingsController : Controller
    {
        SettingsValidator validationRules = new SettingsValidator();
        SettingManager sm = new SettingManager(new EfSettingDal());
        [Authorize(Roles = "A,B")]
        public ActionResult ASetList()
        {
            var setlist = sm.GetList();
            return View(setlist);
        }
        [Authorize(Roles = "A,B")]
        [HttpGet]
        public ActionResult ASettingUpdate(int id)
        {
            var set = sm.GetByID(id);
            return View(set);
        }
        [Authorize(Roles = "A,B")]
        [HttpPost]
        public ActionResult ASettingUpdate(Settings a)
        {
            ValidationResult result = validationRules.Validate(a);

            if (result.IsValid)
            {
                sm.SettingsUpdate(a);
                return RedirectToAction("ASetList");
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