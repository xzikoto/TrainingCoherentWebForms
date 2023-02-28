using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsTraining
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["QuizDatabaseConnectionString"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string sqlQuery = "SELECT * FROM ExamAnswers";

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                Repeater1.DataSource = dt;
                Repeater1.DataBind();


                sqlConnection.Close();
            }
        }
    }
}