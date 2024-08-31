using Project.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Domain
{
    public class OrderItem : BaseRelation
    {
        public int  ProductId { get; set; }
        public int OrderId { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }

    }
}
