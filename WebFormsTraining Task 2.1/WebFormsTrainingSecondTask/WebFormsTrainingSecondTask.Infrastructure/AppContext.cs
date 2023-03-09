using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebFormsTrainingSecondTask.Infrastructure
{
    internal class AppContext : DbContext
    {
        internal AppContext() : base("name=QuizDatabaseConnectionString")
        {
            Database.Connection.ConnectionString = @"Data Source=BG-NBW-0263\MSSQLSERVER01;Initial Catalog=TasksDB;Integrated Security=True";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
