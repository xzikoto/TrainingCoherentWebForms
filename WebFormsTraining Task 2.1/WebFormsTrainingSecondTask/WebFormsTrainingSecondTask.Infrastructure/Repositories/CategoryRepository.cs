using System;
using System.Data.Entity;
using System.Linq;
using WebFormsTrainingSecondTask.Core.Entities;
using WebFormsTrainingSecondTask.Core.Tasks;

namespace WebFormsTrainingSecondTask.Infrastructure.Repositories
{
    internal sealed class CategoryRepository : Repository<Category, Guid>, ICategoryRepository
    {
        internal CategoryRepository(DbContext context) : base(context)
        {
        }

        public Category GetCategoryById(Guid id)
        {
            return MakeInclusions().FirstOrDefault(x => x.Id == id);
        }
    }
}
