using BusinnesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProjectPublic.Controllers
{
    public class SliderController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogDal());
        [AllowAnonymous]
        public PartialViewResult Slider()
        {
            var list = bm.GetBlogByDate().Where(x => x.Status == true).Take(5);
            return PartialView(list);
        }
    }
}