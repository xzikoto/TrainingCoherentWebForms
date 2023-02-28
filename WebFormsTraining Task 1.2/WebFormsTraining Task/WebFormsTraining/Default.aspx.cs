using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WebFormsTraining.Models;

namespace WebFormsTraining
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["QuizDatabaseConnectionString"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string sqlQuery = "SELECT * FROM OnlineExam";

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                Repeater1.DataSource = dt;
                Repeater1.DataBind();


                sqlConnection.Close();
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!CheckAllQuestionsAnswered())
            {
                return;
            }

            var surveyAnswer = new SurveyAnswers()
            {
                Name = Name.Text.ToString(),
                Age = Convert.ToInt32(Age.Text),
                Gender = Gender.Text.ToString().ToString()
            };

            foreach (RepeaterItem item in Repeater1.Items)
            {

                RadioButton rb1 = item.FindControl("option1") as RadioButton;
                RadioButton rb2 = item.FindControl("option2") as RadioButton;
                RadioButton rb3 = item.FindControl("option3") as RadioButton;
                RadioButton rb4 = item.FindControl("option4") as RadioButton;

                var radioButtons = new List<RadioButton>() { rb1, rb2, rb3, rb4 };

                RadioButton checkedRadioButton = radioButtons.FirstOrDefault(b => b.Checked);

                Label labelCorrectAnswer = (Label)item.FindControl("LabelCorrectAnswer");

                Label userSelectedAnswer = (Label)item.FindControl("LabelUserSelectedOption");
                userSelectedAnswer.Text = checkedRadioButton.Text;

                if (checkedRadioButton != null)
                {
                    surveyAnswer.Questions.Add((item.FindControl("Question") as Label).Text);
                    surveyAnswer.QuestionsIds.Add(Convert.ToInt32((item.FindControl("QuestionId") as Label).Text));

                    surveyAnswer.Answers.Add(checkedRadioButton.Text);
                    userSelectedAnswer.Text = checkedRadioButton.Text;

                    if (labelCorrectAnswer.Text.ToLower() == checkedRadioButton.Text.ToLower())
                    {
                        userSelectedAnswer.Text = "The selected answer <b>" + checkedRadioButton.Text.ToString() + "</b> is CORRECT!";
                        userSelectedAnswer.ForeColor = System.Drawing.Color.Green;

                        surveyAnswer.QuestionsAnswersCorrect.Add(1);
                        surveyAnswer.CorrectAnswers += 1;
                    }
                    else
                    {
                        userSelectedAnswer.Text = "The selected answer <b>" + checkedRadioButton.Text.ToString() + "</b> is WRONG!";
                        userSelectedAnswer.ForeColor = System.Drawing.Color.Red;

                        surveyAnswer.QuestionsAnswersCorrect.Add(0);
                        surveyAnswer.WrongAnswers += 1;
                    }
                }
                else
                {
                    userSelectedAnswer.Text = "Please choose an answer!";
                }

            }

            PopulateExamAnswersTable(surveyAnswer);
            Response.Redirect("Results.aspx");
        }

        private bool CheckAllQuestionsAnswered()
        {
            var isFormValid = true;

            foreach (RepeaterItem item in Repeater1.Items)
            {
                bool option1 = (item.FindControl("option1") as RadioButton).Checked;
                bool option2 = (item.FindControl("option2") as RadioButton).Checked;
                bool option3 = (item.FindControl("option3") as RadioButton).Checked;
                bool option4 = (item.FindControl("option4") as RadioButton).Checked;

                if (option1 || option2 || option3 || option4)
                {
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Select one option from each question.');", true);
                    isFormValid = false;
                }
            }

            return isFormValid;
        }

        private void PopulateExamAnswersTable(SurveyAnswers surveyAnswers)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QuizDatabaseConnectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            string sqlQuery = $"INSERT INTO dbo.ExamAnswers(AnswerQuestion1, AnswerQuestion2, AnswerQuestion3, CorrectAnswers, Name, Age, Gender)\r\n" +
                         $"VALUES('{surveyAnswers.Answers[0]}','{surveyAnswers.Answers[1]}','{surveyAnswers.Answers[2]}','{surveyAnswers.CorrectAnswers}','{surveyAnswers.Name}','{surveyAnswers.Age}','{surveyAnswers.Gender}')";

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            for (int i = 0; i < 3; i++)
            {
                var isCorrect = surveyAnswers.QuestionsAnswersCorrect[i] == 1 ? 1 : 0;
                string sqlQuery2 = $"INSERT INTO dbo.QuestionStatisticsTable(QuestionId, Question, IsCorrect,  Gender)\r\n" +
                         $"VALUES('{surveyAnswers.QuestionsIds[i]}','{surveyAnswers.Questions[i]}','{isCorrect}','{surveyAnswers.Gender}')";

                SqlCommand sqlCommand2 = new SqlCommand(sqlQuery2, sqlConnection);
                SqlDataAdapter sda2 = new SqlDataAdapter(sqlCommand2);

                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
            }
            

            sqlConnection.Close();
        }

    }
}