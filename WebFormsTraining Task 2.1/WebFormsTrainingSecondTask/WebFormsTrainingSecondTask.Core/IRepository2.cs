using WebFormsTrainingSecondTask.Core.Entities;

namespace WebFormsTrainingSecondTask.Core
{
    public interface IRepository<TEntity, in TKey> : IRepository<TEntity> where TEntity : Entity<TKey>
    {
        TEntity Find(TKey id);
    }
}
