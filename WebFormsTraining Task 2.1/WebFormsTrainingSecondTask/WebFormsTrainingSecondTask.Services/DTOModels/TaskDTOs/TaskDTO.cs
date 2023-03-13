using System;
using WebFormsTrainingSecondTask.Services.DTOModels.CategoryDTOs;

namespace WebFormsTrainingSecondTask.Services.DTOModels
{
    public class TaskDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
