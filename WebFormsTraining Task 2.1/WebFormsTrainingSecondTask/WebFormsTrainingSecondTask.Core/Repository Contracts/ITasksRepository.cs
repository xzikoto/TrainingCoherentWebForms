using System;
using System.Linq;
using WebFormsTrainingSecondTask.Core.Entities.Tasks;

namespace WebFormsTrainingSecondTask.Core.Tasks
{
    public interface ITasksRepository : IRepository<Task, Guid>
    {
        Task GetTaskById(Guid taskId);
        IQueryable<Task> GetTasks();
    }
}
