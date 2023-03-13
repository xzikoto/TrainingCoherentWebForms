using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebFormsTrainingSecondTask.Core.Entities;

namespace WebFormsTrainingSecondTask.Core
{
    public interface IRepository<TEntity> : IRepository where TEntity : Entity
    {
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Remove(TEntity entity);

        int Count();
        int FilterCount(Expression<Func<TEntity, bool>> predicate);
    }
}
