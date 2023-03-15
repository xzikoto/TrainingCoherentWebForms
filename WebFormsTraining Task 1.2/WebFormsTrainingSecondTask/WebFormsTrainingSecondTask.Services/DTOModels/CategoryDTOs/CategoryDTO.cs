using System;
using System.Collections.Generic;
using WebFormsTrainingSecondTask.Services.DTOModels.TaskDTOs;

namespace WebFormsTrainingSecondTask.Services.DTOModels.CategoryDTOs
{
    public class CategoryDTO
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public List<TaskDTO> Tasks{ get; set; }
    }
}
