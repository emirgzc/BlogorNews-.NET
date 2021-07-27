using BusinnesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProjectPublic.Controllers
{
    public class SubscribeController : Controller
    {
        SubscribeManager sm = new SubscribeManager(new EfSubscribeDal());
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult SubscribeAdd()
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult SubscribeAdd(Subscribe s)
        {
            s.Date = DateTime.Parse(DateTime.Now.ToLongTimeString());
            sm.SubscribeAdd(s);
            return PartialView();
        }
        [Authorize(Roles = "A,D")]
        public ActionResult ASubList()
        {
            var list = sm.GetList();
            return View(list);
        }
    }
}