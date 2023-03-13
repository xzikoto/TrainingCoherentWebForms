using System.Collections.Generic;
using System.Linq;
using WebFormsTrainingSecondTask.Models.Category;
using WebFormsTrainingSecondTask.Services.DTOModels.CategoryDTOs;

namespace WebFormsTrainingSecondTask.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryModel ToModel(this CategoryDTO category)
        {
            if (category == null)
            {
                return null;
            }

            return new CategoryModel
            {
                Id = category.Id,
                Name = category.Name,
                Tasks = category.Tasks.ToModel()
            };
        }

        public static List<CategoryModel> ToModel(this IEnumerable<CategoryDTO> categories)
        {
            if (categories == null || !categories.Any())
            {
                return new List<CategoryModel>();
            }

            return categories.Select(c => ToModel(c)).ToList();
        }
        
        public static CategoryDTO ToDto(this CategoryModel category)
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

        public static List<CategoryDTO> ToDto(this IEnumerable<CategoryModel> categories)
        {
            if (categories == null || !categories.Any())
            {
                return new List<CategoryDTO>();
            }

            return categories.Select(c => ToDto(c)).ToList();
        }
    }
}