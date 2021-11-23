using MvcProjeKampiDeneme.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampiDeneme.Models
{
    public class WriterCategoryHeading
    {
        public Category Category { get; set; }
        public Heading Heading { get; set; }

        public Writer Writer { get; set; }

        public  Content Content { get; set; }
    }
}