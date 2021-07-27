using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactManager cm = new ContactManager(new EfContactDal());
        public ActionResult Inbox()
        {
            string p = (string)Session["Email"];
            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
        }
        public ActionResult SendBox()
        {
            string p = (string)Session["Email"];
            var messagelist = mm.GetListSendbox(p);
            return View(messagelist);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var getcontact = mm.GetByID(id);
            return View(getcontact);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var getcontact = mm.GetByID(id);
            return View(getcontact);
        }
        public PartialViewResult ShowInboxDetailsByWriter()
        {
            string p = (string)Session["Email"];
            //var contactList = cm.GetList();
            //ViewBag.contactCount = contactList.Count();
            var listResult = mm.GetListSendbox(p);
            ViewBag.sendCount = listResult.Count();
            var listResult2 = mm.GetListInbox(p);
            ViewBag.inboxCount = listResult2.Count();
            return PartialView();
        }
        [HttpGet]
        public ActionResult AddNewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewMessage(Message p)
        {
            string mailperson = (string)Session["Email"];
            p.SenderMail = mailperson;
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            mm.MessageAdd(p);
            return RedirectToAction("SendBox");
        }
    }
}