using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsTraining.DataAccess;
using WebFormsTraining.Models;
using WebFormsTraining.Services;

namespace WebFormsTraining
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var questionOptionsDataTable = DataAccessService.FillData(QueriesConfigurations.GetQuestionsOptionsDataQuery());

                var questionOptionsDictionary = CreateQuestionsOptionsDictionary(questionOptionsDataTable);
                RepeaterQuestions.DataSource = CreateDataTable(questionOptionsDictionary);
                RepeaterQuestions.DataBind();
            }
        }

        private Dictionary<int, QuestionOptions> CreateQuestionsOptionsDictionary(DataTable dataTable)
        {
            var dictionary = new Dictionary<int, QuestionOptions>();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var questionId = Convert.ToInt32(dataTable.Rows[i]["QuestionId"]);
                var question = dataTable.Rows[i]["Question"].ToString();
                var option = dataTable.Rows[i]["Option"].ToString();
                var optionId = Convert.ToInt32(dataTable.Rows[i]["OptionId"].ToString());
                var isCorrect = Convert.ToBoolean(dataTable.Rows[i]["IsCorrect"].ToString());

                QuestionOptions questionOptions = new QuestionOptions()
                {
                    QuestionId = questionId,
                    Question = question,
                    CorrectOptionId = isCorrect == true ? optionId : 0,
                };

                if (!dictionary.ContainsKey(questionId))
                {
                    dictionary.Add(questionId, questionOptions);
                }

                dictionary[questionId].Options.Add(new Option { OptionId = optionId, Text = option });
            }

            return dictionary;
        }

        private DataTable CreateDataTable(Dictionary<int, QuestionOptions> dictionary)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("QuestionId");
            dataTable.Columns.Add("Question");
            dataTable.Columns.Add("Option1");
            dataTable.Columns.Add("Option1Id");
            dataTable.Columns.Add("Option2");
            dataTable.Columns.Add("Option2Id");
            dataTable.Columns.Add("Option3");
            dataTable.Columns.Add("Option3Id");
            dataTable.Columns.Add("Option4");
            dataTable.Columns.Add("Option4Id");

            dataTable.Columns.Add("CorrectOptionId");
            dataTable.Columns.Add("CorrectOption");

            foreach (var item in dictionary)
            {
                DataRow row = dataTable.NewRow();

                row["QuestionId"] = item.Value.QuestionId;
                row["Question"] = item.Value.Question;
                row["Option1"] = item.Value.Options[0].Text;
                row["Option2"] = item.Value.Options[1].Text;
                row["Option3"] = item.Value.Options[2].Text;
                row["Option4"] = item.Value.Options[3].Text;
                row["Option1Id"] = item.Value.Options[0].OptionId;
                row["Option2Id"] = item.Value.Options[1].OptionId;
                row["Option3Id"] = item.Value.Options[2].OptionId;
                row["Option4Id"] = item.Value.Options[3].OptionId;
                row["CorrectOptionId"] = item.Value.CorrectOptionId;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            Page.Validate("submission");
            if (!Page.IsValid)
            {
                return;
            }

            UserService.CreateUser(Name.Text.ToString(), age.Text, txtCategory.SelectedValue.ToString());

            var userId = UserService.GetLatestUserId();

            var summarizedQuestion = SummarizeQuestions(userId);

            summarizedQuestion.ForEach(u => UserAnswersService.CreateUserAnswers(u));
        }

        private List<UserAnswers> SummarizeQuestions(int userId)
        {
            var userAnswersCollection = new List<UserAnswers>();

            foreach (var repeaterItem in RepeaterQuestions.Items)
            {
                var userAnswer = new UserAnswers
                {
                    UserId = userId,
                    QuestionId = Convert.ToInt32(((Label)(repeaterItem as RepeaterItem).FindControl("QuestionId")).Text),
                    CorrectOptionId = Convert.ToInt32(((Label)(repeaterItem as RepeaterItem).FindControl("CorrectOptionId")).Text)
                };

                foreach (var item in (repeaterItem as RepeaterItem).Controls)
                {
                    if ((item as RadioButton) != null && (item as RadioButton).Checked == true)
                    {
                        userAnswer.OptionId = Convert.ToInt32((item as RadioButton).CssClass);
                    }
                }

                userAnswer.IsCorrect = userAnswer.OptionId == userAnswer.CorrectOptionId ? 1 : 0;
                userAnswersCollection.Add(userAnswer);
            }

            return userAnswersCollection;
        }

        protected void cusCustom_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string str = args.Value;
            args.IsValid = false;

            bool isNumber = int.TryParse(str, out int numericValue);

            if (!isNumber)
            {
                args.IsValid = false;
                return;
            }

            if (numericValue > 0 && numericValue < 120)
            {
                args.IsValid = isNumber;

                return;
            }

            args.IsValid = false;
        }
    }
}