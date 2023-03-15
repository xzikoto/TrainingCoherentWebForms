using System;
using WebFormsTrainingSecondTask.Core.Entities.Questions;

namespace WebFormsTrainingSecondTask.Core.Entities
{
    public class QuestionOption : VisibleEntity
    {
        public string Option { get; set; }
        public Question Question { get; set; }
        public Guid QuestionId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
