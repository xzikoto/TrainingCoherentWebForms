using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using WebFormsTrainingSecondTask.Core.Entities;
using WebFormsTrainingSecondTask.Core.Repository;

namespace WebFormsTrainingSecondTask.Infrastructure.Repositories
{
    internal sealed class CategoryRepository : Repository<QuestionOption, Guid>, ICategoryRepository
    {
        internal CategoryRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<QuestionOption> GetAllIncluded()
        {
            return MakeInclusions().ToList();
        }

        protected override IQueryable<QuestionOption> MakeInclusions()
        {
            return DbSet.Include(c => c.Question);
        }
    }
}
