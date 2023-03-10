using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsTrainingSecondTask.Core.Entities;

namespace WebFormsTrainingSecondTask.Core.Tasks
{
    public interface ICategoryRepository : IRepository<Category, Guid>
    {
        Category GetCategoryById(Guid categoryId);
    }
}
