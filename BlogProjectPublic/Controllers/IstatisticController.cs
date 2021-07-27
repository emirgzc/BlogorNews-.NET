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
    public class IstatisticController : Controller
    {
        IstatisticManager ısm = new IstatisticManager(new EfIstatisticDal());
        BlogManager bm = new BlogManager(new EfBlogDal());
        SubscribeManager sm = new SubscribeManager(new EfSubscribeDal());
        ContactManager cm = new ContactManager(new EfContactDal());
        CommentManager cmm = new CommentManager(new EfCommentDal());
        GaleryManager gm = new GaleryManager(new EfGaleryDal());
        ServicesManager smm = new ServicesManager(new EfServiceDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        CategoryManager cmmm = new CategoryManager(new EfCategoryDal());
        public ActionResult AIstList()
        {
            var list = bm.GetList().Count();
            ViewBag.count1 = list;
            var list2 = sm.GetList().Count();
            ViewBag.count2 = list2;
            var list3 = cm.GetList().Count();
            ViewBag.count3 = list3;
            var list4 = cmm.GetList().Count();
            ViewBag.count4 = list4;
            var list5 = gm.GetList().Count();
            ViewBag.count5 = list5;
            var list6 = smm.GetList().Count();
            ViewBag.count6 = list6;
            var list7 = wm.GetList().Count();
            ViewBag.count7 = list7;
            var list8 = cmmm.GetList().Count();
            ViewBag.count8 = list8;
            return View();
        }
    }
}