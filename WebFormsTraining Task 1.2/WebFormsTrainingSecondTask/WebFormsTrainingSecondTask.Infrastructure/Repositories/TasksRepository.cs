using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;
using WebFormsTrainingSecondTask.Core.Repository;
using WebFormsTrainingSecondTask.Core.Entities.Questions;

namespace WebFormsTrainingSecondTask.Infrastructure.Repositories
{
    internal sealed class TasksRepository : Repository<Question, Guid>, ITasksRepository
    {
        internal TasksRepository(DbContext context) : base(context)
        {
        }

        protected override IEnumerable<Question> InternalFilter(Expression<Func<Question, bool>> predicate)
        {
            return DbSet.Where(predicate).OrderBy(x => x.Id).ToList();
        }
        
        public Question GetTaskById(Guid id)
        {
            return MakeInclusions().FirstOrDefault(x=> x.Id == id);
        }

        public IQueryable<Question> GetTasks()
        {
            return MakeInclusions();
        }

        protected override IQueryable<Question> MakeInclusions()
        {
            return DbSet.Include(x => x.Options);
        }
    }
}
