namespace WebFormsTrainingSecondTask.Data.Queries
{
    public static class QueriesConfiguration
    {
        public static string GetTaskByCategory(string category) => $"SELECT * FROM TasksTable WHERE category = '{category}'";

    }
}