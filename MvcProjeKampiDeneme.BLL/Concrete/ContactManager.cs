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
    public class ContactManager : IContactService
    {
        private IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Add(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public void Delete(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public List<Contact> GetAll()
        {
            return _contactDal.GetAll();
        }

        public Contact GetByID(int id)
        {
            return _contactDal.Get(x => x.ContactID == id);
        }

        public void Update(Contact contact)
        {
            _contactDal.Update(contact);
        }
    }
}
