using WebFormsTrainingSecondTask.Core.Entities.Tasks;

namespace WebFormsTrainingSecondTask.Core.Tasks
{
    public interface ITasksRepository : IRepository<Task, int>
    {
    }
}
