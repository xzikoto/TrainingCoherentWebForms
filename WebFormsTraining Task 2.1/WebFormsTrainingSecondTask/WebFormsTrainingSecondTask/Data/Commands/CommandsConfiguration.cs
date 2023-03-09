namespace WebFormsTrainingSecondTask.Data.Commands
{
    public static class CommandsConfiguration
    {
        public static string GetCreateTaskCommand(string taskName, string category, string date) => $"INSERT INTO TasksTable(task_name, category, date)" +
                                                                                                    $"VALUES('{taskName}','{category}','{date}')";
        public static string GetUpdateTaskCommand(string taskId, string taskName, string category, string date) => $"UPDATE TasksTable " +
                                                                                                    $"SET task_name = '{taskName}'," +
                                                                                                    $"category = '{category}'," +
                                                                                                    $"date = '{date}'" +
                                                                                                    $"WHERE task_id = '{taskId}'";
        public static string GetDeleteTaskCommand(string taskId) => $"DELETE FROM TasksTable WHERE task_id = '{taskId}'";
    }
}