using System.Data.Entity;
using WebFormsTrainingSecondTask.Core;
using WebFormsTrainingSecondTask.Core.Entities;

namespace WebFormsTrainingSecondTask.Infrastructure
{
    internal abstract class Repository<TEntity, TKey> : Repository<TEntity>, IRepository<TEntity, TKey>
        where TEntity : Entity<TKey>
    {
        protected Repository(DbContext context) : base(context)
        {
        }

        public virtual TEntity Find(TKey id) => Find(x => x.Id.Equals(id));
    }
}
