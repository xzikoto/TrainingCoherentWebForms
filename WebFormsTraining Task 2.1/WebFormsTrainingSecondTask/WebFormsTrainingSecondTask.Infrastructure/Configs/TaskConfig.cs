using System.Data.Entity.ModelConfiguration;
using WebFormsTrainingSecondTask.Core.Entities.Tasks;

namespace WebFormsTrainingSecondTask.Infrastructure.Configs
{
    internal sealed class TaskConfig : EntityTypeConfiguration<Task>
    {
        public void Configure()
        {
            ToTable("Task", "dbo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Name).HasColumnName("Name");
            Property(x => x.Date).HasColumnName("Date");

            HasRequired(x => x.Category).WithMany(x => x.Tasks).HasForeignKey(x => x.CategoryId);
        }
    }
}
