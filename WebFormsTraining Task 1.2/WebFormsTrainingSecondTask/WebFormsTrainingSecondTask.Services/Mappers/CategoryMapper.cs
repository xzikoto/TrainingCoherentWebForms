using System.Collections.Generic;
using System.Linq;
using WebFormsTrainingSecondTask.Core.Entities;
using WebFormsTrainingSecondTask.Services.DTOModels.CategoryDTOs;

namespace WebFormsTrainingSecondTask.Services.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDTO ToDto(this QuestionOption category)
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
        
        public static List<CategoryDTO> ToDto(this IEnumerable<QuestionOption> categories)
        {
            if (categories == null) 
            {
                return new List<CategoryDTO>();
            }

            return categories.Select(c => ToDto(c)).ToList();
        }

        public static QuestionOption ToDomain(this CategoryDTO category)
        {
            if (category == null) 
            {
                return null;
            }

            return new QuestionOption
            {
                Id = category.Id,
                Name = category.Name,
                Tasks = category.Tasks.ToDomain()
            };
        }
        
        public static List<QuestionOption> ToDomain(this IEnumerable<CategoryDTO> categories)
        {
            if (categories == null) 
            {
                new List<QuestionOption>();
            }

            return categories.Select(c => ToDomain(c)).ToList();
        }
    }
}
