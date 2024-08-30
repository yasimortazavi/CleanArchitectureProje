using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Domain
{
    public class ProductPicture : BaseRelation
    {
        public int ProductId { get; set; }
        public int PictureId { get; set; }
        public virtual Picture Picture { get; set; }
        public virtual Product Product { get; set; }
    }
}
