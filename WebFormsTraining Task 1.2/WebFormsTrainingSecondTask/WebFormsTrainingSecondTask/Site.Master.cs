using System;
using System.Web.UI;
using WebFormsTrainingSecondTask.Services.Contracts;

namespace WebFormsTrainingSecondTask
{
    public partial class SiteMaster : MasterPage
    {
        protected ICategoryService CategoryService { get; }

        public SiteMaster(ICategoryService categoryService)
        {
            CategoryService = categoryService;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}