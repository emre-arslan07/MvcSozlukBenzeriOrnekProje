using MvcProjeKampiDeneme.BLL.Abstract;
using MvcProjeKampiDeneme.DAL.Abstract;
using MvcProjeKampiDeneme.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampiDeneme.BLL.Concrete
{
    public class ContentManager : IContentService
    {
        private IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void Add(Content content)
        {
            _contentDal.Insert(content);
        }

        public void Delete(Content content)
        {
            _contentDal.Delete(content);
        }

        public List<Content> GetAll()
        {
            return _contentDal.GetAll();
        }

        public List<Content> GetAllBySearch(string p)
        {
            return _contentDal.GetAll(x => x.ContentValue.Contains(p));
        }

        public List<Content> GetAllByWriterID(int id)
        {
            return _contentDal.GetAll(x => x.WriterID ==id);
        }

        public Content GetByID(int id)
        {
            return _contentDal.Get(x => x.ContentID == id);
        }

        public List<Content> GetListByHeadingID(int id) //get content list by heading id
        {
            return _contentDal.GetAll(x => x.HeadingID == id);
        }

        public void Update(Content content)
        {
            _contentDal.Update(content);
        }
    }
}
