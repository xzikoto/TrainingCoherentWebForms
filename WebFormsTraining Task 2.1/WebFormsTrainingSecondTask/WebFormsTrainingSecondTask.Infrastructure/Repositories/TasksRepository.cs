using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;
using WebFormsTrainingSecondTask.Core.Entities.Tasks;
using WebFormsTrainingSecondTask.Core.Tasks;

namespace WebFormsTrainingSecondTask.Infrastructure.Repositories
{
    internal sealed class TasksRepository : Repository<Task, int>, ITasksRepository
    {
        internal TasksRepository(DbContext context) : base(context)
        {
        }

        protected override IEnumerable<Task> InternalFilter(Expression<Func<Task, bool>> predicate)
        {
            return DbSet.Where(predicate).OrderBy(x => x.Id).ToList();
        }
    }
}
