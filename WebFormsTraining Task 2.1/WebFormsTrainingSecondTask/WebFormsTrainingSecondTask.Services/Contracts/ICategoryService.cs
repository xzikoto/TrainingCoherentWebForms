using System.Collections.Generic;
using WebFormsTrainingSecondTask.Services.DTOModels.CategoryDTOs;

namespace WebFormsTrainingSecondTask.Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDTO> GetAllIncluded();
    }
}
