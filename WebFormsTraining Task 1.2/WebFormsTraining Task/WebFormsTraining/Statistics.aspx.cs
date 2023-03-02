using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsTraining.Models;

namespace WebFormsTraining
{
    public partial class Contact : Page
    {
        private const string manGender = "MAN";
        private const string womanGender = "WOMAN";

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    string connectionString = ConfigurationManager.ConnectionStrings["QuizDatabaseConnectionString"].ConnectionString;
            //    SqlConnection sqlConnection = new SqlConnection(connectionString);
            //    string sqlQueryOveralWrongAnswers = "SELECT * FROM QuestionStatisticsTable";

            //    sqlConnection.Open();

            //    SqlCommand sqlCommand = new SqlCommand(sqlQueryOveralWrongAnswers, sqlConnection);
            //    SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
                
            //    DataTable dt = new DataTable();
            //    sda.Fill(dt);

            //    Repeater1.DataSource = MakeStatistics(dt);
            //    Repeater1.DataBind();

            //    sqlConnection.Close();
            //}


        }

        //private List<Statistics> MakeStatistics(DataTable dt)
        //{
        //    Dictionary<int, Statistics> stats = new Dictionary<int, Statistics>();

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        var question = row["Question"].ToString();

        //        var correctAnswer = int.Parse(row["IsCorrect"].ToString());
        //        var wrongAnswer = correctAnswer == 0 ? 1 : 0;

        //        var gender = row["Gender"].ToString();

        //        var questionId = int.Parse(row["QuestionId"].ToString());

        //        if (!stats.ContainsKey(questionId))
        //        {
        //            stats.Add(questionId, new Statistics());
        //        }

        //        if (stats.ContainsKey(questionId))
        //        {
        //            var questionStatistic = stats[questionId];

        //            questionStatistic.Question = question;
        //            questionStatistic.QuestionId = questionId;

        //            questionStatistic.CorrectAnswers += correctAnswer;
        //            questionStatistic.WrongAnswers += correctAnswer == 0 ? 1 : 0;

        //            MakeGenderStatistics(gender, correctAnswer, wrongAnswer, questionStatistic);
        //        }
        //    }

        //    return stats.Values.ToList();
        //}

        //private void MakeGenderStatistics(string gender, int correctAnswers, int wrongAnswers, Statistics stats)
        //{
        //    if (gender.ToUpper() == manGender)
        //    {
        //        stats.WrongManAnswers += wrongAnswers;
        //        stats.CorrectManAnswers += correctAnswers;
        //    }
        //    else
        //    {
        //        stats.WrongWomenAnswers += wrongAnswers;
        //        stats.CorrectWomenAnswers += correctAnswers;
        //    }
        //}
    }
}