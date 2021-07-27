using BusinessLayer.Concrete;
using BusinnesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProjectPublic.Controllers
{
    public class AnaController : Controller
    {
        SettingManager sm = new SettingManager(new EfSettingDal());
        BlogManager bm = new BlogManager(new EfBlogDal());
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult TopBar()
        {
            var bar = sm.GetList();
            return PartialView(bar);
        }
        [AllowAnonymous]
        public PartialViewResult NewBlog()
        {
            var blognew = bm.GetBlogByDate().Where(x=>x.Status==true).Take(4);
            return PartialView(blognew);
        }
        [AllowAnonymous]
        public PartialViewResult TrendBlog()
        {
            var blogtrend = bm.GetBlogByRating().Where(x => x.Status == true).Take(3);
            return PartialView(blogtrend);
        }
        public ActionResult AIndex()
        {
            return View();
        }
    }
}