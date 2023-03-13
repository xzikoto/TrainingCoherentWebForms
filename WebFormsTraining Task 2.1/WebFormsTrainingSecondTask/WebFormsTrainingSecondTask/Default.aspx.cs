using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsTrainingSecondTask.Mappers;
using WebFormsTrainingSecondTask.Models.Category;
using WebFormsTrainingSecondTask.Models.Enums;
using WebFormsTrainingSecondTask.Models.Task;
using WebFormsTrainingSecondTask.Services.Contracts;
using WebFormsTrainingSecondTask.Services.DTOModels;

namespace WebFormsTrainingSecondTask
{
    public partial class _Default : Page
    {
        protected ICategoryService _categoryService { get; }
        protected ITaskService _taskService { get; }

        private static List<CategoryModel> categories;
        private static TaskModel currentTask;

        public _Default(ICategoryService categoryService, ITaskService taskService)
        {
            _categoryService = categoryService;
            _taskService = taskService;
            var categoriesDTO = _categoryService.GetAllIncluded();
            categories = categoriesDTO.ToModel();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateTasksByCategory(categories);
        }


        private void PopulateTasksByCategory(List<CategoryModel> categories)
        {
            foreach (var item in categories)
            {
                switch (item.Name)
                {
                    case nameof(CategoryEnum.HIGH):
                        GridViewHigh.DataSource = categories.FirstOrDefault(x => x.Name == item.Name).Tasks;
                        GridViewHigh.DataBind();
                        break;

                    case nameof(CategoryEnum.MEDIUM):
                        GridViewMedium.DataSource = categories.FirstOrDefault(x => x.Name == item.Name).Tasks;
                        GridViewMedium.DataBind();
                        break;

                    case nameof(CategoryEnum.LOW):
                        GridViewLow.DataSource = categories.FirstOrDefault(x => x.Name == item.Name).Tasks;
                        GridViewLow.DataBind();
                        break;
                }
            }
        }

        protected void gv_SelectedIndexChanged(object sender, EventArgs e)
        {
            var gridViewSender = sender as GridView;

            RemoveSelectedRow();

            SetSelectedTask(gridViewSender);

            txtCategory.Text = gridViewSender.SelectedRow.Cells[1].Text.ToString();
            txtdob.Text = FormatDate(gridViewSender.SelectedRow.Cells[3].Text.ToString().Split()[0]);
            taskName.Text = gridViewSender.SelectedRow.Cells[2].Text.ToString();

            gridViewSender.SelectedRowStyle.BackColor = Color.Red;
        }

        private void SetSelectedTask(GridView gridViewSender)
        {
            var selectedTaskCategoryId = Guid.Parse(gridViewSender.SelectedRow.Cells[4].Text.ToString());
            var selectedTaskId = Guid.Parse(gridViewSender.SelectedRow.Cells[1].Text.ToString());

            currentTask = categories.FirstOrDefault(c => c.Id == selectedTaskCategoryId)
                          .Tasks.FirstOrDefault(t => t.Id == selectedTaskId);
        }

        private void RemoveSelectedRow()
        {
            GridViewHigh.SelectedRowStyle.BackColor = Color.White;
            GridViewLow.SelectedRowStyle.BackColor = Color.White;
            GridViewMedium.SelectedRowStyle.BackColor = Color.White;
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            var categoryDTO = categories.FirstOrDefault(c => c.Name.ToLower() == txtCategory.Text.ToLower()).ToDto();

            try
            {

                _taskService.Add(
                    new TaskDTO
                    {
                        Id = Guid.NewGuid(),
                        Name = taskName.Text,
                        Date = Convert.ToDateTime(txtdob.Text),
                        Category = categoryDTO,
                    });

                CleanAllFields();

                RefreshPage();
            }
            catch (Exception exc)
            {
                ValidationMessageLabel.Text = exc.Message;
                ValidationMessageLabel.Visible = true;
                ValidationMessageLabel.ForeColor = Color.Red;
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            currentTask.Name = taskName.Text;
            currentTask.Date = Convert.ToDateTime(txtdob.Text);
            currentTask.Category = categories.FirstOrDefault(c => c.Name.ToLower() == txtCategory.Text.ToLower());

            _taskService.Update(currentTask.ToDto());

            CleanAllFields();

            RefreshPage();
        }

        protected void btndlt_Click(object sender, EventArgs e)
        {
            _taskService.Delete(currentTask.Id);

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