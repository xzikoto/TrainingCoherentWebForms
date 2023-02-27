namespace WebFormsTraining.Models
{
    public class Statistics
    {
        public string Question{ get; set; }
        public int QuestionId { get; set; }

        public int WrongAnswers{ get; set; }
        public int CorrectAnswers{ get; set; }
        
        public int WrongWomenAnswers{ get; set; }
        public int CorrectWomenAnswers{ get; set; }
        public int WrongManAnswers{ get; set; }
        public int CorrectManAnswers{ get; set; }

    }
}