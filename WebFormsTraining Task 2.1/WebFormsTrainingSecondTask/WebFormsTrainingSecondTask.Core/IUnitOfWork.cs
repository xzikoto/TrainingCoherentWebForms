using System;
using WebFormsTrainingSecondTask.Core.Tasks;

namespace WebFormsTrainingSecondTask.Infrastructure.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ITasksRepository TasksRepository { get; }

        void Commit();
    }
}
