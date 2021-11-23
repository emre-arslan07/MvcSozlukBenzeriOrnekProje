using MvcProjeKampiDeneme.BLL.Abstract;
using MvcProjeKampiDeneme.BLL.Concrete;
using MvcProjeKampiDeneme.DAL.Abstract;
using MvcProjeKampiDeneme.DAL.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampiDeneme.BLL.DependencyResolvers.Ninject
{
   public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EFCategoryDal>().InSingletonScope();

            Bind<IWriterService>().To<WriterManager>().InSingletonScope();
            Bind<IWriterDal>().To<EFWriterDal>().InSingletonScope();

            Bind<IHeadingService>().To<HeadingManager>().InSingletonScope();
            Bind<IHeadingDal>().To<EFHeadingDal>().InSingletonScope();

            Bind<IContentService>().To<ContentManager>().InSingletonScope();
            Bind<IContentDal>().To<EFContentDal>().InSingletonScope();

            Bind<IAboutService>().To<AboutManager>().InSingletonScope();
            Bind<IAboutDal>().To<EFAboutDal>().InSingletonScope();

            Bind<IContactService>().To<ContactManager>().InSingletonScope();
            Bind<IContactDal>().To<EFContactDal>().InSingletonScope();

            Bind<IMessageService>().To<MessageManager>().InSingletonScope();
            Bind<IMessageDal>().To<EFMessageDal>().InSingletonScope();

            Bind<IImageFileService>().To<ImageFileManager>().InSingletonScope();
            Bind<IImageFileDal>().To<EFImageFileDal>().InSingletonScope();

            Bind<IAdminService>().To<AdminManager>().InSingletonScope();
            Bind<IAdminDal>().To<EFAdminDal>().InSingletonScope();
        }
    }
}
