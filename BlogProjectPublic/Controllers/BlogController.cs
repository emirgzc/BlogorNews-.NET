using BusinnesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using PagedList.Mvc;
using System.Web;
using System.Web.Mvc;

namespace BlogProjectPublic.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogDal());
        CommentManager cm = new CommentManager(new EfCommentDal());
        CategoryManager catm = new CategoryManager(new EfCategoryDal());
        [AllowAnonymous]
        public ActionResult Index()
        {
            var blog = bm.GetBlogByStatus().OrderByDescending(x=>x.BlogDate).ToList();
            return View(blog);
        }
        [AllowAnonymous]
        public PartialViewResult BlogList()
        {
            var blog = bm.GetBlogByStatus().Take(4);
            return PartialView(blog);
        }
        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var comment = cm.GetCommentByBlog(id).Where(z=>z.Status==true).Count();
            ViewBag.com = comment;
            var blog = bm.GetBlogByID(id);
            return PartialView(blog);
        }
        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var blogread = bm.GetBlogByID(id);
            return PartialView(blogread);
        }
        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var comment = cm.GetCommentByBlog(id).Where(z=>z.Status == true).Count();
            ViewBag.comcon = comment;
            var bloglistbycategory = bm.GetBlogByCategory(id).Where(z => z.Status == true).OrderByDescending(z => z.BlogDate).ToList();          
            var bloglistbycatname = bm.GetBlogByCategory(id).Select(z=>z.Category.Title).FirstOrDefault();
            ViewBag.catname = bloglistbycatname;
            return View(bloglistbycategory);
        }
        [Authorize(Roles="A,C")]
        public ActionResult ABlogList()
        {
            var blog = bm.GetBlogByDate();
            return View(blog);
        }
        [Authorize(Roles = "A,C")]
        public ActionResult ABlogDoTrue(int id)
        {
            var idser = bm.GetByID(id);
            idser.Status = true;
            bm.BlogDelete(idser);
            return RedirectToAction("ABlogList");
        }
        [Authorize(Roles = "A,C")]
        public ActionResult ABlogDoFalse(int id)
        {
            var idser = bm.GetByID(id);
            idser.Status = false;
            bm.BlogDelete(idser);
            return RedirectToAction("ABlogList");
        }
    }
}