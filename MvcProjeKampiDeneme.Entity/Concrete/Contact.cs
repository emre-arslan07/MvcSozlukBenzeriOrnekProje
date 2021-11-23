﻿using MvcProjeKampiDeneme.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampiDeneme.Entity.Concrete
{
   public class Contact : IEntity
    {
        [Key]
        public int ContactID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string UserMail { get; set; }

        [StringLength(50)]
        public string Subject { get; set; }
        public DateTime ContactDate { get; set; }


        public string Message { get; set; }
    }
}