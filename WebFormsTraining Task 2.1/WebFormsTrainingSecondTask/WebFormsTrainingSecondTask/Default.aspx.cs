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
        protected readonly ICategoryService _categoryService;
        protected readonly ITaskService _taskService;

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
            ValidationMessageLabel.Visible = false;

            var gridViewSender = sender as GridView;

            RemoveSelectedRow();
            RefreshButtonStates();
            SetSelectedTask(gridViewSender);

            txtCategory.Text = categories.FirstOrDefault(c => c.Id == currentTask.CategoryId).Name;
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
            if (btndlt.Enabled == false)
            {
                DeleteTask(); 
                return;
            }

            var categoryDTO = categories.FirstOrDefault(c => c.Name.ToLower() == txtCategory.Text.ToLower()).ToDto();
            var isTaskIdNotExist = currentTask == null || currentTask.Id == Guid.Empty;

            var taskDTO = new TaskDTO
            {
                Name = taskName.Text, 
                Date = Convert.ToDateTime(txtdob.Text),
                CategoryId = categoryDTO.Id,
            };

            try
            {
                if (isTaskIdNotExist)
                {
                    taskDTO.Id = Guid.NewGuid();
                    _taskService.Add(taskDTO);
                }
                else
                {
                    taskDTO.Id = currentTask.Id;
                    _taskService.Update(taskDTO);
                }

                RefreshPage();
            }
            catch (Exception exc)
            {
                ValidationMessageLabel.Text = exc.Message;
                ValidationMessageLabel.Visible = true;
                ValidationMessageLabel.ForeColor = Color.Red;

                RemoveSelectedRow();
                CleanAllFields();
                RefreshButtonStates();

                currentTask = null;
            }
        }

        protected void btndlt_Click(object sender, EventArgs e)
        {
            DisableInputFields();
            DisableButton(btndlt, Color.DarkRed);
        }

        private void DeleteTask()
        {
            btndlt.BackColor = Color.DarkRed;

            if (currentTask == null)
            {
                currentTask = new TaskModel();

                ValidationMessageLabel.Text = "Can not delete not existing task";

                return;
            }

            try
            {
                _taskService.Delete(currentTask.Id);
            }
            catch (Exception exc)
            {
                ValidationMessageLabel.Text = exc.Message;
            }
            
            RefreshPage();
        }
        private void RefreshButtonStates()
        {
            btndlt.Enabled = true;
            btnsave.Enabled = true;

            btndlt.BackColor = Color.Red;
        }

        private void DisableButton(Button button, Color backColor)
        {
            button.Enabled = false;
            btndlt.BackColor = backColor;
        }
        
        private void DisableInputFields()
        {
            this.txtdob.Enabled = false;
            this.taskName.Enabled = false;
            this.txtCategory.Enabled = false;
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