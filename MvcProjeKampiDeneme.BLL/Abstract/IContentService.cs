using MvcProjeKampiDeneme.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampiDeneme.BLL.Abstract
{
   public interface IContentService
    {
        List<Content> GetAll();
        List<Content> GetAllByWriterID(int id);
        List<Content> GetAllBySearch(string p);
        void Add(Content content);
        void Delete(Content content);
        void Update(Content content);
        Content GetByID(int id);
        List<Content> GetListByHeadingID(int id);
    }
}
