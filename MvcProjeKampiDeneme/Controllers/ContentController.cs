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
    public class ContentController : Controller
    {
        // GET: Content
        private IContentService _contentService;
        private IWriterService _writerService;
        public ContentController()
        {
            _contentService = InstanceFactory.GetInstance<IContentService>();
            _writerService = InstanceFactory.GetInstance<IWriterService>();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllContentBySearch(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                var contentValues = _contentService.GetAllBySearch(p);
                return View(contentValues);
            }

            return View(_contentService.GetAll());
        }

        public ActionResult ContentByHeading(int id)
        {
            List<Content> contents = _contentService.GetAll();
            List<Writer> writers = _writerService.GetAll();

            var record = from w in writers
                         join c in contents on w.WriterID equals c.WriterID
                         where c.HeadingID == id
                         select new WriterContent
                         {
                             Content = c,
                             Writer = w
                         };


            return View(record);
        }
    }
}