using WebFormsTraining.Models.Enums;

namespace WebFormsTraining.Models.Users
{
    public class User
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public GenderEnum Gender { get; set; }
    }
}