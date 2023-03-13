namespace WebFormsTrainingSecondTask.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;
    using WebFormsTrainingSecondTask.Core.Entities.Tasks;

    internal sealed class Configuration : DbMigrationsConfiguration<AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppContext context)
        {
            var tasks = Seeder.Seeder.GenerateTasks();
            tasks.ForEach(t => context.Set<Task>().Add(t));

            context.SaveChanges();
        }
    }
}
