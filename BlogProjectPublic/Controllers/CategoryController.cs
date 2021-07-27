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
    public class CategoryController : Controller
    {
        CategoryValidator validationRules = new CategoryValidator();
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        [AllowAnonymous]
        public PartialViewResult Kategoriler()
        {
            var category = cm.GetListBytrue();
            return PartialView(category);
        }
        [AllowAnonymous]
        public PartialViewResult BlogKategoriList()
        {
            var catlist = cm.GetListBytrue();
            return PartialView(catlist);
        }
        [Authorize(Roles = "A,B")]
        public PartialViewResult ACategoryList()
        {
            var category = cm.GetList();
            return PartialView(category);
        }
        [Authorize(Roles = "A,B")]
        [HttpGet]
        public ActionResult AdminCategoryAdd()
        {
            return View();
        }
        [Authorize(Roles = "A,B")]
        [HttpPost]
        public ActionResult AdminCategoryAdd(Category c)
        {
            ValidationResult result = validationRules.Validate(c);

            if (result.IsValid)
            {
                c.Status = true;
                cm.CategoryAdd(c);
                return RedirectToAction("ACategoryList");
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
        [HttpGet]
        public ActionResult ACategoryEdit(int id)
        {
            var category = cm.GetByID(id);
            return View(category);
        }
        [Authorize(Roles = "A,B")]
        [HttpPost]
        public ActionResult ACategoryEdit(Category p)
        {
            ValidationResult result = validationRules.Validate(p);

            if (result.IsValid)
            {
                p.Status = false;
                cm.CategoryUpdate(p);
                return RedirectToAction("ACategoryList");
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
        public ActionResult CategoryStatusFalse(int id)
        {
            var idcat = cm.GetByID(id);
            idcat.Status = false;
            cm.CategoryDelete(idcat);
            return RedirectToAction("ACategoryList");
        }
        [Authorize(Roles = "A,B")]
        public ActionResult CategoryStatusTrue(int id)
        {
            var idcat = cm.GetByID(id);
            idcat.Status = true;
            cm.CategoryDelete(idcat);
            return RedirectToAction("ACategoryList");
        }
    }
}