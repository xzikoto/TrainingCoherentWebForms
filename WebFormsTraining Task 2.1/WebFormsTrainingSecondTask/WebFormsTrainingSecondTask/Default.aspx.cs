using System;
using System.Drawing;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsTrainingSecondTask.Data;
using WebFormsTrainingSecondTask.Data.Commands;
using WebFormsTrainingSecondTask.Data.Core;
using WebFormsTrainingSecondTask.Data.Queries;
using WebFormsTrainingSecondTask.Infrastructure;
using WebFormsTrainingSecondTask.Models.Enums;

namespace WebFormsTrainingSecondTask
{
    public partial class _Default : Page
    {
        private IDataLayer _dataLayer;
        private static string task_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new UnitOfWorkOptions());

            unitOfWork.TasksRepository.Find(1);

            _dataLayer = new DataLayer();
            PopulateTasksByCategory();
        }

        private void PopulateTasksByCategory()
        {
            foreach (var item in Enum.GetValues(typeof(CategoryEnum)))
            {
                string query = QueriesConfiguration.GetTaskByCategory(item.ToString());

                switch (item.ToString())
                {
                    case nameof(CategoryEnum.HIGH):
                        _dataLayer.FillGridView(query, GridViewHigh, item.ToString());
                        break;
                    
                    case nameof(CategoryEnum.MEDIUM):
                        _dataLayer.FillGridView(query, GridViewMedium, item.ToString());
                        break;
                    
                    case nameof(CategoryEnum.LOW):
                        _dataLayer.FillGridView(query, GridViewLow, item.ToString());
                        break;
                }
            }
        }

        protected void gv_SelectedIndexChanged(object sender, EventArgs e)
        {
            var gridViewSender = (sender as GridView);
            RemoveSelectedRow();

            task_id = gridViewSender.SelectedRow.Cells[1].Text.ToString();
            taskName.Text = gridViewSender.SelectedRow.Cells[2].Text.ToString();
            txtCategory.Text = gridViewSender.SelectedRow.Cells[3].Text.ToString();
            txtdob.Text = FormatDate(gridViewSender.SelectedRow.Cells[4].Text.ToString().Split()[0]);

            gridViewSender.SelectedRowStyle.BackColor = Color.Red;
        }

        private void RemoveSelectedRow()
        {
            GridViewHigh.SelectedRowStyle.BackColor = Color.White;
            GridViewLow.SelectedRowStyle.BackColor = Color.White;
            GridViewMedium.SelectedRowStyle.BackColor = Color.White;
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            string query = CommandsConfiguration.GetCreateTaskCommand(taskName.Text, txtCategory.Text, txtdob.Text);

            lblmessage.Text = _dataLayer.ExecuteQuery(query);

            CleanAllFields();

            RefreshPage();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            string query = CommandsConfiguration.GetUpdateTaskCommand(task_id, taskName.Text, txtCategory.Text, txtdob.Text);

            lblmessage.Text = _dataLayer.ExecuteQuery(query);

            CleanAllFields();

            RefreshPage();
        }

        protected void btndlt_Click(object sender, EventArgs e)
        {
            string query = CommandsConfiguration.GetDeleteTaskCommand(task_id);

            lblmessage.Text = _dataLayer.ExecuteQuery(query);

            RefreshPage();
        }

        private void RefreshPage()
        {
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        private void CleanAllFields()
        {
            txtCategory.Text = string.Empty;
            taskName.Text = string.Empty;
            txtdob.Text = string.Empty;
        }

        private string FormatDate(string sourceDateText)
        {
            DateTime sourceDate = DateTime.ParseExact(sourceDateText, "d/M/yyyy", CultureInfo.InvariantCulture);

            return sourceDate.ToString("yyyy-MM-dd");
        }
    }
}