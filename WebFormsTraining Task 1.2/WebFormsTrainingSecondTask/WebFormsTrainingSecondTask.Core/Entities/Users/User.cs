using System;
using WebFormsTrainingSecondTask.Core.Entities.Enum;

namespace WebFormsTrainingSecondTask.Core.Entities.Users
{
    public class User : VisibleEntity
    {
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Guid GenderId { get; set; }
    }
}
