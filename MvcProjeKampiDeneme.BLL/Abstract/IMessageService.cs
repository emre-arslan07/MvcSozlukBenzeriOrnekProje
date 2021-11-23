using MvcProjeKampiDeneme.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampiDeneme.BLL.Abstract
{
   public interface IMessageService
    {
        List<Message> GetAllInbox(string p);
        List<Message> GetAllSendbox(string p);
        Message GetByID(int id);
        void Add(Message message);
        void Update(Message message);
        void Delete(Message message);
    }
}
