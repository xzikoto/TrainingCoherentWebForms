using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebFormsTrainingSecondTask.Infrastructure.Configs;

namespace WebFormsTrainingSecondTask.Infrastructure
{
    public class AppContext : DbContext
    {
        public AppContext() : base("name=QuizDatabaseConnectionString")
        {
        
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TaskConfig());

            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
