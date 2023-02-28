using System.Collections.Generic;

namespace WebFormsTraining.Models
{
    public class SurveyAnswers
    {
        public List<string> Answers{ get; set; } = new List<string>();
        public List<string> Questions { get; set; } = new List<string>();
        public List<int> QuestionsIds { get; set; } = new List<int>();
        public List<int> QuestionsAnswersCorrect { get; set; } = new List<int>();
        public int CorrectAnswers { get; set; }
        public int WrongAnswers { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}