using System;
using WebFormsTrainingSecondTask.Core.Entities;

namespace WebFormsTrainingSecondTask.Core
{
    public class VisibleEntity : Entity<Guid>
    {
        public string Name { get; set; }
    }
}
