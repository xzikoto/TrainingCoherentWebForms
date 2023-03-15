using System;
using System.Collections.Generic;
using WebFormsTrainingSecondTask.Core.Entities;

namespace WebFormsTrainingSecondTask.Core.Repository
{
    public interface ICategoryRepository : IRepository<QuestionOption, Guid>
    {
        IEnumerable<QuestionOption> GetAllIncluded();
    }
}
