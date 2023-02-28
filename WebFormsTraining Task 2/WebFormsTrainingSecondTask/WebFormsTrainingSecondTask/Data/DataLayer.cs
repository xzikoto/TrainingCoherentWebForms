using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WebFormsTrainingSecondTask.Data.Core;

namespace WebFormsTrainingSecondTask.Data
{
    public class DataLayer : IDataLayer
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataAdapter _adapter;

        public DataLayer()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["QuizDatabaseConnectionString"].ConnectionString;
            _connection = new SqlConnection(ConnectionString);

        }

        public string ConnectionString { get; set; }
        public string GetMessage { get; set; }

        public string TaskCRUD(string query)
        {
            string allqueries = query.ToLower();
            try
            {
                Connect();

                _command = new SqlCommand(query, _connection);
                _adapter = new SqlDataAdapter(_command);

                _adapter.Fill(new DataSet(), "TasksTable");


                if (allqueries.Contains("insert into "))
                {
                    GetMessage = "inserted Successfully!";
                }
                else if (allqueries.Contains("delete from "))
                {
                    GetMessage = "Deleted Successfully!";
                }
                else if (allqueries.Contains("create table "))
                {
                    GetMessage = "Table Created Successfully!";
                }
                else if (allqueries.Contains("update ") && allqueries.Contains("set= "))
                {
                    GetMessage = "Updated Successfully";
                }


            }
            catch (Exception exp)
            {

                GetMessage = "Failed to execute " + query + " \n Reason : " + exp.Message;
            }
            finally { Disconnect(); }

            return GetMessage;
        }

        public string FillGridView(string query, GridView dgv, string category)
        {
            var dt = new DataTable();
            try
            {
                _command = new SqlCommand(query, _connection);
                _adapter = new SqlDataAdapter(_command);

                Connect();

                _adapter.Fill(dt);

                dgv.DataSource = dt;
                dgv.DataBind();


                GetMessage = "Code Executed Successfully (filldatagridView()=> datalayer.cs)";
            }
            catch (Exception exp)
            {
                GetMessage = "Failed (filldatagridView()=> datalayer.cs) : " + exp.Message;
            }
            finally
            {
                Disconnect();
            }

            return GetMessage;

        }

        public bool Connect()
        {
            try
            {
                _connection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool Disconnect()
        {

            try
            {
                _connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;

            }

        }
    }
}