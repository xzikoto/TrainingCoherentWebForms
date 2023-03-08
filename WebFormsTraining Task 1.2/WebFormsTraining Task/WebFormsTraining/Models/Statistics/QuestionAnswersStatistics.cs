namespace WebFormsTraining.Models.Statistics
{
    public class QuestionAnswersStatistics
    {
        public string Question { get; set; }

        public int WrongAnswersOverall { get; set; }
        public int CorrectAnswersOverall { get; set; }

        public int WrongAnswersMen { get; set; }
        public int CorrectAnswersMen { get; set; }

        public int WrongAnswersWomen { get; set; }
        public int CorrectAnswersWomen { get; set; }

        public int WrongAnswersChilds { get; set; }
        public int CorrectAnswersChilds { get; set; }

    }
}