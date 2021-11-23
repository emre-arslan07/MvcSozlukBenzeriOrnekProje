using FluentValidation.Results;
using MvcProjeKampiDeneme.BLL.Abstract;
using MvcProjeKampiDeneme.BLL.DependencyResolvers.Ninject;
using MvcProjeKampiDeneme.BLL.ValidationRules.FluentValidation;
using MvcProjeKampiDeneme.Entity.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampiDeneme.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        private IHeadingService _headingService;
        private ICategoryService _categoryService;
        private IWriterService _writerService;

        public WriterPanelController()
        {
            _headingService = InstanceFactory.GetInstance<IHeadingService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
            _writerService = InstanceFactory.GetInstance<IWriterService>();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult WriterProfile(string p)
        {
            p = (string)Session["WriterMail"];
            var writerIdInfo = _writerService.GetIDByMail(p);
            var writerValue = _writerService.GetByID(writerIdInfo);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult validationResult = validationRules.Validate(writer);
            if (validationResult.IsValid)
            {
                _writerService.Update(writer);
                return RedirectToAction("AllHeading","WriterPanel");
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

        public ActionResult MyHeading(string p)
        {
            p = (string)Session["WriterMail"];
            var writerIdInfo = _writerService.GetIDByMail(p);
            var values = _headingService.GetAllByWriterID(writerIdInfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from c in _categoryService.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.VbCategory = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string writerMailInfo = (string)Session["WriterMail"];
            var writerIdInfo = _writerService.GetIDByMail(writerMailInfo);
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = writerIdInfo;
            heading.HeadingStatus = true;
            _headingService.Add(heading);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> valueCategory = (from c in _categoryService.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.VbCategory = valueCategory;
            var headingValue = _headingService.GetByID(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            _headingService.Update(heading);
            return RedirectToAction("MyHeading");
        }


        public ActionResult DeleteHeading(int id)
        {
            var headingValue = _headingService.GetByID(id);
            headingValue.HeadingStatus = false;
            _headingService.Delete(headingValue);
            return RedirectToAction("MyHeading");
        }

        //p =1 sayfalama 1 den başlar
        public ActionResult AllHeading(int p=1)
        {
            var headings = _headingService.GetAll().ToPagedList(p,5);
            return View(headings);
        }
    }
}