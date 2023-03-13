﻿using System.Collections.Generic;
using System.Linq;
using WebFormsTrainingSecondTask.Core.Entities;
using WebFormsTrainingSecondTask.Services.DTOModels.CategoryDTOs;

namespace WebFormsTrainingSecondTask.Services.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDTO ToDto(this Category category)
        {
            if (category == null) 
            {
                return null;
            }

            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Tasks = category.Tasks.ToDto()
            };
        }
        
        public static List<CategoryDTO> ToDto(this IEnumerable<Category> categories)
        {
            if (categories == null) 
            {
                return null;
            }

            return categories.Select(c => ToDto(c)).ToList();
        }

        public static Category ToDomain(this CategoryDTO category)
        {
            if (category == null) 
            {
                return null;
            }

            return new Category
            {
                Id = category.Id,
                Name = category.Name,
                Tasks = category.Tasks.ToDomain()
            };
        }
        
        public static List<Category> ToDomain(this IEnumerable<CategoryDTO> categories)
        {
            if (categories == null) 
            {
                return null;
            }

            return categories.Select(c => ToDomain(c)).ToList();
        }
    }
}
