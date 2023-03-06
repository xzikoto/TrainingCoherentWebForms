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
using System.Drawing;
using WebFormsTraining.DataAccess;
using WebFormsTraining.Models.Users;
using WebFormsTraining.Models.Enums;
using WebFormsTraining.Services;
using System.Threading;

namespace WebFormsTraining
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RepeaterQuestions.DataSource = DataAccessService.FillData(QueriesConfigurations.GetQuestionsDataQuery());
                RepeaterQuestions.DataBind();
            }
        }

        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string questionId = (e.Item.FindControl("QuestionId") as Label).Text;
                Repeater repeaterOptions = e.Item.FindControl("RepeaterOptions") as Repeater;

                repeaterOptions.DataSource = DataAccessService.FillData(QueriesConfigurations.GetQuestionOptionsDataQuery(questionId));
                repeaterOptions.DataBind();
            }
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

            var a = SummarizeQuestions(userId);

            SummarizeQuestions(userId).ForEach(u => UserAnswersService.CreateUserAnswers(u));


            //Response.Redirect("Results.aspx");
        }

        private List<UserAnswers> SummarizeQuestions(int userId)
        {
            var userAnswersCollection = new List<UserAnswers>();

            foreach (var item in RepeaterQuestions.Items)
            {
                var userAnswer = new UserAnswers() { UserId = userId };
                var nestedRepeater = item as RepeaterItem;

                //foreach (var nestedItem in nestedRepeater)
                //{
                //    var label = nestedItem as Label;
                //    if (label != null && label.ID == "QuestionId")
                //    {
                //        userAnswer.QuestionId = Convert.ToInt32(label.Text);
                //    }
                //    if (label != null && label.ID == "OptionId")
                //    {
                //        userAnswer.OptionId = Convert.ToInt32(label.Text);
                //    }
                //    if (label != null && label.ID == "IsCorrect")
                //    {
                //        userAnswer.IsCorrect = Convert.ToInt32(label.Text);
                //    }
                //}

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