using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebFormsTrainingSecondTask.Core.Entities;
using WebFormsTrainingSecondTask.Core;
using WebFormsTrainingSecondTask.Common;
using WebFormsTrainingSecondTask.Infrastructure.Helpers;
using WebFormsTrainingSecondTask.Core.Exception;

namespace WebFormsTrainingSecondTask.Infrastructure
{
    internal abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(DbContext context) => DbSet = context.Set<TEntity>();

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            Check.ArgumentNotNull(predicate, nameof(predicate));

            try
            {
                return InternalFind(predicate);
            }
            catch (SqlException ex)
            {
                throw SqlExceptionHelper.ToRepositoryException(ex);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message, ex);
            }
        }

        public IEnumerable<TEntity> All() => Filter(x => true);

        public int Count() => FilterCount(x => true);

        public int FilterCount(Expression<Func<TEntity, bool>> predicate)
        {
            Check.ArgumentNotNull(predicate, nameof(predicate));

            try
            {
                return InternalFilterCount(predicate);
            }
            catch (SqlException ex)
            {
                throw ex.ToRepositoryException();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message, ex);
            }
        }

        protected virtual int InternalFilterCount(Expression<Func<TEntity, bool>> predicate)
        {
            return MakeInclusions().Where(predicate).Count();
        }

        public IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            Check.ArgumentNotNull(predicate, nameof(predicate));

            try
            {
                return InternalFilter(predicate);
            }
            catch (SqlException ex)
            {
                throw ex.ToRepositoryException();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message, ex);
            }
        }

        public void Add(TEntity entity)
        {
            Check.ArgumentNotNull(entity, nameof(entity));

            DbSet.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            Check.ArgumentNotNull(entity, nameof(entity));

            DbSet.Remove(entity);
        }

        protected virtual TEntity InternalFind(Expression<Func<TEntity, bool>> predicate)
        {
            return MakeInclusions().SingleOrDefault(predicate);
        }

        protected virtual IEnumerable<TEntity> InternalFilter(Expression<Func<TEntity, bool>> predicate)
        {
            return MakeInclusions().Where(predicate).ToList();
        }

        protected virtual IQueryable<TEntity> MakeInclusions() => DbSet;
    }
}
