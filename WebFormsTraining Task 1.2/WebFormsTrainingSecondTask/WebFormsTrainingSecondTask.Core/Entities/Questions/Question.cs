using System;
using System.Collections.Generic;

namespace WebFormsTrainingSecondTask.Core.Entities.Questions
{
    public class Question : VisibleEntity
    {
        public List<QuestionOption> Options { get; set; }
    }
}
