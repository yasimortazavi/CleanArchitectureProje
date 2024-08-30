
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Domain
{
    public class Order : BaseEntity
    {

        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus
        {

            get => (OrderStatus)OrderStatusId;
            set => OrderStatusId = (int)value;

        }


        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }


    }
}
