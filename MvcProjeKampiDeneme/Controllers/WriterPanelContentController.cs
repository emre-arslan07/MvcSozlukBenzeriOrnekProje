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
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        private IContentService _contentService;
        private IWriterService _writerService;

        public WriterPanelContentController()
        {
            _contentService = InstanceFactory.GetInstance<IContentService>();
            _writerService = InstanceFactory.GetInstance<IWriterService>();
        }

        public ActionResult MyContent(string p)
        {
            p = (string)Session["WriterMail"];
            var writerIdInfo = _writerService.GetIDByMail(p);           
            var contentValues = _contentService.GetAllByWriterID(writerIdInfo);
            return View(contentValues);
        }
       
        [HttpGet]
        public ActionResult AddContent()
        {
            return View();
            
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail=(string)Session["WriterMail"];
            var writerIdInfo = _writerService.GetIDByMail(mail);
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterID = writerIdInfo;
            content.HeadingID = int.Parse(this.RouteData.Values["id"].ToString());
            content.ContentStatus = true;
            _contentService.Add(content);
            return RedirectToAction("MyContent");
        }
    }
}