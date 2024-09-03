using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Devsharp.Core.Domian;

namespace Devsharp.Data.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {


        public void Configure(EntityTypeBuilder<Category> builder)
        {
        
        }
    }
}
