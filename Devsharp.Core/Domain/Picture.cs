
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Domain
{
    public class Picture:BaseEntity
    {
        public string  Title { get; set; }
        public string VirtualPath { get; set; }

        public string MimeTypes { get; set; }


        public virtual ICollection<ProductPicture> ProductPictures { get; set; }
        public bool Deleted { get; set; }
        public DateTime DeleteDate { get; set; }
        public int DeletedUser { get; set; }
    }
}
