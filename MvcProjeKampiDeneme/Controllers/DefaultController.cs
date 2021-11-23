using MvcProjeKampiDeneme.BLL.Abstract;
using MvcProjeKampiDeneme.BLL.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampiDeneme.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
       private IHeadingService _headingService;
        private IContentService _contentService;

        public DefaultController()
        {
            _headingService = InstanceFactory.GetInstance<IHeadingService>();
            _contentService = InstanceFactory.GetInstance<IContentService>();
        }

        public ActionResult Headings()
        {
            var headingValues = _headingService.GetAll();
            
            return View(headingValues);
        }

        public PartialViewResult Index(int id=0)
        {
            var contentValues = _contentService.GetListByHeadingID(id);
            return PartialView(contentValues);
        }
    }
}