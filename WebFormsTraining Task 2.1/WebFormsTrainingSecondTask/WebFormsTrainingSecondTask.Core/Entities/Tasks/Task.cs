using System;

namespace WebFormsTrainingSecondTask.Core.Entities.Tasks
{
    public class Task : VisibleEntity
    {
        public string Category { get; set; }
        public DateTime Date { get; set; }
    }
}
