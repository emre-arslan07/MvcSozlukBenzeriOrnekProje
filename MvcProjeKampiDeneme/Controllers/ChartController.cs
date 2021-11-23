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
    public class ChartController : Controller
    {
        // GET: Chart
        IHeadingService _headingService;
        ICategoryService _categoryService;

        public ChartController()
        {
            _headingService = InstanceFactory.GetInstance<IHeadingService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryHeading> BlogList()
        {
            var resultt = _headingService.GetAll().ToList().GroupBy(x => new { x.Category.CategoryName })
                .Select(g => new CategoryHeading
                {
                    CategoryName=g.Key.CategoryName,
                    HeadingCount = g.Select(x => x.HeadingID).Count()
                }).ToList();
            return resultt;

           
        }
    }
}