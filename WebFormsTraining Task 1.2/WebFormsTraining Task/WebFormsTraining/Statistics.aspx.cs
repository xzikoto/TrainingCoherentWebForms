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
using WebFormsTraining.DataAccess;
using WebFormsTraining.Services;

namespace WebFormsTraining
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var statisticsModel = StatisticsService.CreateStatistics();
                var statisticsDataTable = StatisticsService.CreateStatisticsDataTable(statisticsModel);

                RepeaterStatistics.DataSource = statisticsDataTable;
                RepeaterStatistics.DataBind();
            }

        }
    }
}