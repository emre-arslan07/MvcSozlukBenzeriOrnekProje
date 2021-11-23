using FluentValidation;
using MvcProjeKampiDeneme.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampiDeneme.BLL.ValidationRules.FluentValidation
{
   public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez!!");
            RuleFor(c => c.CategoryDescription).NotEmpty().WithMessage("Açıklama kısmı boş geçilemez!!");
            RuleFor(c => c.CategoryName).MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır!!");
            RuleFor(c => c.CategoryName).MaximumLength(20).WithMessage("Kategori adı en fazla 20 karakter olamalıdır!!");
        }
    }
}
