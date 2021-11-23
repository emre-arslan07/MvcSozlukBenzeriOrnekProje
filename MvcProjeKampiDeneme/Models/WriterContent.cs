using MvcProjeKampiDeneme.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampiDeneme.Models
{
    public class WriterContent
    {
        public Writer Writer{ get; set; }
        public Content Content { get; set; }
    }
}