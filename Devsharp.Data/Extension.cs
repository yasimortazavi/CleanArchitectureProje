using Devsharp.Core.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Devsharp.Data
{
    public static class Extension
    {
        public static void SetMapDate(this ModelBuilder modelBuilder)
        {
            var ListClasses = typeof(IDateEntity).GetAllClassNames();

            var listEntities = modelBuilder.Model.GetEntityTypes()
                .Where(p => ListClasses.Contains(p.ClrType.FullName));

            foreach (var entityType in listEntities)
            {
                var property = entityType.FindProperty("CreateOn");
                if (property != null)
                {
                    property.ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.OnAdd;
                    property.SetDefaultValueSql("GetDate()");
                }

            }
        }

        public static List<string> GetAllClassNames(this Type type)
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                 .Where(x => type.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                 .Select(x => x.FullName).ToList();

        }

        public static void PluralizeTable(this ModelBuilder modelBuilder)
        {
            Pluralize.NET.Pluralizer pluralizer = new Pluralize.NET.Pluralizer();
            var entity = modelBuilder.Model.GetEntityTypes();
            foreach (var item in entity)
            {
                item.SetTableName(pluralizer.Pluralize(item.GetTableName()));
            }
        }
    }
}
