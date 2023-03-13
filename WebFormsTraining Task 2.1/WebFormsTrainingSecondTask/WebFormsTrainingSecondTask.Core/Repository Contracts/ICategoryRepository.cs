using System;
using System.Collections.Generic;
using WebFormsTrainingSecondTask.Core.Entities;

namespace WebFormsTrainingSecondTask.Core.Tasks
{
    public interface ICategoryRepository : IRepository<Category, Guid>
    {
        IEnumerable<Category> GetAllIncluded();
    }
}
