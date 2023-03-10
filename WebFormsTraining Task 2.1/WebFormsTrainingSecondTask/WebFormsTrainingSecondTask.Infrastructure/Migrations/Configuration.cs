namespace WebFormsTrainingSecondTask.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebFormsTrainingSecondTask.Core.Entities.Tasks;

    internal sealed class Configuration : DbMigrationsConfiguration<WebFormsTrainingSecondTask.Infrastructure.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebFormsTrainingSecondTask.Infrastructure.AppContext context)
        {
            var tasks = Seeder.Seeder.GenerateTasks();
            tasks.ForEach(t => context.Set<Task>().Add(t));

            context.SaveChanges();
        }
    }
}
