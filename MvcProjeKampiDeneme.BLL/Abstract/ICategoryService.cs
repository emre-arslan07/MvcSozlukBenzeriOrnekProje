using MvcProjeKampiDeneme.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampiDeneme.BLL.Abstract
{
   public interface ICategoryService
    {
        List<Category> GetAll();
        void Add(Category category);
        void Delete(Category category);
        void Update(Category category);
        Category GetByID(int id);

    }
}
