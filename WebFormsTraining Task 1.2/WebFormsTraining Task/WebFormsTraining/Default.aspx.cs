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

namespace WebFormsTraining
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RepeaterQuestions.DataSource = DataAccessService.GetData(QueriesConfigurations.GetQuestionsDataQuery());
                RepeaterQuestions.DataBind();
            }
        }

        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string questionId = (e.Item.FindControl("QuestionId") as Label).Text;
                Repeater repeaterOptions = e.Item.FindControl("RepeaterOptions") as Repeater;

                repeaterOptions.DataSource = DataAccessService.GetData(QueriesConfigurations.GetQuestionOptionsDataQuery(questionId));
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

            if (!CheckAllQuestionsAnswered())
            {
                return;
            }
            CreateUser();
            Response.Redirect("Results.aspx");
        }

        private bool CheckAllQuestionsAnswered()
        {
            var isFormValid = true;

            foreach (RepeaterItem item in RepeaterQuestions.Items)
            {
                Repeater repeaterOptions = item.FindControl("RepeaterOptions") as Repeater;

                bool option1 = (item.FindControl("option1") as RadioButton).Checked;
                bool option2 = (item.FindControl("option2") as RadioButton).Checked;
                bool option3 = (item.FindControl("option3") as RadioButton).Checked;
                bool option4 = (item.FindControl("option4") as RadioButton).Checked;

                if (option1 || option2 || option3 || option4)
                {
                    var label = item.FindControl("answerValidation") as Label;
                    label.Visible = false;
                }
                else
                {
                    var label = item.FindControl("answerValidation") as Label;

                    label.Visible = true;
                    label.BackColor = Color.Red;

                    isFormValid = false;
                }
            }

            return isFormValid;
        }

        private void CreateUser()
        {
            var newUser = new User()
            {
                Name = Name.Text.ToString(),
                Age = Convert.ToInt32(age.Text),
                Gender = (GenderEnum)Enum.Parse(typeof(GenderEnum), txtCategory.SelectedValue.ToString(), true),
            };

            CommandsConfiguration.CreateUserCommand(newUser.Name, newUser.Age, newUser.Gender.ToString());
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