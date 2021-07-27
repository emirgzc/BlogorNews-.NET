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
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentDal());
        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            var commentlist = cm.GetCommentByBlog(id).Where(z => z.Status == true);
            return PartialView(commentlist);
        }
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult LeaveComment(Comment c)
        {
            c.Status = false;
            cm.CommentAdd(c);
            return PartialView();
        }
        [Authorize(Roles = "A,C")]
        public ActionResult ACommentNewList()
        {
            var comment = cm.GetCommentByStatusTrue().OrderByDescending(z=>z.CommentDate);
            return View(comment);
        }
        [Authorize(Roles = "A,C")]
        public ActionResult ACommentFalseList()
        {
            var comment = cm.GetCommentByStatusFalse().OrderByDescending(z => z.CommentDate);
            return View(comment);
        }
        [Authorize(Roles = "A,C")]
        public PartialViewResult CommentMenu()
        {
            var commenttrucount = cm.GetCommentByStatusTrue().Count();
            ViewBag.truee = commenttrucount;
            var commentfalsecount = cm.GetCommentByStatusFalse().Count();
            ViewBag.falsee = commentfalsecount;
            return PartialView();
        }
        [Authorize(Roles = "A,C")]
        public ActionResult ACommentDetails(int id)
        {
            var comment = cm.GetByID(id);
            return View(comment);
        }
        [Authorize(Roles = "A,C")]
        public ActionResult ACommentStatusDoTrue(int id)
        {
            var idcomment = cm.GetByID(id);
            idcomment.Status = true;
            cm.CommentUpdate(idcomment);
            return RedirectToAction("ACommentNewList");
        }
        [Authorize(Roles = "A,C")]
        public ActionResult ACommentStatusDoFalse(int id)
        {
            var idcomment = cm.GetByID(id);
            idcomment.Status = false;
            cm.CommentUpdate(idcomment);
            return RedirectToAction("ACommentFalseList");
        }
        //public ActionResult ACommentDelete(int id)
        //{
        //    var idcom = cm.GetByID(id);
        //    cm.CommentDelete(idcom);
        //    return RedirectToAction("ACommentNewList");
        //}
    }
}