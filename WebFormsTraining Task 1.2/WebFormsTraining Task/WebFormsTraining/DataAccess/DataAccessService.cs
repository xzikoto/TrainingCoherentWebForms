using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebFormsTraining.DataAccess
{
    public static class DataAccessService
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["QuizDatabaseConnectionString"].ConnectionString;

        public static object GetData(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        return cmd.ExecuteScalar();
                    }
                }
            }
        }
        
        public static DataTable FillData(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public static void InsertData(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;

                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}