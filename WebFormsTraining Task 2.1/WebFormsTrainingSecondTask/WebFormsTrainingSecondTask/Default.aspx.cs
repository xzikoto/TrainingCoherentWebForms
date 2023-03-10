using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsTrainingSecondTask.Core.Entities;
using WebFormsTrainingSecondTask.Core.Entities.Tasks;
using WebFormsTrainingSecondTask.DataAccessService;
using WebFormsTrainingSecondTask.Models.Enums;

namespace WebFormsTrainingSecondTask
{
    public partial class _Default : Page
    {
        private static Guid task_id;
        private static List<Category> categories;
        private static List<Task> tasks;

        protected void Page_Load(object sender, EventArgs e)
        {
            tasks = UnitOfWorkService.Instance.TaskRepository.GetTasks().ToList();
            categories = UnitOfWorkService.Instance.CategoryRepository.All().ToList();

            PopulateTasksByCategory(tasks, categories);
        }

        private void PopulateTasksByCategory(List<Task> tasks, List<Category> categories)
        {
            foreach (var item in categories)
            {
                var tasksByCategory = tasks.Where(x => x.Category.Name == item.Name).ToList();
               
                switch (item.Name.ToString())
                {
                    //Should be modified where if we have more categories in future
                    //to automatically generate 
                    case nameof(CategoryEnum.HIGH):
                        GridViewHigh.DataSource = tasksByCategory;
                        GridViewHigh.DataBind();
                        break;

                    case nameof(CategoryEnum.MEDIUM):
                        GridViewMedium.DataSource = tasksByCategory;
                        GridViewMedium.DataBind();
                        break;

                    case nameof(CategoryEnum.LOW):
                        GridViewLow.DataSource = tasksByCategory;
                        GridViewLow.DataBind();
                        break;
                }
            }
        }

        protected void gv_SelectedIndexChanged(object sender, EventArgs e)
        {
            var gridViewSender = sender as GridView;
            RemoveSelectedRow();

            task_id = Guid.Parse(gridViewSender.SelectedRow.Cells[4].Text.ToString());
            taskName.Text = gridViewSender.SelectedRow.Cells[3].Text.ToString();
            txtCategory.Text = gridViewSender.SelectedRow.Cells[1].Text.ToString();
            txtdob.Text = FormatDate(gridViewSender.SelectedRow.Cells[2].Text.ToString().Split()[0]);

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
            var category = categories.FirstOrDefault(c => c.Name.ToLower() == txtCategory.Text.ToLower());

            UnitOfWorkService.Instance.TaskRepository.Add(
                new Task
                {
                    Id = Guid.NewGuid(),
                    Name = taskName.Text,
                    Date = Convert.ToDateTime(txtdob.Text),
                    Category = category,
                });

            UnitOfWorkService.Instance.Commit();

            CleanAllFields();

            RefreshPage();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            var task = tasks.FirstOrDefault(c => c.Id == task_id);

            task.Name = taskName.Text;
            task.Date = Convert.ToDateTime(txtdob.Text);
            task.Category = categories.FirstOrDefault(c => c.Name.ToLower() == txtCategory.Text.ToLower());

            UnitOfWorkService.Instance.Commit();

            CleanAllFields();

            RefreshPage();
        }

        protected void btndlt_Click(object sender, EventArgs e)
        {
            var task = tasks.FirstOrDefault(c => c.Id == task_id);

            UnitOfWorkService.Instance.TaskRepository.Remove(task);
            UnitOfWorkService.Instance.Commit();

            CleanAllFields();

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
            DateTime sourceDate = DateTime.ParseExact(sourceDateText, "M/d/yyyy", CultureInfo.InvariantCulture);

            return sourceDate.ToString("yyyy-MM-dd");
        }
    }
}