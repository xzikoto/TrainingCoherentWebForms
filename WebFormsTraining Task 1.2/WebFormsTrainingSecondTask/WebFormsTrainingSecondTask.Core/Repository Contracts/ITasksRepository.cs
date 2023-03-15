using System;
using System.Linq;
using WebFormsTrainingSecondTask.Core.Entities.Questions;

namespace WebFormsTrainingSecondTask.Core.Repository
{
    public interface ITasksRepository : IRepository<Question, Guid>
    {
        Question GetTaskById(Guid taskId);
        IQueryable<Question> GetTasks();
    }
}
