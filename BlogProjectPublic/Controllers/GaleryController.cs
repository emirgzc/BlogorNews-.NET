using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProjectPublic.Controllers
{
    public class GaleryController : Controller
    {
        GaleryManager gm = new GaleryManager(new EfGaleryDal());
        [AllowAnonymous]
        public PartialViewResult Galery()
        {
            var galery = gm.GetList().Take(4);
            return PartialView(galery);
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            var galery = gm.GetList();
            return View(galery);
        }
        [Authorize(Roles = "A,B")]
        public ActionResult AGaleryList()
        {
            var galery = gm.GetList();
            return View(galery);
        }
        [Authorize(Roles = "A,B")]
        [HttpGet]
        public ActionResult AGaleryAdd()
        {
            return View();
        }
        [Authorize(Roles = "A,B")]
        [HttpPost]
        public ActionResult AGaleryAdd(Galery g)
        {
            string filename = Path.GetFileName(Request.Files[0].FileName);
            string uzanti = Path.GetExtension(Request.Files[0].FileName);
            Random rand = new Random();
            filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 99999999).ToString() + uzanti;
            string way = "~/Image/Galery/" + filename;
            g.Image = "/Image/Galery/" + filename;

            if (Request.Files.Count > 0)
            {
                if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
                {
                    Request.Files[0].SaveAs(Server.MapPath(way));
                    g.Status = true;
                    gm.GaleryAdd(g);
                    return RedirectToAction("AGaleryList");
                }
                else
                {
                    ViewBag.hata = "Dosya uzantısı yükleme için uygun değil. Uygun olan uzantılar : .jpg, .jpeg, .png";
                }
            }
            return View();
        }
        [Authorize(Roles = "A,B")]
        public ActionResult AGaleryDelete(int id)
        {
            var idgal = gm.GetByID(id);
            var filename = Request.MapPath("~" + idgal.Image);
            if (System.IO.File.Exists(filename))
            {
                System.IO.File.Delete(filename);
            }
            gm.GaleryDelete(idgal);
            return RedirectToAction("AGaleryList");
        }

    }
}