using System.Collections.Generic;
using WebFormsTrainingSecondTask.Core.Entities.Tasks;

namespace WebFormsTrainingSecondTask.Core.Entities
{
    public class Category : VisibleEntity
    {
        public List<Task> Tasks { get; set; }
    }
}
