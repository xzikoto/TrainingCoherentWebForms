using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Cryptography.X509Certificates;
using WebFormsTrainingSecondTask.Core.Entities.Users;
using WebFormsTrainingSecondTask.Infrastructure.Configs;

namespace WebFormsTrainingSecondTask.Infrastructure
{
    public class AppContext : DbContext
    {
        //handle it
        public AppContext() : base("name=QuizDatabaseConnectionString")
        {
        
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OptionsConfig());
            modelBuilder.Configurations.Add(new UserQuestionAnswersConfig());
            modelBuilder.Configurations.Add(new UsersConfig());

            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
