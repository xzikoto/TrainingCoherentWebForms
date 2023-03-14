using System;

namespace WebFormsTrainingSecondTask.Models.Task
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Guid CategoryId { get; set; }
    }
}