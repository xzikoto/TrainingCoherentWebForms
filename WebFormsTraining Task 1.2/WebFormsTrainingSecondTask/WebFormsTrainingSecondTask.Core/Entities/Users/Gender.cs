using System;
using System.Collections.Generic;
using WebFormsTrainingSecondTask.Core.Entities.Enum;

namespace WebFormsTrainingSecondTask.Core.Entities.Users
{
    public class Gender : Entity<Guid>
    {
        public List<User> Users{ get; set; }
        public GenderEnum Type { get; set; }
    }
}
