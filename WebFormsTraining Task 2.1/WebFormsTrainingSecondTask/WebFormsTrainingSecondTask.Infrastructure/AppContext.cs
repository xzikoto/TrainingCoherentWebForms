using System.Data.Entity;
using System.Security;
using WebFormsTrainingSecondTask.Core.Entities.Tasks;
using WebFormsTrainingSecondTask.Infrastructure.Configs;

namespace WebFormsTrainingSecondTask.Infrastructure
{
    public class AppContext : DbContext
    {
        public AppContext() : base("name=QuizDatabaseConnectionString")
        {
            base.Database.Connection.ConnectionString = @"Data Source=BG-NBW-0263\MSSQLSERVER01;Initial Catalog=TasksDB;Integrated Security=True";

        }

        public static AppContext Create()
        {
            return new AppContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TaskConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
