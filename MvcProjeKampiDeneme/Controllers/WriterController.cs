using FluentValidation.Results;
using MvcProjeKampiDeneme.BLL.Abstract;
using MvcProjeKampiDeneme.BLL.DependencyResolvers.Ninject;
using MvcProjeKampiDeneme.BLL.ValidationRules.FluentValidation;
using MvcProjeKampiDeneme.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampiDeneme.Controllers
{
    public class WriterController : Controller
    {
        // GET: Writer
       private IWriterService _writerService;
        public WriterController()
        {
            _writerService = InstanceFactory.GetInstance<IWriterService>();
        }
        public ActionResult Index()
        {
            List<Writer> writerValues = _writerService.GetAll();
            return View(writerValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        public ActionResult AddWriter(Writer writer)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult validationResult = validationRules.Validate(writer);
            if (validationResult.IsValid)
            {
                _writerService.Add(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            var writerValue = _writerService.GetByID(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult UpdateWriter(Writer writer)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult validationResult = validationRules.Validate(writer);
            if (validationResult.IsValid)
            {
                _writerService.Update(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult NewWriter()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult NewWriter(Writer writer)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult validationResult = validationRules.Validate(writer);
            if (validationResult.IsValid)
            {
                byte[] passvalue = ASCIIEncoding.ASCII.GetBytes(writer.WriterPassword);
                string cryptoPass = Convert.ToBase64String(passvalue);
                writer.WriterPassword = cryptoPass;
                writer.WriterStatus = true;
                _writerService.Add(writer);
                return RedirectToAction("WriterLogin", "Login");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
            
        }
    }

}