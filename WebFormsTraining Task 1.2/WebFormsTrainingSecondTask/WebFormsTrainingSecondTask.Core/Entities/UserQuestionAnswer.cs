using System;
using System.Collections.Generic;

namespace WebFormsTrainingSecondTask.Core.Entities.Users
{
    public class UserQuestionAnswer : VisibleEntity
    {
        public int Age { get; set; }
        public string Gender { get; set; }
        public Guid QuestionId{ get; set; }
        public Guid OptionId { get; set; }
        public QuestionOption QuestionOption { get; set; }
        public Guid UserId { get; set; }
        public bool IsCorrect{ get; set; }
    }
}
