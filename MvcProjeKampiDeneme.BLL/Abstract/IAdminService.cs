using MvcProjeKampiDeneme.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampiDeneme.BLL.Abstract
{
   public interface IAdminService
    {
        
        Admin GetByUsernamePassword(Admin admin);
        Admin GetByUsername(string username);
        Admin GetByID(int id);
        List<Admin> GetAll();

        void Add(Admin admin);
        void Update(Admin admin);
        void Delete(Admin admin);
    }
}
