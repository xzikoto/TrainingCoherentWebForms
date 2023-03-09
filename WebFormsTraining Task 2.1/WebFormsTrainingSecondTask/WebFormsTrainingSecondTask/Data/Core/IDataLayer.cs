﻿using System.Web.UI.WebControls;

namespace WebFormsTrainingSecondTask.Data.Core
{
    public interface IDataLayer
    {
        string ExecuteQuery(string query);
        string FillGridView(string query, GridView dgv, string category);
        bool Connect();
        bool Disconnect();
        string ConnectionString { set; get; }
    }
}