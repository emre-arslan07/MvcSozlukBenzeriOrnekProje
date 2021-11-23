using MvcProjeKampiDeneme.BLL.Abstract;
using MvcProjeKampiDeneme.BLL.DependencyResolvers.Ninject;
using MvcProjeKampiDeneme.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampiDeneme.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        private IAdminService _adminService;
        private IWriterService _writerService;

        public LoginController()
        {
            _adminService = InstanceFactory.GetInstance<IAdminService>();
            _writerService = InstanceFactory.GetInstance<IWriterService>();
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var adminuserinfo = _adminService.GetByUsernamePassword(admin);
            if (adminuserinfo!=null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            byte[] passvalue = ASCIIEncoding.ASCII.GetBytes(writer.WriterPassword);
            string cryptoPass = Convert.ToBase64String(passvalue);
            writer.WriterPassword = cryptoPass;
            var writerinfo = _writerService.GetByUsernamePassword(writer);
            if (writerinfo != null && writerinfo.WriterStatus==true)
            {

                FormsAuthentication.SetAuthCookie(writerinfo.WriterMail, false);
                Session["WriterMail"] = writerinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}