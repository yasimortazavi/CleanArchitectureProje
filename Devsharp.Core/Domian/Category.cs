using System;
using System.Collections.Generic;
using System.Text;

namespace Devsharp.Core.Domian
{
    public class Category :BaseEntity
    {
        public Category()
        {

        }

        //private Category(Action<object, string> lazyLoader)
        //{
        //    LazyLoader = lazyLoader;
        //}

        //private Action<object, string> LazyLoader { get; set; }



        public string Name { get; set; }

        public int ParentId { get; set; }


        public virtual Category ParentCategory { get; set; }
        
        //private Category _parentCategory;

            //public virtual Category ParentCategory {

            //    get => LazyLoader.Load(this, ref _parentCategory);
            //   set => _parentCategory = value;
            //        }

        public virtual ICollection<Category> Children { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
