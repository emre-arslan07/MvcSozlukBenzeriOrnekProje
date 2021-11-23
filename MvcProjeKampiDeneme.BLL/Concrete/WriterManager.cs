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
    public class WriterManager : IWriterService
    {
        private IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }
        public void Add(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void Delete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public List<Writer> GetAll()
        {
            return _writerDal.GetAll();
        }

        public Writer GetByID(int id)
        {
            return _writerDal.Get(x => x.WriterID == id);
        }

        public Writer GetByUsernamePassword(Writer writer)
        {
            return _writerDal.Get(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
        }

        public int GetIDByMail(string mail)
        {
            return _writerDal.Get(x => x.WriterMail == mail).WriterID;
        }

        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
