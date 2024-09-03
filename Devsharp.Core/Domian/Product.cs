﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Devsharp.Core.Domian
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string Sku { get; set; }
        public int StockQuantity { get; set; }
        public bool Deleted { get; set; }
        public byte[] Timestamp { get; set; }

        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

        //private ICollection<ProductCategory> _productCategories;
        //public ICollection<ProductCategory> ProductCategories
        //{

        //    get => _productCategories ?? (_productCategories = new List<ProductCategory>());
        //    protected set => _productCategories = value;
        //}

      

       
    }
}
