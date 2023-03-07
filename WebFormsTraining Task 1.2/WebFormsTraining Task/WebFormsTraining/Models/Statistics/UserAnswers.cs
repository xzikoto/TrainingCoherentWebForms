namespace WebFormsTraining.Models
{
    public class UserAnswers
    {
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public int OptionId { get; set; }
        public int CorrectOptionId { get; set; }
        public int IsCorrect { get; set; }
    }
}