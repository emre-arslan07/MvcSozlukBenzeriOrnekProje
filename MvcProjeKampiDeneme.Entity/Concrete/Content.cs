using MvcProjeKampiDeneme.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampiDeneme.Entity.Concrete
{
   public class Content : IEntity
    {
        [Key]
        public int ContentID { get; set; }

        [StringLength(1000)]
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }
        public bool ContentStatus { get; set; }


        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }

        
        public int? WriterID { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
