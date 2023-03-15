﻿using System.Collections.Generic;
using WebFormsTrainingSecondTask.Services.Contracts;
using WebFormsTrainingSecondTask.Services.DTOModels.CategoryDTOs;
using WebFormsTrainingSecondTask.Services.Mappers;
using WebFormsTrainingSecondTask.Core;

namespace WebFormsTrainingSecondTask.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CategoryDTO> GetAllIncluded()
        {
            var result = _unitOfWork.CategoryRepository.GetAllIncluded();

            return result.ToDto();
        }

    }
}
