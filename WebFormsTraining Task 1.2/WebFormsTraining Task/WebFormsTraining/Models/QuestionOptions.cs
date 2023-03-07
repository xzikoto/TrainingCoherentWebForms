using System.Collections.Generic;

namespace WebFormsTraining.Models
{
    public class QuestionOptions
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public List<Option> Options { get; set;} = new List<Option>();
        public int CorrectOptionId { get; set; }
        public bool IsActive { get; set; }
    }
}