using FluentValidation.Results;
using MvcProjeKampiDeneme.BLL.Abstract;
using MvcProjeKampiDeneme.BLL.DependencyResolvers.Ninject;
using MvcProjeKampiDeneme.BLL.ValidationRules.FluentValidation;
using MvcProjeKampiDeneme.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampiDeneme.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        IMessageService _messageService;
        IWriterService _writerService;
        MessageValidator messageValidator = new MessageValidator();
        public WriterPanelMessageController()
        {
            _messageService = InstanceFactory.GetInstance<IMessageService>();
            _writerService = InstanceFactory.GetInstance<IWriterService>();
        }

        public ActionResult Inbox()
        {
            string mail = (string)Session["WriterMail"];
            var messageList = _messageService.GetAllInbox(mail);
            return View(messageList);
        }

        public ActionResult SendBox()
        {
            string mail = (string)Session["WriterMail"];
            var messageList = _messageService.GetAllSendbox(mail);
            return View(messageList);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var inboxDetail = _messageService.GetByID(id);
            return View(inboxDetail);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var sendboxDetail = _messageService.GetByID(id);
            return View(sendboxDetail);
        }
        public PartialViewResult PartialSideBar()
        {
            string mail = (string)Session["WriterMail"];
            var inboxMessage = _messageService.GetAllInbox(mail);
            ViewBag.inboxCount = inboxMessage.Count();
            var sendboxMessage = _messageService.GetAllSendbox(mail);
            ViewBag.sendboxCount = sendboxMessage.Count();
            return PartialView();
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult result = messageValidator.Validate(message);
            if (result.IsValid)
            {
                message.SenderMail = sender;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                _messageService.Add(message);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
    }
}