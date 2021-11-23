using MvcProjeKampiDeneme.BLL.Abstract;
using MvcProjeKampiDeneme.BLL.DependencyResolvers.Ninject;
using MvcProjeKampiDeneme.Entity.Concrete;
using MvcProjeKampiDeneme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampiDeneme.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        private IHeadingService _headingService;
        private ICategoryService _categoryService;
        private IWriterService _writerService;
        public HeadingController()
        {
            _headingService = InstanceFactory.GetInstance<IHeadingService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
            _writerService = InstanceFactory.GetInstance<IWriterService>();

        }
        public ActionResult Index()
        {          
            var headingValues = _headingService.GetAll();
            return View(headingValues);
        }
        public ActionResult HeadingReport()
        {
            var headingValues = _headingService.GetAll();
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from c in _categoryService.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.VbCategory = valueCategory;

            List<SelectListItem> valueWriter = (from w in _writerService.GetAll()
                                                select new SelectListItem
                                                {
                                                    Text = w.WriterName + " " + w.WriterSurname,
                                                    Value = w.WriterID.ToString()
                                                }).ToList();
            ViewBag.VbWriter = valueWriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _headingService.Add(heading);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = _headingService.GetByID(id);
            headingValue.HeadingStatus = false;
            _headingService.Delete(headingValue);
            return RedirectToAction("Index");
        }
    }
}