using MvcProjeKampiDeneme.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampiDeneme.BLL.Abstract
{
   public interface IContactService
    {
        List<Contact> GetAll();
        Contact GetByID(int id);
        void Add(Contact contact);
        void Delete(Contact contact);
        void Update(Contact contact);
    }
}
