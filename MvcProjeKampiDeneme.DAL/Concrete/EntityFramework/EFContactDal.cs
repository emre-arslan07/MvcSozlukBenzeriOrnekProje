using MvcProjeKampiDeneme.DAL.Abstract;
using MvcProjeKampiDeneme.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampiDeneme.DAL.Concrete.EntityFramework
{
   public class EFContactDal:EFRepositoryBase<Contact,MvcProjeKampiDenemeDbContext>,IContactDal
    {
    }
}
