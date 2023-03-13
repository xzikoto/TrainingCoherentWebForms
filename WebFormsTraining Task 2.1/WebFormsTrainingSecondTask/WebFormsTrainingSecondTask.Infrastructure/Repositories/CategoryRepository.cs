using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using WebFormsTrainingSecondTask.Core.Entities;
using WebFormsTrainingSecondTask.Core.Tasks;

namespace WebFormsTrainingSecondTask.Infrastructure.Repositories
{
    internal sealed class CategoryRepository : Repository<Category, Guid>, ICategoryRepository
    {
        internal CategoryRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Category> GetAllIncluded()
        {
            return MakeInclusions().ToList();
        }

        protected override IQueryable<Category> MakeInclusions()
        {
            return DbSet.Include(c => c.Tasks);
        }
    }
}
