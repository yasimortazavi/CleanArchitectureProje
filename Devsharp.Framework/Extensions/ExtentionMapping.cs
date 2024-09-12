using System;
using System.Collections.Generic;
using System.Text;
using Devsharp.Framwork.DTOs;
using Devsharp.Core;
using Mapster;
using Devsharp.Core.Interface;
using Devsharp.Framwork.Extensions;
using Devsharp.Core.Domian;


namespace Devsharp.Framework.Extensions
{
    public static class ExtentionMapping
    {

        public static TDTO ToDTO<TDTO>(this Entity entity) where TDTO : BaseDto
        {
            if (entity.GetType().GetInterface("IDateEntity") != null && typeof(TDTO).GetInterface("IDateDTO") != null)
            { 
                TypeAdapterConfig<IDateEntity, TDTO>.NewConfig().Map("LocalCreateOn", p => p.CreateOn.ToPersian())
                        .Map("LocalUpdateOn", p => p.UpdateOn.ToPersian());
            }
            var Dto = entity.Adapt<TDTO>();
            if (entity is Category)
            { 
                Category category = entity as Category;
                CategoryDTO categoryDTO = Dto as CategoryDTO;
                categoryDTO.ParentName = category.ParentCategory.Name;
                categoryDTO.ChildCount = category.Children.Count;
                categoryDTO.ProdcutCount = category.ProductCategories.Count;


            }

            return Dto;
        
        
        }
    }
}
