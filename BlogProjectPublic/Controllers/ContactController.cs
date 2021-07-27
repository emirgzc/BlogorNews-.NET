using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProjectPublic.Controllers
{
    public class ContactController : Controller
    {
        SettingManager sm = new SettingManager(new EfSettingDal());
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            var setting = sm.GetList();
            return View(setting);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(Contact c)
        {
            c.ContactDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
            cm.ContactAdd(c);
            return RedirectToAction("Index");
        }
        [Authorize(Roles="A,D")]
        public ActionResult AContactList()
        {
            var contact = cm.GetList();
            return View(contact);
        }
        [Authorize(Roles = "A,D")]
        public ActionResult AContactDetails(int id)
        {
            var contact = cm.GetByID(id);
            return View(contact);
        }
    }
}