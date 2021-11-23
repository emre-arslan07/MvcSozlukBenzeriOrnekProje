using FluentValidation;
using MvcProjeKampiDeneme.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampiDeneme.BLL.ValidationRules.FluentValidation
{
   public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adınız boş geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar adı en az 2 karakter olmalıdır");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Yazar soyadı en fazla 50 karakter olmalıdır");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadı boş geçilemez");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmı boş geçilemez");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Soyadı en fazla 50 karakter olmalıdır");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Soyadı en az 2 karakter olmalıdır");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar unvan boş geçilemez");
            RuleFor(x => x.WriterTitle).MaximumLength(50).WithMessage("Yazar unvan en fazla 50 karakter olabilir");
        }
    }
}
