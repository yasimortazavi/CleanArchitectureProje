using System;
using System.Collections.Generic;
using System.Text;
using Devsharp.Core.Extensions;
using Devsharp.Core;
using Mapster;
using Devsharp.Core.Interface;
using Devsharp.Core.Domian;
using Devsharp.Services.DTOs;


namespace Devsharp.Services.Extensions
{
    public static class ExtentionMapping
    {
        public static TEntity ToEntity<TEntity>(this BaseDto dto) where TEntity : Entity
        {
            if (dto.GetType().GetInterface("IDateDTO") != null)
            {
                TypeAdapterConfig<IDateDTO, TEntity>.NewConfig().Ignore("CreateOn", "UpdateOn", "LocalCreateOn", "LocalUpdateOn");

            }
            var entity = dto.Adapt<TEntity>();
            return entity;
        
        }

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

                if (category?.ParentCategory != null) 
                    categoryDTO.ParentName = category?.ParentCategory.Name;

                if (category?.Children != null)
                    categoryDTO.ChildCount = category?.Children.Count;

                if (category?.ProductCategories != null)
                    categoryDTO.ProdcutCount = category?.ProductCategories.Count;


            }

            return Dto;
        
        
        }
    }
}
