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
    public class MessageController : Controller
    {
        private IMessageService _messageService;
        MessageValidator messageValidator = new MessageValidator();

        public MessageController()
        {
            _messageService = InstanceFactory.GetInstance<IMessageService>();
        }

        public ActionResult Inbox(string p)
        {
            var messageList = _messageService.GetAllInbox(p);
            return View(messageList);
        }

        public ActionResult SendBox(string p)
        {
            var messageList = _messageService.GetAllSendbox(p);
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

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult result = messageValidator.Validate(message);
            if (result.IsValid)
            {
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