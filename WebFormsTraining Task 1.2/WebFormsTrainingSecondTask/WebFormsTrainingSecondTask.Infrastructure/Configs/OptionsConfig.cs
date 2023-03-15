using System.Data.Entity.ModelConfiguration;
using WebFormsTrainingSecondTask.Core.Entities;

namespace WebFormsTrainingSecondTask.Infrastructure.Configs
{
    internal sealed class OptionsConfig : EntityTypeConfiguration<QuestionOption>
    {
        public void Configure()
        {
            ToTable("QuestionOptions", "dbo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Name).HasColumnName("Name");
            HasRequired(x => x.Question).WithMany(x => x.Options).HasForeignKey(x => x.QuestionId); 
        }
    }
}
