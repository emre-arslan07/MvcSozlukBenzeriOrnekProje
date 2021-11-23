using MvcProjeKampiDeneme.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampiDeneme.BLL.Abstract
{
   public interface IWriterService
    {
        List<Writer> GetAll();
        Writer GetByUsernamePassword(Writer writer);

        void Add(Writer writer);
        void Update(Writer writer);
        void Delete(Writer writer);
        Writer GetByID(int id);

        int GetIDByMail(string mail);
    }
}
