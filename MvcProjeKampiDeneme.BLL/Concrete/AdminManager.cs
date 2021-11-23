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
    public class AdminManager : IAdminService
    {
        private IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void Add(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void Delete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public List<Admin> GetAll()
        {
            return _adminDal.GetAll();
        }

        public Admin GetByID(int id)
        {
            return _adminDal.Get(x => x.AdminID == id);
        }

        public Admin GetByUsername(string username)
        {
            return _adminDal.Get(x => x.AdminUserName == username);
        }

        public Admin GetByUsernamePassword(Admin admin)
        {
            return _adminDal.Get(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
        }

        public void Update(Admin admin)
        {
            _adminDal.Update(admin);
        }
    }
}
