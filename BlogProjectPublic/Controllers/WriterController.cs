using BusinnesLayer.Concrete;
using BusinnesLayer.ValidationRules;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProjectPublic.Controllers
{
    public class WriterController : Controller
    {
        WriterValidator validationRules = new WriterValidator();
        WriterManager wm = new WriterManager(new EfWriterDal());
        BlogManager bm = new BlogManager(new EfBlogDal());
        Context c = new Context();
        [AllowAnonymous]
        public ActionResult Index()
        {
            var writer = wm.GetList();
            return View(writer);
        }
        public ActionResult AWriterList()
        {
            var writer = wm.GetList();
            return View(writer);
        }
        [HttpGet]
        public ActionResult AWriterAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AWriterAdd(Writer s)
        {
            string filename = Path.GetFileName(Request.Files[0].FileName);
            string uzanti = Path.GetExtension(Request.Files[0].FileName);
            Random rand = new Random();
            filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 99999999).ToString() + uzanti;
            string way = "~/Image/Writer/" + filename;
            s.Image = "/Image/Writer/" + filename;

            ValidationResult result = validationRules.Validate(s);

            if (Request.Files.Count > 0)
            {
                if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
                {
                    Request.Files[0].SaveAs(Server.MapPath(way));
                    if (result.IsValid)
                    {
                        wm.WriterAdd(s);
                        return RedirectToAction("AWriterList");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                        }
                    }                    
                }
                else
                {
                    ViewBag.hata = "Dosya uzantısı yükleme için uygun değil. Uygun olan uzantılar : .jpg, .jpeg, .png";
                }
            }
            return View();
        }
        public ActionResult AWriterDelete(int id)
        {
            var idwri = wm.GetByID(id);
            wm.WriterDelete(idwri);
            return RedirectToAction("AWriterList");
        }
        [HttpGet]
        public ActionResult AWriterUpdate(int id)
        {
            var idwriter = wm.GetByID(id);
            return View(idwriter);
        }
        [HttpPost]
        public ActionResult AWriterUpdate(Writer w)
        {
            ValidationResult result = validationRules.Validate(w);
            if (result.IsValid)
            {
                string ımage = c.Writers.Where(x => x.WriterId == w.WriterId).Select(z => z.Image).FirstOrDefault();
                w.Image = ımage;
                wm.WriterUpdate(w);
                return RedirectToAction("AWriterList");
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