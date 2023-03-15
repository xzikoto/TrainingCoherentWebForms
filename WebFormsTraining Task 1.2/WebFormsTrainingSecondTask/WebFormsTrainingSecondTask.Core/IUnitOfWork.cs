using System;
using WebFormsTrainingSecondTask.Core.Repository;

namespace WebFormsTrainingSecondTask.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ITasksRepository TaskRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        void Commit();
    }
}
