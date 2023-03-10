using System;

namespace WebFormsTrainingSecondTask.Core.Entities.Tasks
{
    public class Task : VisibleEntity
    {
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime Date { get; set; }
    }
}
