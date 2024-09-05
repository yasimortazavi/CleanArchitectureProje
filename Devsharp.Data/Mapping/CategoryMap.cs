using Microsoft.EntityFrameworkCore;
using Devsharp.Core.Domian;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.Data.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
       

        public void Configure(EntityTypeBuilder<Category> builder)
        {
         
        }
    }
}
