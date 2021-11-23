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
    public class CategoryController : Controller
    {
        // GET: Category
        private ICategoryService _categoryService;
        public CategoryController(/*ICategoryService categoryService*/)
        {
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            List<Category> categories = _categoryService.GetAll();
            return View(categories);
        }
        [HttpGet] //sayfa yüklendiğinde çalışır
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost] //sayfada post işlemi olunca açlışır
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(category);
            if (validationResult.IsValid)
            {
                _categoryService.Add(category);
                return RedirectToAction("GetCategoryList");
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