using BusinnesLayer.Concrete;
using DataAccesLayer.Concrete;
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
    public class WriterPanelController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        BlogManager bm = new BlogManager(new EfBlogDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        Context c = new Context();
        public ActionResult MyBlogs(string p)
        {
            p = (string)Session["Email"];
            var writerid = c.Writers.Where(x => x.Email == p).Select(z => z.WriterId).FirstOrDefault();
            var values = bm.GetListBlogByWriter(writerid);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewBlog()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Title,
                                                      Value = x.CatId.ToString()
                                                  }).ToList();
            ViewBag.catelist = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewBlog(Blog b)
        {
            string filename = Path.GetFileName(Request.Files[0].FileName);
            string uzanti = Path.GetExtension(Request.Files[0].FileName);
            Random rand = new Random();
            filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 9999999).ToString() + uzanti;
            string way = "~/Image/Blog/" + filename;
            b.Image = "/Image/Blog/" + filename;

            if (Request.Files.Count > 0)
            {
                if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
                {
                    Request.Files[0].SaveAs(Server.MapPath(way));
                    string mail = (string)Session["Email"];
                    var writeridinfo = c.Writers.Where(x => x.Email == mail).Select(z => z.WriterId).FirstOrDefault();
                    b.BlogDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    b.WriterId = writeridinfo;
                    b.Status = false;
                    b.BlogRating = 0;
                    bm.BlogAdd(b);
                    return RedirectToAction("MyBlogs");
                }
                else
                {
                    ViewBag.hata = "Dosya uzantısı yükleme için uygun değil. Uygun olan uzantılar : .jpg, .jpeg, .png";
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult WriterProfile(int id = 0)
        {
            string p = (string)Session["Email"];
            id = c.Writers.Where(x => x.Email == p).Select(z => z.WriterId).FirstOrDefault();
            var writerid = wm.GetByID(id);
            return View(writerid);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer w)
        {
            string p = (string)Session["Email"];
            string ımage = c.Writers.Where(x => x.Email == p).Select(z => z.Image).FirstOrDefault();
            w.Image = ımage;
            wm.WriterUpdate(w);
            return RedirectToAction("WriterProfile");
        }
        public ActionResult MyBlogsSeePublic(string p)
        {
            p = (string)Session["Email"];
            var writerid = c.Writers.Where(x => x.Email == p).Select(z => z.WriterId).FirstOrDefault();
            var values = bm.GetListBlogByWriter(writerid);
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            var blogid = bm.GetByID(id);
            return View(blogid);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog b)
        {
            string resim = c.Blogs.Where(x => x.BlogId == b.BlogId).Select(z => z.Image).FirstOrDefault();
            b.Image = resim;
            b.Status = false;
            bm.BlogUpdate(b);
            return RedirectToAction("MyBlogs");
        }
    }
}