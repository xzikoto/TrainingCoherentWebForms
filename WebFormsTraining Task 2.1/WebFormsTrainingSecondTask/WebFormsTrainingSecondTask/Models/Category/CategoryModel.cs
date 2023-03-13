using System;
using System.Collections.Generic;
using WebFormsTrainingSecondTask.Models.Task;

namespace WebFormsTrainingSecondTask.Models.Category
{
    public class CategoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<TaskModel> Tasks { get; set; }
    }
}