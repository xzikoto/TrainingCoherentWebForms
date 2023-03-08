using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsTraining.DataAccess;

namespace WebFormsTraining
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var usersDataTable = DataAccessService.FillData(QueriesConfigurations.GetUsers());

                RepeaterUsers.DataSource = usersDataTable;
                RepeaterUsers.DataBind();
            }
        }
    }
}