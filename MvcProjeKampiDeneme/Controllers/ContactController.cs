using MvcProjeKampiDeneme.BLL.Abstract;
using MvcProjeKampiDeneme.BLL.DependencyResolvers.Ninject;
using MvcProjeKampiDeneme.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampiDeneme.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        private IContactService _contactService;
        private IMessageService _messageService;

        public ContactController()
        {
            _contactService = InstanceFactory.GetInstance<IContactService>();
            _messageService = InstanceFactory.GetInstance<IMessageService>();
        }

        public ActionResult Index()
        {
            List<Contact> contactValues = _contactService.GetAll();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValue = _contactService.GetByID(id);
            return View(contactValue);
        }

        public PartialViewResult PartialSideBar()
        {
            List<Contact> contactValues = _contactService.GetAll();
            ViewBag.ContactMessageCount = contactValues.Count();

            //List<Message> inboxMessage = _messageService.GetAllInbox();
            //ViewBag.inboxCount = inboxMessage.Count();
            //List<Message> sendboxMessage = _messageService.GetAllSendbox();
            //ViewBag.sendboxCount = sendboxMessage.Count();
            return PartialView();
        }
    }
}