using System;
using WebFormsTrainingSecondTask.Core.Tasks;

namespace WebFormsTrainingSecondTask.Infrastructure.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ITasksRepository TaskRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        void Commit();
    }
}
