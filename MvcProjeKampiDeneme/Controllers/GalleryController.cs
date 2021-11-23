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
    public class GalleryController : Controller
    {
        private IImageFileService _imageFileService;

        public GalleryController()
        {
            _imageFileService =InstanceFactory.GetInstance<IImageFileService>();
        }

        public ActionResult Index()
        {
            List<ImageFile> imageFiles = _imageFileService.GetAll();
            return View(imageFiles);
        }
    }
}