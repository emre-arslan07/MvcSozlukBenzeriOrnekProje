using MvcProjeKampiDeneme.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampiDeneme.BLL.Abstract
{
   public interface IHeadingService
    {
        List<Heading> GetAll();
        List<Heading> GetAllByWriterID(int id);
        void Add(Heading heading);
        void Update(Heading heading);
        void Delete(Heading heading);
        Heading GetByID(int id);
    }
}
