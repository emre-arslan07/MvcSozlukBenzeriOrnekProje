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
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        private IAdminService _adminService;

        public AuthorizationController()
        {
            _adminService = InstanceFactory.GetInstance<IAdminService>();
        }

        public ActionResult Index()
        {
            var values = _adminService.GetAll();
            return View(values);
        }
        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AdminAdd(Admin admin)
        {
            _adminService.Add(admin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var adminValue = _adminService.GetByID(id);
            return View(adminValue);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            _adminService.Update(admin);
            return RedirectToAction("Index");
        }
    }
}