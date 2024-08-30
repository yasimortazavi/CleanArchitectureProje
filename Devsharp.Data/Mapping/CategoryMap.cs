using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Data.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
       

        public void Configure(EntityTypeBuilder<Category> builder)
        {
         
        }
    }
}
