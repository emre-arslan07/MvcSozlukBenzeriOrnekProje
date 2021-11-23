using FluentValidation;
using MvcProjeKampiDeneme.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampiDeneme.BLL.ValidationRules.FluentValidation
{
   public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("lütfen en fazla 100 karakter girişi yapın");
            //RuleFor(x => x.SenderMail).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz").When(x => !string.IsNullOrEmpty(x.SenderMail));
            //RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz").When(x => !string.IsNullOrEmpty(x.ReceiverMail));
        }
    }
}
