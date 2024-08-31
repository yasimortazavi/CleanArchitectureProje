using Project.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Domain
{
    public class Product : BaseEntity, IDeleted
    {
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int StockQty { get; set; }

        public byte[] TimesStamp { get; set; }
    
        public bool Deleted { get; set; }
        public DateTime DeleteDate { get; set; }
        public int DeletedUser { get; set; }


        public virtual ICollection<ProductCategory> productCategories { get; set; }
        public virtual ICollection<ProductPicture> ProductPictures { get; set; }
    }
}
